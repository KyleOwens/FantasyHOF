import {
  Sheet,
  SheetContent,
  SheetTrigger,
  SheetHeader,
  SheetTitle,
  SheetClose,
} from "../ui/sheet";
import { Menu } from "lucide-react"; // install lucide-react if you haven't
import { Link } from "@tanstack/react-router";
import { Button } from "../ui/button";

export function MobileNav({ navData }: { navData: any[] }) {
  return (
    <Sheet>
      <SheetTrigger asChild>
        <Button variant="ghost" size="icon" className="md:hidden">
          <Menu className="h-6 w-6" />
        </Button>
      </SheetTrigger>
      <SheetContent side="left" className="w-[300px] sm:w-[400px]">
        <SheetHeader>
          <SheetTitle className="text-left">Fantasy HOF</SheetTitle>
        </SheetHeader>
        <div className="flex flex-col gap-6 pt-6">
          {navData.map((menu) => (
            <div key={menu.label} className="flex flex-col">
              <h4 className="mb-2 px-2 text-xs font-bold tracking-widest uppercase text-primary/70">
                {menu.label}
              </h4>
              <div className="flex flex-col border-l-2 border-muted ml-1">
                {menu.links.map((link: any) => (
                  <SheetClose key={link.label} asChild>
                    <Link
                      to={link.to}
                      className="py-3 px-4 text-base transition-colors hover:bg-muted active:bg-muted rounded-r-md"
                    >
                      {link.label}
                    </Link>
                  </SheetClose>
                ))}
              </div>
            </div>
          ))}
        </div>
      </SheetContent>
    </Sheet>
  );
}
