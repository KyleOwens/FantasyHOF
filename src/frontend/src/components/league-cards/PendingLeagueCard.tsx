import { PendingLeagueCardFragment$key } from "@/__generated__/PendingLeagueCardFragment.graphql";
import { useFragment } from "react-relay";
import { graphql } from "relay-runtime";
import { Card, CardContent } from "../ui/card";
import { Badge } from "../ui/badge";
import { Progress } from "../ui/progress";
import { AlertCircle } from "lucide-react";

type Props = {
  importKey: PendingLeagueCardFragment$key;
};

const PendingLeagueCardFragment = graphql`
  fragment PendingLeagueCardFragment on LeagueImport {
    id
    provider {
      id
      name
      logoURL
    }
    status {
      id
      name
      value
    }
    progress
    error
    providerleagueId
  }
`;

export function PendingLeagueCard({ importKey }: Props) {
  const leagueImport = useFragment(PendingLeagueCardFragment, importKey);

  const badgeVariant =
    leagueImport.status.id === "COMPLETED"
      ? "default"
      : leagueImport.status.id === "FAILED"
        ? "destructive"
        : "secondary";

  return (
    <Card
      className={
        leagueImport.status.value === "FAILED" ? "border-destructive" : ""
      }
    >
      <CardContent className="flex items-center gap-4 py-4">
        <img
          src={leagueImport.provider.logoURL}
          alt={leagueImport.provider.name}
          className="size-10 rounded-lg"
        />
        <div className="flex-1 min-w-0">
          <div className="flex items-center gap-2 mb-1">
            <span className="font-medium">
              {leagueImport.provider.name} League #
              {leagueImport.providerleagueId}
            </span>
            <Badge variant={badgeVariant}>{leagueImport.status.name}</Badge>
          </div>
          {leagueImport.status.value !== "COMPLETED" &&
            leagueImport.status.value !== "FAILED" && (
              <div className="flex items-center gap-3">
                <Progress
                  value={leagueImport.progress}
                  className="flex-1 h-2"
                />
                <span className="text-xs text-muted-foreground w-12">
                  {leagueImport.progress}%
                </span>
              </div>
            )}
          {leagueImport.status.value === "FAILED" && leagueImport.error && (
            <div className="flex items-center gap-1.5 text-sm text-destructive">
              <AlertCircle className="size-3" />
              <span>{leagueImport.error}</span>
            </div>
          )}
          {leagueImport.status.value === "QUEUED" && (
            <p className="text-sm text-muted-foreground">Waiting to start...</p>
          )}
        </div>
      </CardContent>
    </Card>
  );
}
