import { createFileRoute, Outlet } from "@tanstack/react-router";

export const Route = createFileRoute("/$mode/$leagueId")({
  // You don't even need a loader here if the parent has the data
  component: () => <Outlet />,
});
