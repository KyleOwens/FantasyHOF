import { RecordTypeId } from "@/__generated__/RecordCardFragment.graphql";
import { RecordTypeIdDetailsQuery } from "@/__generated__/RecordTypeIdDetailsQuery.graphql";
import { preloadQuery } from "@/relay/helpers";
import { createFileRoute } from "@tanstack/react-router";
import { graphql } from "relay-runtime";
import z from "zod";
import { usePreloadedQuery } from "react-relay";

const recordTypeParamsSchema = z.object({
  recordTypeId: z.custom<RecordTypeId>(),
});

export const Route = createFileRoute("/$mode/$leagueId/$recordTypeId")({
  component: RecordDetails,
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
    me {
      league(leagueId: $leagueId) {
        recordDetails(recordType: $recordType) {
          key
          __typename
          rank
          recordType {
            id
            name
          }
          metric {
            metricId
            unit
            value
          }
          ... on LeagueRecordDetails {
            memberDetails {
              id
              firstyear
              lastYear
              tenure
              member {
                id
                fullName
              }
            }
          }
        }
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

  const records = data.me.league.recordDetails;

  if (records.length === 0) return;

  return (
    <div>
      <h2 className="text-3xl font-semibold">
        {records.at(0)!.recordType.name}
      </h2>
      <span className="text-muted-foreground">League history leaderboard</span>
    </div>
  );
}
