import { PlayerCellFragment$key } from "@/__generated__/PlayerCellFragment.graphql";

import { useFragment } from "react-relay";
import { graphql } from "relay-runtime";
import { Avatar, AvatarFallback, AvatarImage } from "../ui/avatar";
import { CircleUser } from "lucide-react";

type Props = {
  entryKey: PlayerCellFragment$key;
};

const playerCellFragment = graphql`
  fragment PlayerCellFragment on RecordEntry {
    memberDetails {
      member {
        fullName
      }
    }
    ... on PlayerRecordEntry {
      position {
        id
        value
        name
      }
      player {
        fullName
        playerImageURL
      }
      week
      year
    }
  }
`;

export function PlayerCell({ entryKey }: Props) {
  const entry = useFragment(playerCellFragment, entryKey);

  if (!entry.player || !entry.position) return;

  return (
    <div className="flex flex-row items-center gap-2">
      <Avatar className="size-10 rounded-full border border-emerald-200 shadow-sm">
        <AvatarImage
          src={entry.player.playerImageURL}
          alt={entry.player.fullName}
          className="size-10 rounded-full aspect-square object-cover object-top"
        />
        <AvatarFallback>
          <CircleUser />
        </AvatarFallback>
      </Avatar>
      <div className="flex flex-col">
        <span>{entry.player.fullName}</span>
        <span className="text-xs text-muted-foreground">
          {entry.position.value === "UNKNOWN" ? "Starter" : entry.position.name}
        </span>
        <>
          <span className="xl:hidden text-xs text-muted-foreground">
            {entry.memberDetails.member.fullName}
          </span>
          <span className="lg:hidden text-xs text-muted-foreground">
            {entry.year} {entry.week && `• Week ${entry.week}`}
          </span>
        </>
      </div>
    </div>
  );
}
