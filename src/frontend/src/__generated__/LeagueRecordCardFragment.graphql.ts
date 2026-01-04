/**
 * @generated SignedSource<<ae6e3952c29236e2bb355416dd9cfdd3>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueRecordCardFragment$data = {
  readonly displayName: string;
  readonly iconURI: string;
  readonly member: {
    readonly firstName: string;
    readonly id: string;
    readonly lastName: string;
  };
  readonly value: any;
  readonly " $fragmentType": "LeagueRecordCardFragment";
};
export type LeagueRecordCardFragment$key = {
  readonly " $data"?: LeagueRecordCardFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "LeagueRecordCardFragment",
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
          "name": "firstName",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "lastName",
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "LeagueValueRecord",
  "abstractKey": null
};

(node as any).hash = "5c4bd4cc4719a731c6d5f5a748cc8dcb";

export default node;
