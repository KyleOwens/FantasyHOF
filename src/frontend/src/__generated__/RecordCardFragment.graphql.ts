/**
 * @generated SignedSource<<6823c5c7c8cc650f7255f8c998e34cff>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type RecordCardFragment$data = {
  readonly displayName: string;
  readonly iconURI: string;
  readonly isPercentage: boolean;
  readonly metric: string;
  readonly value: any;
  readonly " $fragmentType": "RecordCardFragment";
};
export type RecordCardFragment$key = {
  readonly " $data"?: RecordCardFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"RecordCardFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "RecordCardFragment",
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
      "kind": "ScalarField",
      "name": "metric",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "isPercentage",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "value",
      "storageKey": null
    }
  ],
  "type": "Record",
  "abstractKey": "__isRecord"
};

(node as any).hash = "1a95559031f87a43550bc4c0dc3baf9c";

export default node;
