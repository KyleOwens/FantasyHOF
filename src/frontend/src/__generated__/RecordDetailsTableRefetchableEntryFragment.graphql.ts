/**
 * @generated SignedSource<<04769aea83ce921898ecddbce0d874a1>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type RecordDetailsTableRefetchableEntryFragment$data = {
  readonly entries: {
    readonly edges: ReadonlyArray<{
      readonly node: {
        readonly __typename: string;
        readonly key: string;
        readonly metric: {
          readonly denominator?: any;
          readonly denominatorUnit?: string;
          readonly numerator?: any;
          readonly numeratorUnit?: string;
          readonly unit: string;
          readonly value: any;
        };
        readonly player?: {
          readonly fullName: string;
        };
        readonly rank: number;
        readonly week?: number;
        readonly year?: number;
        readonly " $fragmentSpreads": FragmentRefs<"MemberCellFragment" | "MemberTenureCellFragment" | "PlayerCellFragment" | "RankCellFragment" | "RatioBreakdownCellFragment" | "RecordValueCellFragment">;
      };
    }> | null | undefined;
  } | null | undefined;
  readonly id: string;
  readonly " $fragmentType": "RecordDetailsTableRefetchableEntryFragment";
};
export type RecordDetailsTableRefetchableEntryFragment$key = {
  readonly " $data"?: RecordDetailsTableRefetchableEntryFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"RecordDetailsTableRefetchableEntryFragment">;
};

import RecordDetailsRefetchableEntryQuery_graphql from './RecordDetailsRefetchableEntryQuery.graphql';

const node: ReaderFragment = (function(){
var v0 = [
  "entries"
],
v1 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "year",
  "storageKey": null
},
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "week",
  "storageKey": null
};
return {
  "argumentDefinitions": [
    {
      "defaultValue": 10,
      "kind": "LocalArgument",
      "name": "count"
    },
    {
      "defaultValue": null,
      "kind": "LocalArgument",
      "name": "cursor"
    }
  ],
  "kind": "Fragment",
  "metadata": {
    "connection": [
      {
        "count": "count",
        "cursor": "cursor",
        "direction": "forward",
        "path": (v0/*: any*/)
      }
    ],
    "refetch": {
      "connection": {
        "forward": {
          "count": "count",
          "cursor": "cursor"
        },
        "backward": null,
        "path": (v0/*: any*/)
      },
      "fragmentPathInResult": [
        "node"
      ],
      "operation": RecordDetailsRefetchableEntryQuery_graphql,
      "identifierInfo": {
        "identifierField": "id",
        "identifierQueryVariableName": "id"
      }
    }
  },
  "name": "RecordDetailsTableRefetchableEntryFragment",
  "selections": [
    {
      "alias": "entries",
      "args": null,
      "concreteType": "EntriesConnection",
      "kind": "LinkedField",
      "name": "__recordDetails_entries_connection",
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
                {
                  "alias": null,
                  "args": null,
                  "kind": "ScalarField",
                  "name": "__typename",
                  "storageKey": null
                },
                {
                  "kind": "InlineFragment",
                  "selections": [
                    (v1/*: any*/)
                  ],
                  "type": "SeasonalRecordEntry",
                  "abstractKey": null
                },
                {
                  "kind": "InlineFragment",
                  "selections": [
                    (v1/*: any*/),
                    (v2/*: any*/)
                  ],
                  "type": "WeeklyRecordEntry",
                  "abstractKey": null
                },
                {
                  "kind": "InlineFragment",
                  "selections": [
                    (v1/*: any*/),
                    (v2/*: any*/),
                    {
                      "alias": null,
                      "args": null,
                      "concreteType": "Player",
                      "kind": "LinkedField",
                      "name": "player",
                      "plural": false,
                      "selections": [
                        {
                          "alias": null,
                          "args": null,
                          "kind": "ScalarField",
                          "name": "fullName",
                          "storageKey": null
                        }
                      ],
                      "storageKey": null
                    }
                  ],
                  "type": "PlayerRecordEntry",
                  "abstractKey": null
                },
                {
                  "args": null,
                  "kind": "FragmentSpread",
                  "name": "RecordValueCellFragment"
                },
                {
                  "args": null,
                  "kind": "FragmentSpread",
                  "name": "MemberCellFragment"
                },
                {
                  "args": null,
                  "kind": "FragmentSpread",
                  "name": "MemberTenureCellFragment"
                },
                {
                  "args": null,
                  "kind": "FragmentSpread",
                  "name": "RankCellFragment"
                },
                {
                  "args": null,
                  "kind": "FragmentSpread",
                  "name": "RatioBreakdownCellFragment"
                },
                {
                  "args": null,
                  "kind": "FragmentSpread",
                  "name": "PlayerCellFragment"
                }
              ],
              "storageKey": null
            },
            {
              "alias": null,
              "args": null,
              "kind": "ScalarField",
              "name": "cursor",
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
      "args": null,
      "kind": "ScalarField",
      "name": "id",
      "storageKey": null
    }
  ],
  "type": "RecordDetails",
  "abstractKey": null
};
})();

(node as any).hash = "83d9c9aa1d077838f60bf1668df24c95";

export default node;
