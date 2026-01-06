import { SidebarMenuSub } from "../ui/sidebar";
import { SidebarRecordMetadata } from "./RecordNavigation";
import { RecordMenuItem } from "./RecordMenuItem";
import { RecordSentiment } from "@/types/enums";

type Props = {
  records: SidebarRecordMetadata[];
};

export function SidebarRecordList({ records }: Props) {
  return (
    <SidebarMenuSub>
      <RecordSentimentSectionHeader title="🏆 Fame" />
      {records
        .filter(
          (recordMetadata) => recordMetadata.sentiment === RecordSentiment.FAME,
        )
        .map((recordMetadata) => (
          <RecordMenuItem
            recordMetadata={recordMetadata}
            key={recordMetadata.displayName}
          />
        ))}
      <RecordSentimentSectionHeader title="💩 Shame" />
      {records
        .filter(
          (recordMetadata) =>
            recordMetadata.sentiment === RecordSentiment.SHAME,
        )
        .map((recordMetadata) => (
          <RecordMenuItem
            recordMetadata={recordMetadata}
            key={recordMetadata.displayName}
          />
        ))}
    </SidebarMenuSub>
  );
}

function RecordSentimentSectionHeader({ title }: { title: string }) {
  return (
    <div className="px-1 not-first:pt-4 text-sm text-muted-foreground">
      {title}
    </div>
  );
}
