import { Link } from "@tanstack/react-router";
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuTrigger,
} from "../ui/navigation-menu.tsx";
import {
  SignedIn,
  SignedOut,
  SignInButton,
  SignUpButton,
  UserButton,
} from "@clerk/clerk-react";
import { Button } from "../ui/button.tsx";
import { Route as footballDemoRoute } from "../../routes/demo/_layout/football.tsx";
import { title } from "node:process";
import { HeaderNavigation } from "./header-navigation.tsx";
import { HeaderProfile } from "./header-profile.tsx";

const navData = [
  {
    label: "Sports",
    links: [{ label: "Football", to: "#" }],
  },
  {
    label: "Features",
    links: [{ label: "Records", to: "#" }],
  },
  {
    label: "Demo",
    links: [{ label: "Football", to: footballDemoRoute.to }],
  },
];

export function AppHeader() {
  return (
    <header className="flex flex-row items-center justify-between px-4 shadow border z-50">
      <HeaderNavigation />
      <HeaderProfile />
    </header>
  );
}
