/**
 * @generated SignedSource<<8a4a7b5092818b18c93dfe306b25365e>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueNavigationProviderFragment$data = {
  readonly fantasyProviders: ReadonlyArray<{
    readonly " $fragmentSpreads": FragmentRefs<"ProviderSelectionFragment">;
  }>;
  readonly " $fragmentType": "LeagueNavigationProviderFragment";
};
export type LeagueNavigationProviderFragment$key = {
  readonly " $data"?: LeagueNavigationProviderFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationProviderFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "LeagueNavigationProviderFragment",
  "selections": [
    {
      "alias": null,
      "args": null,
      "concreteType": "FantasyProvider",
      "kind": "LinkedField",
      "name": "fantasyProviders",
      "plural": true,
      "selections": [
        {
          "args": null,
          "kind": "FragmentSpread",
          "name": "ProviderSelectionFragment"
        }
      ],
      "storageKey": null
    }
  ],
  "type": "Query",
  "abstractKey": null
};

(node as any).hash = "840db7af9e8106d2d6d49283ec244542";

export default node;
