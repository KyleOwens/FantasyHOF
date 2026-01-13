import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { ProviderSelection } from "./ProviderSelection";
import {
  FantasyProviderId,
  ProviderSelectionFragment$key,
} from "@/__generated__/ProviderSelectionFragment.graphql";
import { useState } from "react";
import { DetailsForm } from "./DetailsForm";
import { ScrollArea } from "../ui/scroll-area";

type Props = {
  children: React.ReactNode;
  providersKey: ProviderSelectionFragment$key;
};

enum LeagueAdditionStep {
  Provider = "Provider",
  Details = "Details",
}

export function LeagueAdditionModal({ children, providersKey }: Props) {
  const [isOpen, setIsOpen] = useState(false);
  const [step, setStep] = useState<LeagueAdditionStep>(
    LeagueAdditionStep.Provider,
  );
  const [selectedProvider, setSelectedProvider] =
    useState<FantasyProviderId | null>(null);

  const onSelectProvider = (provider: FantasyProviderId) => {
    setSelectedProvider(provider);
    setStep(LeagueAdditionStep.Details);
  };

  const onResetEntry = () => {
    setStep(LeagueAdditionStep.Provider);
    setSelectedProvider(null);
  };

  const onOpenChange = (isOpen: boolean) => {
    if (!isOpen) {
      onResetEntry();
    }

    setIsOpen(isOpen);
  };

  const onCompletion = () => {
    onResetEntry();
    setIsOpen(false);
  };

  return (
    <Dialog onOpenChange={onOpenChange} open={isOpen}>
      <DialogTrigger asChild>{children}</DialogTrigger>
      <DialogContent className="fixed top-[10%] min-w-3xl translate-y-0 overflow-hidden pb-8">
        <DialogHeader className="mb-4 shrink-0">
          <DialogTitle>Add league</DialogTitle>
          {step === LeagueAdditionStep.Provider && (
            <DialogDescription>Select a provider to continue</DialogDescription>
          )}
        </DialogHeader>
        <ScrollArea className="-mx-3 max-h-[75vh]">
          <div className="px-6 ">
            {step === LeagueAdditionStep.Provider && (
              <ProviderSelection
                providersKey={providersKey}
                onSelectProvider={onSelectProvider}
              />
            )}
            {step === LeagueAdditionStep.Details && selectedProvider && (
              <DetailsForm
                resetEntry={onResetEntry}
                provider={selectedProvider}
                onCompletion={onCompletion}
              />
            )}
          </div>
        </ScrollArea>
      </DialogContent>
    </Dialog>
  );
}
