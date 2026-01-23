import { User } from "lucide-react";
import { Avatar, AvatarFallback, AvatarImage } from "../ui/avatar";
import { Card, CardContent, CardDescription, CardTitle } from "../ui/card";

export function DemoRecordCard() {
  return (
    <Card className="px-4 pt-2 w-md">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-3">
          <Avatar className="size-16">
            <AvatarImage
              src={"/record-icons/MostPointsPlayer.webp"}
              alt={"Most points single player"}
            />
            <AvatarFallback>
              <User />
            </AvatarFallback>
          </Avatar>
          <div>
            <CardTitle>Most points</CardTitle>
            <CardDescription>Single player in a week</CardDescription>
          </div>
        </div>
        <p className="font-bold text-primary text-sm pr-2">See more</p>
      </div>
      <CardContent className="px-2 space-y-4 -mt-4">
        <div className="space-x-2">
          <span className="text-4xl font-bold">{58.2}</span>
          <span className="text-lg">points</span>
        </div>
        <p className="text-muted-foreground">
          By Alvin Kamara in week 16 of 2020
        </p>
      </CardContent>
    </Card>
  );
}
