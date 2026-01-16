/**
 * @generated SignedSource<<2813246e78fb04fac380544990af50c5>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
export type RecordCategoryId = "LEAGUE" | "PLAYER" | "SEASON" | "WEEK" | "%future added value";
export type RecordMetricType = "RATIO" | "SCALAR" | "%future added value";
import { FragmentRefs } from "relay-runtime";
export type RecordDetailsTableFragment$data = {
  readonly entries: ReadonlyArray<{
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
  }>;
  readonly metadata: {
    readonly category: RecordCategoryId;
    readonly metricType: RecordMetricType;
    readonly unit: string;
  };
  readonly " $fragmentType": "RecordDetailsTableFragment";
};
export type RecordDetailsTableFragment$key = {
  readonly " $data"?: RecordDetailsTableFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"RecordDetailsTableFragment">;
};

const node: ReaderFragment = (function(){
var v0 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "unit",
  "storageKey": null
},
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
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "RecordDetailsTableFragment",
  "selections": [
    {
      "alias": null,
      "args": null,
      "concreteType": "RecordMetadata",
      "kind": "LinkedField",
      "name": "metadata",
      "plural": false,
      "selections": [
        (v0/*: any*/),
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "category",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "metricType",
          "storageKey": null
        }
      ],
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "concreteType": null,
      "kind": "LinkedField",
      "name": "entries",
      "plural": true,
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
            (v0/*: any*/),
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
    }
  ],
  "type": "RecordDetails",
  "abstractKey": null
};
})();

(node as any).hash = "ffea48ab9ce86e2d170e4dbb24f72dc3";

export default node;
