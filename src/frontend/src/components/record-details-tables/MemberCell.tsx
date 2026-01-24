import { User } from "lucide-react";
import { Avatar, AvatarFallback, AvatarImage } from "../ui/avatar";
import { graphql } from "relay-runtime";
import { MemberCellFragment$key } from "@/__generated__/MemberCellFragment.graphql";
import { useFragment } from "react-relay";
import { useIsMobile } from "@/hooks/use-mobile";
import { formatNameShort } from "@/utilities/utilities";

type Props = {
  entryKey: MemberCellFragment$key;
};

const memberCellFragment = graphql`
  fragment MemberCellFragment on RecordEntry {
    memberDetails {
      id
      currentTeamName
      currentTeamLogoURL
      tenure
      firstyear
      lastYear
      member {
        fullName
      }
    }
    ... on SeasonalRecordEntry {
      year
    }
    ... on WeeklyRecordEntry {
      week
      year
    }
    ... on PlayerRecordEntry {
      week
      year
    }
  }
`;

export function MemberCell({ entryKey }: Props) {
  const { memberDetails, week, year } = useFragment(
    memberCellFragment,
    entryKey,
  );
  const isMobile = useIsMobile();

  return (
    <div className="flex items-center gap-4 min-w-[100px]">
      <Avatar className="hidden lg:flex justify-center items-center h-10 w-10 border border-emerald-200 shadow-sm">
        <AvatarImage src={memberDetails.currentTeamLogoURL} alt="Team logo" />
        <AvatarFallback className="text-primary">
          <User />
        </AvatarFallback>
      </Avatar>
      <div className="flex flex-col gap-1 min-w-[100px]">
        <span className="text-base truncate">
          {isMobile
            ? formatNameShort(memberDetails.member.fullName)
            : memberDetails.member.fullName}
        </span>
        <span className="text-xs text-muted-foreground items-center max-w-[120px] truncate">
          {memberDetails.currentTeamName}
        </span>
        <span className="lg:hidden text-xs text-muted-foreground">{`${memberDetails.tenure} year member`}</span>

        {year && (
          <div className="lg:hidden text-xs text-muted-foreground">
            {year} {week && `• Week ${week}`}
          </div>
        )}
      </div>
    </div>
  );
}
