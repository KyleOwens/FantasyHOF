/**
 * @generated SignedSource<<2c09b152ad2de79ed3ad70a82ea82ed8>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type PlayerRecordCardFragment$data = {
  readonly member: {
    readonly fullName: string;
  };
  readonly player: {
    readonly fullName: string;
  };
  readonly week: number;
  readonly year: number;
  readonly " $fragmentSpreads": FragmentRefs<"RecordCardFragment">;
  readonly " $fragmentType": "PlayerRecordCardFragment";
};
export type PlayerRecordCardFragment$key = {
  readonly " $data"?: PlayerRecordCardFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"PlayerRecordCardFragment">;
};

const node: ReaderFragment = (function(){
var v0 = [
  {
    "alias": null,
    "args": null,
    "kind": "ScalarField",
    "name": "fullName",
    "storageKey": null
  }
];
return {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "PlayerRecordCardFragment",
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
      "selections": (v0/*: any*/),
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "concreteType": "Player",
      "kind": "LinkedField",
      "name": "player",
      "plural": false,
      "selections": (v0/*: any*/),
      "storageKey": null
    },
    {
      "args": null,
      "kind": "FragmentSpread",
      "name": "RecordCardFragment"
    }
  ],
  "type": "PlayerRecord",
  "abstractKey": null
};
})();

(node as any).hash = "03c6f4ef87094fe1176dd683705e7438";

export default node;
