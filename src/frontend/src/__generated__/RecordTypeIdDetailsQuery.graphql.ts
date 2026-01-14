/**
 * @generated SignedSource<<3b70179a26f3bd00de53fbf46d731d6d>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type RecordMetricId = "BLOWOUT_LOSSES" | "BLOWOUT_WINS" | "BOTTOM_WEEKS" | "BOTTOM_WEEK_PERCENTAGE" | "CHAMPIONSHIPS" | "CHAMPIONSHIP_PERCENTAGE" | "LAST_PLACES" | "LAST_PLACE_PERCENTAGE" | "LOSING_SEASONS" | "LOSING_SEASON_PERCENTAGE" | "LOSSES" | "LOSS_MARGIN" | "LOSS_SCORE" | "NARROW_LOSSES" | "NARROW_WINS" | "OUTSTANDING_PERFORMANCES" | "PLAYOFF_SCORE" | "PLAYOFF_VICTORY_SCORE_MARGIN" | "POINTS_AGAINST" | "POINTS_AGAINST_AVERAGE" | "POINTS_FOR" | "POINTS_FOR_AVERAGE" | "POINTS_SCORED" | "POINTS_SCORED_NON_DST" | "POINTS_SCORED_NON_QB" | "POOR_PERFORMANCES" | "SCORE" | "SEASONS" | "TOP_WEEKS" | "TOP_WEEK_PERCENTAGE" | "VICTORY_SCORE_MARGIN" | "WEEKS" | "WINNING_SEASONS" | "WINNING_SEASON_PERCENTAGE" | "WINS" | "WIN_MARGIN" | "WIN_PERCENTAGE" | "WIN_SCORE" | "%future added value";
export type RecordTypeId = "HIGHEST_CHAMPIONSHIP_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_LAST_PLACE_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_LOSING_RECORD_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_PERCENTAGE_LOWEST_WEEKLY_SCORES_LEAGUE_HISTORY" | "HIGHEST_PERCENTAGE_TOP_WEEKLY_SCORES_LEAGUE_HISTORY" | "HIGHEST_SCORING_LOSS_SINGLE_WEEK" | "HIGHEST_WINNING_RECORD_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_WIN_PERCENTAGE_LEAGUE_HISTORY" | "LARGEST_MARGIN_OF_VICTORY_SINGLE_PLAYOFF_WEEK" | "LARGEST_MARGIN_OF_VICTORY_SINGLE_WEEK" | "LEAST_AVERAGE_POINTS_ALLOWED_PER_WEEK_LEAGUE_HISTORY" | "LEAST_AVERAGE_POINTS_PER_WEEK_LEAGUE_HISTORY" | "LEAST_LOSSES_LEAGUE_HISTORY" | "LEAST_POINTS_ALLOWED_LEAGUE_HISTORY" | "LEAST_POINTS_ALLOWED_PER_WEEK_SINGLE_SEASON" | "LEAST_POINTS_ALLOWED_SINGLE_SEASON" | "LEAST_POINTS_LEAGUE_HISTORY" | "LEAST_POINTS_PER_WEEK_SINGLE_SEASON" | "LEAST_POINTS_SCORED_SINGLE_NON_DEFENSE_PLAYER" | "LEAST_POINTS_SCORED_SINGLE_PLAYER" | "LEAST_POINTS_SINGLE_PLAYOFF_WEEK" | "LEAST_POINTS_SINGLE_SEASON" | "LEAST_POINTS_SINGLE_WEEK" | "LEAST_WINS_LEAGUE_HISTORY" | "LOWEST_MARGIN_OF_VICTORY_SINGLE_PLAYOFF_WEEK" | "LOWEST_MARGIN_OF_VICTORY_SINGLE_WEEK" | "LOWEST_SCORING_WIN_SINGLE_WEEK" | "LOWEST_WIN_PERCENTAGE_LEAGUE_HISTORY" | "MOST_AVERAGE_POINTS_ALLOWED_PER_WEEK_LEAGUE_HISTORY" | "MOST_AVERAGE_POINTS_PER_WEEK_LEAGUE_HISTORY" | "MOST_BLOWOUT_LOSSES_LEAGUE_HISTORY" | "MOST_BLOWOUT_LOSSES_SINGLE_SEASON" | "MOST_BLOWOUT_WINS_LEAGUE_HISTORY" | "MOST_BLOWOUT_WINS_SINGLE_SEASON" | "MOST_CHAMPIONSHIPS_LEAGUE_HISTORY" | "MOST_HIGHEST_SCORING_WEEKS_SINGLE_SEASON" | "MOST_LAST_PLACES_LEAGUE_HISTORY" | "MOST_LOSSES_LEAGUE_HISTORY" | "MOST_LOSSES_SINGLE_SEASON" | "MOST_LOWEST_SCORING_WEEKS_SINGLE_SEASON" | "MOST_LOWEST_WEEKLY_SCORES_LEAGUE_HISTORY" | "MOST_NARROW_LOSSES_LEAGUE_HISTORY" | "MOST_NARROW_LOSSES_SINGLE_SEASON" | "MOST_NARROW_WINS_LEAGUE_HISTORY" | "MOST_NARROW_WINS_SINGLE_SEASON" | "MOST_OUTSTANDING_PERFORMANCES_LEAGUE_HISTORY" | "MOST_OUTSTANDING_PERFORMANCES_SINGLE_SEASON" | "MOST_POINTS_ALLOWED_LEAGUE_HISTORY" | "MOST_POINTS_ALLOWED_PER_WEEK_SINGLE_SEASON" | "MOST_POINTS_ALLOWED_SINGLE_SEASON" | "MOST_POINTS_LEAGUE_HISTORY" | "MOST_POINTS_PER_WEEK_SINGLE_SEASON" | "MOST_POINTS_SCORED_SINGLE_NON_QB_PLAYER" | "MOST_POINTS_SCORED_SINGLE_PLAYER" | "MOST_POINTS_SINGLE_PLAYOFF_WEEK" | "MOST_POINTS_SINGLE_SEASON" | "MOST_POINTS_SINGLE_WEEK" | "MOST_POOR_PERFORMANCES_LEAGUE_HISTORY" | "MOST_POOR_PERFORMANCES_SINGLE_SEASON" | "MOST_SEASONS_LOSING_RECORD_LEAGUE_HISTORY" | "MOST_SEASONS_WINNING_RECORD_LEAGUE_HISTORY" | "MOST_TOP_WEEKLY_SCORES_LEAGUE_HISTORY" | "MOST_WINS_LEAGUE_HISTORY" | "MOST_WINS_SINGLE_SEASON" | "%future added value";
export type RecordTypeIdDetailsQuery$variables = {
  leagueId: string;
  recordType: RecordTypeId;
};
export type RecordTypeIdDetailsQuery$data = {
  readonly me: {
    readonly league: {
      readonly recordDetails: ReadonlyArray<{
        readonly key: string;
        readonly memberDetails?: {
          readonly firstyear: number;
          readonly id: string;
          readonly lastYear: number;
          readonly member: {
            readonly fullName: string;
            readonly id: string;
          };
          readonly tenure: number;
        };
        readonly metric: {
          readonly metricId: RecordMetricId;
          readonly unit: string;
          readonly value: any;
        };
      }>;
    };
  };
};
export type RecordTypeIdDetailsQuery = {
  response: RecordTypeIdDetailsQuery$data;
  variables: RecordTypeIdDetailsQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "leagueId"
  },
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "recordType"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "leagueId",
    "variableName": "leagueId"
  }
],
v2 = [
  {
    "kind": "Variable",
    "name": "recordType",
    "variableName": "recordType"
  }
],
v3 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "key",
  "storageKey": null
},
v4 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "metricId",
  "storageKey": null
},
v5 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "unit",
  "storageKey": null
},
v6 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "value",
  "storageKey": null
},
v7 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v8 = {
  "kind": "InlineFragment",
  "selections": [
    {
      "alias": null,
      "args": null,
      "concreteType": "LeagueMember",
      "kind": "LinkedField",
      "name": "memberDetails",
      "plural": false,
      "selections": [
        (v7/*: any*/),
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "firstyear",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "lastYear",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "tenure",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "concreteType": "FantasyMember",
          "kind": "LinkedField",
          "name": "member",
          "plural": false,
          "selections": [
            (v7/*: any*/),
            {
              "alias": null,
              "args": null,
              "kind": "ScalarField",
              "name": "fullName",
              "storageKey": null
            }
          ],
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "LeagueRecordDetails",
  "abstractKey": null
},
v9 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "__typename",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "RecordTypeIdDetailsQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "User",
        "kind": "LinkedField",
        "name": "me",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": (v1/*: any*/),
            "concreteType": "League",
            "kind": "LinkedField",
            "name": "league",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": (v2/*: any*/),
                "concreteType": null,
                "kind": "LinkedField",
                "name": "recordDetails",
                "plural": true,
                "selections": [
                  (v3/*: any*/),
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": null,
                    "kind": "LinkedField",
                    "name": "metric",
                    "plural": false,
                    "selections": [
                      (v4/*: any*/),
                      (v5/*: any*/),
                      (v6/*: any*/)
                    ],
                    "storageKey": null
                  },
                  (v8/*: any*/)
                ],
                "storageKey": null
              }
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "RecordTypeIdDetailsQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "User",
        "kind": "LinkedField",
        "name": "me",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": (v1/*: any*/),
            "concreteType": "League",
            "kind": "LinkedField",
            "name": "league",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": (v2/*: any*/),
                "concreteType": null,
                "kind": "LinkedField",
                "name": "recordDetails",
                "plural": true,
                "selections": [
                  (v9/*: any*/),
                  (v3/*: any*/),
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": null,
                    "kind": "LinkedField",
                    "name": "metric",
                    "plural": false,
                    "selections": [
                      (v9/*: any*/),
                      (v4/*: any*/),
                      (v5/*: any*/),
                      (v6/*: any*/)
                    ],
                    "storageKey": null
                  },
                  (v8/*: any*/)
                ],
                "storageKey": null
              },
              (v7/*: any*/)
            ],
            "storageKey": null
          },
          (v7/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "e8ad5e28c886feb6011bd752e82a5af4",
    "id": null,
    "metadata": {},
    "name": "RecordTypeIdDetailsQuery",
    "operationKind": "query",
    "text": "query RecordTypeIdDetailsQuery(\n  $leagueId: ID!\n  $recordType: RecordTypeId!\n) {\n  me {\n    league(leagueId: $leagueId) {\n      recordDetails(recordType: $recordType) {\n        __typename\n        key\n        metric {\n          __typename\n          metricId\n          unit\n          value\n        }\n        ... on LeagueRecordDetails {\n          memberDetails {\n            id\n            firstyear\n            lastYear\n            tenure\n            member {\n              id\n              fullName\n            }\n          }\n        }\n      }\n      id\n    }\n    id\n  }\n}\n"
  }
};
})();

(node as any).hash = "67e4d43d83d4a1a99c0213cd3b98c5e3";

export default node;
