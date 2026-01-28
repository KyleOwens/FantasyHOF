import { DemoRecordCard } from "@/components/league-dashboard/DemoRecordCard";
import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { SignInButton } from "@clerk/clerk-react";
import { createFileRoute, Link } from "@tanstack/react-router";
import {
  Award,
  BellElectric,
  CheckCircle2,
  FileText,
  MessageSquareQuote,
  Trophy,
} from "lucide-react";

export const Route = createFileRoute("/")({
  component: Index,
});

function Index() {
  return (
    <div className="flex flex-col bg-background mx-auto max-w-6xl w-full">
      <section className="px-6 py-12 overflow-hidden border-b">
        <div className="text-center">
          <Badge variant="outline" className="border-primary/50 text-primary">
            Beta Access Now Open
          </Badge>
          <h1 className="py-6 text-5xl md:text-7xl font-extrabold tracking-tighter bg-linear-to-b from-foreground to-muted-foreground bg-clip-text text-transparent">
            Weaponize Your <br /> League Data
          </h1>
          <p className="text-xl text-muted-foreground max-w-2xl mx-auto mb-10">
            Build your case with real numbers. Dig through league history to
            find the stats that settle debates fast.
          </p>
          <div className="flex flex-wrap justify-center gap-4">
            <SignInButton>
              <Button size="lg" className="px-8 font-bold w-44">
                Sign Up
              </Button>
            </SignInButton>
            <Button size="lg" variant="outline" className="px-8 w-44" asChild>
              <Link to={"/$mode"} params={{ mode: "demo" }}>
                View Demo Gallery
              </Link>
            </Button>
          </div>
        </div>
      </section>
      <section className="max-w-6xl mx-auto py-24 px-6">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
          {/* Feature 1: The Record Books */}
          <Card className="border">
            <CardHeader>
              <Trophy className="size-10 text-yellow-500 mb-2" />
              <CardTitle>The Record Books</CardTitle>
            </CardHeader>
            <CardContent className="text-muted-foreground">
              Instant access to all-time high scores, season-bests, weekly
              leaders, and most outstanding player performances. Finally prove
              who is the best.
            </CardContent>
          </Card>
          <Card className="border">
            <CardHeader>
              <Award className="size-10 text-destructive mb-2" />
              <CardTitle>The Wall of Shame</CardTitle>
            </CardHeader>
            <CardContent className="text-muted-foreground">
              Expose your league’s biggest disasters. The managers who score the
              least, lose the most, and somehow keep coming back for more.
            </CardContent>
          </Card>
          <Card className="border">
            <CardHeader>
              <BellElectric className="size-10 text-sky-500 mb-2" />
              <div className="flex flex-row items-center gap-4">
                <CardTitle>Head-to-Head Pulse</CardTitle>
                <Badge variant={"outline"}>Coming soon</Badge>
              </div>
            </CardHeader>
            <CardContent className="text-muted-foreground">
              Select any two managers and get their career head-to-head
              breakdown. The ultimate tool for pre-match taunting.
            </CardContent>
          </Card>
        </div>
      </section>
      <section className="bg-muted/30">
        <div className="max-w-6xl mx-auto px-6">
          <div className="flex flex-col md:flex-row gap-12 items-center pb-28">
            <div className="flex-1">
              <h2 className="text-3xl font-bold mb-6 flex items-center gap-2">
                <MessageSquareQuote className="text-primary" />
                Facts are better than insults.
              </h2>
              <div className="space-y-6">
                <div className="flex gap-4">
                  <div className="p-2 bg-background rounded-md border h-fit">
                    <Trophy className="size-5 text-yellow-500" />
                  </div>
                  <div>
                    <p className="font-semibold italic uppercase tracking-tight">
                      The Leaderboard
                    </p>
                    <p className="text-sm text-muted-foreground leading-relaxed">
                      Instant identification of current record holders across
                      all categories. Know exactly who holds the crown for High
                      Score, Most Points For, and All-Time Wins.
                    </p>
                  </div>
                </div>
                <div className="flex gap-4">
                  <div className="p-2 bg-background rounded-md border h-fit">
                    <FileText className="size-5 text-blue-500" />
                  </div>
                  <div>
                    <p className="font-semibold italic uppercase tracking-tight">
                      Chronological Receipts
                    </p>
                    <p className="text-sm text-muted-foreground leading-relaxed">
                      Drill down into any record to see every entry in league
                      history. Prove that a rival's "legendary" season was
                      actually just a mid-tier performance in the grander
                      archive.
                    </p>
                  </div>
                </div>
                <div className="flex gap-4">
                  <div className="p-2 bg-background rounded-md border h-fit">
                    <CheckCircle2 className="size-5 text-green-500" />
                  </div>
                  <div>
                    <p className="font-semibold italic uppercase tracking-tight">
                      Verified Milestones
                    </p>
                    <p className="text-sm text-muted-foreground leading-relaxed">
                      Eliminate "I think I remember" arguments. Every record
                      entry is backed by archived box scores from your
                      historical league data.
                    </p>
                  </div>
                </div>
              </div>
            </div>
            <DemoRecordCard />
          </div>
        </div>
      </section>
    </div>
  );
}
