import { ProductPage } from "@/components/product-pages/ProductPage";
import { ProductPageFeatureGrid } from "@/components/product-pages/ProductPageFeatureGrid";
import { ProductPageFeatureGridItem } from "@/components/product-pages/ProductPageFeatureGridItem";
import { ProductPageFeatureHighlightGrid } from "@/components/product-pages/ProductPageFeatureHighlightGrid";
import { ProductPageFeatureHighlightGridItem } from "@/components/product-pages/ProductPageFeatureHighlightGridItem";
import { ProductPageFooter } from "@/components/product-pages/ProductPageFooter";
import { ProductPageHeroSection } from "@/components/product-pages/ProductPageHeroSection";
import { ProductPageLabeledFeature } from "@/components/product-pages/ProductPageLabeledFeature";
import { ProductPageSection } from "@/components/product-pages/ProductPageSection";
import { createFileRoute } from "@tanstack/react-router";
import {
  BarChart3,
  Fingerprint,
  History,
  MousePointerClick,
  Zap,
} from "lucide-react";

export const Route = createFileRoute("/features/simple-imports")({
  component: RouteComponent,
});

function RouteComponent() {
  return (
    <ProductPage>
      <ProductPageHeroSection>
        <ProductPageHeroSection.Header>
          SIMPLE <br /> <span className="text-primary">IMPORTS</span>
        </ProductPageHeroSection.Header>
        <ProductPageHeroSection.Subheader>
          You provide the league credentials, we take care of the rest. We pull
          your league data directly from your fantasy provider, rebuild your
          full history, construct your record profile, and keep everything
          verified without a single spreadsheet.
        </ProductPageHeroSection.Subheader>
      </ProductPageHeroSection>
      <ProductPageSection>
        <ProductPageLabeledFeature>
          <ProductPageLabeledFeature.Precursor
            icon={Fingerprint}
            title="CREDENTIAL ENTRY"
          />
          <ProductPageLabeledFeature.Header>
            LEAGUE <span className="text-primary">IDENTITY</span>
          </ProductPageLabeledFeature.Header>
          <ProductPageLabeledFeature.Description>
            We've eliminated the friction of manual data tracking. No CSV
            exports, no spreadsheets, and no manual data entry. By helping us
            identifying your league's unique signature on your fantasy provider,
            our engine has all the information needed to download your league
            history.
          </ProductPageLabeledFeature.Description>
        </ProductPageLabeledFeature>
        <ProductPageFeatureHighlightGrid>
          <ProductPageFeatureHighlightGridItem>
            <ProductPageFeatureHighlightGridItem.Header>
              No Login Details Required
            </ProductPageFeatureHighlightGridItem.Header>
            <ProductPageFeatureHighlightGridItem.Description>
              Login details are not required. For public leagues, the identity
              is all that matters. For private leagues, our simple entry form
              guides you step-by-step to provide the information required for
              import.
            </ProductPageFeatureHighlightGridItem.Description>
          </ProductPageFeatureHighlightGridItem>
          <ProductPageFeatureHighlightGridItem>
            <ProductPageFeatureHighlightGridItem.Header>
              Universal Support
            </ProductPageFeatureHighlightGridItem.Header>
            <ProductPageFeatureHighlightGridItem.Description>
              Whether you play on ESPN, Sleeper, Yahoo, or NFL, the process
              remains identical: Identify and Extract.
            </ProductPageFeatureHighlightGridItem.Description>
          </ProductPageFeatureHighlightGridItem>
        </ProductPageFeatureHighlightGrid>
      </ProductPageSection>
      <ProductPageSection>
        <ProductPageLabeledFeature>
          <ProductPageLabeledFeature.Precursor
            icon={MousePointerClick}
            title="IMPORT PROCESS"
          />
          <ProductPageLabeledFeature.Header>
            ONE-CLICK <span className="text-primary">REFRESHES</span>
          </ProductPageLabeledFeature.Header>
          <ProductPageLabeledFeature.Description>
            Once you hit import, the manual work is finished. Our system
            reconstructs your league's history, connecting every season and
            every manager into a single, continuous data set.
          </ProductPageLabeledFeature.Description>
        </ProductPageLabeledFeature>
        <ProductPageFeatureGrid>
          <ProductPageFeatureGridItem icon={History}>
            <ProductPageFeatureGridItem.Header>
              CONNECT THE PAST
            </ProductPageFeatureGridItem.Header>
            <ProductPageFeatureGridItem.Subheader>
              We stitch together disparate seasons into one career-long
              storyline for every manager in your league.
            </ProductPageFeatureGridItem.Subheader>
          </ProductPageFeatureGridItem>
          <ProductPageFeatureGridItem icon={BarChart3}>
            <ProductPageFeatureGridItem.Header>
              AGGREGATE SCORES
            </ProductPageFeatureGridItem.Header>
            <ProductPageFeatureGridItem.Subheader>
              Total points, career records, and all-time streaks are calculated
              automatically across every year you've played.
            </ProductPageFeatureGridItem.Subheader>
          </ProductPageFeatureGridItem>
          <ProductPageFeatureGridItem icon={Zap}>
            <ProductPageFeatureGridItem.Header>
              ON DEMAND UPDATES
            </ProductPageFeatureGridItem.Header>
            <ProductPageFeatureGridItem.Subheader>
              Your archive grows with your league. Fresh data is pulled in
              seconds, keeping your records current.
            </ProductPageFeatureGridItem.Subheader>
          </ProductPageFeatureGridItem>
        </ProductPageFeatureGrid>
      </ProductPageSection>
      <ProductPageSection>
        <ProductPageLabeledFeature>
          <ProductPageLabeledFeature.Precursor
            icon={MousePointerClick}
            title="ACCURACY"
          />
          <ProductPageLabeledFeature.Header>
            COMPLETE <span className="text-primary">DATASETS</span>
          </ProductPageLabeledFeature.Header>
          <ProductPageLabeledFeature.Description>
            We don't just pull scores and call it a day. Your imports include
            every detail, including settings, rosters, matchups, scores, and
            much more.
          </ProductPageLabeledFeature.Description>
        </ProductPageLabeledFeature>
        <ProductPageFeatureHighlightGrid>
          <ProductPageFeatureHighlightGridItem>
            <ProductPageFeatureHighlightGridItem.Header>
              Verified Data
            </ProductPageFeatureHighlightGridItem.Header>
            <ProductPageFeatureHighlightGridItem.Description>
              Trash talk is only effective if the stats are real. Every imported
              milestone is verified against the provider's original box scores
              to ensure zero errors in your data.
            </ProductPageFeatureHighlightGridItem.Description>
          </ProductPageFeatureHighlightGridItem>
          <ProductPageFeatureHighlightGridItem>
            <ProductPageFeatureHighlightGridItem.Header>
              Historical Integrity
            </ProductPageFeatureHighlightGridItem.Header>
            <ProductPageFeatureHighlightGridItem.Description>
              We preserve the context. Records aren't just numbers; they include
              the week, the year, and the opponent, so you can always point to
              the exact moment it happened.
            </ProductPageFeatureHighlightGridItem.Description>
          </ProductPageFeatureHighlightGridItem>
        </ProductPageFeatureHighlightGrid>
      </ProductPageSection>
      <ProductPageFooter />
    </ProductPage>
  );
}
