/**
 * @generated SignedSource<<476ee8aa6db32fe9c528ccbd11e924e9>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type RecordSentiment = "FAME" | "SHAME" | "%future added value";
export type LeagueDashboardQuery$variables = {
  leagueId: string;
};
export type LeagueDashboardQuery$data = {
  readonly league: {
    readonly currentLeagueName: string;
    readonly recordSummary: {
      readonly leagueRecords: ReadonlyArray<{
        readonly " $fragmentSpreads": FragmentRefs<"RecordSectionFragment">;
      }>;
      readonly playerRecords: ReadonlyArray<{
        readonly member: {
          readonly fullName: string;
        };
        readonly sentiment: RecordSentiment;
        readonly value: any;
        readonly week: number;
        readonly year: number;
        readonly " $fragmentSpreads": FragmentRefs<"RecordSectionFragment">;
      }>;
      readonly seasonalRecords: ReadonlyArray<{
        readonly " $fragmentSpreads": FragmentRefs<"RecordSectionFragment">;
      }>;
      readonly weeklyRecords: ReadonlyArray<{
        readonly " $fragmentSpreads": FragmentRefs<"RecordSectionFragment">;
      }>;
    } | null | undefined;
  };
};
export type LeagueDashboardQuery = {
  response: LeagueDashboardQuery$data;
  variables: LeagueDashboardQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "leagueId"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "id",
    "variableName": "leagueId"
  }
],
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "currentLeagueName",
  "storageKey": null
},
v3 = {
  "args": null,
  "kind": "FragmentSpread",
  "name": "RecordSectionFragment"
},
v4 = [
  (v3/*: any*/)
],
v5 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "value",
  "storageKey": null
},
v6 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "year",
  "storageKey": null
},
v7 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "week",
  "storageKey": null
},
v8 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "sentiment",
  "storageKey": null
},
v9 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "fullName",
  "storageKey": null
},
v10 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "__typename",
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
  "concreteType": "FantasyMember",
  "kind": "LinkedField",
  "name": "member",
  "plural": false,
  "selections": [
    (v11/*: any*/),
    (v9/*: any*/)
  ],
  "storageKey": null
},
v13 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "displayName",
  "storageKey": null
},
v14 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "iconURI",
  "storageKey": null
},
v15 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "metric",
  "storageKey": null
},
v16 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "isPercentage",
  "storageKey": null
},
v17 = {
  "kind": "InlineFragment",
  "selections": [
    (v13/*: any*/),
    (v14/*: any*/),
    (v15/*: any*/),
    (v16/*: any*/),
    (v5/*: any*/)
  ],
  "type": "Record",
  "abstractKey": "__isRecord"
},
v18 = [
  (v9/*: any*/),
  (v11/*: any*/)
],
v19 = {
  "alias": null,
  "args": null,
  "concreteType": "FantasyMember",
  "kind": "LinkedField",
  "name": "member",
  "plural": false,
  "selections": (v18/*: any*/),
  "storageKey": null
},
v20 = {
  "alias": null,
  "args": null,
  "concreteType": "Player",
  "kind": "LinkedField",
  "name": "player",
  "plural": false,
  "selections": (v18/*: any*/),
  "storageKey": null
},
v21 = [
  {
    "kind": "InlineFragment",
    "selections": [
      (v10/*: any*/),
      (v8/*: any*/),
      {
        "kind": "InlineFragment",
        "selections": [
          (v12/*: any*/),
          (v17/*: any*/)
        ],
        "type": "LeagueRecord",
        "abstractKey": null
      },
      {
        "kind": "InlineFragment",
        "selections": [
          (v6/*: any*/),
          (v12/*: any*/),
          (v17/*: any*/)
        ],
        "type": "SeasonalRecord",
        "abstractKey": null
      },
      {
        "kind": "InlineFragment",
        "selections": [
          (v6/*: any*/),
          (v7/*: any*/),
          (v12/*: any*/),
          (v17/*: any*/)
        ],
        "type": "WeeklyRecord",
        "abstractKey": null
      },
      {
        "kind": "InlineFragment",
        "selections": [
          (v6/*: any*/),
          (v7/*: any*/),
          (v19/*: any*/),
          (v20/*: any*/),
          (v17/*: any*/)
        ],
        "type": "PlayerRecord",
        "abstractKey": null
      }
    ],
    "type": "Record",
    "abstractKey": "__isRecord"
  }
],
v22 = {
  "kind": "InlineFragment",
  "selections": [
    (v13/*: any*/),
    (v14/*: any*/),
    (v15/*: any*/),
    (v16/*: any*/)
  ],
  "type": "Record",
  "abstractKey": "__isRecord"
},
v23 = [
  (v22/*: any*/)
];
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "LeagueDashboardQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "League",
        "kind": "LinkedField",
        "name": "league",
        "plural": false,
        "selections": [
          (v2/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "LeagueRecordSummary",
            "kind": "LinkedField",
            "name": "recordSummary",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueRecord",
                "kind": "LinkedField",
                "name": "leagueRecords",
                "plural": true,
                "selections": (v4/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "SeasonalRecord",
                "kind": "LinkedField",
                "name": "seasonalRecords",
                "plural": true,
                "selections": (v4/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "WeeklyRecord",
                "kind": "LinkedField",
                "name": "weeklyRecords",
                "plural": true,
                "selections": (v4/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "PlayerRecord",
                "kind": "LinkedField",
                "name": "playerRecords",
                "plural": true,
                "selections": [
                  (v3/*: any*/),
                  (v5/*: any*/),
                  (v6/*: any*/),
                  (v7/*: any*/),
                  (v8/*: any*/),
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "FantasyMember",
                    "kind": "LinkedField",
                    "name": "member",
                    "plural": false,
                    "selections": [
                      (v9/*: any*/)
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
    "name": "LeagueDashboardQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "League",
        "kind": "LinkedField",
        "name": "league",
        "plural": false,
        "selections": [
          (v2/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "LeagueRecordSummary",
            "kind": "LinkedField",
            "name": "recordSummary",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueRecord",
                "kind": "LinkedField",
                "name": "leagueRecords",
                "plural": true,
                "selections": (v21/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "SeasonalRecord",
                "kind": "LinkedField",
                "name": "seasonalRecords",
                "plural": true,
                "selections": (v21/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "WeeklyRecord",
                "kind": "LinkedField",
                "name": "weeklyRecords",
                "plural": true,
                "selections": (v21/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "PlayerRecord",
                "kind": "LinkedField",
                "name": "playerRecords",
                "plural": true,
                "selections": [
                  (v5/*: any*/),
                  (v6/*: any*/),
                  (v7/*: any*/),
                  (v8/*: any*/),
                  (v19/*: any*/),
                  {
                    "kind": "InlineFragment",
                    "selections": [
                      (v10/*: any*/),
                      {
                        "kind": "InlineFragment",
                        "selections": (v23/*: any*/),
                        "type": "LeagueRecord",
                        "abstractKey": null
                      },
                      {
                        "kind": "InlineFragment",
                        "selections": (v23/*: any*/),
                        "type": "SeasonalRecord",
                        "abstractKey": null
                      },
                      {
                        "kind": "InlineFragment",
                        "selections": (v23/*: any*/),
                        "type": "WeeklyRecord",
                        "abstractKey": null
                      },
                      {
                        "kind": "InlineFragment",
                        "selections": [
                          (v20/*: any*/),
                          (v22/*: any*/)
                        ],
                        "type": "PlayerRecord",
                        "abstractKey": null
                      }
                    ],
                    "type": "Record",
                    "abstractKey": "__isRecord"
                  }
                ],
                "storageKey": null
              }
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
    "cacheID": "eb60fc14c5b05bceeefe9cc1179f0a05",
    "id": null,
    "metadata": {},
    "name": "LeagueDashboardQuery",
    "operationKind": "query",
    "text": "query LeagueDashboardQuery(\n  $leagueId: ID!\n) {\n  league(id: $leagueId) {\n    currentLeagueName\n    recordSummary {\n      leagueRecords {\n        ...RecordSectionFragment\n      }\n      seasonalRecords {\n        ...RecordSectionFragment\n      }\n      weeklyRecords {\n        ...RecordSectionFragment\n      }\n      playerRecords {\n        ...RecordSectionFragment\n        value\n        year\n        week\n        sentiment\n        member {\n          fullName\n          id\n        }\n      }\n    }\n    id\n  }\n}\n\nfragment LeagueRecordCardFragment on LeagueRecord {\n  ...RecordCardFragment\n  member {\n    id\n    fullName\n  }\n}\n\nfragment PlayerRecordCardFragment on PlayerRecord {\n  year\n  week\n  member {\n    fullName\n    id\n  }\n  player {\n    fullName\n    id\n  }\n  ...RecordCardFragment\n}\n\nfragment RecordCardFragment on Record {\n  __isRecord: __typename\n  displayName\n  iconURI\n  metric\n  isPercentage\n  value\n}\n\nfragment RecordSectionFragment on Record {\n  __isRecord: __typename\n  __typename\n  sentiment\n  ... on LeagueRecord {\n    ...LeagueRecordCardFragment\n  }\n  ... on SeasonalRecord {\n    ...SeasonalRecordCardFragment\n  }\n  ... on WeeklyRecord {\n    ...WeeklyRecordCardFragment\n  }\n  ... on PlayerRecord {\n    ...PlayerRecordCardFragment\n  }\n}\n\nfragment SeasonalRecordCardFragment on SeasonalRecord {\n  ...RecordCardFragment\n  year\n  member {\n    id\n    fullName\n  }\n}\n\nfragment WeeklyRecordCardFragment on WeeklyRecord {\n  year\n  week\n  member {\n    id\n    fullName\n  }\n  ...RecordCardFragment\n}\n"
  }
};
})();

(node as any).hash = "db56d4bcba2eb1e918a79e4b98c624b4";

export default node;
