import {
  RefreshCw,
  Trash2,
  Calendar,
  Users,
  MoreHorizontal,
  AlertCircle,
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
import { ConnectionHandler, graphql } from "relay-runtime";
import { LeagueCardFragment$key } from "@/__generated__/LeagueCardFragment.graphql";
import { useFragment, useMutation } from "react-relay";
import { Badge } from "../ui/badge";
import { Link } from "@tanstack/react-router";
import { LeagueCardDeleteLeagueMutation } from "@/__generated__/LeagueCardDeleteLeagueMutation.graphql";
import {
  AlertDialog,
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
} from "@/components/ui/alert-dialog";
import { useState } from "react";
import { Spinner } from "../ui/spinner";
import { Route as dashboardRoute } from "@/routes/$mode/$leagueId/dashboard";
import { Route as myLeaguesRoute } from "@/routes/$mode/my-leagues";
import { Separator } from "../ui/separator";

type Props = {
  userId: string;
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

const leagueCardDeleteLeagueMutation = graphql`
  mutation LeagueCardDeleteLeagueMutation(
    $input: DeleteUserLeagueInput!
    $connections: [ID!]!
  ) {
    deleteUserLeague(input: $input) {
      deleteUserLeagueMutationPayload {
        leagueId @deleteEdge(connections: $connections)
      }
      errors {
        ... on ICodedException {
          errorCode
          message
        }
      }
    }
  }
`;

export function LeagueCard({ leagueKey, userId }: Props) {
  const league = useFragment(leagueCardFragment, leagueKey);
  const [commitLeagueDeletion, isLeagueDeletionPending] =
    useMutation<LeagueCardDeleteLeagueMutation>(leagueCardDeleteLeagueMutation);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [deleteError, setDeleteError] = useState<string | null>(null);

  // While league can't be null, this is important because when relay updates
  // its store after the subscription, this component can rerender before the league
  // is completely removed
  if (!league) {
    return null;
  }

  const handleOpenChange = (open: boolean) => {
    setShowDeleteDialog(open);
    if (!open) setDeleteError(null);
  };

  const handleLeagueDeletion = () => {
    setDeleteError(null);

    commitLeagueDeletion({
      variables: {
        input: {
          leagueId: league.id,
        },
        connections: [ConnectionHandler.getConnectionID(userId, "my_leagues")],
      },
      updater: (store) => {
        store.delete(league.id);
      },
      onCompleted: (response) => {
        const errors = response.deleteUserLeague.errors;

        if (errors && errors.length > 0) {
          setDeleteError(errors[0].message ?? "An unexpected error occurred.");
        } else {
          setShowDeleteDialog(false);
        }
      },
      onError: () => {
        setDeleteError("Network error: Could not reach the server.");
      },
    });
  };

  return (
    <>
      <Card key={league.id}>
        <CardHeader className="space-y-0">
          <div className="flex items-start justify-between">
            <div className="flex items-center gap-3 flex-1 min-w-0">
              <img
                src={league.fantasyProvider.logoURL}
                alt={league.fantasyProvider.name}
                className="size-10 rounded-lg"
              />
              <div className="min-w-0">
                <CardTitle className="text-xl truncate">
                  {league.currentLeagueName}
                </CardTitle>
                <CardDescription className="flex items-center gap-2 mt-1">
                  <Badge variant={"outline"}>
                    {league.fantasyProvider.name}
                  </Badge>
                  <span className="text-xs">ID: {league.providerLeagueId}</span>
                </CardDescription>
              </div>
            </div>
            <DropdownMenu>
              <DropdownMenuTrigger asChild>
                <Button variant="ghost" size="icon">
                  <MoreHorizontal className="size-4" />
                </Button>
              </DropdownMenuTrigger>
              <DropdownMenuContent align="end">
                <DropdownMenuItem
                  className="text-destructive focus:text-destructive"
                  onSelect={() => setShowDeleteDialog(true)}
                >
                  <Trash2 className="size-4 mr-2 text-destructive" />
                  Delete League
                </DropdownMenuItem>
              </DropdownMenuContent>
            </DropdownMenu>
          </div>
          <Button variant="secondary" asChild className="mt-4 w-full sm:hidden">
            <Link
              from={myLeaguesRoute.fullPath}
              to={dashboardRoute.to}
              params={{ leagueId: league.id }}
            >
              View records
            </Link>
          </Button>
        </CardHeader>
        <CardContent>
          <div className="flex flex-col sm:flex-row sm:items-center gap-4 text-sm text-muted-foreground justify-between">
            <div className="flex items-center gap-4">
              <div className="flex items-center gap-1.5 whitespace-nowrap">
                <Calendar className="size-4" />
                <span>{league.seasons.length} seasons</span>
              </div>
              <div className="flex items-center gap-1.5">
                <Users className="size-4" />
                <span>{league.members.length} members</span>
              </div>
            </div>
            <Separator className="sm:hidden" />
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
          <Separator className="hidden sm:block mt-4 mb-2" />
          <div className="hidden md:block">
            <Button variant="link" asChild className="h-auto p-0">
              <Link
                from={myLeaguesRoute.fullPath}
                to={dashboardRoute.to}
                params={{ leagueId: league.id }}
              >
                View records →
              </Link>
            </Button>
          </div>
        </CardContent>
      </Card>
      <AlertDialog open={showDeleteDialog} onOpenChange={handleOpenChange}>
        <AlertDialogContent>
          <AlertDialogHeader>
            <AlertDialogTitle>Are you absolutely sure?</AlertDialogTitle>
            <AlertDialogDescription>
              This will permanently delete{" "}
              <strong>{league.currentLeagueName}</strong>. This action cannot be
              undone.
            </AlertDialogDescription>
          </AlertDialogHeader>
          {deleteError && (
            <div className="bg-destructive/10 border border-destructive/20 text-destructive text-sm p-3 rounded-md flex items-center gap-2">
              <AlertCircle className="size-4" />
              {deleteError}
            </div>
          )}
          <AlertDialogFooter>
            <AlertDialogCancel disabled={isLeagueDeletionPending}>
              Cancel
            </AlertDialogCancel>
            <AlertDialogAction
              onClick={(e) => {
                e.preventDefault();
                handleLeagueDeletion();
              }}
              className="bg-destructive text-destructive-foreground hover:bg-destructive/90"
              disabled={isLeagueDeletionPending}
            >
              <span>Delete League</span>
              {isLeagueDeletionPending && <Spinner />}
            </AlertDialogAction>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </>
  );
}
