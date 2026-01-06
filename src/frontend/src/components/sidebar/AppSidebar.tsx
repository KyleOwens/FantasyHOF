import { graphql } from "relay-runtime";
import { Sidebar, SidebarContent, SidebarHeader } from "../ui/sidebar";
import { LeagueNavigation } from "./LeagueNavigation";
import { RecordNavigation } from "./RecordNavigation";
import { PreloadedQuery, usePreloadedQuery } from "react-relay";
import { AppSidebarQuery } from "@/__generated__/AppSidebarQuery.graphql";

type Props = {
  queryRef: PreloadedQuery<AppSidebarQuery>;
};

export const appSidebarQuery = graphql`
  query AppSidebarQuery {
    ...RecordNavigationFragment
    ...LeagueNavigationFragment
  }
`;

export function AppSidebar({ queryRef }: Props) {
  const data = usePreloadedQuery(appSidebarQuery, queryRef);

  return (
    <Sidebar className="sticky top-[66px] h-[calc(100vh-66px)] w-72">
      <SidebarHeader>
        <LeagueNavigation demoLeaguesKey={data} />
      </SidebarHeader>
      <SidebarContent>
        <RecordNavigation recordMetadataKey={data} />
      </SidebarContent>
    </Sidebar>
  );
}
