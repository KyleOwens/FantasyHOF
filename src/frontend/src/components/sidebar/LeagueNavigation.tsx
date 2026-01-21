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
import { graphql, useFragment } from "react-relay";
import { Link, useNavigate } from "@tanstack/react-router";
import { LeagueNavigationFragment$key } from "@/__generated__/LeagueNavigationFragment.graphql";
import { Route as leagueRoute } from "@/routes/$mode/$leagueId/route";
import { LeagueAdditionModal } from "../league-addition-modal/LeagueAdditionModal";
import { LeagueNavigationProviderFragment$key } from "@/__generated__/LeagueNavigationProviderFragment.graphql";
import { useState } from "react";

type Props = {
  leaguesKey: LeagueNavigationFragment$key;
  providersKey: LeagueNavigationProviderFragment$key;
  userId?: string;
};

const leagueNavigationFragment = graphql`
  fragment LeagueNavigationFragment on League @relay(plural: true) {
    id
    userId
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
`;

const leagueNavigationProviderFragment = graphql`
  fragment LeagueNavigationProviderFragment on Query {
    fantasyProviders {
      ...ProviderSelectionFragment
    }
  }
`;

export function LeagueNavigation({ leaguesKey, providersKey, userId }: Props) {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const { mode, leagueId: selectedLeagueId } = leagueRoute.useParams();
  const leagues = useFragment(leagueNavigationFragment, leaguesKey);
  const fantasyProviders = useFragment(
    leagueNavigationProviderFragment,
    providersKey,
  ).fantasyProviders;
  const navigate = useNavigate();

  const isDemo = mode === "demo";

  const selectedLeague = selectedLeagueId
    ? leagues.find((x) => x.id === selectedLeagueId)
    : leagues.at(-1);

  return (
    <>
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
                    <Link
                      to="/$mode/$leagueId"
                      search={(prev) => ({ ...prev })}
                      params={{ mode: mode, leagueId: league.id }}
                    >
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
                <DropdownMenuItem
                  disabled={isDemo}
                  onClick={() => setIsModalOpen(true)}
                >
                  <div className="flex flex-row gap-2">
                    <div className="border rounded-sm p-0.5">
                      <Plus className="size-4 text-primary" />
                    </div>
                    <span>Add league</span>
                  </div>
                </DropdownMenuItem>
              </DropdownMenuGroup>
            </DropdownMenuContent>
          </DropdownMenu>
        </SidebarMenuItem>
      </SidebarMenu>
      {userId && (
        <LeagueAdditionModal
          isOpen={isModalOpen}
          onClose={() => setIsModalOpen(false)}
          providersKey={fantasyProviders}
          userId={userId}
          onSuccess={() =>
            setTimeout(() => {
              navigate({ to: "/$mode/my-leagues", params: { mode: "me" } });
            }, 500)
          }
        />
      )}
    </>
  );
}
