import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/$mode/$leagueId/$recordTypeId")({
  component: RouteComponent,
});

function RouteComponent() {
  const record = Route.useParams().recordTypeId;

  return (
    <div>{`this is going to display the details for record: ${record}`}</div>
  );
}
