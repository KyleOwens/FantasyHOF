/**
 * @generated SignedSource<<4fcf59f1bcfe7fc3c93f070204389fcc>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueNavigationFragment$data = {
  readonly demoLeagues: ReadonlyArray<{
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
  }>;
  readonly " $fragmentType": "LeagueNavigationFragment";
};
export type LeagueNavigationFragment$key = {
  readonly " $data"?: LeagueNavigationFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationFragment">;
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
  "name": "LeagueNavigationFragment",
  "selections": [
    {
      "alias": null,
      "args": null,
      "concreteType": "League",
      "kind": "LinkedField",
      "name": "demoLeagues",
      "plural": true,
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
      "storageKey": null
    }
  ],
  "type": "Query",
  "abstractKey": null
};
})();

(node as any).hash = "8f019037ad401b807b15389d0623592b";

export default node;
