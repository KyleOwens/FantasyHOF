import { FantasyProviderId } from "@/__generated__/ProviderSelectionFragment.graphql";
import { ESPNForm } from "./espn/ESPNForm";

type Props = {
  resetEntry: () => void;
  onCompletion: () => void;
  provider: FantasyProviderId;
  userId: string;
};

export function DetailsForm({
  resetEntry,
  onCompletion,
  provider,
  userId,
}: Props) {
  return (
    <div className="flex flex-col gap-y-8 animate-in slide-in-from-right-5 w-full">
      {provider === "ESPN" && (
        <ESPNForm
          resetEntry={resetEntry}
          onCompletion={onCompletion}
          userId={userId}
        />
      )}
    </div>
  );
}
