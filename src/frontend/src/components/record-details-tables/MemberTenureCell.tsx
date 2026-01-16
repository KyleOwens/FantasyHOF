import { MemberTenureCellFragment$key } from "@/__generated__/MemberTenureCellFragment.graphql";
import { CalendarClock } from "lucide-react";
import { useFragment } from "react-relay";
import { graphql } from "relay-runtime";

type Props = {
  entryKey: MemberTenureCellFragment$key;
};

const memberTenureCellFragment = graphql`
  fragment MemberTenureCellFragment on RecordEntry {
    memberDetails {
      firstyear
      lastYear
      tenure
    }
  }
`;

export function MemberTenureCell({ entryKey }: Props) {
  const memberDetails = useFragment(
    memberTenureCellFragment,
    entryKey,
  ).memberDetails;

  return (
    <div className="flex items-center gap-2 text-sm italic">
      <CalendarClock className="size-3.5 text-muted-foreground" />
      <div className="flex flex-col text-base">
        <span>{memberDetails.tenure} years</span>
        <span className="text-xs text-muted-foreground">{`${memberDetails.firstyear} - ${memberDetails.lastYear}`}</span>
      </div>
    </div>
  );
}
