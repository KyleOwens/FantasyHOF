/**
 * @generated SignedSource<<8fe4167e96e8b646d1a751bf00c44780>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type LayoutDemoLeaguesQuery$variables = Record<PropertyKey, never>;
export type LayoutDemoLeaguesQuery$data = {
  readonly demoLeagues: ReadonlyArray<{
    readonly id: string;
  }>;
};
export type LayoutDemoLeaguesQuery = {
  response: LayoutDemoLeaguesQuery$data;
  variables: LayoutDemoLeaguesQuery$variables;
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
    "name": "LayoutDemoLeaguesQuery",
    "selections": (v0/*: any*/),
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "LayoutDemoLeaguesQuery",
    "selections": (v0/*: any*/)
  },
  "params": {
    "cacheID": "649d8c28690150526e1bd37b6a334d85",
    "id": null,
    "metadata": {},
    "name": "LayoutDemoLeaguesQuery",
    "operationKind": "query",
    "text": "query LayoutDemoLeaguesQuery {\n  demoLeagues {\n    id\n  }\n}\n"
  }
};
})();

(node as any).hash = "9d28901132c805d30f087755f543276e";

export default node;
