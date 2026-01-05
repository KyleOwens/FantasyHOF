/**
 * @generated SignedSource<<a2915388a21686eee38cb4196da6bbf3>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type demoLeaguesQuery$variables = Record<PropertyKey, never>;
export type demoLeaguesQuery$data = {
  readonly demoLeagues: ReadonlyArray<{
    readonly id: string;
  }>;
};
export type demoLeaguesQuery = {
  response: demoLeaguesQuery$data;
  variables: demoLeaguesQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "alias": null,
    "args": null,
    "concreteType": "League",
    "kind": "LinkedField",
    "name": "demoLeagues",
    "plural": true,
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
  }
];
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "demoLeaguesQuery",
    "selections": (v0/*: any*/),
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "demoLeaguesQuery",
    "selections": (v0/*: any*/)
  },
  "params": {
    "cacheID": "24990146d7633607d9727f8766fb1267",
    "id": null,
    "metadata": {},
    "name": "demoLeaguesQuery",
    "operationKind": "query",
    "text": "query demoLeaguesQuery {\n  demoLeagues {\n    id\n  }\n}\n"
  }
};
})();

(node as any).hash = "b124852ae113c1bf9437f770eaf5c959";

export default node;
