import { Sidebar, SidebarContent, SidebarHeader } from "../ui/sidebar";
import { LeagueNavigation } from "./LeagueNavigation";
import { RecordNavigation } from "./RecordNavigation";

export function AppSidebar() {
  return (
    <Sidebar className="sticky">
      <SidebarHeader>
        <LeagueNavigation />
      </SidebarHeader>
      <SidebarContent>
        <RecordNavigation />
      </SidebarContent>
    </Sidebar>
  );
}
