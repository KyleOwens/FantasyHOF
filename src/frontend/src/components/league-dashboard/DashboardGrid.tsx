import { RecordSentiment } from "@/__generated__/LeagueDashboardQuery.graphql";
import { cn } from "@/lib/utils";

type Props = {
  children: React.ReactNode;
};

export function DashboardGrid({ children }: Props) {
  return (
    <div>
      <div className="grid grid-cols-1 md:grid-cols-2 2xl:grid-cols-4 gap-8 w-full">
        {children}
      </div>
    </div>
  );
}
