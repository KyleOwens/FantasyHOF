import { SignUpButton } from "@clerk/clerk-react";
import { Button } from "../ui/button";

export function ProductPageFooter() {
  return (
    <section className="flex flex-col gap-8 items-center py-24 px-6">
      <h2 className="text-3xl font-black tracking-tighter text-center">
        Ready to view your league's records?
      </h2>
      <SignUpButton>
        <Button size="lg" className="w-48 h-12 text-lg">
          Sign up now
        </Button>
      </SignUpButton>
    </section>
  );
}
