import { graphql } from "relay-runtime";
import { Avatar, AvatarFallback, AvatarImage } from "../ui/avatar";
import { Button } from "../ui/button";
import { Card, CardContent, CardDescription, CardTitle } from "../ui/card";
import { RecordCardFragment$key } from "@/__generated__/RecordCardFragment.graphql";
import { useFragment } from "react-relay";
import { Link } from "@tanstack/react-router";
import { Route as leagueRoute } from "@/routes/$mode/$leagueId";
import { formatRecordMetricForDisplay } from "@/utilities/utilities";

type Props = {
  recordKey: RecordCardFragment$key;
  titleDescription: string;
  footerText: string;
};

const RecordCardFragment = graphql`
  fragment RecordCardFragment on Record {
    metadata {
      recordTypeId
      displayName
      iconURI
    }
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
  }
`;

export function RecordCard({ recordKey, titleDescription, footerText }: Props) {
  const record = useFragment(RecordCardFragment, recordKey);

  const formattedValue = formatRecordMetricForDisplay(record.metric);

  return (
    <Card className="px-4 pt-2">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-3">
          <Avatar className="size-16">
            <AvatarImage
              src={record.metadata.iconURI}
              alt={record.metadata.displayName}
            />
            <AvatarFallback>
              <AvatarImage src="/record-icons/MostPoints.webp" />
            </AvatarFallback>
          </Avatar>
          <div>
            <CardTitle>{record.metadata.displayName}</CardTitle>
            <CardDescription>{titleDescription}</CardDescription>
          </div>
        </div>
        <Button variant={"link"} className="font-bold" asChild>
          <Link
            from={leagueRoute.fullPath}
            to={"/$mode/$leagueId/$recordTypeId"}
            params={{ recordTypeId: record.metadata.recordTypeId }}
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
