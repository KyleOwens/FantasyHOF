/**
 * @generated SignedSource<<37b7f47975e7195907ca0fadd2371fec>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueNavigationFragment$data = ReadonlyArray<{
  readonly currentLeagueName: string;
  readonly fantasyProvider: {
    readonly id: string;
    readonly logoURL: string;
  };
  readonly id: string;
  readonly sport: {
    readonly id: string;
    readonly name: string;
  };
  readonly userId: string;
  readonly " $fragmentType": "LeagueNavigationFragment";
}>;
export type LeagueNavigationFragment$key = ReadonlyArray<{
  readonly " $data"?: LeagueNavigationFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationFragment">;
}>;

const node: ReaderFragment = (function(){
var v0 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
};
return {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": {
    "plural": true
  },
  "name": "LeagueNavigationFragment",
  "selections": [
    (v0/*: any*/),
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "userId",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "currentLeagueName",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "concreteType": "FantasyProvider",
      "kind": "LinkedField",
      "name": "fantasyProvider",
      "plural": false,
      "selections": [
        (v0/*: any*/),
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "logoURL",
          "storageKey": null
        }
      ],
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "concreteType": "Sport",
      "kind": "LinkedField",
      "name": "sport",
      "plural": false,
      "selections": [
        (v0/*: any*/),
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "name",
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "League",
  "abstractKey": null
};
})();

(node as any).hash = "bae138820c84d6e43f5a87a0b6d22d59";

export default node;
