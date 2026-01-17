import { RecordValueCellFragment$key } from "@/__generated__/RecordValueCellFragment.graphql";
import { formatRecordMetricForDisplay } from "@/utilities/utilities";
import { useFragment } from "react-relay";
import { graphql } from "relay-runtime";

type Props = {
  entryKey: RecordValueCellFragment$key;
  rowNumber: number;
};

const recordValueCellFragment = graphql`
  fragment RecordValueCellFragment on RecordEntry {
    metric {
      value
      unit
      ... on RatioRecordMetric {
        __typename
        numerator
        denominator
      }
    }
  }
`;

export function RecordValueCell({ entryKey, rowNumber }: Props) {
  const entry = useFragment(recordValueCellFragment, entryKey);

  const displayValue = formatRecordMetricForDisplay(entry.metric);

  return (
    <div className="text-right pr-2">
      <div
        className={`font-bold ${rowNumber === 1 ? "text-2xl text-primary" : "text-xl"}`}
      >
        {displayValue}
      </div>
      <div className="text-xs font-medium text-muted-foreground tracking-widest">
        {entry.metric.unit}
      </div>
    </div>
  );
}
