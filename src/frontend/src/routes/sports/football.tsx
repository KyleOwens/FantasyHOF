import { createFileRoute } from "@tanstack/react-router";
import { History } from "lucide-react";
import { Badge } from "@/components/ui/badge";
import { preloadQuery } from "@/relay/helpers";
import { graphql } from "relay-runtime";
import { footballQuery as FootballQueryType } from "@/__generated__/footballQuery.graphql";
import { usePreloadedQuery } from "react-relay";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { cn } from "@/lib/utils";
import { ProductPageFooter } from "@/components/product-pages/ProductPageFooter";
import { ProductPage } from "@/components/product-pages/ProductPage";
import { ProductPageHeroSection } from "@/components/product-pages/ProductPageHeroSection";
import { ProductPageSection } from "@/components/product-pages/ProductPageSection";
import { ProductPageFeatureGrid } from "@/components/product-pages/ProductPageFeatureGrid";
import { ProductPageFeatureGridItem } from "@/components/product-pages/ProductPageFeatureGridItem";

const footballQuery = graphql`
  query footballQuery {
    fantasyProviders {
      id
      name
      logoURL
      value
    }
  }
`;

export const Route = createFileRoute("/sports/football")({
  component: FootballProductPage,
  loader: () => preloadQuery<FootballQueryType>(footballQuery, {}),
  onLeave: ({ loaderData }) => loaderData?.dispose(),
});

export default function FootballProductPage() {
  const queryRef = Route.useLoaderData();
  const providers = usePreloadedQuery<FootballQueryType>(
    footballQuery,
    queryRef,
  ).fantasyProviders;

  return (
    <ProductPage>
      <ProductPageHeroSection>
        <ProductPageHeroSection.Header>
          FANTASY <br />
          <span className="text-primary">FOOTBALL</span>
        </ProductPageHeroSection.Header>
        <ProductPageHeroSection.Subheader>
          Your league already wrote the story, we just pull the receipts. Import
          every season and instantly see who’s been elite, who got lucky once,
          and who’s been dragging the standings for years.
        </ProductPageHeroSection.Subheader>
      </ProductPageHeroSection>
      <ProductPageSection>
        <div className="text-center">
          <h2 className="text-sm font-bold uppercase tracking-[0.3em] text-muted-foreground mb-8">
            Providers
          </h2>
          <div className="flex flex-wrap justify-center items-center gap-4 md:gap-16">
            {providers.map((provider) => (
              <div
                key={provider.id}
                className={cn(
                  "flex flex-col items-center gap-2",
                  provider.value !== "ESPN" ? "opacity-60 grayscale" : "",
                )}
              >
                <Avatar className="size-14">
                  <AvatarImage src={provider.logoURL} alt={provider.name} />
                  <AvatarFallback>{provider.name.at(0)}</AvatarFallback>
                </Avatar>
                <span className="font-bold text-sm tracking-widest">
                  {provider.name}
                </span>
                <Badge className="text-xs  font-bold">
                  {provider.value === "ESPN" ? "Available" : "Coming soon"}
                </Badge>
              </div>
            ))}
          </div>
        </div>
      </ProductPageSection>
      <ProductPageSection>
        <ProductPageFeatureGrid>
          <ProductPageFeatureGridItem icon={History}>
            <ProductPageFeatureGridItem.Header>
              SURF THE ARCHIVE
            </ProductPageFeatureGridItem.Header>
            <ProductPageFeatureGridItem.Subheader>
              Seamlessly scroll through years of matchup history. Identify who
              was actually dominant in 2014 and who has been coasting on a
              decade-old reputation.
            </ProductPageFeatureGridItem.Subheader>
          </ProductPageFeatureGridItem>
          <ProductPageFeatureGridItem icon={History}>
            <ProductPageFeatureGridItem.Header>
              IDENTIFY RECORDS
            </ProductPageFeatureGridItem.Header>
            <ProductPageFeatureGridItem.Subheader>
              Automated discovery of all-time leaders. From highest weekly
              scores to career total points, we highlight the statistical peaks
              of your league.
            </ProductPageFeatureGridItem.Subheader>
          </ProductPageFeatureGridItem>
          <ProductPageFeatureGridItem icon={History}>
            <ProductPageFeatureGridItem.Header>
              VERIFIED PROOF
            </ProductPageFeatureGridItem.Header>
            <ProductPageFeatureGridItem.Subheader>
              Every record entry has receipts. Click into any milestone to see
              the full box score and rosters from that specific week.
            </ProductPageFeatureGridItem.Subheader>
          </ProductPageFeatureGridItem>
        </ProductPageFeatureGrid>
      </ProductPageSection>
      <ProductPageFooter />
    </ProductPage>
  );
}
