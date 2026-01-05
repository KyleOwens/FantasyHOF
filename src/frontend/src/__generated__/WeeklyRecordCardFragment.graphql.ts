/**
 * @generated SignedSource<<2e8bb8875e0accfc61cd1391f25e389b>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type WeeklyRecordCardFragment$data = {
  readonly member: {
    readonly fullName: string;
    readonly id: string;
  };
  readonly week: number;
  readonly year: number;
  readonly " $fragmentSpreads": FragmentRefs<"RecordCardFragment">;
  readonly " $fragmentType": "WeeklyRecordCardFragment";
};
export type WeeklyRecordCardFragment$key = {
  readonly " $data"?: WeeklyRecordCardFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"WeeklyRecordCardFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "WeeklyRecordCardFragment",
  "selections": [
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "year",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "week",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "concreteType": "FantasyMember",
      "kind": "LinkedField",
      "name": "member",
      "plural": false,
      "selections": [
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "id",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "fullName",
          "storageKey": null
        }
      ],
      "storageKey": null
    },
    {
      "args": null,
      "kind": "FragmentSpread",
      "name": "RecordCardFragment"
    }
  ],
  "type": "WeeklyRecord",
  "abstractKey": null
};

(node as any).hash = "e9e2219653e767240b8cd45d467f202b";

export default node;
