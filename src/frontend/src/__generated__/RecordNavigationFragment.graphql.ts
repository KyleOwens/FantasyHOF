/**
 * @generated SignedSource<<7f355d9c967054e15d4a73e160472c0f>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type RecordNavigationFragment$data = {
  readonly recordMetadata: ReadonlyArray<{
    readonly categoryDisplayName: string;
    readonly displayName: string;
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
        }
      ],
      "storageKey": null
    }
  ],
  "type": "Query",
  "abstractKey": null
};

(node as any).hash = "f8d06d521694db41baf48934e61671df";

export default node;
