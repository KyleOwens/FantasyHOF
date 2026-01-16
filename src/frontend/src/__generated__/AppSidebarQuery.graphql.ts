/**
 * @generated SignedSource<<88d6531500df280c445fe126ca47afe1>>
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
    readonly leagues: {
      readonly edges: ReadonlyArray<{
        readonly node: {
          readonly id: string;
          readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationFragment">;
        };
      }> | null | undefined;
    } | null | undefined;
  };
  readonly " $fragmentSpreads": FragmentRefs<"RecordNavigationFragment">;
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
  "name": "currentLeagueName",
  "storageKey": null
},
v7 = {
  "alias": null,
  "args": null,
  "concreteType": "FantasyProvider",
  "kind": "LinkedField",
  "name": "fantasyProvider",
  "plural": false,
  "selections": [
    (v2/*: any*/),
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "logoURL",
      "storageKey": null
    }
  ],
  "storageKey": null
},
v8 = {
  "alias": null,
  "args": null,
  "concreteType": "Sport",
  "kind": "LinkedField",
  "name": "sport",
  "plural": false,
  "selections": [
    (v2/*: any*/),
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "name",
      "storageKey": null
    }
  ],
  "storageKey": null
},
v9 = [
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
            "name": "type",
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
              (v8/*: any*/)
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
              {
                "alias": null,
                "args": (v9/*: any*/),
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
                          (v8/*: any*/),
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
                "args": (v9/*: any*/),
                "filters": null,
                "handle": "connection",
                "key": "my_leagues",
                "kind": "LinkedHandle",
                "name": "leagues"
              },
              (v2/*: any*/)
            ],
            "storageKey": null
          }
        ]
      }
    ]
  },
  "params": {
    "cacheID": "2a03eedb7b3c9b8b95756b1e61d26a46",
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
    "text": "query AppSidebarQuery(\n  $isDemo: Boolean!\n) {\n  ...RecordNavigationFragment\n  demoLeagues @include(if: $isDemo) {\n    ...LeagueNavigationFragment\n    id\n  }\n  me @skip(if: $isDemo) {\n    leagues(first: 10) {\n      edges {\n        node {\n          id\n          ...LeagueNavigationFragment\n          __typename\n        }\n        cursor\n      }\n      pageInfo {\n        endCursor\n        hasNextPage\n      }\n    }\n    id\n  }\n}\n\nfragment LeagueNavigationFragment on League {\n  id\n  currentLeagueName\n  fantasyProvider {\n    id\n    logoURL\n  }\n  sport {\n    id\n    name\n  }\n}\n\nfragment RecordNavigationFragment on Query {\n  recordMetadata {\n    type\n    displayName\n    categoryDisplayName\n    sentiment\n  }\n}\n"
  }
};
})();

(node as any).hash = "59219b064359eba5c8c466086c4850b8";

export default node;
