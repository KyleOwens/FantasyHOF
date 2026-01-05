/**
 * @generated SignedSource<<4984cc1ce0df5774904b4b34d10ec52c>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type SeasonalRecordCardFragment$data = {
  readonly member: {
    readonly fullName: string;
    readonly id: string;
  };
  readonly year: number;
  readonly " $fragmentSpreads": FragmentRefs<"RecordCardFragment">;
  readonly " $fragmentType": "SeasonalRecordCardFragment";
};
export type SeasonalRecordCardFragment$key = {
  readonly " $data"?: SeasonalRecordCardFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"SeasonalRecordCardFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "SeasonalRecordCardFragment",
  "selections": [
    {
      "args": null,
      "kind": "FragmentSpread",
      "name": "RecordCardFragment"
    },
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
    }
  ],
  "type": "SeasonalRecord",
  "abstractKey": null
};

(node as any).hash = "41fa73ed2549c918ffb9e37565edcb1a";

export default node;
