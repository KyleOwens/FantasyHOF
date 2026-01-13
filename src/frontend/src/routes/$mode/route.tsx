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
  component: () => <Outlet />,
});
