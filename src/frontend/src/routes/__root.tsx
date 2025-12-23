import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/react-router-devtools";
import {
  ClerkProvider,
  SignedIn,
  SignedOut,
  SignInButton,
  SignUpButton,
  UserButton,
} from "@clerk/clerk-react";
import { Button } from "@/components/ui/button";
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuTrigger,
} from "@/components/ui/navigation-menu";

const PUBLISHABLE_KEY = import.meta.env.VITE_CLERK_PUBLISHABLE_KEY;

const RootLayout = () => (
  <>
    <ClerkProvider publishableKey={PUBLISHABLE_KEY}>
      <header className="flex flex-row items-center justify-between px-4 shadow border">
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
      <div className="px-12 py-4">
        <Outlet />
      </div>
    </ClerkProvider>
    <TanStackRouterDevtools />
  </>
);

export const Route = createRootRoute({ component: RootLayout });
