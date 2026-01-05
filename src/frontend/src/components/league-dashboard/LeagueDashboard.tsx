import {
  LeagueDashboardQuery,
  RecordSentiment,
} from "@/__generated__/LeagueDashboardQuery.graphql";
import { useParams } from "@tanstack/react-router";
import { graphql, useLazyLoadQuery } from "react-relay";
import { RecordSection } from "./RecordSection";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "../ui/tabs";
import { ToggleGroup, ToggleGroupItem } from "../ui/toggle-group";
import { useState } from "react";

const dashboardQuery = graphql`
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
        playerRecords {
          value
          year
          week
          sentiment
          member {
            fullName
          }
        }
      }
    }
  }
`;

const LEAGUE_TAB_NAME = "League";
const SEASONAL_TAB_NAME = "Seasonal";
const WEEKLY_TAB_NAME = "Weekly";
const PLAYER_TAB_NAME = "Player";

export function LeagueDashboard() {
  const [sentiment, setSentiment] = useState<RecordSentiment>("FAME");
  const leagueId = useParams({ from: "/demo/$leagueId" }).leagueId;
  const league = useLazyLoadQuery<LeagueDashboardQuery>(dashboardQuery, {
    leagueId: leagueId,
  }).league;

  if (!league.recordSummary) return;

  return (
    <div>
      <h1 className="text-3xl font-bold tracking-tight">Dashboard</h1>
      <span className="text-muted-foreground">{league.currentLeagueName}</span>

      <div className="flex flex-col space-y-2 mt-6">
        <Tabs defaultValue={LEAGUE_TAB_NAME}>
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
              value={sentiment}
              onValueChange={(value) => setSentiment(value as RecordSentiment)}
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
          <TabsContent value={LEAGUE_TAB_NAME}>
            <RecordSection
              recordKey={league.recordSummary.leagueRecords}
              sentiment={sentiment}
              title="League"
            />
          </TabsContent>
          <TabsContent value={SEASONAL_TAB_NAME}>
            <RecordSection
              title={"Seasonal records"}
              recordKey={league.recordSummary.seasonalRecords}
              sentiment={sentiment}
            />
          </TabsContent>
          <TabsContent value={WEEKLY_TAB_NAME}>
            <RecordSection
              title={"Weekly records"}
              recordKey={league.recordSummary.weeklyRecords}
              sentiment={sentiment}
            />
          </TabsContent>
          <TabsContent value={PLAYER_TAB_NAME}>
            <RecordSection
              title={"Player records"}
              recordKey={league.recordSummary.playerRecords}
              sentiment={sentiment}
            />
          </TabsContent>
        </Tabs>
      </div>
      {/* <RecordSection
          title={"League records"}
          recordKey={league.recordSummary.leagueRecords}
        />
        <RecordSection
          title={"Seasonal records"}
          recordKey={league.recordSummary.seasonalRecords}
        />
        <RecordSection
          title={"Weekly records"}
          recordKey={league.recordSummary.weeklyRecords}
        />
        <RecordSection
          title={"Player records"}
          recordKey={league.recordSummary.playerRecords}
        /> */}
    </div>
  );
}
