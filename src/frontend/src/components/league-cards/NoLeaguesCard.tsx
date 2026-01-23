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
    <div className="flex flex-1 flex-col gap-4 items-center pt-12">
      <h2 className="text-3xl font-bold">Let's get started</h2>
      <Card className="shadow-2xl border-emerald-200">
        <CardContent className="p-8">
          <div className="flex flex-col items-center text-center gap-8 lg:flex-row lg:gap-16 lg:text-left">
            <div className="grid grid-cols-4 gap-8 *:rounded-md *:size-12 *:lg:size-20 lg:grid-cols-2">
              {fantasyProviders.map((provider) => (
                <img
                  src={provider.logoURL}
                  alt={provider.name}
                  key={provider.name}
                />
              ))}
            </div>
            <div className="flex flex-col gap-y-4 max-w-xl items-center lg:items-baseline">
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
