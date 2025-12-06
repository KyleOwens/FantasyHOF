import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import tailwindcss from "@tailwindcss/vite";

export default defineConfig({
  plugins: [react(), tailwindcss()],
  server: {
    proxy: {
      "/graphql": "http://localhost:5095",
    },
  },
  build: {
    outDir: "../backend/FantasyHOF/wwwroot",
    emptyOutDir: true,
  },
});
