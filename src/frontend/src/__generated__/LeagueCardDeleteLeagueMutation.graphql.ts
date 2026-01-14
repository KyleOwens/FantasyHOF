/**
 * @generated SignedSource<<ababce5cf7b2db0c5a98ca590ec87033>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type AppErrorCode = "ESPN_AUTHENTICATION_FAILED" | "ESPN_GENERAL_HTTP_ERROR" | "ESPN_INVALID_YEAR" | "ESPN_LEAGUE_INVALID" | "ESPN_NO_ACTIVE_YEARS" | "FANTASY_HOF_FORBIDDEN" | "FANTASY_HOF_NOT_FOUND" | "%future added value";
export type DeleteUserLeagueInput = {
  leagueId: string;
};
export type LeagueCardDeleteLeagueMutation$variables = {
  input: DeleteUserLeagueInput;
};
export type LeagueCardDeleteLeagueMutation$data = {
  readonly deleteUserLeague: {
    readonly deleteUserLeagueMutationPayload: {
      readonly leagueId: string;
    } | null | undefined;
    readonly errors: ReadonlyArray<{
      readonly errorCode?: AppErrorCode;
      readonly message?: string;
    }> | null | undefined;
  };
};
export type LeagueCardDeleteLeagueMutation = {
  response: LeagueCardDeleteLeagueMutation$data;
  variables: LeagueCardDeleteLeagueMutation$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "input"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "input",
    "variableName": "input"
  }
],
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "leagueId",
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
    "name": "LeagueCardDeleteLeagueMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "DeleteUserLeaguePayload",
        "kind": "LinkedField",
        "name": "deleteUserLeague",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "DeleteUserLeagueMutationPayload",
            "kind": "LinkedField",
            "name": "deleteUserLeagueMutationPayload",
            "plural": false,
            "selections": [
              (v2/*: any*/)
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
    "name": "LeagueCardDeleteLeagueMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "DeleteUserLeaguePayload",
        "kind": "LinkedField",
        "name": "deleteUserLeague",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "DeleteUserLeagueMutationPayload",
            "kind": "LinkedField",
            "name": "deleteUserLeagueMutationPayload",
            "plural": false,
            "selections": [
              (v2/*: any*/),
              {
                "alias": null,
                "args": null,
                "filters": null,
                "handle": "deleteRecord",
                "key": "",
                "kind": "ScalarHandle",
                "name": "leagueId"
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
    "cacheID": "30da207e24a153692e1bc10b340daa72",
    "id": null,
    "metadata": {},
    "name": "LeagueCardDeleteLeagueMutation",
    "operationKind": "mutation",
    "text": "mutation LeagueCardDeleteLeagueMutation(\n  $input: DeleteUserLeagueInput!\n) {\n  deleteUserLeague(input: $input) {\n    deleteUserLeagueMutationPayload {\n      leagueId\n    }\n    errors {\n      __typename\n      ... on ICodedException {\n        __isICodedException: __typename\n        errorCode\n        message\n      }\n    }\n  }\n}\n"
  }
};
})();

(node as any).hash = "b71ce91113f4db1c4a30336be1435515";

export default node;
