/**
 * @generated SignedSource<<4969915b09c802bf02e50b2169b9501a>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueDashboardQuery$variables = {
  leagueId: string;
};
export type LeagueDashboardQuery$data = {
  readonly league: {
    readonly currentLeagueName: string;
    readonly recordSummary: {
      readonly leagueRecords: ReadonlyArray<{
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      }>;
      readonly playerRecords: ReadonlyArray<{
        readonly member: {
          readonly fullName: string;
        };
        readonly value: any;
        readonly week: number;
        readonly year: number;
      }>;
      readonly seasonalRecords: ReadonlyArray<{
        readonly member: {
          readonly fullName: string;
        };
        readonly value: any;
        readonly year: number;
      }>;
      readonly weeklyRecords: ReadonlyArray<{
        readonly member: {
          readonly fullName: string;
        };
        readonly value: any;
        readonly week: number;
        readonly year: number;
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
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "value",
  "storageKey": null
},
v4 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "year",
  "storageKey": null
},
v5 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "fullName",
  "storageKey": null
},
v6 = {
  "alias": null,
  "args": null,
  "concreteType": "FantasyMember",
  "kind": "LinkedField",
  "name": "member",
  "plural": false,
  "selections": [
    (v5/*: any*/)
  ],
  "storageKey": null
},
v7 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "week",
  "storageKey": null
},
v8 = [
  (v3/*: any*/),
  (v4/*: any*/),
  (v7/*: any*/),
  (v6/*: any*/)
],
v9 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v10 = {
  "alias": null,
  "args": null,
  "concreteType": "FantasyMember",
  "kind": "LinkedField",
  "name": "member",
  "plural": false,
  "selections": [
    (v5/*: any*/),
    (v9/*: any*/)
  ],
  "storageKey": null
},
v11 = [
  (v3/*: any*/),
  (v4/*: any*/),
  (v7/*: any*/),
  (v10/*: any*/)
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
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leagueRecords",
                "plural": true,
                "selections": [
                  {
                    "args": null,
                    "kind": "FragmentSpread",
                    "name": "LeagueRecordCardFragment"
                  }
                ],
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "SeasonalValueRecord",
                "kind": "LinkedField",
                "name": "seasonalRecords",
                "plural": true,
                "selections": [
                  (v3/*: any*/),
                  (v4/*: any*/),
                  (v6/*: any*/)
                ],
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "WeeklyValueRecord",
                "kind": "LinkedField",
                "name": "weeklyRecords",
                "plural": true,
                "selections": (v8/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "PlayerValueRecord",
                "kind": "LinkedField",
                "name": "playerRecords",
                "plural": true,
                "selections": (v8/*: any*/),
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
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leagueRecords",
                "plural": true,
                "selections": [
                  (v3/*: any*/),
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "displayName",
                    "storageKey": null
                  },
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "iconURI",
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
                      (v9/*: any*/),
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "firstName",
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "lastName",
                        "storageKey": null
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
                "concreteType": "SeasonalValueRecord",
                "kind": "LinkedField",
                "name": "seasonalRecords",
                "plural": true,
                "selections": [
                  (v3/*: any*/),
                  (v4/*: any*/),
                  (v10/*: any*/)
                ],
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "WeeklyValueRecord",
                "kind": "LinkedField",
                "name": "weeklyRecords",
                "plural": true,
                "selections": (v11/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "PlayerValueRecord",
                "kind": "LinkedField",
                "name": "playerRecords",
                "plural": true,
                "selections": (v11/*: any*/),
                "storageKey": null
              }
            ],
            "storageKey": null
          },
          (v9/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "43d899f75591389faf2af77b3002ed86",
    "id": null,
    "metadata": {},
    "name": "LeagueDashboardQuery",
    "operationKind": "query",
    "text": "query LeagueDashboardQuery(\n  $leagueId: ID!\n) {\n  league(id: $leagueId) {\n    currentLeagueName\n    recordSummary {\n      leagueRecords {\n        ...LeagueRecordCardFragment\n      }\n      seasonalRecords {\n        value\n        year\n        member {\n          fullName\n          id\n        }\n      }\n      weeklyRecords {\n        value\n        year\n        week\n        member {\n          fullName\n          id\n        }\n      }\n      playerRecords {\n        value\n        year\n        week\n        member {\n          fullName\n          id\n        }\n      }\n    }\n    id\n  }\n}\n\nfragment LeagueRecordCardFragment on LeagueValueRecord {\n  value\n  displayName\n  iconURI\n  member {\n    id\n    firstName\n    lastName\n  }\n}\n"
  }
};
})();

(node as any).hash = "2204a298774ce141f7dc126279664281";

export default node;
