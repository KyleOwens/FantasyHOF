/**
 * @generated SignedSource<<122376288af171f740fefe19cd33f968>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type AppSidebarMetadataFragment$data = {
  readonly " $fragmentSpreads": FragmentRefs<"RecordNavigationFragment">;
  readonly " $fragmentType": "AppSidebarMetadataFragment";
};
export type AppSidebarMetadataFragment$key = {
  readonly " $data"?: AppSidebarMetadataFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"AppSidebarMetadataFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "AppSidebarMetadataFragment",
  "selections": [
    {
      "args": null,
      "kind": "FragmentSpread",
      "name": "RecordNavigationFragment"
    }
  ],
  "type": "Query",
  "abstractKey": null
};

(node as any).hash = "7a47615488365ed5c2e00d993dbe13e3";

export default node;
