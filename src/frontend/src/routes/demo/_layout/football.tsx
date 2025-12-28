import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/demo/_layout/football")({
  component: RouteComponent,
});

function RouteComponent() {
  return (
    <>
      <p>test</p>
    </>
  );
}
