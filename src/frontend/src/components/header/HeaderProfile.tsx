import {
  SignedIn,
  SignedOut,
  SignInButton,
  SignUpButton,
  UserButton,
} from "@clerk/clerk-react";
import { Button } from "../ui/button";
import {
  NavigationMenu,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
} from "../ui/navigation-menu";
import { Link } from "@tanstack/react-router";
import { Route as myLeaguesRoute } from "../../routes/$mode/my-leagues";
import { Route as dashboardRoute } from "@/routes/$mode";

export function HeaderProfile() {
  return (
    <div className="flex flex-row space-x-8">
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
        <NavigationMenu viewport={false}>
          <NavigationMenuList>
            <NavigationMenuItem>
              <NavigationMenuLink asChild>
                <Link
                  to={dashboardRoute.to}
                  params={{ mode: "me" }}
                  className="font-medium text-muted-foreground px-4 py-2"
                >
                  Record dashboard
                </Link>
              </NavigationMenuLink>
            </NavigationMenuItem>
            <NavigationMenuItem>
              <NavigationMenuLink asChild>
                <Link
                  to={myLeaguesRoute.to}
                  params={{ mode: "me" }}
                  className="font-medium text-muted-foreground px-4 py-2"
                >
                  My leagues
                </Link>
              </NavigationMenuLink>
            </NavigationMenuItem>
          </NavigationMenuList>
        </NavigationMenu>
        <UserButton appearance={{ elements: { avatarBox: "!h-8 !w-8" } }} />
      </SignedIn>
    </div>
  );
}
