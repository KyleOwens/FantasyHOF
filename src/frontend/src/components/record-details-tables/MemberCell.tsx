import { User } from "lucide-react";
import { Avatar, AvatarFallback, AvatarImage } from "../ui/avatar";
import { graphql } from "relay-runtime";
import { MemberCellFragment$key } from "@/__generated__/MemberCellFragment.graphql";
import { useFragment } from "react-relay";

type Props = {
  entryKey: MemberCellFragment$key;
};

const memberCellFragment = graphql`
  fragment MemberCellFragment on RecordEntry {
    memberDetails {
      id
      currentTeamName
      currentTeamLogoURL
      member {
        fullName
      }
    }
  }
`;

export function MemberCell({ entryKey }: Props) {
  const memberDetails = useFragment(memberCellFragment, entryKey).memberDetails;

  return (
    <div className="flex items-center gap-4">
      <Avatar className="flex justify-center items-center h-10 w-10 border border-emerald-200 shadow-sm">
        <AvatarImage src={memberDetails.currentTeamLogoURL} alt="Team logo" />
        <AvatarFallback className="text-primary">
          <User />
        </AvatarFallback>
      </Avatar>
      <div className="flex flex-col">
        <span className="text-base">{memberDetails.member.fullName}</span>
        <span className="text-xs text-muted-foreground flex items-center gap-1">
          {memberDetails.currentTeamName}
        </span>
      </div>
    </div>
  );
}
