import {
  ArrowRight,
  BellElectric,
  Calculator,
  Calendar,
  ChevronRight,
  GamepadDirectional,
  Home,
  Inbox,
  Search,
  Settings,
} from "lucide-react";
import {
  Sidebar,
  SidebarContent,
  SidebarGroup,
  SidebarGroupContent,
  SidebarGroupLabel,
  SidebarHeader,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
  SidebarMenuSub,
  SidebarMenuSubButton,
  SidebarMenuSubItem,
  SidebarTrigger,
  useSidebar,
} from "./ui/sidebar";
import { Button } from "./ui/button";
import { cn } from "@/lib/utils";
import { Collapsible, CollapsibleContent } from "./ui/collapsible";
import { CollapsibleTrigger } from "@radix-ui/react-collapsible";

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

export function AppSidebar() {
  const { toggleSidebar, open } = useSidebar();

  return (
    <Sidebar collapsible="icon" className="sticky">
      <SidebarHeader className="flex items-end -mx-1.5">
        <Button
          onClick={toggleSidebar}
          variant="ghost"
          className="flex flex-row items-center"
        >
          <ArrowRight
            className={cn(
              "h-4 w-4 transition-transform duration-400 text-primary",
              open && "rotate-180"
            )}
          />
        </Button>
      </SidebarHeader>
      <SidebarContent>
        <SidebarGroup>
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
      </SidebarContent>
    </Sidebar>
  );
}
