import {
  Environment,
  Network,
  RecordSource,
  Store,
  FetchFunction,
  SubscribeFunction,
  Observable,
  GraphQLResponse,
} from "relay-runtime";
import { createClient } from "graphql-sse";

const HTTP_ENDPOINT = import.meta.env.PROD
  ? "/graphql"
  : "http://localhost:5173/graphql";

type TokenGetter = () => Promise<string | null>;

let getToken: TokenGetter = async () => null;

export function setTokenGetter(getter: TokenGetter) {
  getToken = getter;
}

const fetchFn: FetchFunction = async (request, variables) => {
  const token = await getToken();

  const resp = await fetch(HTTP_ENDPOINT, {
    method: "POST",
    headers: {
      Accept:
        "application/graphql-response+json; charset=utf-8, application/json; charset=utf-8",
      "Content-Type": "application/json",
      ...(token && { Authorization: `Bearer ${token}` }),
    },
    body: JSON.stringify({
      query: request.text,
      variables,
    }),
  });

  return await resp.json();
};

const sseClient = createClient({
  url: HTTP_ENDPOINT,
  headers: async () => {
    const token = await getToken();
    return {
      ...(token && { Authorization: `Bearer ${token}` }),
    };
  },
});

const subscribeFn: SubscribeFunction = (request, variables) => {
  return Observable.create((sink) => {
    if (!request.text) {
      return sink.error(new Error("Operation does not have query text."));
    }

    return sseClient.subscribe(
      {
        query: request.text,
        variables,
      },
      {
        next: (data) => sink.next(data as GraphQLResponse),
        error: (err) => sink.error(err as Error),
        complete: () => sink.complete(),
      },
    );
  });
};

function createRelayEnvironment() {
  return new Environment({
    network: Network.create(fetchFn, subscribeFn),
    store: new Store(new RecordSource()),
  });
}

export const RelayEnvironment = createRelayEnvironment();
