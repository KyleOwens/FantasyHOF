import {
  Collapsible,
  CollapsibleContent,
  CollapsibleTrigger,
} from "../ui/collapsible";
import { SidebarMenuButton, SidebarMenuItem } from "../ui/sidebar";
import { SidebarRecordList } from "./RecordList";
import { SidebarRecordMetadata } from "./RecordNavigation";
import {
  CalendarClock,
  CalendarDays,
  History,
  User,
  X,
  ChevronRight,
} from "lucide-react";

type SidebarRecordCategoryProps = {
  categoryDisplayName: string;
  records: SidebarRecordMetadata[];
};

export function SidebarRecordCategory({
  categoryDisplayName,
  records,
}: SidebarRecordCategoryProps) {
  return (
    <Collapsible
      className="group/collapsible"
      asChild
      key={categoryDisplayName}
    >
      <SidebarMenuItem>
        <CollapsibleTrigger asChild>
          <SidebarMenuButton tooltip={categoryDisplayName}>
            <RecordSectionIcon categoryDisplayName={categoryDisplayName} />
            <span>{categoryDisplayName}</span>
            <ChevronRight className="ml-auto transition-transform duration-200 group-data-[state=open]/collapsible:rotate-90" />
          </SidebarMenuButton>
        </CollapsibleTrigger>
        <CollapsibleContent>
          <SidebarRecordList records={records} />
        </CollapsibleContent>
      </SidebarMenuItem>
    </Collapsible>
  );
}

// Would like to not rely on a category display name for the switch here
function RecordSectionIcon({
  categoryDisplayName,
}: {
  categoryDisplayName: string;
}) {
  switch (categoryDisplayName) {
    case "League":
      return <History />;
    case "Season":
      return <CalendarClock />;
    case "Week":
      return <CalendarDays />;
    case "Player":
      return <User />;
    default:
      return <X />;
  }
}
