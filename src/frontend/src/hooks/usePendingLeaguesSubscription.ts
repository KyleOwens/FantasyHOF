import {
  usePendingLeaguesSubscription$data,
  usePendingLeaguesSubscription as UsePendingLeaguesSubscriptionType,
} from "@/__generated__/usePendingLeaguesSubscription.graphql";
import { useMemo } from "react";
import { useSubscription } from "react-relay";
import {
  ConnectionHandler,
  graphql,
  GraphQLSubscriptionConfig,
  RecordProxy,
  RecordSourceSelectorProxy,
} from "relay-runtime";

const leagueImportSubscription = graphql`
  subscription usePendingLeaguesSubscription {
    leagueImportProgress {
      id
      progress
      error
      statusId
      status {
        id
        name
        value
      }
      league {
        id
        ...LeagueCardFragment
      }
    }
  }
`;

export function usePendingLeaguesSubscription() {
  const subscriptionConfig = useMemo<
    GraphQLSubscriptionConfig<UsePendingLeaguesSubscriptionType>
  >(
    () => ({
      subscription: leagueImportSubscription,
      variables: {},
      updater: (store) => {
        const rootField = store.getRootField("leagueImportProgress");
        if (!rootField) return;

        const statusId = rootField.getValue("statusId");
        if (statusId !== "COMPLETED") return;

        const me = store.getRoot().getLinkedRecord("me");

        if (!me) return;

        addLeagueToMyLeaguesConnection(store, rootField, me);
        removeLeagueImportFromLeagueImportConnection(rootField, me);
      },
    }),
    [],
  );

  return useSubscription(subscriptionConfig);
}

function addLeagueToMyLeaguesConnection(
  store: RecordSourceSelectorProxy<usePendingLeaguesSubscription$data>,
  rootField: RecordProxy,
  me: RecordProxy,
) {
  const newLeague = rootField.getLinkedRecord("league");
  if (!newLeague) return;

  const newProviderId = newLeague.getValue("providerLeagueId");

  const leaguesConnection = ConnectionHandler.getConnection(me, "my_leagues");
  if (!leaguesConnection) return;

  const existingEdges = leaguesConnection.getLinkedRecords("edges") || [];
  const alreadyExists = existingEdges.some((edge) => {
    const node = edge?.getLinkedRecord("node");
    return node?.getValue("providerLeagueId") === newProviderId;
  });

  if (alreadyExists) return;

  const edge = ConnectionHandler.createEdge(
    store,
    leaguesConnection,
    newLeague,
    "LeagueEdge",
  );
  ConnectionHandler.insertEdgeAfter(leaguesConnection, edge);
}

function removeLeagueImportFromLeagueImportConnection(
  rootField: RecordProxy,
  me: RecordProxy,
) {
  const importsConnection = ConnectionHandler.getConnection(
    me,
    "my_leagueImports",
  );
  if (!importsConnection) return;

  const importId = rootField.getDataID();
  ConnectionHandler.deleteNode(importsConnection, importId);
}
