import { createFileRoute } from "@tanstack/react-router";
import { graphql } from "relay-runtime";
import { useLazyLoadQuery } from "react-relay";
import { Button } from "@/components/ui/button";
import { Plus } from "lucide-react";
import { LeagueAdditionModal } from "@/components/league-addition-modal/LeagueAdditionModal";
import { myLeaguesQuery as MyLeaguesQueryType } from "@/__generated__/myLeaguesQuery.graphql";
import { NoLeaguesCard } from "@/components/league-cards/NoLeaguesCard";
import { LeagueCard } from "@/components/league-cards/LeagueCard";
import { PendingLeagueCard } from "@/components/league-cards/PendingLeagueCard";
import { usePendingLeaguesSubscription } from "@/hooks/usePendingLeaguesSubscription";

export const Route = createFileRoute("/$mode/my-leagues")({
  component: MyLeaguesPage,
});

const myLeaguesQuery = graphql`
  query myLeaguesQuery {
    me {
      leagues {
        id
        ...LeagueCardFragment
        fantasyProvider {
          name
          logoURL
        }
        providerLeagueId
      }
      leagueImports {
        id
        ...PendingLeagueCardFragment
      }
    }
    ...NoLeaguesCardFragment
    fantasyProviders {
      ...ProviderSelectionFragment
    }
  }
`;

function MyLeaguesPage() {
  const data = useLazyLoadQuery<MyLeaguesQueryType>(myLeaguesQuery, {});
  usePendingLeaguesSubscription();

  const { leagues, leagueImports } = data.me;

  const validLeagues = leagues.filter(Boolean);

  if (validLeagues.length === 0 && leagueImports.length === 0)
    return <NoLeaguesCard providersKey={data} />;

  return (
    <div className="container max-w-4xl mx-auto py-6">
      <div className="flex items-center justify-between mb-8">
        <div>
          <h2 className="text-3xl font-bold">My Leagues</h2>
          <p className="text-muted-foreground mt-1">
            Manage your fantasy football leagues
          </p>
        </div>
        <LeagueAdditionModal providersKey={data.fantasyProviders}>
          <Button>
            <Plus className="size-4 mr-2" />
            Add League
          </Button>
        </LeagueAdditionModal>
      </div>
      <div className="flex flex-col gap-8">
        {validLeagues.length > 0 && (
          <section>
            <h3 className="text-lg font-semibold mb-4">
              Your Leagues ({validLeagues.length})
            </h3>
            <div className="flex flex-col gap-4">
              {validLeagues.map((league) => (
                <LeagueCard leagueKey={league} key={league.id} />
              ))}
            </div>
          </section>
        )}
        {leagueImports.length > 0 && (
          <section>
            <h3 className="text-lg font-semibold mb-4">
              Pending Leagues ({leagueImports.length})
            </h3>
            <div className="flex flex-col gap-4">
              {leagueImports.map((leagueImport) => (
                <PendingLeagueCard
                  importKey={leagueImport}
                  key={leagueImport.id}
                />
              ))}
            </div>
          </section>
        )}
      </div>
    </div>
  );
}
