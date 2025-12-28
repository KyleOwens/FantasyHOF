/**
 * @generated SignedSource<<48105433f9ad49e5f64411b40b563963>>
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
    readonly fantasyProvider: {
      readonly id: string;
      readonly logoURL: string;
    };
    readonly id: string;
    readonly seasons: ReadonlyArray<{
      readonly id: string;
      readonly settings: {
        readonly id: string;
        readonly leagueName: string;
      };
    }>;
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
        "concreteType": "LeagueSeason",
        "kind": "LinkedField",
        "name": "seasons",
        "plural": true,
        "selections": [
          (v0/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "LeagueSeasonSettings",
            "kind": "LinkedField",
            "name": "settings",
            "plural": false,
            "selections": [
              (v0/*: any*/),
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "leagueName",
                "storageKey": null
              }
            ],
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
    "cacheID": "9ad67577f06307d8aec382ecd883d943",
    "id": null,
    "metadata": {},
    "name": "leagueNavigationQuery",
    "operationKind": "query",
    "text": "query leagueNavigationQuery {\n  demoLeagues {\n    id\n    fantasyProvider {\n      id\n      logoURL\n    }\n    seasons {\n      id\n      settings {\n        id\n        leagueName\n      }\n    }\n    sport {\n      id\n      name\n    }\n  }\n}\n"
  }
};
})();

(node as any).hash = "a8e070263d1dc86468b0f2a38a45c4e3";

export default node;
