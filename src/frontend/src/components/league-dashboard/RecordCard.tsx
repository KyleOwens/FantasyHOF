import { graphql } from "relay-runtime";
import { Avatar, AvatarFallback, AvatarImage } from "../ui/avatar";
import { Button } from "../ui/button";
import { Card, CardContent, CardDescription, CardTitle } from "../ui/card";
import { RecordCardFragment$key } from "@/__generated__/RecordCardFragment.graphql";
import { useFragment } from "react-relay";
import { Link } from "@tanstack/react-router";
import { Route as dashboardRoute } from "@/routes/$mode/$leagueId/dashboard";
import { Route as detailsRoute } from "@/routes/$mode/$leagueId/$recordTypeId";

type Props = {
  recordKey: RecordCardFragment$key;
  titleDescription: string;
  footerText: string;
};

const RecordCardFragment = graphql`
  fragment RecordCardFragment on Record {
    displayName
    iconURI
    metric {
      ... on RatioRecordMetric {
        __typename
      }
      ... on ScalarRecordMetric {
        __typename
      }
      value
      unit
    }
    type
  }
`;

export function RecordCard({ recordKey, titleDescription, footerText }: Props) {
  const record = useFragment(RecordCardFragment, recordKey);

  const roundedValue = parseFloat(record.metric.value.toFixed(2));
  const formattedValue =
    record.metric.__typename === "RatioRecordMetric"
      ? new Intl.NumberFormat("en-US", { style: "percent" }).format(
          roundedValue,
        )
      : roundedValue;

  return (
    <Card className="px-4 pt-2">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-3">
          <Avatar className="size-16">
            <AvatarImage src={record.iconURI} alt={record.displayName} />
            <AvatarFallback>
              <AvatarImage src="MostPointsLeague.png" />
            </AvatarFallback>
          </Avatar>
          <div>
            <CardTitle>{record.displayName}</CardTitle>
            <CardDescription>{titleDescription}</CardDescription>
          </div>
        </div>
        <Button variant={"link"} className="font-bold" asChild>
          <Link
            from={dashboardRoute.fullPath}
            to={detailsRoute.to}
            params={{ recordTypeId: record.type }}
          >
            See more
          </Link>
        </Button>
      </div>
      <CardContent className="px-2 space-y-4 -mt-4">
        <div className="space-x-2">
          <span className="text-4xl font-bold">{formattedValue}</span>
          <span className="text-lg">{record.metric.unit}</span>
        </div>
        <p className="text-muted-foreground">{footerText}</p>
      </CardContent>
    </Card>
  );
}
