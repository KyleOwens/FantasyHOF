import { AppSidebar } from "@/components/sidebar/AppSidebar";
import { createFileRoute, Outlet } from "@tanstack/react-router";

export const Route = createFileRoute("/demo/_layout")({
  component: DemoLayout,
});

function DemoLayout() {
  return (
    <>
      <AppSidebar />
      <div className="p-8">
        <Outlet />
      </div>
    </>
  );
}
