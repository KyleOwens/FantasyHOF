import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuTrigger,
} from "../ui/navigation-menu";
import { Route as footballDemoRoute } from "../../routes/demo/_layout/football.tsx";
import { Route as indexRoute } from "../../routes/index.tsx";
import { Link } from "@tanstack/react-router";

const navData = [
  {
    label: "Sports",
    links: [{ label: "Football", to: indexRoute.to }],
  },
  {
    label: "Features",
    links: [{ label: "Records", to: indexRoute.to }],
  },
  {
    label: "Demo",
    links: [{ label: "Football", to: footballDemoRoute.to }],
  },
];

export function HeaderNavigation() {
  return (
    <div className="flex items-center">
      <img src="/logo.png" className="-mx-2 h-16 w-22" />
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
        </NavigationMenuList>
      </NavigationMenu>
    </div>
  );
}
