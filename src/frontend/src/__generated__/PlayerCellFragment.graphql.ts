/**
 * @generated SignedSource<<a5d218af95f196df7d61892a2571b294>>
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
  readonly memberDetails: {
    readonly member: {
      readonly fullName: string;
    };
  };
  readonly player?: {
    readonly fullName: string;
    readonly playerImageURL: string;
  };
  readonly position?: {
    readonly id: string;
    readonly name: string;
    readonly value: PositionId;
  };
  readonly week?: number;
  readonly year?: number;
  readonly " $fragmentType": "PlayerCellFragment";
};
export type PlayerCellFragment$key = {
  readonly " $data"?: PlayerCellFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"PlayerCellFragment">;
};

const node: ReaderFragment = (function(){
var v0 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "fullName",
  "storageKey": null
};
return {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "PlayerCellFragment",
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
          "concreteType": "FantasyMember",
          "kind": "LinkedField",
          "name": "member",
          "plural": false,
          "selections": [
            (v0/*: any*/)
          ],
          "storageKey": null
        }
      ],
      "storageKey": null
    },
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
            (v0/*: any*/),
            {
              "alias": null,
              "args": null,
              "kind": "ScalarField",
              "name": "playerImageURL",
              "storageKey": null
            }
          ],
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
          "kind": "ScalarField",
          "name": "year",
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
})();

(node as any).hash = "059ea04a7a0778ec7f77eba6de81f94f";

export default node;
