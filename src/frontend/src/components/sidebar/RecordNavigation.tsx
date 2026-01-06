import { BellElectric, LayoutDashboard, Scale, Users } from "lucide-react";
import {
  SidebarGroup,
  SidebarGroupContent,
  SidebarGroupLabel,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
} from "../ui/sidebar";
import { Link } from "@tanstack/react-router";
import { graphql } from "relay-runtime";
import { useFragment } from "react-relay";
import {
  RecordNavigationFragment$key,
  RecordNavigationFragment$data,
} from "@/__generated__/RecordNavigationFragment.graphql";
import { Route as demoDashboardRoute } from "@/routes/demo/$leagueId/dashboard";
import { SidebarRecordCategory } from "./RecordCategoryCollapsible";

type Props = {
  recordMetadataKey: RecordNavigationFragment$key;
};

const recordNavigationFragment = graphql`
  fragment RecordNavigationFragment on Query {
    recordMetadata {
      displayName
      categoryDisplayName
      sentiment
    }
  }
`;

export type SidebarRecordMetadata =
  RecordNavigationFragment$data["recordMetadata"][number];

export function RecordNavigation({ recordMetadataKey }: Props) {
  const leagueId = demoDashboardRoute.useParams().leagueId;
  const recordMetadata = useFragment(
    recordNavigationFragment,
    recordMetadataKey,
  ).recordMetadata;

  const sidebarData = recordMetadata.reduce(
    (map, record) => {
      map[record.categoryDisplayName] ??= [];
      map[record.categoryDisplayName].push(record);

      return map;
    },
    {} as Record<string, SidebarRecordMetadata[]>,
  );

  return (
    <>
      <SidebarGroup className="-my-2">
        <SidebarGroupLabel>Dashboard</SidebarGroupLabel>
        <SidebarGroupContent>
          <SidebarMenu>
            <SidebarMenuItem>
              <SidebarMenuButton asChild>
                <Link
                  to={demoDashboardRoute.to}
                  params={{ leagueId }}
                  search={(prev) => prev}
                >
                  <LayoutDashboard />
                  <span>Dashboard</span>
                </Link>
              </SidebarMenuButton>
            </SidebarMenuItem>
          </SidebarMenu>
        </SidebarGroupContent>
      </SidebarGroup>
      <SidebarGroup>
        <SidebarGroupLabel>Records</SidebarGroupLabel>
        <SidebarGroupContent>
          <SidebarMenu>
            {Object.entries(sidebarData).map(([category, records]) => (
              <SidebarRecordCategory
                categoryDisplayName={category}
                records={records}
              />
            ))}
          </SidebarMenu>
        </SidebarGroupContent>
      </SidebarGroup>
      <SidebarGroup>
        <SidebarGroupLabel>Member tools</SidebarGroupLabel>
        <SidebarGroupContent>
          <SidebarMenu>
            <SidebarMenuItem>
              <SidebarMenuButton>
                <Scale />
                <span>Stat comparison</span>
              </SidebarMenuButton>
            </SidebarMenuItem>
            <SidebarMenuItem>
              <SidebarMenuButton>
                <BellElectric />
                <span>Head to head details</span>
              </SidebarMenuButton>
            </SidebarMenuItem>
          </SidebarMenu>
        </SidebarGroupContent>
      </SidebarGroup>
      <SidebarGroup>
        <SidebarGroupLabel>Settings</SidebarGroupLabel>
        <SidebarGroupContent>
          <SidebarMenu>
            <SidebarMenuItem>
              <SidebarMenuButton>
                <Users />
                <span>Merge members</span>
              </SidebarMenuButton>
            </SidebarMenuItem>
          </SidebarMenu>
        </SidebarGroupContent>
      </SidebarGroup>
    </>
  );
}
