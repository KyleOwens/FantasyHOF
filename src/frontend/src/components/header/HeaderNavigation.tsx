import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuTrigger,
} from "../ui/navigation-menu";
import { Route as indexRoute } from "../../routes/index.tsx";
import { Route as modeRoute } from "../../routes/$mode/index";

import { Link } from "@tanstack/react-router";

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

export function HeaderNavigation() {
  return (
    <div className="items-center hidden md:flex">
      <Link to={indexRoute.to} className="min-h-16 min-w-20">
        <img src="/logo.webp" className="-mx-2 h-16 w-20" />
      </Link>
      <NavigationMenu viewport={false}>
        <NavigationMenuList>
          {navData.map((menu) => (
            <NavigationMenuItem key={menu.label}>
              <NavigationMenuTrigger className="font-medium text-muted-foreground">
                {menu.label}
              </NavigationMenuTrigger>
              <NavigationMenuContent className="w-max">
                {menu.links.map((link) => (
                  <NavigationMenuLink
                    key={link.label}
                    className="cursor-pointer w-full whitespace-nowrap px-4"
                    asChild
                  >
                    <Link
                      to={link.to}
                      className="w-full whitespace-nowrap px-4 py-2 cursor-pointer"
                    >
                      {link.label}
                    </Link>
                  </NavigationMenuLink>
                ))}
              </NavigationMenuContent>
            </NavigationMenuItem>
          ))}
          <NavigationMenuItem>
            <NavigationMenuLink asChild>
              <Link
                to={modeRoute.to}
                params={{ mode: "demo" }}
                activeProps={{ className: "text-primary" }}
                className="font-medium text-muted-foreground px-4 py-2"
              >
                Demo
              </Link>
            </NavigationMenuLink>
          </NavigationMenuItem>
        </NavigationMenuList>
      </NavigationMenu>
    </div>
  );
}
