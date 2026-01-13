import { Separator } from "../ui/separator";

export type InstructionStep = {
  title: string;
  description: string;
  additionalContent?: React.ReactNode;
};

type Props = {
  steps: InstructionStep[];
};

export function InstructionSet({ steps }: Props) {
  return (
    <div className="space-y-6 pt-2">
      {steps.map((step, index) => (
        <div key={index} className="relative flex gap-4">
          {index !== steps.length - 1 && (
            <Separator
              orientation="vertical"
              className="absolute left-[9px] top-5.5 h-full w-[2px] bg-slate-300"
            />
          )}
          <div className="relative flex size-5 shrink-0 items-center justify-center rounded-full bg-primary text-[10px] font-bold text-primary-foreground">
            {index + 1}
          </div>
          <div className="flex-1 space-y-1">
            <p className="text-sm font-semibold leading-none">{step.title}</p>
            <p className="text-sm text-muted-foreground">{step.description}</p>
            {step.additionalContent && step.additionalContent}
          </div>
        </div>
      ))}
    </div>
  );
}
