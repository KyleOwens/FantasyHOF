/**
 * @generated SignedSource<<13c43cab018a0d120c5aebe560e0e6fe>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type AppSidebarQuery$variables = Record<PropertyKey, never>;
export type AppSidebarQuery$data = {
  readonly demoLeagues: ReadonlyArray<{
    readonly currentLeagueName: string;
    readonly fantasyProvider: {
      readonly id: string;
      readonly logoURL: string;
    };
    readonly id: string;
    readonly sport: {
      readonly id: string;
      readonly name: string;
    };
  }>;
};
export type AppSidebarQuery = {
  response: AppSidebarQuery$data;
  variables: AppSidebarQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v1 = [
  {
    "alias": null,
    "args": null,
    "concreteType": "League",
    "kind": "LinkedField",
    "name": "demoLeagues",
    "plural": true,
    "selections": [
      (v0/*: any*/),
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "currentLeagueName",
        "storageKey": null
      },
      {
        "alias": null,
        "args": null,
        "concreteType": "FantasyProvider",
        "kind": "LinkedField",
        "name": "fantasyProvider",
        "plural": false,
        "selections": [
          (v0/*: any*/),
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
        "concreteType": "Sport",
        "kind": "LinkedField",
        "name": "sport",
        "plural": false,
        "selections": [
          (v0/*: any*/),
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "name",
            "storageKey": null
          }
        ],
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
    "name": "AppSidebarQuery",
    "selections": (v1/*: any*/),
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "AppSidebarQuery",
    "selections": (v1/*: any*/)
  },
  "params": {
    "cacheID": "e7df678ff41f3946eedce6f5e22099e0",
    "id": null,
    "metadata": {},
    "name": "AppSidebarQuery",
    "operationKind": "query",
    "text": "query AppSidebarQuery {\n  demoLeagues {\n    id\n    currentLeagueName\n    fantasyProvider {\n      id\n      logoURL\n    }\n    sport {\n      id\n      name\n    }\n  }\n}\n"
  }
};
})();

(node as any).hash = "dddc41c54c4a19d3c5f1ff1aea730d13";

export default node;
