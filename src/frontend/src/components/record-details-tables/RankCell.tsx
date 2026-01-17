import { Medal, Trophy } from "lucide-react";

type Props = {
  rowNumber: number;
};

export function RankCell({ rowNumber }: Props) {
  return (
    <div className="flex justify-center items-center gap-2 font-bold">
      {rowNumber === 1 && <Trophy className="size-4 text-yellow-500 mr-1.5" />}
      {rowNumber === 2 && <Medal className="size-4 text-slate-400 mr-1.5" />}
      {rowNumber === 3 && <Medal className="size-4 text-amber-700 mr-1.5" />}
      <span
        className={
          rowNumber <= 3 ? "text-lg" : "text-muted-foreground font-medium"
        }
      >
        {rowNumber}
      </span>
    </div>
  );
}
