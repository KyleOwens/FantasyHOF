import { LeagueDashboardQuery } from "@/__generated__/LeagueDashboardQuery.graphql";
import { useNavigate, useSearch } from "@tanstack/react-router";
import { graphql, PreloadedQuery, usePreloadedQuery } from "react-relay";
import { RecordSection } from "./RecordSection";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "../ui/tabs";
import { ToggleGroup, ToggleGroupItem } from "../ui/toggle-group";
import { cn } from "@/lib/utils";
import { RecordCategory, RecordSentiment } from "@/types/enums";

type Props = {
  queryRef: PreloadedQuery<LeagueDashboardQuery>;
};

export const leagueDashboardQuery = graphql`
  query LeagueDashboardQuery($leagueId: ID!) {
    league(id: $leagueId) {
      currentLeagueName
      recordSummary {
        leagueRecords {
          ...RecordSectionFragment
        }
        seasonalRecords {
          ...RecordSectionFragment
        }
        weeklyRecords {
          ...RecordSectionFragment
        }
        playerRecords {
          ...RecordSectionFragment
        }
      }
    }
  }
`;

const LEAGUE_TAB_NAME = "LEAGUE";
const SEASONAL_TAB_NAME = "SEASONAL";
const WEEKLY_TAB_NAME = "WEEKLY";
const PLAYER_TAB_NAME = "PLAYER";

export function LeagueDashboard({ queryRef }: Props) {
  const { recordCategory, recordSentiment } = useSearch({
    from: "/demo/$leagueId",
  });
  const navigate = useNavigate({ from: "/demo/$leagueId" });

  const league = usePreloadedQuery(leagueDashboardQuery, queryRef).league;

  if (!league.recordSummary) return;

  const onCategoryChange = (value: string) => {
    navigate({
      search: (prev) => ({ ...prev, recordCategory: value as RecordCategory }),
    });
  };

  const onSentimentChange = (value: string) => {
    navigate({
      search: (prev) => ({
        ...prev,
        recordSentiment: value as RecordSentiment,
      }),
    });
  };

  return (
    <div>
      <h1 className="text-3xl font-bold tracking-tight">Dashboard</h1>
      <span className="text-muted-foreground">{league.currentLeagueName}</span>

      <div className="flex flex-col space-y-2 mt-6">
        <Tabs value={recordCategory} onValueChange={onCategoryChange}>
          <div className="flex items-center space-x-8">
            <TabsList className="*:data-[state=active]:shadow-none bg-slate-200 ">
              <TabsTrigger value={LEAGUE_TAB_NAME}>League</TabsTrigger>
              <TabsTrigger value={SEASONAL_TAB_NAME}>Seasonal</TabsTrigger>
              <TabsTrigger value={WEEKLY_TAB_NAME}>Weekly</TabsTrigger>
              <TabsTrigger value={PLAYER_TAB_NAME}>Player</TabsTrigger>
            </TabsList>
            <ToggleGroup
              type="single"
              className="bg-slate-200"
              value={recordSentiment}
              onValueChange={onSentimentChange}
            >
              <ToggleGroupItem
                className="data-[state=on]:bg-emerald-400 data-[state=on]:text-slate-50 hover:bg-emerald-400  hover:text-slate-50 transition-all"
                value="FAME"
              >
                Fame
              </ToggleGroupItem>
              <ToggleGroupItem
                className="data-[state=on]:bg-rose-400 data-[state=on]:text-slate-50 hover:bg-rose-400 hover:text-slate-50 transition-all"
                value="SHAME"
              >
                Shame
              </ToggleGroupItem>
            </ToggleGroup>
          </div>
          <div
            className={cn(
              "*:data-[state=inactive]:hidden",
              "*:data-[state=active]:animate-in",
              "*:data-[state=active]:fade-in-0",
              "*:slide-in-from-bottom-2",
              "*:data-[state=active]:duration-300",
            )}
          >
            <TabsContent value={LEAGUE_TAB_NAME} forceMount>
              <RecordSection
                recordKey={league.recordSummary.leagueRecords}
                sentiment={recordSentiment}
                title="League"
              />
            </TabsContent>
            <TabsContent value={SEASONAL_TAB_NAME} forceMount>
              <RecordSection
                title={"Seasonal records"}
                recordKey={league.recordSummary.seasonalRecords}
                sentiment={recordSentiment}
              />
            </TabsContent>
            <TabsContent value={WEEKLY_TAB_NAME} forceMount>
              <RecordSection
                title={"Weekly records"}
                recordKey={league.recordSummary.weeklyRecords}
                sentiment={recordSentiment}
              />
            </TabsContent>
            <TabsContent value={PLAYER_TAB_NAME} forceMount>
              <div>
                <RecordSection
                  title={"Player records"}
                  recordKey={league.recordSummary.playerRecords}
                  sentiment={recordSentiment}
                />
              </div>
            </TabsContent>
          </div>
        </Tabs>
      </div>
    </div>
  );
}
