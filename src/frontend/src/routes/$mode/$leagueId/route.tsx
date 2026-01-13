import { AppSidebarQuery } from "@/__generated__/AppSidebarQuery.graphql";
import { AppSidebar, appSidebarQuery } from "@/components/sidebar/AppSidebar";
import { preloadQuery } from "@/relay/helpers";
import { createFileRoute, Outlet } from "@tanstack/react-router";

export const Route = createFileRoute("/$mode/$leagueId")({
  loader: ({ params }) => {
    return preloadQuery<AppSidebarQuery>(appSidebarQuery, {
      isDemo: params.mode === "demo",
    });
  },
  onLeave: ({ loaderData }) => {
    loaderData?.dispose();
  },
  component: LeagueLayout,
});

function LeagueLayout() {
  const { mode } = Route.useParams();
  const appSidebarQueryRef = Route.useLoaderData();

  return (
    <>
      <AppSidebar queryRef={appSidebarQueryRef} mode={mode} />
      <div className="p-8 flex flex-1">
        <Outlet />
      </div>
    </>
  );
}
