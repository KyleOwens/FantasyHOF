import { RatioBreakdownCellFragment$key } from "@/__generated__/RatioBreakdownCellFragment.graphql";
import { useFragment } from "react-relay";
import { graphql } from "relay-runtime";

type Props = {
  entryKey: RatioBreakdownCellFragment$key;
};

const ratioBreakdownCellFragment = graphql`
  fragment RatioBreakdownCellFragment on RecordEntry {
    metric {
      ... on RatioRecordMetric {
        numerator
        numeratorUnit
        denominator
        denominatorUnit
      }
    }
  }
`;

export function RatioBreakdownCell({ entryKey }: Props) {
  const metric = useFragment(ratioBreakdownCellFragment, entryKey).metric;

  if (!metric.numerator || !metric.denominator) return null;

  return (
    <div className="flex items-center gap-2 py-2">
      <div className="flex flex-col items-end -translate-y-1">
        <span className="text-sm font-black text-foreground tabular-nums">
          {metric.numerator}
        </span>
        <span className="text-xs text-muted-foreground capitalize tracking-tighter leading-none">
          {metric.numeratorUnit}
        </span>
      </div>

      <div className="h-9 w-[1.5px] bg-primary/20 rotate-25 rounded-full" />

      <div className="flex flex-col items-start translate-y-1">
        <span className="text-sm font-black text-foreground tabular-nums">
          {metric.denominator}
        </span>
        <span className="text-xs text-muted-foreground capitalize tracking-tighter leading-none">
          {metric.denominatorUnit}
        </span>
      </div>
    </div>
  );
}
