import { RelayEnvironmentProvider } from "react-relay";
import { RelayEnvironment } from "./relay/RelayEnvironment";
import { StrictMode } from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { createRouter, RouterProvider } from "@tanstack/react-router";
import { routeTree } from "./routeTree.gen";
import "@fontsource/inter/400.css";
import "@fontsource/inter/500.css";
import "@fontsource/inter/600.css";
import "@fontsource/inter/700.css";
import { ClerkProvider, useAuth } from "@clerk/clerk-react";
import { RelayAuthProvider } from "./relay/RelayAuthProvider";
import { SidebarProvider } from "./components/ui/sidebar";

const PUBLISHABLE_KEY = import.meta.env.VITE_CLERK_PUBLISHABLE_KEY;

const router = createRouter({
  routeTree,
  context: {
    auth: undefined!,
  },
});

declare module "@tanstack/react-router" {
  interface Register {
    router: typeof router;
  }
}

const AppRouter = () => {
  const auth = useAuth();

  if (!auth.isLoaded) return null;

  return <RouterProvider router={router} context={{ auth }} />;
};

const rootElement = document.getElementById("root")!;
if (!rootElement.innerHTML) {
  const root = ReactDOM.createRoot(rootElement);
  root.render(
    <RelayEnvironmentProvider environment={RelayEnvironment}>
      <StrictMode>
        <ClerkProvider publishableKey={PUBLISHABLE_KEY}>
          <RelayAuthProvider>
            <SidebarProvider>
              <AppRouter />
            </SidebarProvider>
          </RelayAuthProvider>
        </ClerkProvider>
      </StrictMode>
    </RelayEnvironmentProvider>,
  );
}
