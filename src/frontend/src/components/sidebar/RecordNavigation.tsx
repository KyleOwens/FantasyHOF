import {
  BellElectric,
  Calculator,
  Calendar,
  CalendarClock,
  CalendarDays,
  ChevronRight,
  GamepadDirectional,
  GitCompare,
  History,
  LayoutDashboard,
  Scale,
  Trophy,
  User,
  Users,
  X,
} from "lucide-react";
import {
  SidebarGroup,
  SidebarGroupContent,
  SidebarGroupLabel,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
  SidebarMenuSub,
  SidebarMenuSubButton,
  SidebarMenuSubItem,
} from "../ui/sidebar";
import {
  Collapsible,
  CollapsibleContent,
  CollapsibleTrigger,
} from "../ui/collapsible";
import { Link, useParams } from "@tanstack/react-router";
import { graphql } from "relay-runtime";
import { useFragment } from "react-relay";
import {
  RecordNavigationFragment$key,
  RecordNavigationFragment$data,
} from "@/__generated__/RecordNavigationFragment.graphql";

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

type SidebarRecordMetadata =
  RecordNavigationFragment$data["recordMetadata"][number];

export function RecordNavigation({ recordMetadataKey }: Props) {
  const leagueId = useParams({ strict: false }).leagueId ?? "";
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
                  to="/demo/$leagueId"
                  search={(prev) => ({
                    recordCategory: prev.recordCategory ?? "LEAGUE",
                    recordSentiment: prev.recordSentiment ?? "FAME",
                  })}
                  params={{ leagueId }}
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

type SidebarRecordCategoryProps = {
  categoryDisplayName: string;
  records: SidebarRecordMetadata[];
};
function SidebarRecordCategory({
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

function SidebarRecordList({ records }: { records: SidebarRecordMetadata[] }) {
  return (
    <SidebarMenuSub>
      <div className="px-1 py-1 text-sm text-muted-foreground">🏆 Fame</div>
      {records
        .filter((x) => x.sentiment === "FAME")
        .map((x) => (
          <SidebarMenuSubItem>
            <SidebarMenuSubButton asChild>
              <Link to={"/demo/$leagueId"}>
                {formatRecordNameForSidebar(x.displayName)}
              </Link>
            </SidebarMenuSubButton>
          </SidebarMenuSubItem>
        ))}
      <div className="px-1 pt-4 text-sm text-muted-foreground">💩 Shame</div>
      {records
        .filter((x) => x.sentiment === "SHAME")
        .map((x) => (
          <SidebarMenuSubItem>
            <SidebarMenuSubButton asChild>
              <Link to={"/demo/$leagueId"}>
                {formatRecordNameForSidebar(x.displayName)}
              </Link>
            </SidebarMenuSubButton>
          </SidebarMenuSubItem>
        ))}
    </SidebarMenuSub>
  );
}

function formatRecordNameForSidebar(recordName: string) {
  let formattedName = recordName;

  formattedName = formattedName.replace("percentage", "%");
  formattedName = formattedName.substring(formattedName.indexOf(" ") + 1);
  formattedName =
    formattedName.charAt(0).toUpperCase() + formattedName.slice(1);
  return formattedName;
}
