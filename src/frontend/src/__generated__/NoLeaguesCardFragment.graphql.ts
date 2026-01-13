/**
 * @generated SignedSource<<92663d8653e8285eb96e91183edefdb2>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type NoLeaguesCardFragment$data = {
  readonly fantasyProviders: ReadonlyArray<{
    readonly logoURL: string;
    readonly name: string;
    readonly " $fragmentSpreads": FragmentRefs<"ProviderSelectionFragment">;
  }>;
  readonly " $fragmentType": "NoLeaguesCardFragment";
};
export type NoLeaguesCardFragment$key = {
  readonly " $data"?: NoLeaguesCardFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"NoLeaguesCardFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "NoLeaguesCardFragment",
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
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "logoURL",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "name",
          "storageKey": null
        },
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

(node as any).hash = "069b4b1569c24a1ee66fff6f46a7fe46";

export default node;
