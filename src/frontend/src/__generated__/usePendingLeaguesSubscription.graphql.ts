/**
 * @generated SignedSource<<6cc3e0b8de32f2739ccad6dde1b35bbb>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueImportStatusId = "COMPLETED" | "FAILED" | "FORMATTING_DATA" | "LOADING_SEASONAL_DATA" | "LOADING_WEEKLYL_DATA" | "QUEUED" | "SAVING_DATA" | "SAVING_MATCHUPS" | "SAVING_MEMBERS" | "SAVING_MISCELLANEOUS_DATA" | "SAVING_ROSTERS" | "SAVING_SEASONS" | "SAVING_STATS" | "SAVING_TEAMS" | "%future added value";
export type usePendingLeaguesSubscription$variables = Record<PropertyKey, never>;
export type usePendingLeaguesSubscription$data = {
  readonly leagueImportProgress: {
    readonly error: string | null | undefined;
    readonly id: string;
    readonly league: {
      readonly id: string;
      readonly " $fragmentSpreads": FragmentRefs<"LeagueCardFragment">;
    } | null | undefined;
    readonly progress: number;
    readonly status: {
      readonly id: string;
      readonly name: string;
      readonly value: LeagueImportStatusId;
    };
    readonly statusId: LeagueImportStatusId;
  };
};
export type usePendingLeaguesSubscription = {
  response: usePendingLeaguesSubscription$data;
  variables: usePendingLeaguesSubscription$variables;
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
  "name": "progress",
  "storageKey": null
},
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "error",
  "storageKey": null
},
v3 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "statusId",
  "storageKey": null
},
v4 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "name",
  "storageKey": null
},
v5 = {
  "alias": null,
  "args": null,
  "concreteType": "LeagueImportStatus",
  "kind": "LinkedField",
  "name": "status",
  "plural": false,
  "selections": [
    (v0/*: any*/),
    (v4/*: any*/),
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "value",
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
    "name": "usePendingLeaguesSubscription",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "LeagueImport",
        "kind": "LinkedField",
        "name": "leagueImportProgress",
        "plural": false,
        "selections": [
          (v0/*: any*/),
          (v1/*: any*/),
          (v2/*: any*/),
          (v3/*: any*/),
          (v5/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "League",
            "kind": "LinkedField",
            "name": "league",
            "plural": false,
            "selections": [
              (v0/*: any*/),
              {
                "args": null,
                "kind": "FragmentSpread",
                "name": "LeagueCardFragment"
              }
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ],
    "type": "Subscription",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "usePendingLeaguesSubscription",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "LeagueImport",
        "kind": "LinkedField",
        "name": "leagueImportProgress",
        "plural": false,
        "selections": [
          (v0/*: any*/),
          (v1/*: any*/),
          (v2/*: any*/),
          (v3/*: any*/),
          (v5/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "League",
            "kind": "LinkedField",
            "name": "league",
            "plural": false,
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
                "kind": "ScalarField",
                "name": "providerLeagueId",
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
                  (v4/*: any*/),
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
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "d6df15304ccb7a59e49e2f2afea7c00b",
    "id": null,
    "metadata": {},
    "name": "usePendingLeaguesSubscription",
    "operationKind": "subscription",
    "text": "subscription usePendingLeaguesSubscription {\n  leagueImportProgress {\n    id\n    progress\n    error\n    statusId\n    status {\n      id\n      name\n      value\n    }\n    league {\n      id\n      ...LeagueCardFragment\n    }\n  }\n}\n\nfragment LeagueCardFragment on League {\n  id\n  currentLeagueName\n  providerLeagueId\n  fantasyProvider {\n    id\n    name\n    logoURL\n  }\n  members {\n    memberId\n    id\n  }\n  seasons {\n    id\n  }\n  createdAt\n}\n"
  }
};
})();

(node as any).hash = "32aeb43bc689c29546a20501688f5b11";

export default node;
