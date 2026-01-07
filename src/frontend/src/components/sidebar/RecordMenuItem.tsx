import { Link } from "@tanstack/react-router";
import { SidebarMenuSubItem, SidebarMenuSubButton } from "../ui/sidebar";
import { SidebarRecordMetadata } from "./RecordNavigation";

type Props = {
  recordMetadata: SidebarRecordMetadata;
};

export function RecordMenuItem({ recordMetadata }: Props) {
  return (
    <SidebarMenuSubItem>
      <SidebarMenuSubButton asChild>
        <Link to={"."} className="text-xs">
          {formatRecordNameForSidebar(recordMetadata.displayName)}
        </Link>
      </SidebarMenuSubButton>
    </SidebarMenuSubItem>
  );
}

// This just simply needs to be done smarter. Okay as a stop-gap, but not a longterm solution
function formatRecordNameForSidebar(recordName: string) {
  let formattedName = recordName;

  formattedName = formattedName.replace("percentage", "%");
  return formattedName;
}
