import { noLeaguesPageQuery as NoLeaguesPageQuery } from "@/__generated__/noLeaguesPageQuery.graphql";
import { LeagueAdditionModal } from "@/components/league-addition-modal/LeagueAdditionModal";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { preloadQuery } from "@/relay/helpers";
import { createFileRoute } from "@tanstack/react-router";
import { Plus } from "lucide-react";
import { usePreloadedQuery } from "react-relay";
import { graphql } from "relay-runtime";

export const Route = createFileRoute("/$mode/no-leagues")({
  loader: () => {
    return preloadQuery<NoLeaguesPageQuery>(noLeaguesPageQuery, {});
  },
  onLeave: ({ loaderData }) => {
    loaderData?.dispose();
  },
  component: NoLeaguesPage,
});

const noLeaguesPageQuery = graphql`
  query noLeaguesPageQuery {
    fantasyProviders {
      logoURL
      name
      ...ProviderSelectionFragment
    }
  }
`;

function NoLeaguesPage() {
  const queryRef = Route.useLoaderData();
  const fantasyProviders = usePreloadedQuery<NoLeaguesPageQuery>(
    noLeaguesPageQuery,
    queryRef,
  ).fantasyProviders;

  return (
    <div className="flex flex-1 flex-col gap-4 items-center pt-28">
      <h2 className="text-3xl font-bold">Let's get started</h2>
      <Card className="shadow-2xl border-emerald-200">
        <CardContent className="p-12">
          <div className="flex flex-row items-center space-x-16">
            <div className="grid grid-cols-2 gap-8  *:rounded-lg *:size-20">
              {fantasyProviders.map((provider) => (
                <img src={provider.logoURL} alt={provider.name} />
              ))}
            </div>
            <div className="flex flex-col gap-y-4 max-w-xl">
              <span className="font-bold text-4xl">Add your first league</span>
              <p className="text-muted-foreground">
                To start exploring your records, you'll need to help us get
                connected to your fantasy provider. Click below to get started.
              </p>
              <LeagueAdditionModal providersKey={fantasyProviders}>
                <Button size={"lg"} className="mt-4 text-base max-w-fit">
                  <Plus /> Add fantasy League
                </Button>
              </LeagueAdditionModal>
            </div>
          </div>
        </CardContent>
      </Card>
    </div>
  );
}
