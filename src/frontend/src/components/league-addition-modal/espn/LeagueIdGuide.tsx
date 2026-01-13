import { InstructionAccordion } from "../InstructionAccordion";
import { InstructionSet, InstructionStep } from "../InstructionSet";

const steps: InstructionStep[] = [
  {
    title: "Navigate to your League",
    description:
      "Open your ESPN Fantasy Football league home page in your browser.",
  },
  {
    title: "Check the Address Bar",
    description: "Look at the URL at the top of your browser window.",
  },
  {
    title: "Identify the ID",
    description:
      "Find the numbers following 'leagueId='. It's usually an 8-9 digit number.",
    additionalContent: (
      <div className="mt-2 rounded p-2 border border-dashed text-xs ">
        https://fantasy.espn.com/.../team?leagueId=
        <span className="bg-primary/10 text-primary px-1 rounded font-bold">
          12345678
        </span>
        &seasonId=2025
      </div>
    ),
  },
];

export function LeagueIdGuide() {
  return (
    <InstructionAccordion title="How do I find my League Id?">
      <InstructionSet steps={steps} />
    </InstructionAccordion>
  );
}
