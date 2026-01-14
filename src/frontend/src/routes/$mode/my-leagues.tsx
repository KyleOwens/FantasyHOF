import { createFileRoute } from "@tanstack/react-router";
import { graphql } from "relay-runtime";
import { usePreloadedQuery } from "react-relay";
import { Button } from "@/components/ui/button";
import { Plus } from "lucide-react";
import { LeagueAdditionModal } from "@/components/league-addition-modal/LeagueAdditionModal";
import { myLeaguesQuery as MyLeaguesQueryType } from "@/__generated__/myLeaguesQuery.graphql";
import { NoLeaguesCard } from "@/components/league-cards/NoLeaguesCard";
import { LeagueCard } from "@/components/league-cards/LeagueCard";
import { PendingLeagueCard } from "@/components/league-cards/PendingLeagueCard";
import { usePendingLeaguesSubscription } from "@/hooks/usePendingLeaguesSubscription";
import { AnimatePresence, motion } from "framer-motion";
import { preloadQuery } from "@/relay/helpers";

export const Route = createFileRoute("/$mode/my-leagues")({
  component: MyLeaguesPage,
  loader: () => {
    return preloadQuery<MyLeaguesQueryType>(myLeaguesQuery, {});
  },
  onLeave: ({ loaderData }) => {
    loaderData?.dispose();
  },
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
  const queryRef = Route.useLoaderData();
  const data = usePreloadedQuery<MyLeaguesQueryType>(myLeaguesQuery, queryRef);
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
        <section>
          <h3 className="text-lg font-semibold mb-4">
            Your Leagues ({validLeagues.length})
          </h3>
          <div className="flex flex-col gap-4">
            <AnimatePresence mode="popLayout">
              {validLeagues.map((league) => (
                <motion.div
                  key={league.id}
                  layout // This animates the position change
                  initial={{ opacity: 0, y: 20 }}
                  animate={{ opacity: 1, y: 0 }}
                  exit={{ opacity: 0, scale: 0.95 }}
                  transition={{ type: "spring", stiffness: 500, damping: 30 }}
                >
                  <LeagueCard leagueKey={league} />
                </motion.div>
              ))}
            </AnimatePresence>
          </div>
        </section>
        <AnimatePresence>
          {leagueImports.length > 0 && (
            <motion.section
              initial={{ opacity: 0 }}
              animate={{ opacity: 1 }}
              exit={{ opacity: 0 }}
            >
              <h3 className="text-lg font-semibold mb-4">
                Pending Leagues ({leagueImports.length})
              </h3>
              <div className="flex flex-col gap-4">
                <AnimatePresence mode="popLayout">
                  {leagueImports.map((leagueImport) => (
                    <motion.div
                      key={leagueImport.id}
                      layout
                      initial={{ opacity: 0, x: -20 }}
                      animate={{ opacity: 1, x: 0 }}
                      exit={{ opacity: 0, x: 20, scale: 0.9 }}
                      transition={{
                        type: "spring",
                        stiffness: 500,
                        damping: 30,
                      }}
                    >
                      <PendingLeagueCard importKey={leagueImport} />
                    </motion.div>
                  ))}
                </AnimatePresence>
              </div>
            </motion.section>
          )}
        </AnimatePresence>
      </div>
    </div>
  );
}
