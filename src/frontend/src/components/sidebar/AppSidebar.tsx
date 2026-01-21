import { graphql } from "relay-runtime";
import { Sidebar, SidebarContent, SidebarHeader } from "../ui/sidebar";
import { LeagueNavigation } from "./LeagueNavigation";
import { RecordNavigation } from "./RecordNavigation";
import { useLazyLoadQuery } from "react-relay";
import { AppSidebarQuery } from "@/__generated__/AppSidebarQuery.graphql";

type Props = {
  mode: "demo" | "me";
};

export const appSidebarMetatdataFragment = graphql`
  fragment AppSidebarMetadataFragment on Query {
    ...RecordNavigationFragment
  }
`;

export const appSidebarDataFragment = graphql`
  fragment AppSidebarDataFragment on League @relay(plural: true) {
    ...LeagueNavigationFragment
  }
`;

export const appSidebarQuery = graphql`
  query AppSidebarQuery($isDemo: Boolean!) {
    ...RecordNavigationFragment
    demoLeagues @include(if: $isDemo) {
      ...LeagueNavigationFragment
    }
    me @skip(if: $isDemo) {
      id
      leagues(first: 10) @connection(key: "my_leagues") {
        edges {
          node {
            id
            ...LeagueNavigationFragment
          }
        }
      }
    }
    ...LeagueNavigationProviderFragment
  }
`;

export function AppSidebar({ mode }: Props) {
  const data = useLazyLoadQuery<AppSidebarQuery>(appSidebarQuery, {
    isDemo: mode === "demo",
  });

  const leagues =
    (mode === "demo"
      ? data.demoLeagues
      : data.me?.leagues?.edges?.map((x) => x.node)) ?? [];

  return (
    <Sidebar className="sticky top-[66px] h-[calc(100vh-66px)] w-80">
      <SidebarHeader>
        <LeagueNavigation
          leaguesKey={leagues}
          providersKey={data}
          userId={data.me?.id}
        />
      </SidebarHeader>
      <SidebarContent>
        <RecordNavigation recordMetadataKey={data} />
      </SidebarContent>
    </Sidebar>
  );
}
