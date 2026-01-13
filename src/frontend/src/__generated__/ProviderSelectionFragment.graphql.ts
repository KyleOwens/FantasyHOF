/**
 * @generated SignedSource<<9c6c03d2b0e356a92e93c98f0591200d>>
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
  readonly id: string;
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
      "name": "id",
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

(node as any).hash = "a445a8b16c5044a8c4f5c07f3e59ab67";

export default node;
