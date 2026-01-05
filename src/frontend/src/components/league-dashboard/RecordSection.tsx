import { graphql } from "relay-runtime";
import { RecordSectionFragment$key } from "@/__generated__/RecordSectionFragment.graphql";
import { useFragment } from "react-relay";
import { LeagueRecordCard } from "./LeagueRecordCard";
import { SeasonalRecordCard } from "./SeasonalRecordCard";
import { WeeklyRecordCard } from "./WeeklyRecordCard";
import { PlayerRecordCard } from "./PlayerRecordCard";
import { RecordSentiment } from "@/__generated__/LeagueDashboardQuery.graphql";

type Props = {
  recordKey: RecordSectionFragment$key;
  title: string;
  sentiment: RecordSentiment;
};

const RecordSectionFragment = graphql`
  fragment RecordSectionFragment on Record @relay(plural: true) {
    __typename
    sentiment
    ... on LeagueRecord {
      ...LeagueRecordCardFragment
    }
    ... on SeasonalRecord {
      ...SeasonalRecordCardFragment
    }
    ... on WeeklyRecord {
      ...WeeklyRecordCardFragment
    }
    ... on PlayerRecord {
      ...PlayerRecordCardFragment
    }
  }
`;

export function RecordSection({ recordKey, title, sentiment }: Props) {
  const records = useFragment(RecordSectionFragment, recordKey);

  const fameRecords = records.filter((r) => r.sentiment === "FAME");
  const shameRecords = records.filter((r) => r.sentiment === "SHAME");

  const recordsToDisplay = sentiment === "FAME" ? fameRecords : shameRecords;

  const renderRecord = (record: (typeof records)[number], index: number) => {
    switch (record.__typename) {
      case "LeagueRecord":
        return <LeagueRecordCard key={index} recordKey={record} />;
      case "SeasonalRecord":
        return <SeasonalRecordCard key={index} recordKey={record} />;
      case "WeeklyRecord":
        return <WeeklyRecordCard key={index} recordKey={record} />;
      case "PlayerRecord":
        return <PlayerRecordCard key={index} recordKey={record} />;
      default:
        return null;
    }
  };

  return (
    <section
      key={sentiment}
      className="mt-4 animate-in fade-in-0 slide-in-from-bottom-3 duration-300"
    >
      <h3 className="text-xl font-medium mb-3">{title}</h3>
      <div className="grid grid-cols-1 md:grid-cols-2 2xl:grid-cols-4 gap-8 w-full">
        {recordsToDisplay.map((record, index) => renderRecord(record, index))}
      </div>
    </section>
  );
}
