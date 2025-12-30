import { BadgeCheck, ChevronsUpDown, Plus } from "lucide-react";
import { Avatar, AvatarImage } from "../ui/avatar";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "../ui/dropdown-menu";
import { SidebarMenu, SidebarMenuButton, SidebarMenuItem } from "../ui/sidebar";
import { graphql } from "react-relay";
import { useLazyLoadQuery } from "react-relay";
import { LeagueNavigationQuery } from "@/__generated__/LeagueNavigationQuery.graphql";
import { Link, useMatchRoute, useParams } from "@tanstack/react-router";

export const leagueNavigationQuery = graphql`
  query LeagueNavigationQuery {
    demoLeagues {
      id
      currentLeagueName
      fantasyProvider {
        id
        logoURL
      }
      sport {
        id
        name
      }
    }
  }
`;

export function LeagueNavigation() {
  const selectedLeagueId = useParams({ strict: false }).leagueId;
  const matchRoute = useMatchRoute();
  const leagues = useLazyLoadQuery<LeagueNavigationQuery>(
    leagueNavigationQuery,
    {},
  ).demoLeagues;

  const isDemo = !!matchRoute({ to: "/demo", fuzzy: true });

  const selectedLeague = selectedLeagueId
    ? leagues.find((x) => x.id === selectedLeagueId)
    : leagues.at(-1);

  return (
    <SidebarMenu>
      <SidebarMenuItem>
        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <SidebarMenuButton
              size="lg"
              className="data-[state=open]:bg-sidebar-accent data-[state=open]:text-sidebar-accent-foreground"
            >
              <Avatar className="w-8 h-8 rounded-lg">
                <AvatarImage src={selectedLeague?.fantasyProvider.logoURL} />
              </Avatar>
              <div className="grid flex-1 text-left text-xs leading-tight">
                <span className="truncate font-medium">
                  {selectedLeague?.currentLeagueName}
                </span>
                <span className="truncate text-muted-foreground">
                  {selectedLeague?.sport.name}
                </span>
              </div>
              <ChevronsUpDown className="ml-auto size-4" />
            </SidebarMenuButton>
          </DropdownMenuTrigger>
          <DropdownMenuContent
            className=" min-w-56 rounded-lg"
            side="right"
            align="start"
            sideOffset={4}
          >
            <DropdownMenuLabel>Leagues</DropdownMenuLabel>
            <DropdownMenuGroup>
              {leagues.map((league) => (
                <DropdownMenuItem key={league.id} asChild>
                  <Link to="/demo/$leagueId" params={{ leagueId: league.id }}>
                    <div className="border rounded-sm p-0.5">
                      <img
                        src={league.fantasyProvider.logoURL}
                        className="size-4"
                      />
                    </div>
                    <div className="grid flex-1">
                      <span className="text-sm">
                        {league.currentLeagueName}
                      </span>
                      <span className="text-xs text-muted-foreground">
                        {league.sport.name}
                      </span>
                    </div>
                    <BadgeCheck
                      className={`size-4 ml-auto text-primary ${league.id === selectedLeagueId ? "opacity-100" : "opacity-0"}`}
                    />
                  </Link>
                </DropdownMenuItem>
              ))}
            </DropdownMenuGroup>
            <DropdownMenuSeparator />
            <DropdownMenuGroup>
              <DropdownMenuItem disabled={isDemo}>
                <div className="border rounded-sm p-0.5">
                  <Plus className="size-4 text-primary" />
                </div>
                {"Add league"}
              </DropdownMenuItem>
            </DropdownMenuGroup>
          </DropdownMenuContent>
        </DropdownMenu>
      </SidebarMenuItem>
    </SidebarMenu>
  );
}
