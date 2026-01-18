/**
 * @generated SignedSource<<efe2edd0499e18488d134f4862dbbd03>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from 'relay-runtime';
export type RecordSentiment = "FAME" | "SHAME" | "%future added value";
export type RecordTypeId = "HIGHEST_CHAMPIONSHIP_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_LAST_PLACE_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_LOSING_RECORD_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_PERCENTAGE_LOWEST_WEEKLY_SCORES_LEAGUE_HISTORY" | "HIGHEST_PERCENTAGE_TOP_WEEKLY_SCORES_LEAGUE_HISTORY" | "HIGHEST_SCORING_LOSS_SINGLE_WEEK" | "HIGHEST_WINNING_RECORD_PERCENTAGE_LEAGUE_HISTORY" | "HIGHEST_WIN_PERCENTAGE_LEAGUE_HISTORY" | "LARGEST_MARGIN_OF_VICTORY_SINGLE_PLAYOFF_WEEK" | "LARGEST_MARGIN_OF_VICTORY_SINGLE_WEEK" | "LEAST_AVERAGE_POINTS_ALLOWED_PER_WEEK_LEAGUE_HISTORY" | "LEAST_AVERAGE_POINTS_PER_WEEK_LEAGUE_HISTORY" | "LEAST_LOSSES_LEAGUE_HISTORY" | "LEAST_POINTS_ALLOWED_LEAGUE_HISTORY" | "LEAST_POINTS_ALLOWED_PER_WEEK_SINGLE_SEASON" | "LEAST_POINTS_ALLOWED_SINGLE_SEASON" | "LEAST_POINTS_LEAGUE_HISTORY" | "LEAST_POINTS_PER_WEEK_SINGLE_SEASON" | "LEAST_POINTS_SCORED_SINGLE_NON_DEFENSE_PLAYER" | "LEAST_POINTS_SCORED_SINGLE_PLAYER" | "LEAST_POINTS_SINGLE_PLAYOFF_WEEK" | "LEAST_POINTS_SINGLE_SEASON" | "LEAST_POINTS_SINGLE_WEEK" | "LEAST_WINS_LEAGUE_HISTORY" | "LOWEST_MARGIN_OF_VICTORY_SINGLE_PLAYOFF_WEEK" | "LOWEST_MARGIN_OF_VICTORY_SINGLE_WEEK" | "LOWEST_SCORING_WIN_SINGLE_WEEK" | "LOWEST_WIN_PERCENTAGE_LEAGUE_HISTORY" | "MOST_AVERAGE_POINTS_ALLOWED_PER_WEEK_LEAGUE_HISTORY" | "MOST_AVERAGE_POINTS_PER_WEEK_LEAGUE_HISTORY" | "MOST_BLOWOUT_LOSSES_LEAGUE_HISTORY" | "MOST_BLOWOUT_LOSSES_SINGLE_SEASON" | "MOST_BLOWOUT_WINS_LEAGUE_HISTORY" | "MOST_BLOWOUT_WINS_SINGLE_SEASON" | "MOST_CHAMPIONSHIPS_LEAGUE_HISTORY" | "MOST_HIGHEST_SCORING_WEEKS_SINGLE_SEASON" | "MOST_LAST_PLACES_LEAGUE_HISTORY" | "MOST_LOSSES_LEAGUE_HISTORY" | "MOST_LOSSES_SINGLE_SEASON" | "MOST_LOWEST_SCORING_WEEKS_SINGLE_SEASON" | "MOST_LOWEST_WEEKLY_SCORES_LEAGUE_HISTORY" | "MOST_NARROW_LOSSES_LEAGUE_HISTORY" | "MOST_NARROW_LOSSES_SINGLE_SEASON" | "MOST_NARROW_WINS_LEAGUE_HISTORY" | "MOST_NARROW_WINS_SINGLE_SEASON" | "MOST_OUTSTANDING_PERFORMANCES_LEAGUE_HISTORY" | "MOST_OUTSTANDING_PERFORMANCES_SINGLE_SEASON" | "MOST_POINTS_ALLOWED_LEAGUE_HISTORY" | "MOST_POINTS_ALLOWED_PER_WEEK_SINGLE_SEASON" | "MOST_POINTS_ALLOWED_SINGLE_SEASON" | "MOST_POINTS_LEAGUE_HISTORY" | "MOST_POINTS_PER_WEEK_SINGLE_SEASON" | "MOST_POINTS_SCORED_SINGLE_NON_QB_PLAYER" | "MOST_POINTS_SCORED_SINGLE_PLAYER" | "MOST_POINTS_SINGLE_PLAYOFF_WEEK" | "MOST_POINTS_SINGLE_SEASON" | "MOST_POINTS_SINGLE_WEEK" | "MOST_POOR_PERFORMANCES_LEAGUE_HISTORY" | "MOST_POOR_PERFORMANCES_SINGLE_SEASON" | "MOST_SEASONS_LOSING_RECORD_LEAGUE_HISTORY" | "MOST_SEASONS_WINNING_RECORD_LEAGUE_HISTORY" | "MOST_TOP_WEEKLY_SCORES_LEAGUE_HISTORY" | "MOST_WINS_LEAGUE_HISTORY" | "MOST_WINS_SINGLE_SEASON" | "%future added value";
import { FragmentRefs } from "relay-runtime";
export type RecordNavigationFragment$data = {
  readonly recordMetadata: ReadonlyArray<{
    readonly categoryDisplayName: string;
    readonly displayName: string;
    readonly recordTypeId: RecordTypeId;
    readonly sentiment: RecordSentiment;
  }>;
  readonly " $fragmentType": "RecordNavigationFragment";
};
export type RecordNavigationFragment$key = {
  readonly " $data"?: RecordNavigationFragment$data;
  readonly " $fragmentSpreads": FragmentRefs<"RecordNavigationFragment">;
};

const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "RecordNavigationFragment",
  "selections": [
    {
      "alias": null,
      "args": null,
      "concreteType": "RecordMetadata",
      "kind": "LinkedField",
      "name": "recordMetadata",
      "plural": true,
      "selections": [
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "recordTypeId",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "displayName",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "categoryDisplayName",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "sentiment",
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "Query",
  "abstractKey": null
};

(node as any).hash = "f0df0ceb16bfa4d0809190a4baa771e8";

export default node;
