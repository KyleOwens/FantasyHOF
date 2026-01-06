import { createFileRoute, redirect } from "@tanstack/react-router";

export const Route = createFileRoute("/demo/$leagueId/")({
  beforeLoad: () => {
    throw redirect({
      from: Route.fullPath,
      to: "./dashboard",
    });
  },
});
