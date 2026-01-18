/**
 * @generated SignedSource<<1d833f4acb6199975b306f6c6a36cf7e>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
export type RecordSentiment = "FAME" | "SHAME" | "%future added value";
import { FragmentRefs } from "relay-runtime";
export type RecordSectionFragment$data = ReadonlyArray<{
  readonly __typename: string;
  readonly metadata: {
    readonly sentiment: RecordSentiment;
  };
  readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment" | "PlayerRecordCardFragment" | "SeasonalRecordCardFragment" | "WeeklyRecordCardFragment">;
  readonly " $fragmentType": "RecordSectionFragment";
}>;
export type RecordSectionFragment$key = ReadonlyArray<{
  readonly " $data"?: RecordSectionFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"RecordSectionFragment">;
}>;

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": {
    "plural": true
  },
  "name": "RecordSectionFragment",
  "selections": [
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "__typename",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "concreteType": "RecordMetadata",
      "kind": "LinkedField",
      "name": "metadata",
      "plural": false,
      "selections": [
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "sentiment",
          "storageKey": null
        }
      ],
      "storageKey": null
    },
    {
      "kind": "InlineFragment",
      "selections": [
        {
          "args": null,
          "kind": "FragmentSpread",
          "name": "LeagueRecordCardFragment"
        }
      ],
      "type": "LeagueRecord",
      "abstractKey": null
    },
    {
      "kind": "InlineFragment",
      "selections": [
        {
          "args": null,
          "kind": "FragmentSpread",
          "name": "SeasonalRecordCardFragment"
        }
      ],
      "type": "SeasonalRecord",
      "abstractKey": null
    },
    {
      "kind": "InlineFragment",
      "selections": [
        {
          "args": null,
          "kind": "FragmentSpread",
          "name": "WeeklyRecordCardFragment"
        }
      ],
      "type": "WeeklyRecord",
      "abstractKey": null
    },
    {
      "kind": "InlineFragment",
      "selections": [
        {
          "args": null,
          "kind": "FragmentSpread",
          "name": "PlayerRecordCardFragment"
        }
      ],
      "type": "PlayerRecord",
      "abstractKey": null
    }
  ],
  "type": "Record",
  "abstractKey": "__isRecord"
};

(node as any).hash = "98b760dfa7c4b4724326050e01b382e8";

export default node;
