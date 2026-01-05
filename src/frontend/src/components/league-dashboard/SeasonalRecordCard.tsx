import { graphql } from "relay-runtime";
import { useFragment } from "react-relay";
import { RecordCard } from "./RecordCard";
import { SeasonalRecordCardFragment$key } from "@/__generated__/SeasonalRecordCardFragment.graphql";

type Props = {
  recordKey: SeasonalRecordCardFragment$key;
};

const SeasonalRecordCardFragment = graphql`
  fragment SeasonalRecordCardFragment on SeasonalRecord {
    ...RecordCardFragment
    year
    member {
      id
      fullName
    }
  }
`;

export function SeasonalRecordCard({ recordKey }: Props) {
  const record = useFragment(SeasonalRecordCardFragment, recordKey);

  return (
    <RecordCard
      recordKey={record}
      titleDescription="Single season"
      footerText={record.member.fullName + " in " + record.year}
    />
  );
}
