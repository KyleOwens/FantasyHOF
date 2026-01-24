export function formatRecordMetricForDisplay(metric: {
  __typename: "RatioRecordMetric";
  value: any;
}): string {
  const roundedValue = parseFloat(metric.value.toFixed(2));

  return metric.__typename !== "RatioRecordMetric"
    ? roundedValue.toString()
    : new Intl.NumberFormat("en-US", { style: "percent" }).format(roundedValue);
}

export function formatNameShort(fullName: string): string {
  if (!fullName) return "";

  const parts = fullName.trim().split(/\s+/);

  // If it's just one name (e.g., "LeBron"), return it as is
  if (parts.length === 1) return parts[0];

  const firstName = parts[0];
  const lastName = parts[parts.length - 1];
  const lastInitial = lastName.charAt(0).toUpperCase();

  return `${firstName} ${lastInitial}.`;
}
