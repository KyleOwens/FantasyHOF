/**
 * @generated SignedSource<<7d2c0d405344abea685995cd01e33bc0>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type FantasyProviderId = "ESPN" | "NFL" | "SLEEPER" | "YAHOO" | "%future added value";
export type footballQuery$variables = Record<PropertyKey, never>;
export type footballQuery$data = {
  readonly fantasyProviders: ReadonlyArray<{
    readonly id: string;
    readonly logoURL: string;
    readonly name: string;
    readonly value: FantasyProviderId;
  }>;
};
export type footballQuery = {
  response: footballQuery$data;
  variables: footballQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "alias": null,
    "args": null,
    "concreteType": "FantasyProvider",
    "kind": "LinkedField",
    "name": "fantasyProviders",
    "plural": true,
    "selections": [
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "id",
        "storageKey": null
      },
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "name",
        "storageKey": null
      },
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "logoURL",
        "storageKey": null
      },
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "value",
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
    "name": "footballQuery",
    "selections": (v0/*: any*/),
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "footballQuery",
    "selections": (v0/*: any*/)
  },
  "params": {
    "cacheID": "0d11daf166ecb876a72e7da39da0171f",
    "id": null,
    "metadata": {},
    "name": "footballQuery",
    "operationKind": "query",
    "text": "query footballQuery {\n  fantasyProviders {\n    id\n    name\n    logoURL\n    value\n  }\n}\n"
  }
};
})();

(node as any).hash = "5c9643ec4e78a003950f00eb163f479d";

export default node;
