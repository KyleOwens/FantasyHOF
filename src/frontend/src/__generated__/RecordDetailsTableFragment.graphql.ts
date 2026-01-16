/**
 * @generated SignedSource<<db12fee5100fe5fd5a1ada221af1e3f2>>
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
  readonly metadata: {
    readonly category: RecordCategoryId;
    readonly metricType: RecordMetricType;
    readonly unit: string;
  };
  readonly " $fragmentSpreads": FragmentRefs<"RecordDetailsTableRefetchableEntryFragment">;
  readonly " $fragmentType": "RecordDetailsTableFragment";
};
export type RecordDetailsTableFragment$key = {
  readonly " $data"?: RecordDetailsTableFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"RecordDetailsTableFragment">;
};

const node: ReaderFragment = {
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
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "unit",
          "storageKey": null
        },
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
      "args": null,
      "kind": "FragmentSpread",
      "name": "RecordDetailsTableRefetchableEntryFragment"
    }
  ],
  "type": "RecordDetails",
  "abstractKey": null
};

(node as any).hash = "78b66233f4a6ba8f03433ec4716fed5f";

export default node;
