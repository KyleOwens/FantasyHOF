/**
 * @generated SignedSource<<bb0afa9bf1c3bc8e29b7af0058b7fe97>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueCardFragment$data = {
  readonly createdAt: any;
  readonly currentLeagueName: string;
  readonly fantasyProvider: {
    readonly id: string;
    readonly logoURL: string;
    readonly name: string;
  };
  readonly id: string;
  readonly members: ReadonlyArray<{
    readonly memberId: number;
  }>;
  readonly providerLeagueId: string;
  readonly seasons: ReadonlyArray<{
    readonly id: string;
  }>;
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
    },
    {
      "alias": null,
      "args": null,
      "concreteType": "LeagueMember",
      "kind": "LinkedField",
      "name": "members",
      "plural": true,
      "selections": [
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "memberId",
          "storageKey": null
        }
      ],
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "concreteType": "LeagueSeason",
      "kind": "LinkedField",
      "name": "seasons",
      "plural": true,
      "selections": [
        (v0/*: any*/)
      ],
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "createdAt",
      "storageKey": null
    }
  ],
  "type": "League",
  "abstractKey": null
};
})();

(node as any).hash = "310e129dd7a98fa0af1026e86f935534";

export default node;
