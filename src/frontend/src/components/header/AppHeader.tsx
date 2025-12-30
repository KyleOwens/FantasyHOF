import { HeaderNavigation } from "./HeaderNavigation.tsx";
import { HeaderProfile } from "./HeaderProfile.tsx";

export function AppHeader() {
  return (
    <header className="flex flex-row items-center justify-between px-4 shadow border z-50">
      <HeaderNavigation />
      <HeaderProfile />
    </header>
  );
}
