import { RankCellFragment$key } from "@/__generated__/RankCellFragment.graphql";
import { Medal, Trophy } from "lucide-react";
import { useFragment } from "react-relay";
import { graphql } from "relay-runtime";

type Props = {
  entryKey: RankCellFragment$key;
};

const rankCellFragment = graphql`
  fragment RankCellFragment on RecordEntry {
    rank
  }
`;
export function RankCell({ entryKey }: Props) {
  const rank = useFragment(rankCellFragment, entryKey).rank;

  return (
    <div className="flex justify-center items-center gap-2 font-bold">
      {rank === 1 && <Trophy className="size-4 text-yellow-500 mr-1.5" />}
      {rank === 2 && <Medal className="size-4 text-slate-400 mr-1.5" />}
      {rank === 3 && <Medal className="size-4 text-amber-700 mr-1.5" />}
      <span
        className={rank <= 3 ? "text-lg" : "text-muted-foreground font-medium"}
      >
        {rank}
      </span>
    </div>
  );
}
