import { HeaderNavigation } from "./HeaderNavigation.tsx";
import { HeaderProfile } from "./HeaderProfile.tsx";
import { MobileNav } from "./MobileDrawer.tsx";

export function AppHeader() {
  const navData = [
    {
      label: "Sports",
      links: [{ label: "Football", to: "/sports/football" }],
    },
    {
      label: "Features",
      links: [
        { label: "Simple imports", to: "/features/simple-imports" },
        { label: "Records", to: "/features/records" },
      ],
    },
  ];

  return (
    <header className="sticky top-0 flex flex-row h-[66px] items-center justify-between px-4 shadow border bg-background z-50">
      <div className="flex items-center gap-2">
        <div className="md:hidden">
          <MobileNav navData={navData} />
        </div>
        <HeaderNavigation />
      </div>
      <HeaderProfile />
    </header>
  );
}
