import { Link, useRouter } from "@tanstack/react-router";
import { Button } from "../ui/button";
import { AlertCircle, Home, RefreshCcw } from "lucide-react";

type Props = {
  error: Error;
  reset: () => void;
};

export function RootErrorPage({ error, reset }: Props) {
  const router = useRouter();

  return (
    <div className="flex min-h-[400px] w-full flex-col items-center justify-center p-6 text-center">
      <div className="mb-4 flex h-20 w-20 items-center justify-center rounded-full bg-destructive/10">
        <AlertCircle className="h-10 w-10 text-destructive" />
      </div>
      <h1 className="mb-2 text-2xl font-bold tracking-tight">
        Something went wrong
      </h1>
      <p className="mb-6 max-w-md text-muted-foreground">
        {
          "An unexpected error occurred. Please try again or contact support if the problem persists."
        }
      </p>
      <div className="flex flex-wrap items-center justify-center gap-4">
        <Button
          variant="outline"
          onClick={() => {
            router.invalidate();
            reset();
          }}
        >
          <RefreshCcw className="mr-2 h-4 w-4" />
          Try again
        </Button>
        <Button asChild>
          <Link to="/">
            <Home className="mr-2 h-4 w-4" />
            Go home
          </Link>
        </Button>
      </div>
      {process.env.NODE_ENV === "development" && (
        <div className="mt-8 w-full max-w-2xl overflow-hidden rounded-lg border bg-muted p-4 text-left">
          <p className="mb-2 font-mono text-sm font-bold text-destructive">
            Dev Only Error Detail:
          </p>
          <pre className="overflow-auto font-mono text-xs leading-relaxed">
            {error.stack}
          </pre>
        </div>
      )}
    </div>
  );
}
