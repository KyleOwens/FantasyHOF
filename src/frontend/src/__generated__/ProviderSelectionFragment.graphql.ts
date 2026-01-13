/**
 * @generated SignedSource<<093edf8d15757c5e95fe8286f1783c56>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
export type FantasyProviderId = "ESPN" | "NFL" | "SLEEPER" | "YAHOO" | "%future added value";
import { FragmentRefs } from "relay-runtime";
export type ProviderSelectionFragment$data = ReadonlyArray<{
  readonly logoURL: string;
  readonly name: string;
  readonly value: FantasyProviderId;
  readonly " $fragmentType": "ProviderSelectionFragment";
}>;
export type ProviderSelectionFragment$key = ReadonlyArray<{
  readonly " $data"?: ProviderSelectionFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"ProviderSelectionFragment">;
}>;

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": {
    "plural": true
  },
  "name": "ProviderSelectionFragment",
  "selections": [
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
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "value",
      "storageKey": null
    }
  ],
  "type": "FantasyProvider",
  "abstractKey": null
};

(node as any).hash = "68d9933279cc148354bf4ec0fe1ad3a1";

export default node;
