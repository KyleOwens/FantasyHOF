import "@/styles/globals.css";
import ReactDOM from "react-dom/client";
import { App } from "./App";

export default defineContentScript({
  matches: ["*://fantasy.espn.com/*"],
  cssInjectionMode: "ui",

  async main(ctx) {
    const ui = await createShadowRootUi(ctx, {
      name: "fantasy-hof-helper",
      position: "inline",
      anchor: "body",
      append: "first",
      onMount: (container) => {
        const root = ReactDOM.createRoot(container);
        root.render(<App />);
        return root;
      },
      onRemove: (root) => {
        root?.unmount();
      },
    });

    ui.mount();
  },
});
