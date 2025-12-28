import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/demo/_layout/$leagueId')({
  component: RouteComponent,
})

function RouteComponent() {
  return <div>Hello "/demo/_layout/$leagueId"!</div>
}
