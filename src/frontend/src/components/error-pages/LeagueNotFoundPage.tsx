import { AlertCircle } from "lucide-react";

export function LeagueNotFoundPage() {
  return (
    <div className="flex w-full flex-col items-center justify-center p-6 text-center">
      <div className="mb-4 flex h-20 w-20 items-center justify-center rounded-full bg-destructive/10">
        <AlertCircle className="h-10 w-10 text-destructive" />
      </div>

      <h1 className="mb-2 text-2xl font-bold tracking-tight">
        League not found
      </h1>

      <p className="mb-6 max-w-md text-muted-foreground">
        {"This league no longer exists and could not be loaded"}
      </p>

      <div className="flex flex-wrap items-center justify-center gap-4"></div>
    </div>
  );
}
