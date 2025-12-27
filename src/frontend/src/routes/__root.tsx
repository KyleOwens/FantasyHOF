import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/react-router-devtools";
import { ClerkProvider } from "@clerk/clerk-react";
import { AppSidebar } from "@/components/app-sidebar";
import { AppHeader } from "@/components/app-header";
import { SidebarInset, SidebarProvider } from "@/components/ui/sidebar";
import { RelayAuthProvider } from "@/relay/RelayAuthProvider";

const PUBLISHABLE_KEY = import.meta.env.VITE_CLERK_PUBLISHABLE_KEY;

const RootLayout = () => (
  <>
    <ClerkProvider publishableKey={PUBLISHABLE_KEY}>
      <RelayAuthProvider>
        <SidebarProvider>
          <div className="flex flex-col w-full">
            <AppHeader />
            <div className="flex">
              <AppSidebar />
              <main className="p-4">
                <Outlet />
              </main>
            </div>
          </div>
        </SidebarProvider>
      </RelayAuthProvider>
    </ClerkProvider>
    <TanStackRouterDevtools />
  </>
);

export const Route = createRootRoute({ component: RootLayout });
