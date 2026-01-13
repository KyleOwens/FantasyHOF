/**
 * @generated SignedSource<<61c35ef4fdc474144dd74244afd05021>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueCardFragment$data = {
  readonly currentLeagueName: string;
  readonly fantasyProvider: {
    readonly id: string;
    readonly logoURL: string;
    readonly name: string;
  };
  readonly id: string;
  readonly providerLeagueId: string;
  readonly " $fragmentType": "LeagueCardFragment";
};
export type LeagueCardFragment$key = {
  readonly " $data"?: LeagueCardFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"LeagueCardFragment">;
};

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
  "metadata": null,
  "name": "LeagueCardFragment",
  "selections": [
    (v0/*: any*/),
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
      "kind": "ScalarField",
      "name": "providerLeagueId",
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
          "name": "name",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "logoURL",
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

(node as any).hash = "269982208df062a0a1088ff036fdeabf";

export default node;
