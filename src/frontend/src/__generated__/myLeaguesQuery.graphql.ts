/**
 * @generated SignedSource<<ccecfe56d22791111d01d36074908a03>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueImportStatusId = "COMPLETED" | "FAILED" | "FORMATTING_DATA" | "LOADING_DATA" | "QUEUED" | "SAVING_DATA" | "%future added value";
export type myLeaguesQuery$variables = Record<PropertyKey, never>;
export type myLeaguesQuery$data = {
  readonly fantasyProviders: ReadonlyArray<{
    readonly " $fragmentSpreads": FragmentRefs<"ProviderSelectionFragment">;
  }>;
  readonly me: {
    readonly id: string;
    readonly leagueImports: {
      readonly edges: ReadonlyArray<{
        readonly node: {
          readonly id: string;
          readonly league: {
            readonly id: string;
            readonly " $fragmentSpreads": FragmentRefs<"LeagueCardFragment">;
          } | null | undefined;
          readonly statusId: LeagueImportStatusId;
          readonly " $fragmentSpreads": FragmentRefs<"PendingLeagueCardFragment">;
        };
      }> | null | undefined;
    } | null | undefined;
    readonly leagues: {
      readonly edges: ReadonlyArray<{
        readonly node: {
          readonly fantasyProvider: {
            readonly logoURL: string;
            readonly name: string;
          };
          readonly id: string;
          readonly providerLeagueId: string;
          readonly " $fragmentSpreads": FragmentRefs<"LeagueCardFragment">;
        };
      }> | null | undefined;
    } | null | undefined;
  };
  readonly " $fragmentSpreads": FragmentRefs<"NoLeaguesCardFragment">;
};
export type myLeaguesQuery = {
  response: myLeaguesQuery$data;
  variables: myLeaguesQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v1 = {
  "args": null,
  "kind": "FragmentSpread",
  "name": "LeagueCardFragment"
},
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "name",
  "storageKey": null
},
v3 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "logoURL",
  "storageKey": null
},
v4 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "providerLeagueId",
  "storageKey": null
},
v5 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "__typename",
  "storageKey": null
},
v6 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "cursor",
  "storageKey": null
},
v7 = {
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
v8 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "statusId",
  "storageKey": null
},
v9 = [
  {
    "kind": "Literal",
    "name": "first",
    "value": 5
  }
],
v10 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "currentLeagueName",
  "storageKey": null
},
v11 = [
  (v0/*: any*/),
  (v2/*: any*/),
  (v3/*: any*/)
],
v12 = {
  "alias": null,
  "args": null,
  "concreteType": "FantasyProvider",
  "kind": "LinkedField",
  "name": "fantasyProvider",
  "plural": false,
  "selections": (v11/*: any*/),
  "storageKey": null
},
v13 = {
  "alias": null,
  "args": null,
  "concreteType": "LeagueMember",
  "kind": "LinkedField",
  "name": "members",
  "plural": true,
  "selections": [
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "memberId",
      "storageKey": null
    },
    (v0/*: any*/)
  ],
  "storageKey": null
},
v14 = {
  "alias": null,
  "args": null,
  "concreteType": "LeagueSeason",
  "kind": "LinkedField",
  "name": "seasons",
  "plural": true,
  "selections": [
    (v0/*: any*/)
  ],
  "storageKey": null
},
v15 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "createdAt",
  "storageKey": null
},
v16 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "value",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "myLeaguesQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "User",
        "kind": "LinkedField",
        "name": "me",
        "plural": false,
        "selections": [
          (v0/*: any*/),
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
                      (v0/*: any*/),
                      (v1/*: any*/),
                      {
                        "alias": null,
                        "args": null,
                        "concreteType": "FantasyProvider",
                        "kind": "LinkedField",
                        "name": "fantasyProvider",
                        "plural": false,
                        "selections": [
                          (v2/*: any*/),
                          (v3/*: any*/)
                        ],
                        "storageKey": null
                      },
                      (v4/*: any*/),
                      (v5/*: any*/)
                    ],
                    "storageKey": null
                  },
                  (v6/*: any*/)
                ],
                "storageKey": null
              },
              (v7/*: any*/)
            ],
            "storageKey": null
          },
          {
            "alias": "leagueImports",
            "args": null,
            "concreteType": "LeagueImportsConnection",
            "kind": "LinkedField",
            "name": "__my_leagueImports_connection",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueImportsEdge",
                "kind": "LinkedField",
                "name": "edges",
                "plural": true,
                "selections": [
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "LeagueImport",
                    "kind": "LinkedField",
                    "name": "node",
                    "plural": false,
                    "selections": [
                      (v0/*: any*/),
                      (v8/*: any*/),
                      {
                        "args": null,
                        "kind": "FragmentSpread",
                        "name": "PendingLeagueCardFragment"
                      },
                      {
                        "alias": null,
                        "args": null,
                        "concreteType": "League",
                        "kind": "LinkedField",
                        "name": "league",
                        "plural": false,
                        "selections": [
                          (v0/*: any*/),
                          (v1/*: any*/)
                        ],
                        "storageKey": null
                      },
                      (v5/*: any*/)
                    ],
                    "storageKey": null
                  },
                  (v6/*: any*/)
                ],
                "storageKey": null
              },
              (v7/*: any*/)
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      },
      {
        "args": null,
        "kind": "FragmentSpread",
        "name": "NoLeaguesCardFragment"
      },
      {
        "alias": null,
        "args": null,
        "concreteType": "FantasyProvider",
        "kind": "LinkedField",
        "name": "fantasyProviders",
        "plural": true,
        "selections": [
          {
            "args": null,
            "kind": "FragmentSpread",
            "name": "ProviderSelectionFragment"
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
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "myLeaguesQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "User",
        "kind": "LinkedField",
        "name": "me",
        "plural": false,
        "selections": [
          (v0/*: any*/),
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
                      (v0/*: any*/),
                      (v10/*: any*/),
                      (v4/*: any*/),
                      (v12/*: any*/),
                      (v13/*: any*/),
                      (v14/*: any*/),
                      (v15/*: any*/),
                      (v5/*: any*/)
                    ],
                    "storageKey": null
                  },
                  (v6/*: any*/)
                ],
                "storageKey": null
              },
              (v7/*: any*/)
            ],
            "storageKey": "leagues(first:5)"
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
          {
            "alias": null,
            "args": (v9/*: any*/),
            "concreteType": "LeagueImportsConnection",
            "kind": "LinkedField",
            "name": "leagueImports",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueImportsEdge",
                "kind": "LinkedField",
                "name": "edges",
                "plural": true,
                "selections": [
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "LeagueImport",
                    "kind": "LinkedField",
                    "name": "node",
                    "plural": false,
                    "selections": [
                      (v0/*: any*/),
                      (v8/*: any*/),
                      {
                        "alias": null,
                        "args": null,
                        "concreteType": "FantasyProvider",
                        "kind": "LinkedField",
                        "name": "provider",
                        "plural": false,
                        "selections": (v11/*: any*/),
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "concreteType": "LeagueImportStatus",
                        "kind": "LinkedField",
                        "name": "status",
                        "plural": false,
                        "selections": [
                          (v0/*: any*/),
                          (v2/*: any*/),
                          (v16/*: any*/)
                        ],
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "progress",
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "error",
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "providerleagueId",
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "concreteType": "League",
                        "kind": "LinkedField",
                        "name": "league",
                        "plural": false,
                        "selections": [
                          (v0/*: any*/),
                          (v10/*: any*/),
                          (v4/*: any*/),
                          (v12/*: any*/),
                          (v13/*: any*/),
                          (v14/*: any*/),
                          (v15/*: any*/)
                        ],
                        "storageKey": null
                      },
                      (v5/*: any*/)
                    ],
                    "storageKey": null
                  },
                  (v6/*: any*/)
                ],
                "storageKey": null
              },
              (v7/*: any*/)
            ],
            "storageKey": "leagueImports(first:5)"
          },
          {
            "alias": null,
            "args": (v9/*: any*/),
            "filters": null,
            "handle": "connection",
            "key": "my_leagueImports",
            "kind": "LinkedHandle",
            "name": "leagueImports"
          }
        ],
        "storageKey": null
      },
      {
        "alias": null,
        "args": null,
        "concreteType": "FantasyProvider",
        "kind": "LinkedField",
        "name": "fantasyProviders",
        "plural": true,
        "selections": [
          (v3/*: any*/),
          (v2/*: any*/),
          (v0/*: any*/),
          (v16/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "1a40d26d9c27e29307e19f04e8fc763e",
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
        },
        {
          "count": null,
          "cursor": null,
          "direction": "forward",
          "path": [
            "me",
            "leagueImports"
          ]
        }
      ]
    },
    "name": "myLeaguesQuery",
    "operationKind": "query",
    "text": "query myLeaguesQuery {\n  me {\n    id\n    leagues(first: 5) {\n      edges {\n        node {\n          id\n          ...LeagueCardFragment\n          fantasyProvider {\n            name\n            logoURL\n            id\n          }\n          providerLeagueId\n          __typename\n        }\n        cursor\n      }\n      pageInfo {\n        endCursor\n        hasNextPage\n      }\n    }\n    leagueImports(first: 5) {\n      edges {\n        node {\n          id\n          statusId\n          ...PendingLeagueCardFragment\n          league {\n            id\n            ...LeagueCardFragment\n          }\n          __typename\n        }\n        cursor\n      }\n      pageInfo {\n        endCursor\n        hasNextPage\n      }\n    }\n  }\n  ...NoLeaguesCardFragment\n  fantasyProviders {\n    ...ProviderSelectionFragment\n    id\n  }\n}\n\nfragment LeagueCardFragment on League {\n  id\n  currentLeagueName\n  providerLeagueId\n  fantasyProvider {\n    id\n    name\n    logoURL\n  }\n  members {\n    memberId\n    id\n  }\n  seasons {\n    id\n  }\n  createdAt\n}\n\nfragment NoLeaguesCardFragment on Query {\n  fantasyProviders {\n    logoURL\n    name\n    ...ProviderSelectionFragment\n    id\n  }\n}\n\nfragment PendingLeagueCardFragment on LeagueImport {\n  id\n  provider {\n    id\n    name\n    logoURL\n  }\n  status {\n    id\n    name\n    value\n  }\n  progress\n  error\n  providerleagueId\n}\n\nfragment ProviderSelectionFragment on FantasyProvider {\n  id\n  name\n  logoURL\n  value\n}\n"
  }
};
})();

(node as any).hash = "1921c243cfb9958274ed41b2b0c8633b";

export default node;
