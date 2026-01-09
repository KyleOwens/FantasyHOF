/**
 * @generated SignedSource<<6ded34c0a2022fde77e69abda5924855>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueDashboardQuery$variables = {
  leagueId: string;
};
export type LeagueDashboardQuery$data = {
  readonly league: {
    readonly currentLeagueName: string;
    readonly recordSummary: {
      readonly leagueRecords: ReadonlyArray<{
        readonly " $fragmentSpreads": FragmentRefs<"RecordSectionFragment">;
      }>;
      readonly playerRecords: ReadonlyArray<{
        readonly " $fragmentSpreads": FragmentRefs<"RecordSectionFragment">;
      }>;
      readonly seasonalRecords: ReadonlyArray<{
        readonly " $fragmentSpreads": FragmentRefs<"RecordSectionFragment">;
      }>;
      readonly weeklyRecords: ReadonlyArray<{
        readonly " $fragmentSpreads": FragmentRefs<"RecordSectionFragment">;
      }>;
    } | null | undefined;
  };
};
export type LeagueDashboardQuery = {
  response: LeagueDashboardQuery$data;
  variables: LeagueDashboardQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "leagueId"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "id",
    "variableName": "leagueId"
  }
],
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "currentLeagueName",
  "storageKey": null
},
v3 = [
  {
    "args": null,
    "kind": "FragmentSpread",
    "name": "RecordSectionFragment"
  }
],
v4 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "__typename",
  "storageKey": null
},
v5 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v6 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "fullName",
  "storageKey": null
},
v7 = {
  "alias": null,
  "args": null,
  "concreteType": "FantasyMember",
  "kind": "LinkedField",
  "name": "member",
  "plural": false,
  "selections": [
    (v5/*: any*/),
    (v6/*: any*/)
  ],
  "storageKey": null
},
v8 = {
  "kind": "InlineFragment",
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
      "name": "iconURI",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "concreteType": null,
      "kind": "LinkedField",
      "name": "metric",
      "plural": false,
      "selections": [
        (v4/*: any*/),
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "value",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "unit",
          "storageKey": null
        }
      ],
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "type",
      "storageKey": null
    }
  ],
  "type": "Record",
  "abstractKey": "__isRecord"
},
v9 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "year",
  "storageKey": null
},
v10 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "week",
  "storageKey": null
},
v11 = [
  (v6/*: any*/),
  (v5/*: any*/)
],
v12 = [
  {
    "kind": "InlineFragment",
    "selections": [
      (v4/*: any*/),
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "sentiment",
        "storageKey": null
      },
      {
        "kind": "InlineFragment",
        "selections": [
          (v7/*: any*/),
          (v8/*: any*/)
        ],
        "type": "LeagueRecord",
        "abstractKey": null
      },
      {
        "kind": "InlineFragment",
        "selections": [
          (v9/*: any*/),
          (v7/*: any*/),
          (v8/*: any*/)
        ],
        "type": "SeasonalRecord",
        "abstractKey": null
      },
      {
        "kind": "InlineFragment",
        "selections": [
          (v9/*: any*/),
          (v10/*: any*/),
          (v7/*: any*/),
          (v8/*: any*/)
        ],
        "type": "WeeklyRecord",
        "abstractKey": null
      },
      {
        "kind": "InlineFragment",
        "selections": [
          (v9/*: any*/),
          (v10/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "FantasyMember",
            "kind": "LinkedField",
            "name": "member",
            "plural": false,
            "selections": (v11/*: any*/),
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "concreteType": "Player",
            "kind": "LinkedField",
            "name": "player",
            "plural": false,
            "selections": (v11/*: any*/),
            "storageKey": null
          },
          (v8/*: any*/)
        ],
        "type": "PlayerRecord",
        "abstractKey": null
      }
    ],
    "type": "Record",
    "abstractKey": "__isRecord"
  }
];
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "LeagueDashboardQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "League",
        "kind": "LinkedField",
        "name": "league",
        "plural": false,
        "selections": [
          (v2/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "LeagueRecordSummary",
            "kind": "LinkedField",
            "name": "recordSummary",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueRecord",
                "kind": "LinkedField",
                "name": "leagueRecords",
                "plural": true,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "SeasonalRecord",
                "kind": "LinkedField",
                "name": "seasonalRecords",
                "plural": true,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "WeeklyRecord",
                "kind": "LinkedField",
                "name": "weeklyRecords",
                "plural": true,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "PlayerRecord",
                "kind": "LinkedField",
                "name": "playerRecords",
                "plural": true,
                "selections": (v3/*: any*/),
                "storageKey": null
              }
            ],
            "storageKey": null
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
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "LeagueDashboardQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "League",
        "kind": "LinkedField",
        "name": "league",
        "plural": false,
        "selections": [
          (v2/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "LeagueRecordSummary",
            "kind": "LinkedField",
            "name": "recordSummary",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueRecord",
                "kind": "LinkedField",
                "name": "leagueRecords",
                "plural": true,
                "selections": (v12/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "SeasonalRecord",
                "kind": "LinkedField",
                "name": "seasonalRecords",
                "plural": true,
                "selections": (v12/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "WeeklyRecord",
                "kind": "LinkedField",
                "name": "weeklyRecords",
                "plural": true,
                "selections": (v12/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "PlayerRecord",
                "kind": "LinkedField",
                "name": "playerRecords",
                "plural": true,
                "selections": (v12/*: any*/),
                "storageKey": null
              }
            ],
            "storageKey": null
          },
          (v5/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "98ed17719ef59da3eccf937e2e7e6686",
    "id": null,
    "metadata": {},
    "name": "LeagueDashboardQuery",
    "operationKind": "query",
    "text": "query LeagueDashboardQuery(\n  $leagueId: ID!\n) {\n  league(id: $leagueId) {\n    currentLeagueName\n    recordSummary {\n      leagueRecords {\n        ...RecordSectionFragment\n      }\n      seasonalRecords {\n        ...RecordSectionFragment\n      }\n      weeklyRecords {\n        ...RecordSectionFragment\n      }\n      playerRecords {\n        ...RecordSectionFragment\n      }\n    }\n    id\n  }\n}\n\nfragment LeagueRecordCardFragment on LeagueRecord {\n  ...RecordCardFragment\n  member {\n    id\n    fullName\n  }\n}\n\nfragment PlayerRecordCardFragment on PlayerRecord {\n  year\n  week\n  member {\n    fullName\n    id\n  }\n  player {\n    fullName\n    id\n  }\n  ...RecordCardFragment\n}\n\nfragment RecordCardFragment on Record {\n  __isRecord: __typename\n  displayName\n  iconURI\n  metric {\n    __typename\n    ... on RatioRecordMetric {\n      __typename\n    }\n    ... on ScalarRecordMetric {\n      __typename\n    }\n    value\n    unit\n  }\n  type\n}\n\nfragment RecordSectionFragment on Record {\n  __isRecord: __typename\n  __typename\n  sentiment\n  ... on LeagueRecord {\n    ...LeagueRecordCardFragment\n  }\n  ... on SeasonalRecord {\n    ...SeasonalRecordCardFragment\n  }\n  ... on WeeklyRecord {\n    ...WeeklyRecordCardFragment\n  }\n  ... on PlayerRecord {\n    ...PlayerRecordCardFragment\n  }\n}\n\nfragment SeasonalRecordCardFragment on SeasonalRecord {\n  ...RecordCardFragment\n  year\n  member {\n    id\n    fullName\n  }\n}\n\nfragment WeeklyRecordCardFragment on WeeklyRecord {\n  year\n  week\n  member {\n    id\n    fullName\n  }\n  ...RecordCardFragment\n}\n"
  }
};
})();

(node as any).hash = "4813ee4aab894f6f4af7fde562f10691";

export default node;
