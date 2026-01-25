import { createRootRouteWithContext, Outlet } from "@tanstack/react-router";
import { useAuth } from "@clerk/clerk-react";
import { AppHeader } from "@/components/header/AppHeader";
import { RootErrorPage } from "@/components/error-pages/RootErrorPage";

export type RouterContext = {
  auth: ReturnType<typeof useAuth>;
};

const RootLayout = () => {
  return (
    <>
      <div className="flex flex-col w-full min-h-screen">
        <AppHeader />
        <main className="flex flex-1">
          <Outlet />
        </main>
      </div>
      {/* <TanStackRouterDevtools /> */}
    </>
  );
};

export const Route = createRootRouteWithContext<RouterContext>()({
  component: RootLayout,
  errorComponent: ({ error, reset }) => (
    <RootErrorPage error={error} reset={reset} />
  ),
});
