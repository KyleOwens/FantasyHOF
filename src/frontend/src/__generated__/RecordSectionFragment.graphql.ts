/**
 * @generated SignedSource<<26abf46b05608dba3036c2b3e2b43af2>>
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
  readonly sentiment: RecordSentiment;
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
      "kind": "ScalarField",
      "name": "sentiment",
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

(node as any).hash = "4e7a97a621e17190512e7d3b05c8dc13";

export default node;
