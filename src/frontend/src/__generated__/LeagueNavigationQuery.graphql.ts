/**
 * @generated SignedSource<<687dc34a3da8f7eb8a4aaac112febb9d>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type LeagueNavigationQuery$variables = Record<PropertyKey, never>;
export type LeagueNavigationQuery$data = {
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
export type LeagueNavigationQuery = {
  response: LeagueNavigationQuery$data;
  variables: LeagueNavigationQuery$variables;
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
    "name": "LeagueNavigationQuery",
    "selections": (v1/*: any*/),
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "LeagueNavigationQuery",
    "selections": (v1/*: any*/)
  },
  "params": {
    "cacheID": "292b1a4d521071d5bb6e4ae0f2f73480",
    "id": null,
    "metadata": {},
    "name": "LeagueNavigationQuery",
    "operationKind": "query",
    "text": "query LeagueNavigationQuery {\n  demoLeagues {\n    id\n    currentLeagueName\n    fantasyProvider {\n      id\n      logoURL\n    }\n    sport {\n      id\n      name\n    }\n  }\n}\n"
  }
};
})();

(node as any).hash = "63a74ca7b8155aaa8ef3b2f43d8224bf";

export default node;
