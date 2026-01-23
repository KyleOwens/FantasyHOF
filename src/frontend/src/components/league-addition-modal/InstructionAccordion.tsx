import { HelpCircle } from "lucide-react";
import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger,
} from "../ui/accordion";

type Props = {
  title: string;
  children: React.ReactNode;
};

export function InstructionAccordion({ title, children }: Props) {
  return (
    <Accordion
      type="single"
      collapsible
      className="w-full border rounded-lg -mt-2 px-4 bg-slate-50 border-dashed"
    >
      <AccordionItem value="guide" className="border-none ">
        <AccordionTrigger className="text-xs hover:no-underline ">
          <span className="flex items-center gap-2">
            <HelpCircle className="size-5 text-primary" />
            {title}
          </span>
        </AccordionTrigger>
        <AccordionContent>{children}</AccordionContent>
      </AccordionItem>
    </Accordion>
  );
}
