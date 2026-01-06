/**
 * @generated SignedSource<<c3a27305e0085c6df7f8b33ca523f574>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
export type RecordSentiment = "FAME" | "SHAME" | "%future added value";
import { FragmentRefs } from "relay-runtime";
export type RecordNavigationFragment$data = {
  readonly recordMetadata: ReadonlyArray<{
    readonly categoryDisplayName: string;
    readonly displayName: string;
    readonly sentiment: RecordSentiment;
  }>;
  readonly " $fragmentType": "RecordNavigationFragment";
};
export type RecordNavigationFragment$key = {
  readonly " $data"?: RecordNavigationFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"RecordNavigationFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "RecordNavigationFragment",
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
    }
  ],
  "type": "Query",
  "abstractKey": null
};

(node as any).hash = "477f321b7ec7a7ffe40f3a73828eae01";

export default node;
