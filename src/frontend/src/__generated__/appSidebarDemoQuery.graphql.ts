/**
 * @generated SignedSource<<79d040b1f4da5bf50323867081b55116>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
export type appSidebarDemoQuery$variables = Record<PropertyKey, never>;
export type appSidebarDemoQuery$data = {
  readonly demoLeagues: ReadonlyArray<{
    readonly fantasyProvider: {
      readonly id: string;
      readonly name: string;
    };
    readonly id: string;
    readonly seasons: ReadonlyArray<{
      readonly settings: {
        readonly leagueName: string;
      };
    }>;
  }>;
};
export type appSidebarDemoQuery = {
  response: appSidebarDemoQuery$data;
  variables: appSidebarDemoQuery$variables;
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
  "kind": "ScalarField",
  "name": "leagueName",
  "storageKey": null
},
v2 = {
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
      "name": "name",
      "storageKey": null
    }
  ],
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "appSidebarDemoQuery",
    "selections": [
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
            "concreteType": "LeagueSeason",
            "kind": "LinkedField",
            "name": "seasons",
            "plural": true,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueSeasonSettings",
                "kind": "LinkedField",
                "name": "settings",
                "plural": false,
                "selections": [
                  (v1/*: any*/)
                ],
                "storageKey": null
              }
            ],
            "storageKey": null
          },
          (v2/*: any*/)
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
    "name": "appSidebarDemoQuery",
    "selections": [
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
            "concreteType": "LeagueSeason",
            "kind": "LinkedField",
            "name": "seasons",
            "plural": true,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueSeasonSettings",
                "kind": "LinkedField",
                "name": "settings",
                "plural": false,
                "selections": [
                  (v1/*: any*/),
                  (v0/*: any*/)
                ],
                "storageKey": null
              },
              (v0/*: any*/)
            ],
            "storageKey": null
          },
          (v2/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "254c8f0fb6c258c66857823823018bda",
    "id": null,
    "metadata": {},
    "name": "appSidebarDemoQuery",
    "operationKind": "query",
    "text": "query appSidebarDemoQuery {\n  demoLeagues {\n    id\n    seasons {\n      settings {\n        leagueName\n        id\n      }\n      id\n    }\n    fantasyProvider {\n      id\n      name\n    }\n  }\n}\n"
  }
};
})();

(node as any).hash = "7a97a77f12e614ed27262a416e0ec46e";

export default node;
