import { createFileRoute } from "@tanstack/react-router";
import { LayoutDashboard, ReceiptText } from "lucide-react";
import { ProductPage } from "@/components/product-pages/ProductPage";
import { ProductPageHeroSection } from "@/components/product-pages/ProductPageHeroSection";
import { ProductPageSection } from "@/components/product-pages/ProductPageSection";
import { ProductPageFooter } from "@/components/product-pages/ProductPageFooter";

export const Route = createFileRoute("/features/records")({
  component: RouteComponent,
});

function RouteComponent() {
  return (
    <ProductPage>
      <ProductPageHeroSection>
        <ProductPageHeroSection.Header>
          THE <br /> <span className="text-primary">RECORD book</span>
        </ProductPageHeroSection.Header>
        <ProductPageHeroSection.Subheader>
          Every legendary peak and every brutal collapse, preserved in a
          searchable record book you can pull up anytime. No more arguing from
          memory, get access to real stats and undeniable facts
        </ProductPageHeroSection.Subheader>
      </ProductPageHeroSection>
      <ProductPageSection>
        <div className="flex flex-col gap-y-4">
          <div className="flex items-center gap-2 text-muted-foreground">
            <LayoutDashboard className="size-6" />
            <span className="font-black tracking-widest text-sm">
              RECORD DASHBOARD
            </span>
          </div>
          <h2 className="text-4xl font-black tracking-tight">
            THE HALL OF <span className="text-primary">FAME</span> & THE WALL OF{" "}
            <span className="text-rose-400">SHAME</span>
          </h2>
          <p className="text-muted-foreground">
            Your high-level command center. Our dashboard scans your entire
            league history to surface the current record holders for every major
            statistical category.
          </p>
          <div className="rounded-xl border bg-card shadow-2xl overflow-hidden">
            <img
              src="/records.png"
              alt="The Record Dashboard showing all-time leaders"
              className="w-full h-auto"
            />
          </div>
        </div>
      </ProductPageSection>
      <ProductPageSection>
        <div className="flex flex-col gap-y-4">
          <div className="flex items-center gap-2 text-muted-foreground">
            <ReceiptText className="size-6" />
            <span className="font-black tracking-widest text-sm">
              THE DEEP DIVE
            </span>
          </div>
          <h2 className="text-4xl font-black tracking-tight">RECORD ENTRIES</h2>
          <p className="text-muted-foreground">
            Go beyond the leaders. Every record is backed by a complete list of
            historical entries, so you can trace how the record has evolved over
            time and see exactly where each number came from.
          </p>
          <div className="rounded-xl border bg-card shadow-2xl overflow-hidden">
            <img
              src="/record-details.png"
              alt="The Record Dashboard showing all-time leaders"
              className="w-full h-auto"
            />
          </div>
        </div>
      </ProductPageSection>
      <ProductPageFooter />
    </ProductPage>
  );
}
