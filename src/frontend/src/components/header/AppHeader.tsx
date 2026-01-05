import { HeaderNavigation } from "./HeaderNavigation.tsx";
import { HeaderProfile } from "./HeaderProfile.tsx";

export function AppHeader() {
  return (
    <header className="sticky top-0 flex flex-row h-[66px] items-center justify-between px-4 shadow border bg-background z-50">
      <HeaderNavigation />
      <HeaderProfile />
    </header>
  );
}
