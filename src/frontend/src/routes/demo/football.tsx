import { AppSidebar } from "@/components/sidebar/app-sidebar";
import { SidebarProvider, SidebarTrigger } from "@/components/ui/sidebar";
import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/demo/football")({
  component: RouteComponent,
});

function RouteComponent() {
  return <></>;
}
