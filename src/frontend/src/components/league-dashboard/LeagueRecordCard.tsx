import { graphql } from "relay-runtime";
import { LeagueRecordCardFragment$key } from "@/__generated__/LeagueRecordCardFragment.graphql";
import { useFragment } from "react-relay";
import { RecordCard } from "./RecordCard";

type Props = {
  recordKey: LeagueRecordCardFragment$key;
};

const LeagueRecordCardFragment = graphql`
  fragment LeagueRecordCardFragment on LeagueRecord {
    ...RecordCardFragment
    member {
      id
      fullName
    }
  }
`;

export function LeagueRecordCard({ recordKey }: Props) {
  const record = useFragment(LeagueRecordCardFragment, recordKey);

  return (
    <RecordCard
      recordKey={record}
      titleDescription="League history"
      footerText={record.member.fullName}
    />
  );
}
