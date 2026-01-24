import { RecordTypeId } from "@/__generated__/RecordCardFragment.graphql";
import {
  RecordCategoryId,
  RecordTypeIdDetailsQuery,
} from "@/__generated__/RecordTypeIdDetailsQuery.graphql";
import { preloadQuery } from "@/relay/helpers";
import { createFileRoute } from "@tanstack/react-router";
import { graphql } from "relay-runtime";
import z from "zod";
import { usePreloadedQuery } from "react-relay";
import { RecordDetailsTable } from "@/components/record-details-tables/RecordDetailsTable";
import { RecordCategory } from "@/types/enums";
import { Spinner } from "@/components/ui/spinner";

const recordTypeParamsSchema = z.object({
  recordTypeId: z.custom<RecordTypeId>(),
});

export const Route = createFileRoute("/$mode/$leagueId/$recordTypeId")({
  component: RecordDetails,
  pendingComponent: () => <Spinner className="m-auto size-20 text-primary" />,
  params: {
    parse: (rawParams) => recordTypeParamsSchema.parse(rawParams),
    stringify: (params) => ({ recordTypeId: params.recordTypeId }),
  },
  loader: ({ params }) => {
    return preloadQuery<RecordTypeIdDetailsQuery>(recordDetailsQuery, {
      leagueId: params.leagueId,
      recordType: params.recordTypeId,
    });
  },
  onLeave: ({ loaderData }) => {
    loaderData?.dispose();
  },
});

const recordDetailsQuery = graphql`
  query RecordTypeIdDetailsQuery($leagueId: ID!, $recordType: RecordTypeId!) {
    league(leagueId: $leagueId) {
      recordDetails(recordType: $recordType) {
        metadata {
          displayName
          description
          iconURI
          category
        }
        ...RecordDetailsTableFragment
      }
    }
  }
`;

function RecordDetails() {
  const loaderData = Route.useLoaderData();
  const data = usePreloadedQuery<RecordTypeIdDetailsQuery>(
    recordDetailsQuery,
    loaderData,
  );

  const records = data.league.recordDetails;
  const subheader = getSubheaderDisplayText(
    data.league.recordDetails.metadata.category,
  );

  return (
    <div className=" w-full max-w-6xl mx-auto">
      <div className="flex flex-row gap-4">
        <div className="flex flex-col gap-4">
          <div>
            <h2 className="text-3xl font-semibold">
              {records.metadata.displayName}
            </h2>
            <span className="text-muted-foreground">{subheader}</span>
          </div>
          <p>{records.metadata.description}</p>
        </div>
      </div>
      <RecordDetailsTable recordDetailsKey={records} />
    </div>
  );
}

function getSubheaderDisplayText(category: RecordCategoryId) {
  switch (category) {
    case RecordCategory.LEAGUE:
      return "League history leaderboard";
    case RecordCategory.SEASON:
      return "Single season leaderboard";
    case RecordCategory.WEEK:
      return "Single week leaderboard";
    case RecordCategory.PLAYER:
      return "Player leaderboard";
  }
}
