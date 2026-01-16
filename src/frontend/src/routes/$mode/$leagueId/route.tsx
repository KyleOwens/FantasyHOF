import { AppSidebar } from "@/components/sidebar/AppSidebar";
import { createFileRoute, Outlet } from "@tanstack/react-router";

export const Route = createFileRoute("/$mode/$leagueId")({
  component: LeagueLayout,
});

function LeagueLayout() {
  const { mode } = Route.useParams();

  return (
    <>
      <AppSidebar mode={mode} />
      <div className="p-8 flex flex-1">
        <Outlet />
      </div>
    </>
  );
}
