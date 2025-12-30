import {
  BellElectric,
  Calculator,
  ChevronRight,
  GamepadDirectional,
  LayoutDashboard,
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

const sidebarGroups = [
  {
    title: "Scoring",
    url: "#",
    icon: Calculator,
    items: [
      {
        title: "All time points",
      },
      {
        title: "All time points2",
      },
      {
        title: "All time points3",
      },
      {
        title: "All time points4",
      },
    ],
  },
  {
    title: "Record",
    url: "#",
    icon: GamepadDirectional,
    items: [
      {
        title: "Championships",
      },
    ],
  },
  {
    title: "Matchups",
    url: "#",
    icon: BellElectric,
    items: [
      {
        title: "Head to head",
      },
    ],
  },
];

export function RecordNavigation() {
  const leagueId = useParams({ strict: false }).leagueId ?? "";

  return (
    <>
      <SidebarGroup className="-my-2">
        <SidebarGroupLabel>Dashboard</SidebarGroupLabel>
        <SidebarGroupContent>
          <SidebarMenu>
            <SidebarMenuItem>
              <SidebarMenuButton asChild>
                <Link to="/demo/$leagueId" params={{ leagueId }}>
                  <LayoutDashboard />
                  <span>Dashboard</span>
                </Link>
              </SidebarMenuButton>
            </SidebarMenuItem>
          </SidebarMenu>
        </SidebarGroupContent>
      </SidebarGroup>
      <SidebarGroup className="-my-2">
        <SidebarGroupLabel>Records</SidebarGroupLabel>
        <SidebarGroupContent>
          <SidebarMenu>
            {sidebarGroups.map((group) => (
              <Collapsible
                className="group/collapsible"
                asChild
                key={group.title}
              >
                <SidebarMenuItem>
                  <CollapsibleTrigger asChild>
                    <SidebarMenuButton tooltip={group.title}>
                      <group.icon />
                      <span>{group.title}</span>
                      <ChevronRight className="ml-auto transition-transform duration-200 group-data-[state=open]/collapsible:rotate-90" />
                    </SidebarMenuButton>
                  </CollapsibleTrigger>
                  <CollapsibleContent>
                    <SidebarMenuSub>
                      {group.items.map((item) => (
                        <SidebarMenuSubItem key={item.title}>
                          <SidebarMenuSubButton asChild>
                            <a href="#">
                              <span>{item.title}</span>
                            </a>
                          </SidebarMenuSubButton>
                        </SidebarMenuSubItem>
                      ))}
                    </SidebarMenuSub>
                  </CollapsibleContent>
                </SidebarMenuItem>
              </Collapsible>
            ))}
          </SidebarMenu>
        </SidebarGroupContent>
      </SidebarGroup>
    </>
  );
}
