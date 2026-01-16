/**
 * @generated SignedSource<<426a356f6d9d76dd783745236afb12f4>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type RatioBreakdownCellFragment$data = {
  readonly metric: {
    readonly denominator?: any;
    readonly denominatorUnit?: string;
    readonly numerator?: any;
    readonly numeratorUnit?: string;
  };
  readonly " $fragmentType": "RatioBreakdownCellFragment";
};
export type RatioBreakdownCellFragment$key = {
  readonly " $data"?: RatioBreakdownCellFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"RatioBreakdownCellFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "RatioBreakdownCellFragment",
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
    }
  ],
  "type": "RecordEntry",
  "abstractKey": "__isRecordEntry"
};

(node as any).hash = "78fed46174171f4b07186db300818753";

export default node;
