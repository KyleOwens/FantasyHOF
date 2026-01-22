import { LeagueNotFoundPage } from "@/components/error-pages/LeagueNotFoundPage";
import { isRelayError } from "@/utilities/errorUtilities";
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
  onCatch: (error) => {
    if (!isRelayError(error)) throw error;
    if (error.source?.errors?.at(0)?.extensions?.code !== "FantasyHOFNotFound")
      throw error;

    return;
  },
  errorComponent: LeagueNotFoundPage,
});
