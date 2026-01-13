/**
 * @generated SignedSource<<28b6b836621d937325097e65a0f1f980>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type AppErrorCode = "ESPN_AUTHENTICATION_FAILED" | "ESPN_GENERAL_HTTP_ERROR" | "ESPN_INVALID_YEAR" | "ESPN_LEAGUE_INVALID" | "ESPN_NO_ACTIVE_YEARS" | "%future added value";
export type AddESPNLeagueToUserInput = {
  espnS2Id: string;
  leagueId: string;
  swid: string;
};
export type ESPNFormAddLeagueMutation$variables = {
  espnCredentials: AddESPNLeagueToUserInput;
};
export type ESPNFormAddLeagueMutation$data = {
  readonly addESPNLeagueToUser: {
    readonly errors: ReadonlyArray<{
      readonly errorCode?: AppErrorCode;
      readonly message?: string;
    }> | null | undefined;
    readonly league: {
      readonly id: string;
    } | null | undefined;
  };
};
export type ESPNFormAddLeagueMutation = {
  response: ESPNFormAddLeagueMutation$data;
  variables: ESPNFormAddLeagueMutation$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "espnCredentials"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "input",
    "variableName": "espnCredentials"
  }
],
v2 = {
  "alias": null,
  "args": null,
  "concreteType": "League",
  "kind": "LinkedField",
  "name": "league",
  "plural": false,
  "selections": [
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "id",
      "storageKey": null
    }
  ],
  "storageKey": null
},
v3 = {
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
};
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "ESPNFormAddLeagueMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "AddESPNLeagueToUserPayload",
        "kind": "LinkedField",
        "name": "addESPNLeagueToUser",
        "plural": false,
        "selections": [
          (v2/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": null,
            "kind": "LinkedField",
            "name": "errors",
            "plural": true,
            "selections": [
              (v3/*: any*/)
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
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "ESPNFormAddLeagueMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "AddESPNLeagueToUserPayload",
        "kind": "LinkedField",
        "name": "addESPNLeagueToUser",
        "plural": false,
        "selections": [
          (v2/*: any*/),
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
              (v3/*: any*/)
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "0813bb596757fa8290a8fc77ec176841",
    "id": null,
    "metadata": {},
    "name": "ESPNFormAddLeagueMutation",
    "operationKind": "mutation",
    "text": "mutation ESPNFormAddLeagueMutation(\n  $espnCredentials: AddESPNLeagueToUserInput!\n) {\n  addESPNLeagueToUser(input: $espnCredentials) {\n    league {\n      id\n    }\n    errors {\n      __typename\n      ... on ICodedException {\n        __isICodedException: __typename\n        errorCode\n        message\n      }\n    }\n  }\n}\n"
  }
};
})();

(node as any).hash = "14db5ed4b8e2ea0d3e55a203d7463431";

export default node;
