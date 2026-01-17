/**
 * @generated SignedSource<<155cc64f83bb6c508ad294e7570f4274>>
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

(node as any).hash = "03fc61d37a9b07431d36ce8625158b40";

export default node;
