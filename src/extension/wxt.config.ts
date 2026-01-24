import tailwindcss from "@tailwindcss/vite";
import path from "path";
import { defineConfig } from "wxt";

export default defineConfig({
  modules: ["@wxt-dev/module-react", "@wxt-dev/auto-icons"],
  srcDir: "src",
  autoIcons: {
    baseIconPath: "assets/icon.svg",
    sizes: [16, 32, 48, 128],
  },
  // Cast the manifest to 'any' to allow the new Firefox keys
  manifest: {
    permissions: ["cookies"],
    host_permissions: ["*://*.espn.com/*"],
    name: "Fantasy HOF Credential Extractor",
    description:
      "Retrieves ESPN cookies for importing a fantasy league to Fantasy HOF",
    web_accessible_resources: [
      {
        resources: ["logo.png"],
        matches: ["*://*.espn.com/*"],
      },
    ],
    version: "1.0.0",
    browser_specific_settings: {
      gecko: {
        id: "fantasyhof-credential-extractor@fantasyhof.local",
        strict_min_version: "140.0", // Update to 140.0 for this feature
        data_collection_permissions: {
          required: ["none"],
        },
      },
    },
  } as any,
  vite: () => ({
    plugins: [tailwindcss()],
    resolve: {
      alias: {
        "@": path.resolve(__dirname, "./src"),
      },
    },
  }),
});
