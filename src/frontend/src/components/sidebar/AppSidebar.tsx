import { Sidebar, SidebarContent, SidebarHeader } from "../ui/sidebar";
import { LeagueNavigation } from "./LeagueNavigation";
import { RecordNavigation } from "./RecordNavigation";

export function AppSidebar() {
  return (
    <Sidebar className="sticky top-[66px] h-[calc(100vh-66px)]">
      <SidebarHeader>
        <LeagueNavigation />
      </SidebarHeader>
      <SidebarContent>
        <RecordNavigation />
      </SidebarContent>
    </Sidebar>
  );
}
