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

const router = createRouter({
  routeTree,
});

declare module "@tanstack/react-router" {
  interface Register {
    router: typeof router;
  }
}

const rootElement = document.getElementById("root")!;
if (!rootElement.innerHTML) {
  const root = ReactDOM.createRoot(rootElement);
  root.render(
    <RelayEnvironmentProvider environment={RelayEnvironment}>
      <StrictMode>
        <RouterProvider router={router} />
      </StrictMode>
    </RelayEnvironmentProvider>
  );
}
