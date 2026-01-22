/**
 * @generated SignedSource<<d7abf5931efa3f3f08f2c4b15de5dc62>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type RecordCategoryId = "LEAGUE" | "PLAYER" | "SEASON" | "WEEK" | "%future added value";
export type RecordTypeId = "HIGHEST_CHAMPIONSHIP_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_LAST_PLACE_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_LOSING_RECORD_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_PERCENTAGE_LOWEST_WEEKLY_SCORES_LEAGUE_HISTORY" | "HIGHEST_PERCENTAGE_TOP_WEEKLY_SCORES_LEAGUE_HISTORY" | "HIGHEST_SCORING_LOSS_SINGLE_WEEK" | "HIGHEST_WINNING_RECORD_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_WIN_PERCENTAGE_LEAGUE_HISTORY" | "LARGEST_MARGIN_OF_VICTORY_SINGLE_PLAYOFF_WEEK" | "LARGEST_MARGIN_OF_VICTORY_SINGLE_WEEK" | "LEAST_AVERAGE_POINTS_ALLOWED_PER_WEEK_LEAGUE_HISTORY" | "LEAST_AVERAGE_POINTS_PER_WEEK_LEAGUE_HISTORY" | "LEAST_LOSSES_LEAGUE_HISTORY" | "LEAST_POINTS_ALLOWED_LEAGUE_HISTORY" | "LEAST_POINTS_ALLOWED_PER_WEEK_SINGLE_SEASON" | "LEAST_POINTS_ALLOWED_SINGLE_SEASON" | "LEAST_POINTS_LEAGUE_HISTORY" | "LEAST_POINTS_PER_WEEK_SINGLE_SEASON" | "LEAST_POINTS_SCORED_SINGLE_NON_DEFENSE_PLAYER" | "LEAST_POINTS_SCORED_SINGLE_PLAYER" | "LEAST_POINTS_SINGLE_PLAYOFF_WEEK" | "LEAST_POINTS_SINGLE_SEASON" | "LEAST_POINTS_SINGLE_WEEK" | "LEAST_WINS_LEAGUE_HISTORY" | "LOWEST_MARGIN_OF_VICTORY_SINGLE_PLAYOFF_WEEK" | "LOWEST_MARGIN_OF_VICTORY_SINGLE_WEEK" | "LOWEST_SCORING_WIN_SINGLE_WEEK" | "LOWEST_WIN_PERCENTAGE_LEAGUE_HISTORY" | "MOST_AVERAGE_POINTS_ALLOWED_PER_WEEK_LEAGUE_HISTORY" | "MOST_AVERAGE_POINTS_PER_WEEK_LEAGUE_HISTORY" | "MOST_BLOWOUT_LOSSES_LEAGUE_HISTORY" | "MOST_BLOWOUT_LOSSES_SINGLE_SEASON" | "MOST_BLOWOUT_WINS_LEAGUE_HISTORY" | "MOST_BLOWOUT_WINS_SINGLE_SEASON" | "MOST_CHAMPIONSHIPS_LEAGUE_HISTORY" | "MOST_HIGHEST_SCORING_WEEKS_SINGLE_SEASON" | "MOST_LAST_PLACES_LEAGUE_HISTORY" | "MOST_LOSSES_LEAGUE_HISTORY" | "MOST_LOSSES_SINGLE_SEASON" | "MOST_LOWEST_SCORING_WEEKS_SINGLE_SEASON" | "MOST_LOWEST_WEEKLY_SCORES_LEAGUE_HISTORY" | "MOST_NARROW_LOSSES_LEAGUE_HISTORY" | "MOST_NARROW_LOSSES_SINGLE_SEASON" | "MOST_NARROW_WINS_LEAGUE_HISTORY" | "MOST_NARROW_WINS_SINGLE_SEASON" | "MOST_OUTSTANDING_PERFORMANCES_LEAGUE_HISTORY" | "MOST_OUTSTANDING_PERFORMANCES_SINGLE_SEASON" | "MOST_POINTS_ALLOWED_LEAGUE_HISTORY" | "MOST_POINTS_ALLOWED_PER_WEEK_SINGLE_SEASON" | "MOST_POINTS_ALLOWED_SINGLE_SEASON" | "MOST_POINTS_LEAGUE_HISTORY" | "MOST_POINTS_PER_WEEK_SINGLE_SEASON" | "MOST_POINTS_SCORED_SINGLE_NON_QB_PLAYER" | "MOST_POINTS_SCORED_SINGLE_PLAYER" | "MOST_POINTS_SINGLE_PLAYOFF_WEEK" | "MOST_POINTS_SINGLE_SEASON" | "MOST_POINTS_SINGLE_WEEK" | "MOST_POOR_PERFORMANCES_LEAGUE_HISTORY" | "MOST_POOR_PERFORMANCES_SINGLE_SEASON" | "MOST_SEASONS_LOSING_RECORD_LEAGUE_HISTORY" | "MOST_SEASONS_WINNING_RECORD_LEAGUE_HISTORY" | "MOST_TOP_WEEKLY_SCORES_LEAGUE_HISTORY" | "MOST_WINS_LEAGUE_HISTORY" | "MOST_WINS_SINGLE_SEASON" | "%future added value";
export type RecordTypeIdDetailsQuery$variables = {
  leagueId: string;
  recordType: RecordTypeId;
};
export type RecordTypeIdDetailsQuery$data = {
  readonly league: {
    readonly recordDetails: {
      readonly metadata: {
        readonly category: RecordCategoryId;
        readonly description: string;
        readonly displayName: string;
        readonly iconURI: string;
      };
      readonly " $fragmentSpreads": FragmentRefs<"RecordDetailsTableFragment">;
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
  "name": "displayName",
  "storageKey": null
},
v4 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "description",
  "storageKey": null
},
v5 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "iconURI",
  "storageKey": null
},
v6 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "category",
  "storageKey": null
},
v7 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "unit",
  "storageKey": null
},
v8 = [
  {
    "kind": "Literal",
    "name": "first",
    "value": 20
  }
],
v9 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "__typename",
  "storageKey": null
},
v10 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "value",
  "storageKey": null
},
v11 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v12 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "fullName",
  "storageKey": null
},
v13 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "year",
  "storageKey": null
},
v14 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "week",
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
        "args": (v1/*: any*/),
        "concreteType": "League",
        "kind": "LinkedField",
        "name": "league",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": (v2/*: any*/),
            "concreteType": "RecordDetails",
            "kind": "LinkedField",
            "name": "recordDetails",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "RecordMetadata",
                "kind": "LinkedField",
                "name": "metadata",
                "plural": false,
                "selections": [
                  (v3/*: any*/),
                  (v4/*: any*/),
                  (v5/*: any*/),
                  (v6/*: any*/)
                ],
                "storageKey": null
              },
              {
                "args": null,
                "kind": "FragmentSpread",
                "name": "RecordDetailsTableFragment"
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
        "args": (v1/*: any*/),
        "concreteType": "League",
        "kind": "LinkedField",
        "name": "league",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": (v2/*: any*/),
            "concreteType": "RecordDetails",
            "kind": "LinkedField",
            "name": "recordDetails",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "RecordMetadata",
                "kind": "LinkedField",
                "name": "metadata",
                "plural": false,
                "selections": [
                  (v3/*: any*/),
                  (v4/*: any*/),
                  (v5/*: any*/),
                  (v6/*: any*/),
                  (v7/*: any*/),
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "metricType",
                    "storageKey": null
                  }
                ],
                "storageKey": null
              },
              {
                "alias": null,
                "args": (v8/*: any*/),
                "concreteType": "EntriesConnection",
                "kind": "LinkedField",
                "name": "entries",
                "plural": false,
                "selections": [
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "EntriesEdge",
                    "kind": "LinkedField",
                    "name": "edges",
                    "plural": true,
                    "selections": [
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "cursor",
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "concreteType": null,
                        "kind": "LinkedField",
                        "name": "node",
                        "plural": false,
                        "selections": [
                          {
                            "alias": null,
                            "args": null,
                            "kind": "ScalarField",
                            "name": "key",
                            "storageKey": null
                          },
                          {
                            "alias": null,
                            "args": null,
                            "kind": "ScalarField",
                            "name": "rank",
                            "storageKey": null
                          },
                          {
                            "alias": null,
                            "args": null,
                            "concreteType": null,
                            "kind": "LinkedField",
                            "name": "metric",
                            "plural": false,
                            "selections": [
                              (v9/*: any*/),
                              (v10/*: any*/),
                              (v7/*: any*/),
                              {
                                "kind": "InlineFragment",
                                "selections": [
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "numerator",
                                    "storageKey": null
                                  },
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "numeratorUnit",
                                    "storageKey": null
                                  },
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "denominator",
                                    "storageKey": null
                                  },
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "denominatorUnit",
                                    "storageKey": null
                                  }
                                ],
                                "type": "RatioRecordMetric",
                                "abstractKey": null
                              }
                            ],
                            "storageKey": null
                          },
                          (v9/*: any*/),
                          {
                            "kind": "TypeDiscriminator",
                            "abstractKey": "__isRecordEntry"
                          },
                          {
                            "alias": null,
                            "args": null,
                            "concreteType": "LeagueMember",
                            "kind": "LinkedField",
                            "name": "memberDetails",
                            "plural": false,
                            "selections": [
                              (v11/*: any*/),
                              {
                                "alias": null,
                                "args": null,
                                "kind": "ScalarField",
                                "name": "currentTeamName",
                                "storageKey": null
                              },
                              {
                                "alias": null,
                                "args": null,
                                "kind": "ScalarField",
                                "name": "currentTeamLogoURL",
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
                                  (v12/*: any*/),
                                  (v11/*: any*/)
                                ],
                                "storageKey": null
                              },
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
                              }
                            ],
                            "storageKey": null
                          },
                          {
                            "kind": "InlineFragment",
                            "selections": [
                              (v13/*: any*/)
                            ],
                            "type": "SeasonalRecordEntry",
                            "abstractKey": null
                          },
                          {
                            "kind": "InlineFragment",
                            "selections": [
                              (v13/*: any*/),
                              (v14/*: any*/)
                            ],
                            "type": "WeeklyRecordEntry",
                            "abstractKey": null
                          },
                          {
                            "kind": "InlineFragment",
                            "selections": [
                              (v13/*: any*/),
                              (v14/*: any*/),
                              {
                                "alias": null,
                                "args": null,
                                "concreteType": "Player",
                                "kind": "LinkedField",
                                "name": "player",
                                "plural": false,
                                "selections": [
                                  (v12/*: any*/),
                                  (v11/*: any*/),
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "playerImageURL",
                                    "storageKey": null
                                  }
                                ],
                                "storageKey": null
                              },
                              {
                                "alias": null,
                                "args": null,
                                "concreteType": "Position",
                                "kind": "LinkedField",
                                "name": "position",
                                "plural": false,
                                "selections": [
                                  (v11/*: any*/),
                                  (v10/*: any*/),
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "name",
                                    "storageKey": null
                                  }
                                ],
                                "storageKey": null
                              }
                            ],
                            "type": "PlayerRecordEntry",
                            "abstractKey": null
                          }
                        ],
                        "storageKey": null
                      }
                    ],
                    "storageKey": null
                  },
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "PageInfo",
                    "kind": "LinkedField",
                    "name": "pageInfo",
                    "plural": false,
                    "selections": [
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "endCursor",
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "hasNextPage",
                        "storageKey": null
                      }
                    ],
                    "storageKey": null
                  }
                ],
                "storageKey": "entries(first:20)"
              },
              {
                "alias": null,
                "args": (v8/*: any*/),
                "filters": null,
                "handle": "connection",
                "key": "recordDetails_entries",
                "kind": "LinkedHandle",
                "name": "entries"
              },
              (v11/*: any*/)
            ],
            "storageKey": null
          },
          (v11/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "c9e716a05675742298bcbc9be8cf82c5",
    "id": null,
    "metadata": {},
    "name": "RecordTypeIdDetailsQuery",
    "operationKind": "query",
    "text": "query RecordTypeIdDetailsQuery(\n  $leagueId: ID!\n  $recordType: RecordTypeId!\n) {\n  league(leagueId: $leagueId) {\n    recordDetails(recordType: $recordType) {\n      metadata {\n        displayName\n        description\n        iconURI\n        category\n      }\n      ...RecordDetailsTableFragment\n      id\n    }\n    id\n  }\n}\n\nfragment MemberCellFragment on RecordEntry {\n  __isRecordEntry: __typename\n  memberDetails {\n    id\n    currentTeamName\n    currentTeamLogoURL\n    member {\n      fullName\n      id\n    }\n  }\n}\n\nfragment MemberTenureCellFragment on RecordEntry {\n  __isRecordEntry: __typename\n  memberDetails {\n    firstyear\n    lastYear\n    tenure\n    id\n  }\n}\n\nfragment PlayerCellFragment on RecordEntry {\n  __isRecordEntry: __typename\n  ... on PlayerRecordEntry {\n    position {\n      id\n      value\n      name\n    }\n    player {\n      fullName\n      playerImageURL\n      id\n    }\n  }\n}\n\nfragment RatioBreakdownCellFragment on RecordEntry {\n  __isRecordEntry: __typename\n  metric {\n    __typename\n    ... on RatioRecordMetric {\n      numerator\n      numeratorUnit\n      denominator\n      denominatorUnit\n    }\n  }\n}\n\nfragment RecordDetailsTableFragment on RecordDetails {\n  metadata {\n    unit\n    category\n    metricType\n  }\n  ...RecordDetailsTableRefetchableEntryFragment\n}\n\nfragment RecordDetailsTableRefetchableEntryFragment on RecordDetails {\n  entries(first: 20) {\n    edges {\n      cursor\n      node {\n        key\n        rank\n        metric {\n          __typename\n          value\n          unit\n          ... on RatioRecordMetric {\n            numerator\n            numeratorUnit\n            denominator\n            denominatorUnit\n          }\n        }\n        __typename\n        ... on SeasonalRecordEntry {\n          year\n        }\n        ... on WeeklyRecordEntry {\n          year\n          week\n        }\n        ... on PlayerRecordEntry {\n          year\n          week\n          player {\n            fullName\n            id\n          }\n        }\n        ...RecordValueCellFragment\n        ...MemberCellFragment\n        ...MemberTenureCellFragment\n        ...RatioBreakdownCellFragment\n        ...PlayerCellFragment\n      }\n    }\n    pageInfo {\n      endCursor\n      hasNextPage\n    }\n  }\n  id\n}\n\nfragment RecordValueCellFragment on RecordEntry {\n  __isRecordEntry: __typename\n  metric {\n    __typename\n    value\n    unit\n    ... on RatioRecordMetric {\n      __typename\n      numerator\n      denominator\n    }\n  }\n}\n"
  }
};
})();

(node as any).hash = "c7d06cb28540fbc3e14fc43d6c5d1b54";

export default node;
