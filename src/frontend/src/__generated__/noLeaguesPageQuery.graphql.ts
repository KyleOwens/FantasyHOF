/**
 * @generated SignedSource<<caa827d34b7bce6a73b7927cec18eede>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type noLeaguesPageQuery$variables = Record<PropertyKey, never>;
export type noLeaguesPageQuery$data = {
  readonly fantasyProviders: ReadonlyArray<{
    readonly logoURL: string;
    readonly name: string;
    readonly " $fragmentSpreads": FragmentRefs<"ProviderSelectionFragment">;
  }>;
};
export type noLeaguesPageQuery = {
  response: noLeaguesPageQuery$data;
  variables: noLeaguesPageQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "logoURL",
  "storageKey": null
},
v1 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "name",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "noLeaguesPageQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "FantasyProvider",
        "kind": "LinkedField",
        "name": "fantasyProviders",
        "plural": true,
        "selections": [
          (v0/*: any*/),
          (v1/*: any*/),
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
    "name": "noLeaguesPageQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "FantasyProvider",
        "kind": "LinkedField",
        "name": "fantasyProviders",
        "plural": true,
        "selections": [
          (v0/*: any*/),
          (v1/*: any*/),
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "value",
            "storageKey": null
          },
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
    ]
  },
  "params": {
    "cacheID": "2321277750e08f5c8e3128ec8a0e48af",
    "id": null,
    "metadata": {},
    "name": "noLeaguesPageQuery",
    "operationKind": "query",
    "text": "query noLeaguesPageQuery {\n  fantasyProviders {\n    logoURL\n    name\n    ...ProviderSelectionFragment\n    id\n  }\n}\n\nfragment ProviderSelectionFragment on FantasyProvider {\n  name\n  logoURL\n  value\n}\n"
  }
};
})();

(node as any).hash = "71b99b6c2e3f9a7b57fdc6a4c02edb22";

export default node;
