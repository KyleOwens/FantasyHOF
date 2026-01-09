/**
 * @generated SignedSource<<3834caca2621d78bb6943e3c2c145524>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type ModeDemoLeaguesQuery$variables = Record<PropertyKey, never>;
export type ModeDemoLeaguesQuery$data = {
  readonly demoLeagues: ReadonlyArray<{
    readonly id: string;
  }>;
};
export type ModeDemoLeaguesQuery = {
  response: ModeDemoLeaguesQuery$data;
  variables: ModeDemoLeaguesQuery$variables;
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
    "name": "ModeDemoLeaguesQuery",
    "selections": (v0/*: any*/),
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "ModeDemoLeaguesQuery",
    "selections": (v0/*: any*/)
  },
  "params": {
    "cacheID": "a43d085ea82f2299b1ac2f40e1f01eec",
    "id": null,
    "metadata": {},
    "name": "ModeDemoLeaguesQuery",
    "operationKind": "query",
    "text": "query ModeDemoLeaguesQuery {\n  demoLeagues {\n    id\n  }\n}\n"
  }
};
})();

(node as any).hash = "40fe5ddd47154cef17680d8975f93198";

export default node;
