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
import { Route as footballRoute } from "../../routes/sports/football.tsx";
import { Route as importsRoute } from "@/routes/features/simple-imports.tsx";
import { Route as recordsFeatureRoute } from "@/routes/features/records.tsx";

import { Link, useNavigate } from "@tanstack/react-router";

const navData = [
  {
    label: "Sports",
    links: [{ label: "Football", to: footballRoute.to }],
  },
  {
    label: "Features",
    links: [
      { label: "Simple imports", to: importsRoute.to },
      { label: "Records", to: recordsFeatureRoute.to },
    ],
  },
];

export function HeaderNavigation() {
  const navigate = useNavigate();

  return (
    <div className="flex items-center">
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
                    onSelect={() => {
                      console.log("navigating to " + link.to);
                      navigate({ to: link.to });
                    }}
                  >
                    {link.label}
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
