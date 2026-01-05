import { graphql } from "relay-runtime";
import { DashboardGrid } from "./DashboardGrid";
import { RecordSectionFragment$key } from "@/__generated__/RecordSectionFragment.graphql";
import { useFragment } from "react-relay";
import { LeagueRecordCard } from "./LeagueRecordCard";
import { Separator } from "../ui/separator";
import { SeasonalRecordCard } from "./SeasonalRecordCard";
import { WeeklyRecordCard } from "./WeeklyRecordCard";
import { PlayerRecordCard } from "./PlayerRecordCard";

type Props = {
  recordKey: RecordSectionFragment$key;
  title: string;
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

export function RecordSection({ recordKey, title }: Props) {
  const records = useFragment(RecordSectionFragment, recordKey);

  const fameRecords = records.filter((r) => r.sentiment === "FAME");
  const shameRecords = records.filter((r) => r.sentiment === "SHAME");

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
    <section className="mt-8">
      <h3 className="text-xl font-medium mb-3">{title}</h3>
      <DashboardGrid>
        {fameRecords.map((record, index) => renderRecord(record, index))}
      </DashboardGrid>
      <Separator className="my-8" />
      <DashboardGrid>
        {shameRecords.map((record, index) => renderRecord(record, index))}
      </DashboardGrid>
    </section>
  );
}
