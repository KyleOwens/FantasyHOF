import { Button } from "@/components/ui/button";
import {
  Card,
  CardAction,
  CardContent,
  CardDescription,
  CardTitle,
} from "@/components/ui/card";
import { Avatar, AvatarImage } from "@radix-ui/react-avatar";
import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/")({
  component: Index,
});

function Index() {
  return (
    <Card className="max-w-sm px-4">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-2">
          <Avatar>
            <AvatarImage
              src="/PointsRecordWeek.png"
              alt="Most points"
              className="h-12 w-12"
            />
          </Avatar>
          <div>
            <CardTitle>Most points scored</CardTitle>
            <CardDescription>Week</CardDescription>
          </div>
        </div>
        <CardAction>
          <Button variant={"link"} className="font-bold">
            See more
          </Button>
        </CardAction>
      </div>
      <CardContent className="space-y-4">
        <p className="text-5xl font-semibold">269.9</p>
        <p className="text-muted-foreground font-medium">
          Week 12 of 2015 by Kory Seymor
        </p>
      </CardContent>
    </Card>
  );
}
