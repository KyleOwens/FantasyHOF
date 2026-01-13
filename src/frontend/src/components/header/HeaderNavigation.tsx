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
import { SignedIn } from "@clerk/clerk-react";

const navData = [
  {
    label: "Sports",
    links: [{ label: "Football", to: indexRoute.to }],
  },
  {
    label: "Features",
    links: [{ label: "Records", to: indexRoute.to }],
  },
];

export function HeaderNavigation() {
  return (
    <div className="flex items-center">
      <Link to={indexRoute.to}>
        <img src="/logo.png" className="-mx-2 h-16 w-22" />
      </Link>
      <NavigationMenu viewport={false}>
        <NavigationMenuList>
          {navData.map((menu) => (
            <NavigationMenuItem key={menu.label}>
              <NavigationMenuTrigger className="font-medium text-muted-foreground">
                {menu.label}
              </NavigationMenuTrigger>
              <NavigationMenuContent>
                {menu.links.map((link) => (
                  <NavigationMenuLink key={link.label} asChild>
                    <Link to={link.to}>{link.label}</Link>
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
                className="font-medium text-muted-foreground px-4 py-2"
              >
                Demo
              </Link>
            </NavigationMenuLink>
          </NavigationMenuItem>
          <SignedIn>
            <NavigationMenuItem>
              <NavigationMenuLink asChild>
                <Link
                  to={modeRoute.to}
                  params={{ mode: "me" }}
                  className="font-medium text-muted-foreground px-4 py-2"
                >
                  My leagues
                </Link>
              </NavigationMenuLink>
            </NavigationMenuItem>
          </SignedIn>
        </NavigationMenuList>
      </NavigationMenu>
    </div>
  );
}
