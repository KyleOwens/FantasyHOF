/**
 * @generated SignedSource<<da0d9a625f63f00800b0542176f8a27f>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type RankCellFragment$data = {
  readonly rank: number;
  readonly " $fragmentType": "RankCellFragment";
};
export type RankCellFragment$key = {
  readonly " $data"?: RankCellFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"RankCellFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "RankCellFragment",
  "selections": [
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "rank",
      "storageKey": null
    }
  ],
  "type": "RecordEntry",
  "abstractKey": "__isRecordEntry"
};

(node as any).hash = "308003d9d423db0db1a672eebc857f89";

export default node;
