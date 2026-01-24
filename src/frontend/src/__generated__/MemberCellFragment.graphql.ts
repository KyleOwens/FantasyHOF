/**
 * @generated SignedSource<<eb7724c039b73a2feef71f79f709a5ab>>
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
    readonly firstyear: number;
    readonly id: string;
    readonly lastYear: number;
    readonly member: {
      readonly fullName: string;
    };
    readonly tenure: number;
  };
  readonly week?: number;
  readonly year?: number;
  readonly " $fragmentType": "MemberCellFragment";
};
export type MemberCellFragment$key = {
  readonly " $data"?: MemberCellFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"MemberCellFragment">;
};

const node: ReaderFragment = (function(){
var v0 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "year",
  "storageKey": null
},
v1 = [
  {
    "alias": null,
    "args": null,
    "kind": "ScalarField",
    "name": "week",
    "storageKey": null
  },
  (v0/*: any*/)
];
return {
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
          "kind": "ScalarField",
          "name": "tenure",
          "storageKey": null
        },
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
    },
    {
      "kind": "InlineFragment",
      "selections": [
        (v0/*: any*/)
      ],
      "type": "SeasonalRecordEntry",
      "abstractKey": null
    },
    {
      "kind": "InlineFragment",
      "selections": (v1/*: any*/),
      "type": "WeeklyRecordEntry",
      "abstractKey": null
    },
    {
      "kind": "InlineFragment",
      "selections": (v1/*: any*/),
      "type": "PlayerRecordEntry",
      "abstractKey": null
    }
  ],
  "type": "RecordEntry",
  "abstractKey": "__isRecordEntry"
};
})();

(node as any).hash = "f07b07ae404cbdbcc39b04804f18862b";

export default node;
