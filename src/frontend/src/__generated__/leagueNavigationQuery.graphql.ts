/**
 * @generated SignedSource<<43d633cba06c432376e3f27320ff6a1e>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type leagueNavigationQuery$variables = Record<PropertyKey, never>;
export type leagueNavigationQuery$data = {
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
export type leagueNavigationQuery = {
  response: leagueNavigationQuery$data;
  variables: leagueNavigationQuery$variables;
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
    "name": "leagueNavigationQuery",
    "selections": (v1/*: any*/),
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "leagueNavigationQuery",
    "selections": (v1/*: any*/)
  },
  "params": {
    "cacheID": "76325dc011c0f5b3d443bb32dd0d1ba4",
    "id": null,
    "metadata": {},
    "name": "leagueNavigationQuery",
    "operationKind": "query",
    "text": "query leagueNavigationQuery {\n  demoLeagues {\n    id\n    currentLeagueName\n    fantasyProvider {\n      id\n      logoURL\n    }\n    sport {\n      id\n      name\n    }\n  }\n}\n"
  }
};
})();

(node as any).hash = "5d28277b31327ba7a543554b6714d89d";

export default node;
