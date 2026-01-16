/**
 * @generated SignedSource<<6704f0f4d1f36988e6e3aad73c034186>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type ModeUserLeaguesQuery$variables = Record<PropertyKey, never>;
export type ModeUserLeaguesQuery$data = {
  readonly me: {
    readonly leagues: {
      readonly nodes: ReadonlyArray<{
        readonly id: string;
      }> | null | undefined;
    } | null | undefined;
  };
};
export type ModeUserLeaguesQuery = {
  response: ModeUserLeaguesQuery$data;
  variables: ModeUserLeaguesQuery$variables;
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
  "alias": null,
  "args": [
    {
      "kind": "Literal",
      "name": "first",
      "value": 50
    }
  ],
  "concreteType": "LeaguesConnection",
  "kind": "LinkedField",
  "name": "leagues",
  "plural": false,
  "selections": [
    {
      "alias": null,
      "args": null,
      "concreteType": "League",
      "kind": "LinkedField",
      "name": "nodes",
      "plural": true,
      "selections": [
        (v0/*: any*/)
      ],
      "storageKey": null
    }
  ],
  "storageKey": "leagues(first:50)"
};
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "ModeUserLeaguesQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "User",
        "kind": "LinkedField",
        "name": "me",
        "plural": false,
        "selections": [
          (v1/*: any*/)
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
    "name": "ModeUserLeaguesQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "User",
        "kind": "LinkedField",
        "name": "me",
        "plural": false,
        "selections": [
          (v1/*: any*/),
          (v0/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "bfd1718e99b39bfcbab11a47317ed4d5",
    "id": null,
    "metadata": {},
    "name": "ModeUserLeaguesQuery",
    "operationKind": "query",
    "text": "query ModeUserLeaguesQuery {\n  me {\n    leagues(first: 50) {\n      nodes {\n        id\n      }\n    }\n    id\n  }\n}\n"
  }
};
})();

(node as any).hash = "caae2ad099753e38419804e45cc22f2c";

export default node;
