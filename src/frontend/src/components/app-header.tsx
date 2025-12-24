import { Link } from "@tanstack/react-router";
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuTrigger,
} from "./ui/navigation-menu";
import {
  SignedIn,
  SignedOut,
  SignInButton,
  SignUpButton,
  UserButton,
} from "@clerk/clerk-react";
import { Button } from "./ui/button";
import { Route as footballDemoRoute } from "../routes/demo/football.tsx";

export function AppHeader() {
  return (
    <header className="flex flex-row items-center justify-between px-4 shadow border z-50">
      <div className="flex items-center">
        <img src="/logo.png" className="-mx-2 h-16 w-22" />
        <NavigationMenu viewport={false}>
          <NavigationMenuList>
            <NavigationMenuItem>
              <NavigationMenuTrigger className="font-medium text-muted-foreground">
                Sports
              </NavigationMenuTrigger>
              <NavigationMenuContent>
                <NavigationMenuLink>Football</NavigationMenuLink>
              </NavigationMenuContent>
            </NavigationMenuItem>
            <NavigationMenuItem>
              <NavigationMenuTrigger className="font-medium text-muted-foreground">
                Features
              </NavigationMenuTrigger>
              <NavigationMenuContent>
                <NavigationMenuLink>Records</NavigationMenuLink>
              </NavigationMenuContent>
            </NavigationMenuItem>
            <NavigationMenuItem>
              <NavigationMenuTrigger className="font-medium text-muted-foreground">
                Demo
              </NavigationMenuTrigger>
              <NavigationMenuContent>
                <NavigationMenuLink>
                  <Link to={footballDemoRoute.to}>Football</Link>
                </NavigationMenuLink>
              </NavigationMenuContent>
            </NavigationMenuItem>
          </NavigationMenuList>
        </NavigationMenu>
      </div>
      <div className="flex flex-row items-center space-x-8"></div>
      <SignedOut>
        <div className="flex flex-row space-x-4">
          <SignInButton>
            <Button className="bg-secondary-foreground hover:bg-slate-500">
              Sign in
            </Button>
          </SignInButton>
          <SignUpButton>
            <Button>Sign up</Button>
          </SignUpButton>
        </div>
      </SignedOut>
      <SignedIn>
        <UserButton appearance={{ elements: { avatarBox: "!h-10 !w-10" } }} />
      </SignedIn>
    </header>
  );
}
