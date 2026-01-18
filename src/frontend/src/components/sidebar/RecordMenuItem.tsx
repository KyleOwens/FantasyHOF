import { Link } from "@tanstack/react-router";
import { SidebarMenuSubItem, SidebarMenuSubButton } from "../ui/sidebar";
import { SidebarRecordMetadata } from "./RecordNavigation";
import { Route as leagueRoute } from "@/routes/$mode/$leagueId/dashboard";
import { Route as recordRoute } from "@/routes/$mode/$leagueId/$recordTypeId";

type Props = {
  recordMetadata: SidebarRecordMetadata;
};

export function RecordMenuItem({ recordMetadata }: Props) {
  return (
    <SidebarMenuSubItem>
      <SidebarMenuSubButton asChild>
        <Link
          from={leagueRoute.fullPath}
          to={recordRoute.to}
          params={{ recordTypeId: recordMetadata.recordTypeId }}
          className="text-xs"
        >
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
