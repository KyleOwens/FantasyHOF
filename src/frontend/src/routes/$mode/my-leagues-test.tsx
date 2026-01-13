import { createFileRoute, Link } from "@tanstack/react-router";
import { graphql } from "relay-runtime";
import { useLazyLoadQuery } from "react-relay";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { Progress } from "@/components/ui/progress";
import {
  MoreVertical,
  RefreshCw,
  Trash2,
  Trophy,
  Users,
  Calendar,
  Plus,
  AlertCircle,
} from "lucide-react";
import { useState } from "react";
import { LeagueAdditionModal } from "@/components/league-addition-modal/LeagueAdditionModal";
import { Badge } from "@/components/ui/badge";
import { myLeaguesTestQuery } from "@/__generated__/myLeaguesTestQuery.graphql";
import { NoLeaguesCard } from "@/components/no-leagues-card/NoLeaguesCard";
import { LeagueCard } from "@/components/league-card/LeagueCard";

export const Route = createFileRoute("/$mode/my-leagues-test")({
  component: MyLeaguesTestPage,
});

const MyLeaguesQueryDef = graphql`
  query myLeaguesTestQuery {
    me {
      leagues {
        id
        ...LeagueCardFragment
        fantasyProvider {
          name
          logoURL
        }
        providerLeagueId
      }
    }
    ...NoLeaguesCardFragment
    fantasyProviders {
      ...ProviderSelectionFragment
    }
  }
`;

function MyLeaguesTestPage() {
  const data = useLazyLoadQuery<myLeaguesTestQuery>(MyLeaguesQueryDef, {});

  const { leagues } = data.me;

  if (leagues.length === 0) return <NoLeaguesCard providersKey={data} />;

  return (
    <div className="container max-w-4xl mx-auto py-6">
      <div className="flex items-center justify-between mb-8">
        <div>
          <h2 className="text-3xl font-bold">My Leagues</h2>
          <p className="text-muted-foreground mt-1">
            Manage your fantasy football leagues
          </p>
        </div>
        <LeagueAdditionModal providersKey={data.fantasyProviders}>
          <Button>
            <Plus className="size-4 mr-2" />
            Add League
          </Button>
        </LeagueAdditionModal>
      </div>
      <section>
        <h3 className="text-lg font-semibold mb-4">
          Your Leagues ({leagues.length})
        </h3>
        <div className="flex flex-col gap-4">
          {leagues.map((league) => (
            <LeagueCard leagueKey={league} />
          ))}
        </div>
      </section>
    </div>
  );
}

type PendingLeague = {
  id: string;
  provider: {
    name: string;
    logoURL: string;
  };
  externalLeagueId: string;
  status: "QUEUED" | "PROCESSING" | "FAILED";
  progress: number;
  error: string | null;
  createdAt: string;
};

function PendingLeagueCard({ pending }: { pending: PendingLeague }) {
  const statusConfig = {
    QUEUED: { label: "Queued", variant: "secondary" as const },
    PROCESSING: { label: "Processing", variant: "default" as const },
    FAILED: { label: "Failed", variant: "destructive" as const },
  };

  const status = statusConfig[pending.status];

  return (
    <Card
      className={pending.status === "FAILED" ? "border-destructive/50" : ""}
    >
      <CardContent className="flex items-center gap-4 py-4">
        <img
          src={pending.provider.logoURL}
          alt={pending.provider.name}
          className="size-10 rounded-lg"
        />

        <div className="flex-1 min-w-0">
          <div className="flex items-center gap-2 mb-1">
            <span className="font-medium">
              {pending.provider.name} League #{pending.externalLeagueId}
            </span>
            <Badge variant={status.variant}>{status.label}</Badge>
          </div>

          {pending.status === "PROCESSING" && (
            <div className="flex items-center gap-3">
              <Progress value={pending.progress} className="flex-1 h-2" />
              <span className="text-xs text-muted-foreground w-12">
                {pending.progress}%
              </span>
            </div>
          )}

          {pending.status === "FAILED" && pending.error && (
            <div className="flex items-center gap-1.5 text-sm text-destructive">
              <AlertCircle className="size-3" />
              <span>{pending.error}</span>
            </div>
          )}

          {pending.status === "QUEUED" && (
            <p className="text-sm text-muted-foreground">Waiting to start...</p>
          )}
        </div>

        {pending.status === "FAILED" && (
          <Button variant="outline" size="sm">
            Retry
          </Button>
        )}
      </CardContent>
    </Card>
  );
}
