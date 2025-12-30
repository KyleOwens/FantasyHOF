import {
  SignedIn,
  SignedOut,
  SignInButton,
  SignUpButton,
  UserButton,
} from "@clerk/clerk-react";
import { Button } from "../ui/button";

export function HeaderProfile() {
  return (
    <>
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
        <UserButton appearance={{ elements: { avatarBox: "!h-8 !w-8" } }} />
      </SignedIn>
    </>
  );
}
