import { Sidebar, SidebarContent, SidebarHeader } from "../ui/sidebar";
import { graphql } from "relay-runtime";
import { LeagueNavigation } from "./league-navigation";
import { RecordNavigation } from "./record-navigation";

const AppSidebarDemoQuery = graphql`
  query appSidebarDemoQuery {
    demoLeagues {
      id
      seasons {
        settings {
          leagueName
        }
      }
      fantasyProvider {
        id
        name
      }
    }
  }
`;

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
