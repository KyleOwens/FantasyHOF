import {
  RefreshCw,
  Trash2,
  Calendar,
  Users,
  MoreHorizontal,
} from "lucide-react";
import { Button } from "../ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../ui/card";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "../ui/dropdown-menu";
import { graphql } from "relay-runtime";
import { LeagueCardFragment$key } from "@/__generated__/LeagueCardFragment.graphql";
import { useFragment } from "react-relay";
import { Badge } from "../ui/badge";
import { Link } from "@tanstack/react-router";

type Props = {
  leagueKey: LeagueCardFragment$key;
};

const leagueCardFragment = graphql`
  fragment LeagueCardFragment on League {
    id
    currentLeagueName
    providerLeagueId
    fantasyProvider {
      id
      name
      logoURL
    }
    members {
      memberId
    }
    seasons {
      id
    }
    createdAt
  }
`;

export function LeagueCard({ leagueKey }: Props) {
  const league = useFragment(leagueCardFragment, leagueKey);

  return (
    <Card key={league.id}>
      <CardHeader className="flex flex-row items-start justify-between space-y-0 pb-2">
        <div className="flex items-center gap-3">
          <img
            src={league.fantasyProvider.logoURL}
            alt={league.fantasyProvider.name}
            className="size-10 rounded-lg"
          />
          <div>
            <CardTitle className="text-xl">
              <span>{league.currentLeagueName}</span>
            </CardTitle>
            <CardDescription className="flex items-center gap-2 mt-1">
              <Badge variant={"outline"}>{league.fantasyProvider.name}</Badge>
              <span className="text-xs">ID: {league.providerLeagueId}</span>
            </CardDescription>
          </div>
        </div>
        <Button variant={"link"} asChild className="ml-auto">
          <Link to="/">View records</Link>
        </Button>
        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <Button variant="ghost" size="icon">
              <MoreHorizontal className="size-4" />
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent align="end">
            <DropdownMenuItem className="text-destructive focus:text-destructive">
              <Trash2 className="size-4 mr-2 text-destructive" />
              Delete League
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      </CardHeader>
      <CardContent>
        <div className="flex items-center gap-6 text-sm text-muted-foreground justify-between">
          <div className="flex items-center gap-4">
            <div className="flex items-center gap-1.5">
              <Calendar className="size-4" />
              <span>{league.seasons.length} seasons</span>
            </div>
            <div className="flex items-center gap-1.5">
              <Users className="size-4" />
              <span>{league.members.length} members</span>
            </div>
          </div>
          <div className="flex items-center gap-1.5">
            <RefreshCw className="size-3" />
            <span>
              Synced{" "}
              {new Intl.DateTimeFormat("en-US", {
                dateStyle: "medium",
                timeStyle: "short",
              }).format(new Date(league.createdAt))}
            </span>
          </div>
        </div>
      </CardContent>
    </Card>
  );
}
