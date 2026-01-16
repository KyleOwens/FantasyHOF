/**
 * @generated SignedSource<<99309c505cf8ee35323ac7b1700316b0>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
export type PositionId = "BE" | "CB" | "DB" | "DE" | "DL" | "DP" | "DST" | "DT" | "ER" | "HC" | "IR" | "K" | "LB" | "OP" | "P" | "QB" | "RB" | "RBWR" | "RBWRTE" | "ROOKIE" | "S" | "TE" | "TQB" | "UNKNOWN" | "WR" | "WRTE" | "%future added value";
import { FragmentRefs } from "relay-runtime";
export type PlayerCellFragment$data = {
  readonly player?: {
    readonly fullName: string;
    readonly playerImageURL: string;
  };
  readonly position?: {
    readonly id: string;
    readonly name: string;
    readonly value: PositionId;
  };
  readonly " $fragmentType": "PlayerCellFragment";
};
export type PlayerCellFragment$key = {
  readonly " $data"?: PlayerCellFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"PlayerCellFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "PlayerCellFragment",
  "selections": [
    {
      "kind": "InlineFragment",
      "selections": [
        {
          "alias": null,
          "args": null,
          "concreteType": "Position",
          "kind": "LinkedField",
          "name": "position",
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
              "name": "value",
              "storageKey": null
            },
            {
              "alias": null,
              "args": null,
              "kind": "ScalarField",
              "name": "name",
              "storageKey": null
            }
          ],
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "concreteType": "Player",
          "kind": "LinkedField",
          "name": "player",
          "plural": false,
          "selections": [
            {
              "alias": null,
              "args": null,
              "kind": "ScalarField",
              "name": "fullName",
              "storageKey": null
            },
            {
              "alias": null,
              "args": null,
              "kind": "ScalarField",
              "name": "playerImageURL",
              "storageKey": null
            }
          ],
          "storageKey": null
        }
      ],
      "type": "PlayerRecordEntry",
      "abstractKey": null
    }
  ],
  "type": "RecordEntry",
  "abstractKey": "__isRecordEntry"
};

(node as any).hash = "6e76afd1648a67afb79eecb5c14a469a";

export default node;
