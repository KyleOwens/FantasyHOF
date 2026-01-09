/**
 * @generated SignedSource<<2bbe5cdf903b76a356b28934d39e3992>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type AppSidebarDataFragment$data = ReadonlyArray<{
  readonly " $fragmentSpreads": FragmentRefs<"LeagueNavigationFragment">;
  readonly " $fragmentType": "AppSidebarDataFragment";
}>;
export type AppSidebarDataFragment$key = ReadonlyArray<{
  readonly " $data"?: AppSidebarDataFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"AppSidebarDataFragment">;
}>;

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": {
    "plural": true
  },
  "name": "AppSidebarDataFragment",
  "selections": [
    {
      "args": null,
      "kind": "FragmentSpread",
      "name": "LeagueNavigationFragment"
    }
  ],
  "type": "League",
  "abstractKey": null
};

(node as any).hash = "c9429655e450a7cfe94f6d1c49c201b2";

export default node;
