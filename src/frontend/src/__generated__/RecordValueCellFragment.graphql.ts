/**
 * @generated SignedSource<<d5290bd0cde57b405684c53ac4694d20>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type RecordValueCellFragment$data = {
  readonly metric: {
    readonly __typename: "RatioRecordMetric";
    readonly denominator?: any;
    readonly numerator?: any;
    readonly unit: string;
    readonly value: any;
  };
  readonly rank: number;
  readonly " $fragmentType": "RecordValueCellFragment";
};
export type RecordValueCellFragment$key = {
  readonly " $data"?: RecordValueCellFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"RecordValueCellFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "RecordValueCellFragment",
  "selections": [
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
              "name": "__typename",
              "storageKey": null
            },
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
              "name": "denominator",
              "storageKey": null
            }
          ],
          "type": "RatioRecordMetric",
          "abstractKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "RecordEntry",
  "abstractKey": "__isRecordEntry"
};

(node as any).hash = "5bef95597023346a5de8c38395c4ac57";

export default node;
