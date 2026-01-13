/**
 * @generated SignedSource<<028a1dea74e4af1797a0fa7f6b7f1e7a>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type myLeaguesTestQuery$variables = Record<PropertyKey, never>;
export type myLeaguesTestQuery$data = {
  readonly fantasyProviders: ReadonlyArray<{
    readonly " $fragmentSpreads": FragmentRefs<"ProviderSelectionFragment">;
  }>;
  readonly me: {
    readonly leagues: ReadonlyArray<{
      readonly fantasyProvider: {
        readonly logoURL: string;
        readonly name: string;
      };
      readonly id: string;
      readonly providerLeagueId: string;
      readonly " $fragmentSpreads": FragmentRefs<"LeagueCardFragment">;
    }>;
  };
  readonly " $fragmentSpreads": FragmentRefs<"NoLeaguesCardFragment">;
};
export type myLeaguesTestQuery = {
  response: myLeaguesTestQuery$data;
  variables: myLeaguesTestQuery$variables;
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
  "name": "name",
  "storageKey": null
},
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "logoURL",
  "storageKey": null
},
v3 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "providerLeagueId",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "myLeaguesTestQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "User",
        "kind": "LinkedField",
        "name": "me",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "League",
            "kind": "LinkedField",
            "name": "leagues",
            "plural": true,
            "selections": [
              (v0/*: any*/),
              {
                "args": null,
                "kind": "FragmentSpread",
                "name": "LeagueCardFragment"
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "FantasyProvider",
                "kind": "LinkedField",
                "name": "fantasyProvider",
                "plural": false,
                "selections": [
                  (v1/*: any*/),
                  (v2/*: any*/)
                ],
                "storageKey": null
              },
              (v3/*: any*/)
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      },
      {
        "args": null,
        "kind": "FragmentSpread",
        "name": "NoLeaguesCardFragment"
      },
      {
        "alias": null,
        "args": null,
        "concreteType": "FantasyProvider",
        "kind": "LinkedField",
        "name": "fantasyProviders",
        "plural": true,
        "selections": [
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
    "name": "myLeaguesTestQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "User",
        "kind": "LinkedField",
        "name": "me",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "League",
            "kind": "LinkedField",
            "name": "leagues",
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
              (v3/*: any*/),
              {
                "alias": null,
                "args": null,
                "concreteType": "FantasyProvider",
                "kind": "LinkedField",
                "name": "fantasyProvider",
                "plural": false,
                "selections": [
                  (v0/*: any*/),
                  (v1/*: any*/),
                  (v2/*: any*/)
                ],
                "storageKey": null
              }
            ],
            "storageKey": null
          },
          (v0/*: any*/)
        ],
        "storageKey": null
      },
      {
        "alias": null,
        "args": null,
        "concreteType": "FantasyProvider",
        "kind": "LinkedField",
        "name": "fantasyProviders",
        "plural": true,
        "selections": [
          (v2/*: any*/),
          (v1/*: any*/),
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "value",
            "storageKey": null
          },
          (v0/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "3d82ee918c7cdbcf1f450973c89858fd",
    "id": null,
    "metadata": {},
    "name": "myLeaguesTestQuery",
    "operationKind": "query",
    "text": "query myLeaguesTestQuery {\n  me {\n    leagues {\n      id\n      ...LeagueCardFragment\n      fantasyProvider {\n        name\n        logoURL\n        id\n      }\n      providerLeagueId\n    }\n    id\n  }\n  ...NoLeaguesCardFragment\n  fantasyProviders {\n    ...ProviderSelectionFragment\n    id\n  }\n}\n\nfragment LeagueCardFragment on League {\n  id\n  currentLeagueName\n  providerLeagueId\n  fantasyProvider {\n    id\n    name\n    logoURL\n  }\n}\n\nfragment NoLeaguesCardFragment on Query {\n  fantasyProviders {\n    logoURL\n    name\n    ...ProviderSelectionFragment\n    id\n  }\n}\n\nfragment ProviderSelectionFragment on FantasyProvider {\n  name\n  logoURL\n  value\n}\n"
  }
};
})();

(node as any).hash = "98641a160a70ef29c2b0498a29ec20a4";

export default node;
