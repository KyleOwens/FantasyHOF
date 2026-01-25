import { AppSidebar } from "@/components/sidebar/AppSidebar";
import { SidebarTrigger } from "@/components/ui/sidebar";
import { createFileRoute, Outlet } from "@tanstack/react-router";

export const Route = createFileRoute("/$mode/$leagueId")({
  component: LeagueLayout,
});

function LeagueLayout() {
  const { mode } = Route.useParams();

  return (
    <>
      <AppSidebar mode={mode} />
      <div className="flex flex-col flex-1">
        <div className="md:hidden fixed bottom-6 left-6 z-50">
          <SidebarTrigger className="size-12 rounded-full border shadow-2xl bg-primary text-primary-foreground hover:text-primary-foreground hover:bg-primary/90 transition-transform active:scale-95" />
        </div>
        <main className="flex flex-1 p-6 md:p-8">
          <Outlet />
        </main>
      </div>
    </>
  );
}
