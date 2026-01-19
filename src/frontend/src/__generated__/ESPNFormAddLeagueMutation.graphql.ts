/**
 * @generated SignedSource<<6468f779e5fd0da8b95f0f8c64293ab1>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type AppErrorCode = "ESPN_AUTHENTICATION_FAILED" | "ESPN_GENERAL_HTTP_ERROR" | "ESPN_INVALID_YEAR" | "ESPN_LEAGUE_INVALID" | "ESPN_NO_ACTIVE_YEARS" | "FANTASY_HOF_FORBIDDEN" | "FANTASY_HOF_LEAGUE_IMPORT_EXISTS" | "FANTASY_HOF_NOT_FOUND" | "%future added value";
export type AddESPNLeagueToUserInput = {
  espnS2Id: string;
  leagueId: string;
  swid: string;
};
export type ESPNFormAddLeagueMutation$variables = {
  connections: ReadonlyArray<string>;
  espnCredentials: AddESPNLeagueToUserInput;
};
export type ESPNFormAddLeagueMutation$data = {
  readonly addESPNLeagueToUser: {
    readonly addLeagueMutationPayload: {
      readonly import: {
        readonly id: string;
        readonly " $fragmentSpreads": FragmentRefs<"PendingLeagueCardFragment">;
      };
      readonly jobId: string;
    } | null | undefined;
    readonly errors: ReadonlyArray<{
      readonly errorCode?: AppErrorCode;
      readonly message?: string;
    }> | null | undefined;
  };
};
export type ESPNFormAddLeagueMutation = {
  response: ESPNFormAddLeagueMutation$data;
  variables: ESPNFormAddLeagueMutation$variables;
};

const node: ConcreteRequest = (function(){
var v0 = {
  "defaultValue": null,
  "kind": "LocalArgument",
  "name": "connections"
},
v1 = {
  "defaultValue": null,
  "kind": "LocalArgument",
  "name": "espnCredentials"
},
v2 = [
  {
    "kind": "Variable",
    "name": "input",
    "variableName": "espnCredentials"
  }
],
v3 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "jobId",
  "storageKey": null
},
v4 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v5 = {
  "kind": "InlineFragment",
  "selections": [
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "errorCode",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "message",
      "storageKey": null
    }
  ],
  "type": "ICodedException",
  "abstractKey": "__isICodedException"
},
v6 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "name",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": [
      (v0/*: any*/),
      (v1/*: any*/)
    ],
    "kind": "Fragment",
    "metadata": null,
    "name": "ESPNFormAddLeagueMutation",
    "selections": [
      {
        "alias": null,
        "args": (v2/*: any*/),
        "concreteType": "AddESPNLeagueToUserPayload",
        "kind": "LinkedField",
        "name": "addESPNLeagueToUser",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "AddLeagueMutationPayload",
            "kind": "LinkedField",
            "name": "addLeagueMutationPayload",
            "plural": false,
            "selections": [
              (v3/*: any*/),
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueImport",
                "kind": "LinkedField",
                "name": "import",
                "plural": false,
                "selections": [
                  (v4/*: any*/),
                  {
                    "args": null,
                    "kind": "FragmentSpread",
                    "name": "PendingLeagueCardFragment"
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
            "concreteType": null,
            "kind": "LinkedField",
            "name": "errors",
            "plural": true,
            "selections": [
              (v5/*: any*/)
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ],
    "type": "Mutation",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [
      (v1/*: any*/),
      (v0/*: any*/)
    ],
    "kind": "Operation",
    "name": "ESPNFormAddLeagueMutation",
    "selections": [
      {
        "alias": null,
        "args": (v2/*: any*/),
        "concreteType": "AddESPNLeagueToUserPayload",
        "kind": "LinkedField",
        "name": "addESPNLeagueToUser",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "AddLeagueMutationPayload",
            "kind": "LinkedField",
            "name": "addLeagueMutationPayload",
            "plural": false,
            "selections": [
              (v3/*: any*/),
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueImport",
                "kind": "LinkedField",
                "name": "import",
                "plural": false,
                "selections": [
                  (v4/*: any*/),
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "FantasyProvider",
                    "kind": "LinkedField",
                    "name": "provider",
                    "plural": false,
                    "selections": [
                      (v4/*: any*/),
                      (v6/*: any*/),
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
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "LeagueImportStatus",
                    "kind": "LinkedField",
                    "name": "status",
                    "plural": false,
                    "selections": [
                      (v4/*: any*/),
                      (v6/*: any*/),
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "value",
                        "storageKey": null
                      }
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
                  }
                ],
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "filters": null,
                "handle": "appendNode",
                "key": "",
                "kind": "LinkedHandle",
                "name": "import",
                "handleArgs": [
                  {
                    "kind": "Variable",
                    "name": "connections",
                    "variableName": "connections"
                  },
                  {
                    "kind": "Literal",
                    "name": "edgeTypeName",
                    "value": "LeagueImportsEdge"
                  }
                ]
              }
            ],
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "concreteType": null,
            "kind": "LinkedField",
            "name": "errors",
            "plural": true,
            "selections": [
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "__typename",
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
  "params": {
    "cacheID": "e42eced7f857cc4cf78a06667619b71a",
    "id": null,
    "metadata": {},
    "name": "ESPNFormAddLeagueMutation",
    "operationKind": "mutation",
    "text": "mutation ESPNFormAddLeagueMutation(\n  $espnCredentials: AddESPNLeagueToUserInput!\n) {\n  addESPNLeagueToUser(input: $espnCredentials) {\n    addLeagueMutationPayload {\n      jobId\n      import {\n        id\n        ...PendingLeagueCardFragment\n      }\n    }\n    errors {\n      __typename\n      ... on ICodedException {\n        __isICodedException: __typename\n        errorCode\n        message\n      }\n    }\n  }\n}\n\nfragment PendingLeagueCardFragment on LeagueImport {\n  id\n  provider {\n    id\n    name\n    logoURL\n  }\n  status {\n    id\n    name\n    value\n  }\n  progress\n  error\n  providerleagueId\n}\n"
  }
};
})();

(node as any).hash = "05f81239b242db83f8b83d36577c4959";

export default node;
