import { AppSidebarQuery } from "@/__generated__/AppSidebarQuery.graphql";
import { AppSidebar, appSidebarQuery } from "@/components/sidebar/AppSidebar";
import { preloadQuery } from "@/relay/helpers";
import { createFileRoute, Outlet } from "@tanstack/react-router";

export const Route = createFileRoute("/demo")({
  component: DemoLayout,
  loader: () => {
    return preloadQuery<AppSidebarQuery>(appSidebarQuery, {});
  },
  onLeave: ({ loaderData }) => {
    loaderData?.dispose();
  },
});

function DemoLayout() {
  const appSidebarQueryRef = Route.useLoaderData();

  return (
    <>
      <AppSidebar queryRef={appSidebarQueryRef} />
      <div className="p-8 flex flex-1">
        <Outlet />
      </div>
    </>
  );
}
