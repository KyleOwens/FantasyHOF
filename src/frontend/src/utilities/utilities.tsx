export function formatRecordMetricForDisplay(metric: {
  __typename: "RatioRecordMetric";
  value: any;
}): string {
  const roundedValue = parseFloat(metric.value.toFixed(2));

  return metric.__typename !== "RatioRecordMetric"
    ? roundedValue.toString()
    : new Intl.NumberFormat("en-US", { style: "percent" }).format(roundedValue);
}
