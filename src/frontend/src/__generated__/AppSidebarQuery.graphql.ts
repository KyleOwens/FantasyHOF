/**
 * @generated SignedSource<<2fd7a8fea4331bce468e0b55d0c0148e>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type AppSidebarQuery$variables = {
  isDemo: boolean;
};
export type AppSidebarQuery$data = {
  readonly demoLeagues?: ReadonlyArray<{
    readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationFragment">;
  }>;
  readonly me?: {
    readonly leagues: ReadonlyArray<{
      readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationFragment">;
    }>;
  };
  readonly " $fragmentSpreads": FragmentRefs<"RecordNavigationFragment">;
};
export type AppSidebarQuery = {
  response: AppSidebarQuery$data;
  variables: AppSidebarQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "isDemo"
  }
],
v1 = [
  {
    "args": null,
    "kind": "FragmentSpread",
    "name": "LeagueNavigationFragment"
  }
],
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v3 = [
  (v2/*: any*/),
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
      (v2/*: any*/),
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
      (v2/*: any*/),
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
];
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
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
        "condition": "isDemo",
        "kind": "Condition",
        "passingValue": true,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "League",
            "kind": "LinkedField",
            "name": "demoLeagues",
            "plural": true,
            "selections": (v1/*: any*/),
            "storageKey": null
          }
        ]
      },
      {
        "condition": "isDemo",
        "kind": "Condition",
        "passingValue": false,
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
                "selections": (v1/*: any*/),
                "storageKey": null
              }
            ],
            "storageKey": null
          }
        ]
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
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
            "name": "type",
            "storageKey": null
          },
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
        "condition": "isDemo",
        "kind": "Condition",
        "passingValue": true,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "League",
            "kind": "LinkedField",
            "name": "demoLeagues",
            "plural": true,
            "selections": (v3/*: any*/),
            "storageKey": null
          }
        ]
      },
      {
        "condition": "isDemo",
        "kind": "Condition",
        "passingValue": false,
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
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              (v2/*: any*/)
            ],
            "storageKey": null
          }
        ]
      }
    ]
  },
  "params": {
    "cacheID": "db9791ed56c1ea520bc00111abee1b26",
    "id": null,
    "metadata": {},
    "name": "AppSidebarQuery",
    "operationKind": "query",
    "text": "query AppSidebarQuery(\n  $isDemo: Boolean!\n) {\n  ...RecordNavigationFragment\n  demoLeagues @include(if: $isDemo) {\n    ...LeagueNavigationFragment\n    id\n  }\n  me @skip(if: $isDemo) {\n    leagues {\n      ...LeagueNavigationFragment\n      id\n    }\n    id\n  }\n}\n\nfragment LeagueNavigationFragment on League {\n  id\n  currentLeagueName\n  fantasyProvider {\n    id\n    logoURL\n  }\n  sport {\n    id\n    name\n  }\n}\n\nfragment RecordNavigationFragment on Query {\n  recordMetadata {\n    type\n    displayName\n    categoryDisplayName\n    sentiment\n  }\n}\n"
  }
};
})();

(node as any).hash = "316fda5bd15c240e4b17b26facaa7791";

export default node;
