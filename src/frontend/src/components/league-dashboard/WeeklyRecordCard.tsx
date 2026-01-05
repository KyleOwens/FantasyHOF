import { graphql } from "relay-runtime";
import { RecordCard } from "./RecordCard";
import { useFragment } from "react-relay";
import { WeeklyRecordCardFragment$key } from "@/__generated__/WeeklyRecordCardFragment.graphql";

type Props = {
  recordKey: WeeklyRecordCardFragment$key;
};

const WeeklyRecordCardFragment = graphql`
  fragment WeeklyRecordCardFragment on WeeklyRecord {
    year
    week
    member {
      id
      fullName
    }
    ...RecordCardFragment
  }
`;

export function WeeklyRecordCard({ recordKey }: Props) {
  const record = useFragment(WeeklyRecordCardFragment, recordKey);

  return (
    <RecordCard
      recordKey={record}
      titleDescription="Single week"
      footerText={
        record.member.fullName +
        " in week " +
        record.week +
        " of " +
        record.year
      }
    />
  );
}
