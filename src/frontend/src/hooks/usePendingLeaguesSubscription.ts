import { usePendingLeaguesSubscription as UsePendingLeaguesSubscriptionType } from "@/__generated__/usePendingLeaguesSubscription.graphql";
import { useMemo } from "react";
import { useSubscription } from "react-relay";
import { graphql, GraphQLSubscriptionConfig } from "relay-runtime";

const leagueImportSubscription = graphql`
  subscription usePendingLeaguesSubscription {
    leagueImportProgress {
      id
      progress
      error
      status {
        id
        name
        value
      }
      league {
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

        const statusValue = rootField
          .getLinkedRecord("status")
          .getValue("value");

        if (statusValue !== "COMPLETED") return;

        const importId = rootField.getValue("id");
        const newLeague = rootField.getLinkedRecord("league");
        const me = store.getRoot().getLinkedRecord("me");

        if (!me || !newLeague) return;

        const newExternalId = newLeague.getValue("providerLeagueId");
        const currentLeagues = me.getLinkedRecords("leagues") || [];
        const filteredLeagues = currentLeagues.filter(
          (league) => league.getValue("providerLeagueId") !== newExternalId,
        );

        me.setLinkedRecords([...filteredLeagues, newLeague], "leagues");

        const pendingImports = me.getLinkedRecords("leagueImports") || [];

        me.setLinkedRecords(
          pendingImports.filter((imp) => imp.getDataID() !== importId),
          "leagueImports",
        );
      },
    }),
    [],
  );

  return useSubscription(subscriptionConfig);
}
