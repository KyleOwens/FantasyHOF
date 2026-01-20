/**
 * @generated SignedSource<<d961da2594c612d603df378899a068ad>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type AppSidebarQuery$variables = {
  isDemo: boolean;
};
export type AppSidebarQuery$data = {
  readonly demoLeagues?: ReadonlyArray<{
    readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationFragment">;
  }>;
  readonly me?: {
    readonly id: string;
    readonly leagues: {
      readonly edges: ReadonlyArray<{
        readonly node: {
          readonly id: string;
          readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationFragment">;
        };
      }> | null | undefined;
    } | null | undefined;
  };
  readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationProviderFragment" | "RecordNavigationFragment">;
};
export type AppSidebarQuery = {
  response: AppSidebarQuery$data;
  variables: AppSidebarQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "isDemo"
  }
],
v1 = {
  "args": null,
  "kind": "FragmentSpread",
  "name": "LeagueNavigationFragment"
},
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v3 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "__typename",
  "storageKey": null
},
v4 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "cursor",
  "storageKey": null
},
v5 = {
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
},
v6 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "userId",
  "storageKey": null
},
v7 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "currentLeagueName",
  "storageKey": null
},
v8 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "logoURL",
  "storageKey": null
},
v9 = {
  "alias": null,
  "args": null,
  "concreteType": "FantasyProvider",
  "kind": "LinkedField",
  "name": "fantasyProvider",
  "plural": false,
  "selections": [
    (v2/*: any*/),
    (v8/*: any*/)
  ],
  "storageKey": null
},
v10 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "name",
  "storageKey": null
},
v11 = {
  "alias": null,
  "args": null,
  "concreteType": "Sport",
  "kind": "LinkedField",
  "name": "sport",
  "plural": false,
  "selections": [
    (v2/*: any*/),
    (v10/*: any*/)
  ],
  "storageKey": null
},
v12 = [
  {
    "kind": "Literal",
    "name": "first",
    "value": 10
  }
];
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "AppSidebarQuery",
    "selections": [
      {
        "args": null,
        "kind": "FragmentSpread",
        "name": "RecordNavigationFragment"
      },
      {
        "condition": "isDemo",
        "kind": "Condition",
        "passingValue": true,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "League",
            "kind": "LinkedField",
            "name": "demoLeagues",
            "plural": true,
            "selections": [
              (v1/*: any*/)
            ],
            "storageKey": null
          }
        ]
      },
      {
        "condition": "isDemo",
        "kind": "Condition",
        "passingValue": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "User",
            "kind": "LinkedField",
            "name": "me",
            "plural": false,
            "selections": [
              (v2/*: any*/),
              {
                "alias": "leagues",
                "args": null,
                "concreteType": "LeaguesConnection",
                "kind": "LinkedField",
                "name": "__my_leagues_connection",
                "plural": false,
                "selections": [
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "LeaguesEdge",
                    "kind": "LinkedField",
                    "name": "edges",
                    "plural": true,
                    "selections": [
                      {
                        "alias": null,
                        "args": null,
                        "concreteType": "League",
                        "kind": "LinkedField",
                        "name": "node",
                        "plural": false,
                        "selections": [
                          (v2/*: any*/),
                          (v1/*: any*/),
                          (v3/*: any*/)
                        ],
                        "storageKey": null
                      },
                      (v4/*: any*/)
                    ],
                    "storageKey": null
                  },
                  (v5/*: any*/)
                ],
                "storageKey": null
              }
            ],
            "storageKey": null
          }
        ]
      },
      {
        "args": null,
        "kind": "FragmentSpread",
        "name": "LeagueNavigationProviderFragment"
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "AppSidebarQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "RecordMetadata",
        "kind": "LinkedField",
        "name": "recordMetadata",
        "plural": true,
        "selections": [
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "recordTypeId",
            "storageKey": null
          },
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
            "name": "categoryDisplayName",
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "sentiment",
            "storageKey": null
          }
        ],
        "storageKey": null
      },
      {
        "condition": "isDemo",
        "kind": "Condition",
        "passingValue": true,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "League",
            "kind": "LinkedField",
            "name": "demoLeagues",
            "plural": true,
            "selections": [
              (v2/*: any*/),
              (v6/*: any*/),
              (v7/*: any*/),
              (v9/*: any*/),
              (v11/*: any*/)
            ],
            "storageKey": null
          }
        ]
      },
      {
        "condition": "isDemo",
        "kind": "Condition",
        "passingValue": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "User",
            "kind": "LinkedField",
            "name": "me",
            "plural": false,
            "selections": [
              (v2/*: any*/),
              {
                "alias": null,
                "args": (v12/*: any*/),
                "concreteType": "LeaguesConnection",
                "kind": "LinkedField",
                "name": "leagues",
                "plural": false,
                "selections": [
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "LeaguesEdge",
                    "kind": "LinkedField",
                    "name": "edges",
                    "plural": true,
                    "selections": [
                      {
                        "alias": null,
                        "args": null,
                        "concreteType": "League",
                        "kind": "LinkedField",
                        "name": "node",
                        "plural": false,
                        "selections": [
                          (v2/*: any*/),
                          (v6/*: any*/),
                          (v7/*: any*/),
                          (v9/*: any*/),
                          (v11/*: any*/),
                          (v3/*: any*/)
                        ],
                        "storageKey": null
                      },
                      (v4/*: any*/)
                    ],
                    "storageKey": null
                  },
                  (v5/*: any*/)
                ],
                "storageKey": "leagues(first:10)"
              },
              {
                "alias": null,
                "args": (v12/*: any*/),
                "filters": null,
                "handle": "connection",
                "key": "my_leagues",
                "kind": "LinkedHandle",
                "name": "leagues"
              }
            ],
            "storageKey": null
          }
        ]
      },
      {
        "alias": null,
        "args": null,
        "concreteType": "FantasyProvider",
        "kind": "LinkedField",
        "name": "fantasyProviders",
        "plural": true,
        "selections": [
          (v2/*: any*/),
          (v10/*: any*/),
          (v8/*: any*/),
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "value",
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "347ca7869ed57f35c9cb98ceff6a7383",
    "id": null,
    "metadata": {
      "connection": [
        {
          "count": null,
          "cursor": null,
          "direction": "forward",
          "path": [
            "me",
            "leagues"
          ]
        }
      ]
    },
    "name": "AppSidebarQuery",
    "operationKind": "query",
    "text": "query AppSidebarQuery(\n  $isDemo: Boolean!\n) {\n  ...RecordNavigationFragment\n  demoLeagues @include(if: $isDemo) {\n    ...LeagueNavigationFragment\n    id\n  }\n  me @skip(if: $isDemo) {\n    id\n    leagues(first: 10) {\n      edges {\n        node {\n          id\n          ...LeagueNavigationFragment\n          __typename\n        }\n        cursor\n      }\n      pageInfo {\n        endCursor\n        hasNextPage\n      }\n    }\n  }\n  ...LeagueNavigationProviderFragment\n}\n\nfragment LeagueNavigationFragment on League {\n  id\n  userId\n  currentLeagueName\n  fantasyProvider {\n    id\n    logoURL\n  }\n  sport {\n    id\n    name\n  }\n}\n\nfragment LeagueNavigationProviderFragment on Query {\n  fantasyProviders {\n    ...ProviderSelectionFragment\n    id\n  }\n}\n\nfragment ProviderSelectionFragment on FantasyProvider {\n  id\n  name\n  logoURL\n  value\n}\n\nfragment RecordNavigationFragment on Query {\n  recordMetadata {\n    recordTypeId\n    displayName\n    categoryDisplayName\n    sentiment\n  }\n}\n"
  }
};
})();

(node as any).hash = "279c708cc4942d52e2b84b885d286f27";

export default node;
