/**
 * @generated SignedSource<<92d607a254ce24fbedda0bf9a7465e1e>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueRecordCardFragment$data = {
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

(node as any).hash = "0485738b305868a4da4e7a019d177bfe";

export default node;
