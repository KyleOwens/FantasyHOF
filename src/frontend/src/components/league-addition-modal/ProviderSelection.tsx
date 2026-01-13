import { graphql } from "relay-runtime";
import {
  Item,
  ItemActions,
  ItemContent,
  ItemDescription,
  ItemMedia,
  ItemTitle,
} from "../ui/item";
import {
  FantasyProviderId,
  ProviderSelectionFragment$key,
} from "@/__generated__/ProviderSelectionFragment.graphql";
import { useFragment } from "react-relay";
import { ChevronRightIcon } from "lucide-react";

type Props = {
  providersKey: ProviderSelectionFragment$key;
  onSelectProvider: (provider: FantasyProviderId) => void;
};

const providerSelectionFragment = graphql`
  fragment ProviderSelectionFragment on FantasyProvider @relay(plural: true) {
    name
    logoURL
    value
  }
`;

export function ProviderSelection({ providersKey, onSelectProvider }: Props) {
  const fantasyProviders = useFragment(providerSelectionFragment, providersKey);

  return (
    <div className="flex flex-col gap-4 animate-in slide-in-from-left-10">
      {fantasyProviders.map((provider) => {
        const isEnabled = provider.value === "ESPN";

        return (
          <Item
            variant={"outline"}
            className={!isEnabled ? "opacity-60 grayscale-[0.5]" : ""}
            asChild
          >
            <button
              className="flex w-full text-left enabled:hover:bg-sidebar-accent "
              disabled={!isEnabled}
              onClick={() => onSelectProvider(provider.value)}
            >
              <ItemMedia>
                <img
                  src={provider.logoURL}
                  alt={provider.name}
                  className="size-12 rounded-lg"
                />
              </ItemMedia>
              <ItemContent className="flex flex-col">
                <ItemTitle>{provider.name}</ItemTitle>
                <ItemDescription>
                  {provider.value === "ESPN"
                    ? "Football and more coming soon!"
                    : "Coming soon..."}
                </ItemDescription>
              </ItemContent>
              <ItemActions>
                {isEnabled && <ChevronRightIcon className="size-4" />}
              </ItemActions>
            </button>
          </Item>
        );
      })}
    </div>
  );
}
