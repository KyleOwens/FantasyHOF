import { ArrowLeft, Check } from "lucide-react";
import { Button } from "../ui/button";
import { FantasyProviderId } from "@/__generated__/ProviderSelectionFragment.graphql";
import { ESPNForm } from "./espn/ESPNForm";

type Props = {
  resetEntry: () => void;
  provider: FantasyProviderId;
};

export function DetailsForm({ resetEntry, provider }: Props) {
  return (
    <div className="flex flex-col gap-y-8 animate-in slide-in-from-right-5 w-full">
      {provider === "ESPN" && <ESPNForm />}
    </div>
  );
}
