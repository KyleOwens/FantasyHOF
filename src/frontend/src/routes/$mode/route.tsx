import { AppSidebarQuery } from "@/__generated__/AppSidebarQuery.graphql";
import { AppSidebar, appSidebarQuery } from "@/components/sidebar/AppSidebar";
import { preloadQuery } from "@/relay/helpers";
import { createFileRoute, Outlet } from "@tanstack/react-router";
import z from "zod";

const leagueParamsSchema = z.object({
  mode: z.enum(["me", "demo"]),
});

export const Route = createFileRoute("/$mode")({
  params: {
    parse: (rawParams) => leagueParamsSchema.parse(rawParams),
    stringify: (params) => ({ mode: params.mode }),
  },
  loader: ({ params }) => {
    return preloadQuery<AppSidebarQuery>(appSidebarQuery, {
      isDemo: params.mode === "demo",
    });
  },
  onLeave: ({ loaderData }) => {
    loaderData?.dispose();
  },
  component: RecordViewerLayout,
});

function RecordViewerLayout() {
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
