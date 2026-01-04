import { graphql } from "relay-runtime";
import { Avatar, AvatarImage } from "./ui/avatar";
import { Button } from "./ui/button";
import {
  Card,
  CardAction,
  CardContent,
  CardDescription,
  CardTitle,
} from "./ui/card";
import { LeagueRecordCardFragment$key } from "@/__generated__/LeagueRecordCardFragment.graphql";
import { useFragment } from "react-relay";

type Props = {
  recordKey: LeagueRecordCardFragment$key;
  title: string;
  isPercentage?: boolean;
};

const LeagueRecordCardFragment = graphql`
  fragment LeagueRecordCardFragment on LeagueValueRecord {
    value
    member {
      id
      firstName
      lastName
    }
  }
`;

export function LeagueRecordCard({ recordKey, title, isPercentage }: Props) {
  const record = useFragment(LeagueRecordCardFragment, recordKey);

  const roundedValue = parseFloat(record.value.toFixed(2));
  const formattedValue = isPercentage
    ? new Intl.NumberFormat("en-US", { style: "percent" }).format(roundedValue)
    : roundedValue;

  return (
    <Card className="px-4 pt-2">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-3">
          <Avatar className="size-20">
            <AvatarImage
              src="/record-icons/MostPointsLeague.png"
              alt="Most points"
            />
          </Avatar>
          <div>
            <CardTitle>{title}</CardTitle>
            <CardDescription>League history</CardDescription>
          </div>
        </div>
        <Button variant={"link"} className="font-bold">
          See more
        </Button>
      </div>
      <CardContent className="space-y-4 -mt-4">
        <p className="text-4xl font-bold">{formattedValue}</p>
        <p className="text-muted-foreground font-medium">
          {record.member.firstName + " " + record.member.lastName}
        </p>
      </CardContent>
    </Card>
  );
}
