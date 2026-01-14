import {
  LeagueImportStatusId,
  PendingLeagueCardFragment$key,
} from "@/__generated__/PendingLeagueCardFragment.graphql";
import { useFragment } from "react-relay";
import { graphql } from "relay-runtime";
import { Card, CardContent } from "../ui/card";
import { Badge } from "../ui/badge";
import { Progress } from "../ui/progress";
import { AlertCircle } from "lucide-react";
import { useEffect, useRef, useState } from "react";

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
  const [visualProgress, setVisualProgress] = useState(leagueImport.progress);
  const timerRef = useRef<NodeJS.Timeout | null>(null);

  const statusConfig: Record<
    LeagueImportStatusId,
    "secondary" | "destructive" | "default"
  > = {
    QUEUED: "secondary",
    LOADING_DATA: "secondary",
    SAVING_DATA: "secondary",
    FAILED: "destructive",
    COMPLETED: "default",
    "%future added value": "secondary",
    FORMATTING_DATA: "secondary",
  };

  useEffect(() => {
    const serverProgress = leagueImport.progress;
    const status = leagueImport.status.value;

    if (
      serverProgress > visualProgress ||
      status === "COMPLETED" ||
      status === "FAILED"
    ) {
      setVisualProgress(serverProgress);

      if (timerRef.current) clearInterval(timerRef.current);
    }

    if (status === "SAVING_DATA") {
      if (timerRef.current) clearInterval(timerRef.current);

      timerRef.current = setInterval(() => {
        setVisualProgress((prev) => {
          if (prev >= 98) {
            clearInterval(timerRef.current!);
            return 98;
          }

          return prev + 0.8;
        });
      }, 300);
    }

    return () => {
      if (timerRef.current) clearInterval(timerRef.current);
    };
  }, [leagueImport.progress, leagueImport.status.value]);

  const displayProgress = Math.floor(visualProgress);

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
            <Badge variant={statusConfig[leagueImport.status.value]}>
              {leagueImport.status.name}
            </Badge>
          </div>
          {leagueImport.status.value !== "COMPLETED" &&
            leagueImport.status.value !== "FAILED" && (
              <div className="flex items-center gap-3">
                <Progress value={displayProgress} className="flex-1 h-2" />
                <span className="text-xs text-muted-foreground w-12">
                  {displayProgress}%
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
