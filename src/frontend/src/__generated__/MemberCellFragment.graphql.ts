/**
 * @generated SignedSource<<13c7341fed6959d14acddc5a777b4336>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type MemberCellFragment$data = {
  readonly memberDetails: {
    readonly currentTeamLogoURL: string;
    readonly currentTeamName: string;
    readonly id: string;
    readonly member: {
      readonly fullName: string;
    };
  };
  readonly " $fragmentType": "MemberCellFragment";
};
export type MemberCellFragment$key = {
  readonly " $data"?: MemberCellFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"MemberCellFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "MemberCellFragment",
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
          "name": "id",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "currentTeamName",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "currentTeamLogoURL",
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
              "name": "fullName",
              "storageKey": null
            }
          ],
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "RecordEntry",
  "abstractKey": "__isRecordEntry"
};

(node as any).hash = "d1919b33ae52f254151ed04ce0cb1980";

export default node;
