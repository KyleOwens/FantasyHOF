import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/react-router-devtools";
import { ClerkProvider } from "@clerk/clerk-react";
import { AppHeader } from "@/components/header/AppHeader";
import { SidebarProvider } from "@/components/ui/sidebar";
import { RelayAuthProvider } from "@/relay/RelayAuthProvider";

const PUBLISHABLE_KEY = import.meta.env.VITE_CLERK_PUBLISHABLE_KEY;

const RootLayout = () => {
  return (
    <>
      <ClerkProvider publishableKey={PUBLISHABLE_KEY}>
        <RelayAuthProvider>
          <SidebarProvider>
            <div className="flex flex-col w-full">
              <AppHeader />
              <main className="flex">
                <Outlet />
              </main>
            </div>
          </SidebarProvider>
        </RelayAuthProvider>
      </ClerkProvider>
      <TanStackRouterDevtools />
    </>
  );
};

export const Route = createRootRoute({ component: RootLayout });
