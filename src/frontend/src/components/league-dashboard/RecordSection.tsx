import { graphql } from "relay-runtime";
import { RecordSectionFragment$key } from "@/__generated__/RecordSectionFragment.graphql";
import { useFragment } from "react-relay";
import { LeagueRecordCard } from "./LeagueRecordCard";
import { SeasonalRecordCard } from "./SeasonalRecordCard";
import { WeeklyRecordCard } from "./WeeklyRecordCard";
import { PlayerRecordCard } from "./PlayerRecordCard";
import { RecordSentiment } from "@/types/enums";

type Props = {
  recordKey: RecordSectionFragment$key;
  title: string;
  sentiment: RecordSentiment;
};

const RecordSectionFragment = graphql`
  fragment RecordSectionFragment on Record @relay(plural: true) {
    __typename
    metadata {
      sentiment
    }
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

  const fameRecords = records.filter(
    (r) => r.metadata.sentiment === RecordSentiment.FAME,
  );
  const shameRecords = records.filter(
    (r) => r.metadata.sentiment === RecordSentiment.SHAME,
  );

  const recordsToDisplay =
    sentiment === RecordSentiment.FAME ? fameRecords : shameRecords;

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
      <div className="grid grid-cols-1 lg:grid-cols-2 min-[112rem]:grid-cols-4 gap-8 w-full">
        {recordsToDisplay.map((record, index) => renderRecord(record, index))}
      </div>
    </section>
  );
}
