import { PlayerRecordCardFragment$key } from "@/__generated__/PlayerRecordCardFragment.graphql";
import { useFragment } from "react-relay";
import { graphql } from "relay-runtime";
import { RecordCard } from "./RecordCard";

type Props = {
  recordKey: PlayerRecordCardFragment$key;
};

const PlayerRecordCardFragment = graphql`
  fragment PlayerRecordCardFragment on PlayerRecord {
    year
    week
    member {
      fullName
    }
    player {
      fullName
    }
    ...RecordCardFragment
  }
`;

export function PlayerRecordCard({ recordKey }: Props) {
  const record = useFragment(PlayerRecordCardFragment, recordKey);

  return (
    <RecordCard
      recordKey={record}
      titleDescription="Single player in a week"
      footerText={`By ${record.player.fullName} in week ${record.week} of ${record.year} for ${record.member.fullName}`}
    />
  );
}
