import { createFileRoute, redirect } from "@tanstack/react-router";

export const Route = createFileRoute("/$mode/$leagueId/")({
  beforeLoad: () => {
    throw redirect({
      from: Route.fullPath,
      to: "./dashboard",
    });
  },
});
