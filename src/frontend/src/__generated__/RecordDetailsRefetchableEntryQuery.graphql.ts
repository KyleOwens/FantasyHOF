/**
 * @generated SignedSource<<ce64ec0ede3e9a736927ff1e510bd7da>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type RecordDetailsRefetchableEntryQuery$variables = {
  count?: number | null | undefined;
  cursor?: string | null | undefined;
  id: string;
};
export type RecordDetailsRefetchableEntryQuery$data = {
  readonly node: {
    readonly " $fragmentSpreads": FragmentRefs<"RecordDetailsTableRefetchableEntryFragment">;
  } | null | undefined;
};
export type RecordDetailsRefetchableEntryQuery = {
  response: RecordDetailsRefetchableEntryQuery$data;
  variables: RecordDetailsRefetchableEntryQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": 20,
    "kind": "LocalArgument",
    "name": "count"
  },
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "cursor"
  },
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "id"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "id",
    "variableName": "id"
  }
],
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "__typename",
  "storageKey": null
},
v3 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v4 = [
  {
    "kind": "Variable",
    "name": "after",
    "variableName": "cursor"
  },
  {
    "kind": "Variable",
    "name": "first",
    "variableName": "count"
  }
],
v5 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "value",
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
  "kind": "ScalarField",
  "name": "year",
  "storageKey": null
},
v8 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "week",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "RecordDetailsRefetchableEntryQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": null,
        "kind": "LinkedField",
        "name": "node",
        "plural": false,
        "selections": [
          {
            "args": [
              {
                "kind": "Variable",
                "name": "count",
                "variableName": "count"
              },
              {
                "kind": "Variable",
                "name": "cursor",
                "variableName": "cursor"
              }
            ],
            "kind": "FragmentSpread",
            "name": "RecordDetailsTableRefetchableEntryFragment"
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
    "name": "RecordDetailsRefetchableEntryQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": null,
        "kind": "LinkedField",
        "name": "node",
        "plural": false,
        "selections": [
          (v2/*: any*/),
          (v3/*: any*/),
          {
            "kind": "InlineFragment",
            "selections": [
              {
                "alias": null,
                "args": (v4/*: any*/),
                "concreteType": "EntriesConnection",
                "kind": "LinkedField",
                "name": "entries",
                "plural": false,
                "selections": [
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "EntriesEdge",
                    "kind": "LinkedField",
                    "name": "edges",
                    "plural": true,
                    "selections": [
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "cursor",
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "concreteType": null,
                        "kind": "LinkedField",
                        "name": "node",
                        "plural": false,
                        "selections": [
                          {
                            "alias": null,
                            "args": null,
                            "kind": "ScalarField",
                            "name": "key",
                            "storageKey": null
                          },
                          {
                            "alias": null,
                            "args": null,
                            "kind": "ScalarField",
                            "name": "rank",
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
                              (v2/*: any*/),
                              (v5/*: any*/),
                              {
                                "alias": null,
                                "args": null,
                                "kind": "ScalarField",
                                "name": "unit",
                                "storageKey": null
                              },
                              {
                                "kind": "InlineFragment",
                                "selections": [
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "numerator",
                                    "storageKey": null
                                  },
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "numeratorUnit",
                                    "storageKey": null
                                  },
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "denominator",
                                    "storageKey": null
                                  },
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "denominatorUnit",
                                    "storageKey": null
                                  }
                                ],
                                "type": "RatioRecordMetric",
                                "abstractKey": null
                              }
                            ],
                            "storageKey": null
                          },
                          (v2/*: any*/),
                          {
                            "kind": "TypeDiscriminator",
                            "abstractKey": "__isRecordEntry"
                          },
                          {
                            "alias": null,
                            "args": null,
                            "concreteType": "LeagueMember",
                            "kind": "LinkedField",
                            "name": "memberDetails",
                            "plural": false,
                            "selections": [
                              (v3/*: any*/),
                              {
                                "alias": null,
                                "args": null,
                                "kind": "ScalarField",
                                "name": "currentTeamName",
                                "storageKey": null
                              },
                              {
                                "alias": null,
                                "args": null,
                                "kind": "ScalarField",
                                "name": "currentTeamLogoURL",
                                "storageKey": null
                              },
                              {
                                "alias": null,
                                "args": null,
                                "concreteType": "FantasyMember",
                                "kind": "LinkedField",
                                "name": "member",
                                "plural": false,
                                "selections": [
                                  (v6/*: any*/),
                                  (v3/*: any*/)
                                ],
                                "storageKey": null
                              },
                              {
                                "alias": null,
                                "args": null,
                                "kind": "ScalarField",
                                "name": "firstyear",
                                "storageKey": null
                              },
                              {
                                "alias": null,
                                "args": null,
                                "kind": "ScalarField",
                                "name": "lastYear",
                                "storageKey": null
                              },
                              {
                                "alias": null,
                                "args": null,
                                "kind": "ScalarField",
                                "name": "tenure",
                                "storageKey": null
                              }
                            ],
                            "storageKey": null
                          },
                          {
                            "kind": "InlineFragment",
                            "selections": [
                              (v7/*: any*/)
                            ],
                            "type": "SeasonalRecordEntry",
                            "abstractKey": null
                          },
                          {
                            "kind": "InlineFragment",
                            "selections": [
                              (v7/*: any*/),
                              (v8/*: any*/)
                            ],
                            "type": "WeeklyRecordEntry",
                            "abstractKey": null
                          },
                          {
                            "kind": "InlineFragment",
                            "selections": [
                              (v7/*: any*/),
                              (v8/*: any*/),
                              {
                                "alias": null,
                                "args": null,
                                "concreteType": "Player",
                                "kind": "LinkedField",
                                "name": "player",
                                "plural": false,
                                "selections": [
                                  (v6/*: any*/),
                                  (v3/*: any*/),
                                  {
                                    "alias": null,
                                    "args": null,
                                    "kind": "ScalarField",
                                    "name": "playerImageURL",
                                    "storageKey": null
                                  }
                                ],
                                "storageKey": null
                              },
                              {
                                "alias": null,
                                "args": null,
                                "concreteType": "Position",
                                "kind": "LinkedField",
                                "name": "position",
                                "plural": false,
                                "selections": [
                                  (v3/*: any*/),
                                  (v5/*: any*/),
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
                            "type": "PlayerRecordEntry",
                            "abstractKey": null
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
                    "concreteType": "PageInfo",
                    "kind": "LinkedField",
                    "name": "pageInfo",
                    "plural": false,
                    "selections": [
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "endCursor",
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "hasNextPage",
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
                "args": (v4/*: any*/),
                "filters": null,
                "handle": "connection",
                "key": "recordDetails_entries",
                "kind": "LinkedHandle",
                "name": "entries"
              }
            ],
            "type": "RecordDetails",
            "abstractKey": null
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "b3604a8805b44563ed0741366fedf56b",
    "id": null,
    "metadata": {},
    "name": "RecordDetailsRefetchableEntryQuery",
    "operationKind": "query",
    "text": "query RecordDetailsRefetchableEntryQuery(\n  $count: Int = 20\n  $cursor: String\n  $id: ID!\n) {\n  node(id: $id) {\n    __typename\n    ...RecordDetailsTableRefetchableEntryFragment_1G22uz\n    id\n  }\n}\n\nfragment MemberCellFragment on RecordEntry {\n  __isRecordEntry: __typename\n  memberDetails {\n    id\n    currentTeamName\n    currentTeamLogoURL\n    member {\n      fullName\n      id\n    }\n  }\n}\n\nfragment MemberTenureCellFragment on RecordEntry {\n  __isRecordEntry: __typename\n  memberDetails {\n    firstyear\n    lastYear\n    tenure\n    id\n  }\n}\n\nfragment PlayerCellFragment on RecordEntry {\n  __isRecordEntry: __typename\n  ... on PlayerRecordEntry {\n    position {\n      id\n      value\n      name\n    }\n    player {\n      fullName\n      playerImageURL\n      id\n    }\n  }\n}\n\nfragment RatioBreakdownCellFragment on RecordEntry {\n  __isRecordEntry: __typename\n  metric {\n    __typename\n    ... on RatioRecordMetric {\n      numerator\n      numeratorUnit\n      denominator\n      denominatorUnit\n    }\n  }\n}\n\nfragment RecordDetailsTableRefetchableEntryFragment_1G22uz on RecordDetails {\n  entries(after: $cursor, first: $count) {\n    edges {\n      cursor\n      node {\n        key\n        rank\n        metric {\n          __typename\n          value\n          unit\n          ... on RatioRecordMetric {\n            numerator\n            numeratorUnit\n            denominator\n            denominatorUnit\n          }\n        }\n        __typename\n        ... on SeasonalRecordEntry {\n          year\n        }\n        ... on WeeklyRecordEntry {\n          year\n          week\n        }\n        ... on PlayerRecordEntry {\n          year\n          week\n          player {\n            fullName\n            id\n          }\n        }\n        ...RecordValueCellFragment\n        ...MemberCellFragment\n        ...MemberTenureCellFragment\n        ...RatioBreakdownCellFragment\n        ...PlayerCellFragment\n      }\n    }\n    pageInfo {\n      endCursor\n      hasNextPage\n    }\n  }\n  id\n}\n\nfragment RecordValueCellFragment on RecordEntry {\n  __isRecordEntry: __typename\n  metric {\n    __typename\n    value\n    unit\n    ... on RatioRecordMetric {\n      __typename\n      numerator\n      denominator\n    }\n  }\n}\n"
  }
};
})();

(node as any).hash = "393c3a7995abef5a35a2ad972170c195";

export default node;
