import { loadQuery, PreloadedQuery } from "react-relay";
import { GraphQLTaggedNode, OperationType } from "relay-runtime";
import { RelayEnvironment } from "@/relay/RelayEnvironment";

export function preloadQuery<T extends OperationType>(
  query: GraphQLTaggedNode,
  variables: T["variables"],
): PreloadedQuery<T> {
  return loadQuery<T>(RelayEnvironment, query, variables, {
    fetchPolicy: "store-or-network",
  });
}
