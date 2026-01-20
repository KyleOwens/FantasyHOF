import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import { ProviderSelection } from "./ProviderSelection";
import {
  FantasyProviderId,
  ProviderSelectionFragment$key,
} from "@/__generated__/ProviderSelectionFragment.graphql";
import { useEffect, useState } from "react";
import { DetailsForm } from "./DetailsForm";
import { ScrollArea } from "../ui/scroll-area";
import { ImportSuccessMessage } from "./ImportSuccessMessage";

type Props = {
  providersKey: ProviderSelectionFragment$key;
  userId: string;
  isOpen: boolean;
  onClose: () => void;
  onSuccess?: () => void;
};

enum LeagueAdditionStep {
  Provider = "Provider",
  Details = "Details",
  Completed = "Completed",
}

export function LeagueAdditionModal({
  isOpen,
  onClose,
  providersKey,
  userId,
  onSuccess,
}: Props) {
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
      onClose();
    }
  };

  const onCompletion = () => {
    setStep(LeagueAdditionStep.Completed);
  };

  useEffect(() => {
    if (!isOpen) return;

    onResetEntry();
  }, [isOpen]);

  useEffect(() => {
    if (step === LeagueAdditionStep.Completed) {
      const timer = setTimeout(() => {
        onOpenChange(false);
        onSuccess?.();
      }, 2000);
      return () => clearTimeout(timer);
    }
  }, [step]);

  return (
    <Dialog onOpenChange={onOpenChange} open={isOpen}>
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
                userId={userId}
              />
            )}
          </div>
          {step === LeagueAdditionStep.Completed && <ImportSuccessMessage />}
        </ScrollArea>
      </DialogContent>
    </Dialog>
  );
}
