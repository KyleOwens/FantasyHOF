/**
 * @generated SignedSource<<90975d47b2ec1d96357d27eb14862e6b>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type MemberTenureCellFragment$data = {
  readonly memberDetails: {
    readonly firstyear: number;
    readonly lastYear: number;
    readonly tenure: number;
  };
  readonly " $fragmentType": "MemberTenureCellFragment";
};
export type MemberTenureCellFragment$key = {
  readonly " $data"?: MemberTenureCellFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"MemberTenureCellFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "MemberTenureCellFragment",
  "selections": [
    {
      "alias": null,
      "args": null,
      "concreteType": "LeagueMember",
      "kind": "LinkedField",
      "name": "memberDetails",
      "plural": false,
      "selections": [
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "firstyear",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "lastYear",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "tenure",
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "RecordEntry",
  "abstractKey": "__isRecordEntry"
};

(node as any).hash = "cd88cf86e9278c707d361331e8b0afb4";

export default node;
