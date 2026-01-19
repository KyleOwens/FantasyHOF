import { NoLeaguesCardFragment$key } from "@/__generated__/NoLeaguesCardFragment.graphql";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Plus } from "lucide-react";
import { useFragment } from "react-relay";
import { graphql } from "relay-runtime";

type Props = {
  providersKey: NoLeaguesCardFragment$key;
  openModal: () => void;
};

const noLeaguesCardFragment = graphql`
  fragment NoLeaguesCardFragment on Query {
    fantasyProviders {
      logoURL
      name
      ...ProviderSelectionFragment
    }
  }
`;

export function NoLeaguesCard({ providersKey, openModal }: Props) {
  const fantasyProviders = useFragment(
    noLeaguesCardFragment,
    providersKey,
  ).fantasyProviders;

  return (
    <div className="flex flex-1 flex-col gap-4 items-center pt-28">
      <h2 className="text-3xl font-bold">Let's get started</h2>
      <Card className="shadow-2xl border-emerald-200">
        <CardContent className="p-12">
          <div className="flex flex-row items-center space-x-16">
            <div className="grid grid-cols-2 gap-8  *:rounded-lg *:size-20">
              {fantasyProviders.map((provider) => (
                <img
                  src={provider.logoURL}
                  alt={provider.name}
                  key={provider.name}
                />
              ))}
            </div>
            <div className="flex flex-col gap-y-4 max-w-xl">
              <span className="font-bold text-4xl">Add your first league</span>
              <p className="text-muted-foreground">
                To start exploring your records, you'll need to help us get
                connected to your fantasy provider. Click below to get started.
              </p>
              <Button
                onClick={openModal}
                size={"lg"}
                className="mt-4 text-base max-w-fit"
              >
                <Plus /> Add fantasy League
              </Button>
            </div>
          </div>
        </CardContent>
      </Card>
    </div>
  );
}
