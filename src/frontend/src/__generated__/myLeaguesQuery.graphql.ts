/**
 * @generated SignedSource<<7f5805a25c774af2067a1850dcf9452c>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type myLeaguesQuery$variables = Record<PropertyKey, never>;
export type myLeaguesQuery$data = {
  readonly fantasyProviders: ReadonlyArray<{
    readonly " $fragmentSpreads": FragmentRefs<"ProviderSelectionFragment">;
  }>;
  readonly me: {
    readonly leagueImports: ReadonlyArray<{
      readonly id: string;
      readonly " $fragmentSpreads": FragmentRefs<"PendingLeagueCardFragment">;
    }>;
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
export type myLeaguesQuery = {
  response: myLeaguesQuery$data;
  variables: myLeaguesQuery$variables;
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
},
v4 = [
  (v0/*: any*/),
  (v1/*: any*/),
  (v2/*: any*/)
],
v5 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "value",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "myLeaguesQuery",
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
          },
          {
            "alias": null,
            "args": null,
            "concreteType": "LeagueImport",
            "kind": "LinkedField",
            "name": "leagueImports",
            "plural": true,
            "selections": [
              (v0/*: any*/),
              {
                "args": null,
                "kind": "FragmentSpread",
                "name": "PendingLeagueCardFragment"
              }
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
    "name": "myLeaguesQuery",
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
                "selections": (v4/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueMember",
                "kind": "LinkedField",
                "name": "members",
                "plural": true,
                "selections": [
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "memberId",
                    "storageKey": null
                  },
                  (v0/*: any*/)
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
                  (v0/*: any*/)
                ],
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "createdAt",
                "storageKey": null
              }
            ],
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "concreteType": "LeagueImport",
            "kind": "LinkedField",
            "name": "leagueImports",
            "plural": true,
            "selections": [
              (v0/*: any*/),
              {
                "alias": null,
                "args": null,
                "concreteType": "FantasyProvider",
                "kind": "LinkedField",
                "name": "provider",
                "plural": false,
                "selections": (v4/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueImportStatus",
                "kind": "LinkedField",
                "name": "status",
                "plural": false,
                "selections": [
                  (v0/*: any*/),
                  (v1/*: any*/),
                  (v5/*: any*/)
                ],
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "progress",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "error",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "providerleagueId",
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
          (v0/*: any*/),
          (v5/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "3145862114215a11c1e1dccdf6ba84b5",
    "id": null,
    "metadata": {},
    "name": "myLeaguesQuery",
    "operationKind": "query",
    "text": "query myLeaguesQuery {\n  me {\n    leagues {\n      id\n      ...LeagueCardFragment\n      fantasyProvider {\n        name\n        logoURL\n        id\n      }\n      providerLeagueId\n    }\n    leagueImports {\n      id\n      ...PendingLeagueCardFragment\n    }\n    id\n  }\n  ...NoLeaguesCardFragment\n  fantasyProviders {\n    ...ProviderSelectionFragment\n    id\n  }\n}\n\nfragment LeagueCardFragment on League {\n  id\n  currentLeagueName\n  providerLeagueId\n  fantasyProvider {\n    id\n    name\n    logoURL\n  }\n  members {\n    memberId\n    id\n  }\n  seasons {\n    id\n  }\n  createdAt\n}\n\nfragment NoLeaguesCardFragment on Query {\n  fantasyProviders {\n    logoURL\n    name\n    ...ProviderSelectionFragment\n    id\n  }\n}\n\nfragment PendingLeagueCardFragment on LeagueImport {\n  id\n  provider {\n    id\n    name\n    logoURL\n  }\n  status {\n    id\n    name\n    value\n  }\n  progress\n  error\n  providerleagueId\n}\n\nfragment ProviderSelectionFragment on FantasyProvider {\n  id\n  name\n  logoURL\n  value\n}\n"
  }
};
})();

(node as any).hash = "f36af02eff1ed85481404d67240e491a";

export default node;
