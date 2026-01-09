/**
 * @generated SignedSource<<5767c373589f14feed99afe1cf481b24>>
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
    readonly leagues: ReadonlyArray<{
      readonly id: string;
    }>;
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
  "args": null,
  "concreteType": "League",
  "kind": "LinkedField",
  "name": "leagues",
  "plural": true,
  "selections": [
    (v0/*: any*/)
  ],
  "storageKey": null
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
    "cacheID": "d1e726fce69a3a9dba445b0b789f066c",
    "id": null,
    "metadata": {},
    "name": "ModeUserLeaguesQuery",
    "operationKind": "query",
    "text": "query ModeUserLeaguesQuery {\n  me {\n    leagues {\n      id\n    }\n    id\n  }\n}\n"
  }
};
})();

(node as any).hash = "8921296ff7d76391a26ec69511ea97cc";

export default node;
