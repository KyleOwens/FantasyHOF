/**
 * @generated SignedSource<<8b1064f9f557a1a5c79e227ce410e1f0>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type AppSidebarQuery$variables = Record<PropertyKey, never>;
export type AppSidebarQuery$data = {
  readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationFragment" | "RecordNavigationFragment">;
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
};
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "AppSidebarQuery",
    "selections": [
      {
        "args": null,
        "kind": "FragmentSpread",
        "name": "RecordNavigationFragment"
      },
      {
        "args": null,
        "kind": "FragmentSpread",
        "name": "LeagueNavigationFragment"
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "AppSidebarQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "RecordMetadata",
        "kind": "LinkedField",
        "name": "recordMetadata",
        "plural": true,
        "selections": [
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "displayName",
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "categoryDisplayName",
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "sentiment",
            "storageKey": null
          }
        ],
        "storageKey": null
      },
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
    ]
  },
  "params": {
    "cacheID": "f847107150aac76cc8f8fb35fb438fff",
    "id": null,
    "metadata": {},
    "name": "AppSidebarQuery",
    "operationKind": "query",
    "text": "query AppSidebarQuery {\n  ...RecordNavigationFragment\n  ...LeagueNavigationFragment\n}\n\nfragment LeagueNavigationFragment on Query {\n  demoLeagues {\n    id\n    currentLeagueName\n    fantasyProvider {\n      id\n      logoURL\n    }\n    sport {\n      id\n      name\n    }\n  }\n}\n\nfragment RecordNavigationFragment on Query {\n  recordMetadata {\n    displayName\n    categoryDisplayName\n    sentiment\n  }\n}\n"
  }
};
})();

(node as any).hash = "de6229d37e2997a2c65f5177b4208d93";

export default node;
