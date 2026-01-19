/**
 * @generated SignedSource<<a43c44106b97ae3cb39eb1adf8eff0f0>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
export type LeagueImportStatusId = "COMPLETED" | "FAILED" | "FORMATTING_DATA" | "LOADING_SEASONAL_DATA" | "LOADING_WEEKLYL_DATA" | "QUEUED" | "SAVING_DATA" | "SAVING_MATCHUPS" | "SAVING_MEMBERS" | "SAVING_MISCELLANEOUS_DATA" | "SAVING_ROSTERS" | "SAVING_SEASONS" | "SAVING_STATS" | "SAVING_TEAMS" | "%future added value";
import { FragmentRefs } from "relay-runtime";
export type PendingLeagueCardFragment$data = {
  readonly error: string | null | undefined;
  readonly id: string;
  readonly progress: number;
  readonly provider: {
    readonly id: string;
    readonly logoURL: string;
    readonly name: string;
  };
  readonly providerleagueId: string;
  readonly status: {
    readonly id: string;
    readonly name: string;
    readonly value: LeagueImportStatusId;
  };
  readonly " $fragmentType": "PendingLeagueCardFragment";
};
export type PendingLeagueCardFragment$key = {
  readonly " $data"?: PendingLeagueCardFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"PendingLeagueCardFragment">;
};

const node: ReaderFragment = (function(){
var v0 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v1 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "name",
  "storageKey": null
};
return {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "PendingLeagueCardFragment",
  "selections": [
    (v0/*: any*/),
    {
      "alias": null,
      "args": null,
      "concreteType": "FantasyProvider",
      "kind": "LinkedField",
      "name": "provider",
      "plural": false,
      "selections": [
        (v0/*: any*/),
        (v1/*: any*/),
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
      "concreteType": "LeagueImportStatus",
      "kind": "LinkedField",
      "name": "status",
      "plural": false,
      "selections": [
        (v0/*: any*/),
        (v1/*: any*/),
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "value",
          "storageKey": null
        }
      ],
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "progress",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "error",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "providerleagueId",
      "storageKey": null
    }
  ],
  "type": "LeagueImport",
  "abstractKey": null
};
})();

(node as any).hash = "6a5627fe34fbafee5f831561e557592f";

export default node;
