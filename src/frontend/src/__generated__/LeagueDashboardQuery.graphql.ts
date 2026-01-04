/**
 * @generated SignedSource<<84019ed0a6ab5e757584b8209cde815a>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type LeagueDashboardQuery$variables = {
  leagueId: string;
};
export type LeagueDashboardQuery$data = {
  readonly league: {
    readonly currentLeagueName: string;
    readonly recordSummary: {
      readonly highestChampionshipPercentageLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly highestLastPlacePercentageLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly highestLosingRecordPercentageLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly highestPercentageLowestWeeklyScoresLeagueHisotry: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly highestPercentageTopWeeklyScoresLeagueHisotry: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly highestWinPercentageLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly highestWinningRecordPercentageLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly leastAveragePointsAllowedPerWeekLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly leastAveragePointsPerWeekLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly leastLossesLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly leastPointsAllowedLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly leastPointsLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly leastWinsLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly lowestWinPercentageLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostAveragePointsAllowedPerWeekLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostAveragePointsPerWeekLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostBlowoutLossesLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostBlowoutWinsLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostChampionshipsLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostLastPlacesLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostLossesLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostLowestWeeklyScoresLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostNarrowLossesLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostNarrowWinsLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostOutstandingPerformancesLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostPointsAllowedLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostPointsLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostPoorPerformancesLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostSeasonsLosingRecordLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostSeasonsWinningRecordLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostTopWeeklyScoresLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
      readonly mostWinsLeagueHistory: {
        readonly " $fragmentSpreads": FragmentRefs<"LeagueRecordCardFragment">;
      };
    } | null | undefined;
  };
};
export type LeagueDashboardQuery = {
  response: LeagueDashboardQuery$data;
  variables: LeagueDashboardQuery$variables;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "leagueId"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "id",
    "variableName": "leagueId"
  }
],
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "currentLeagueName",
  "storageKey": null
},
v3 = [
  {
    "args": null,
    "kind": "FragmentSpread",
    "name": "LeagueRecordCardFragment"
  }
],
v4 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v5 = [
  {
    "alias": null,
    "args": null,
    "kind": "ScalarField",
    "name": "value",
    "storageKey": null
  },
  {
    "alias": null,
    "args": null,
    "concreteType": "FantasyMember",
    "kind": "LinkedField",
    "name": "member",
    "plural": false,
    "selections": [
      (v4/*: any*/),
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "firstName",
        "storageKey": null
      },
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "lastName",
        "storageKey": null
      }
    ],
    "storageKey": null
  }
];
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "LeagueDashboardQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "League",
        "kind": "LinkedField",
        "name": "league",
        "plural": false,
        "selections": [
          (v2/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "LeagueRecordSummary",
            "kind": "LinkedField",
            "name": "recordSummary",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostPointsLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostAveragePointsPerWeekLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastPointsAllowedLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastAveragePointsAllowedPerWeekLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostWinsLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastLossesLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestWinPercentageLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostTopWeeklyScoresLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestPercentageTopWeeklyScoresLeagueHisotry",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostBlowoutWinsLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostNarrowWinsLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostChampionshipsLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestChampionshipPercentageLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostSeasonsWinningRecordLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestWinningRecordPercentageLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostOutstandingPerformancesLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastPointsLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastAveragePointsPerWeekLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostPointsAllowedLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostAveragePointsAllowedPerWeekLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastWinsLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostLossesLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "lowestWinPercentageLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostLowestWeeklyScoresLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestPercentageLowestWeeklyScoresLeagueHisotry",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostBlowoutLossesLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostNarrowLossesLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostLastPlacesLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestLastPlacePercentageLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostSeasonsLosingRecordLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestLosingRecordPercentageLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostPoorPerformancesLeagueHistory",
                "plural": false,
                "selections": (v3/*: any*/),
                "storageKey": null
              }
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "LeagueDashboardQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "League",
        "kind": "LinkedField",
        "name": "league",
        "plural": false,
        "selections": [
          (v2/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "LeagueRecordSummary",
            "kind": "LinkedField",
            "name": "recordSummary",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostPointsLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostAveragePointsPerWeekLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastPointsAllowedLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastAveragePointsAllowedPerWeekLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostWinsLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastLossesLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestWinPercentageLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostTopWeeklyScoresLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestPercentageTopWeeklyScoresLeagueHisotry",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostBlowoutWinsLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostNarrowWinsLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostChampionshipsLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestChampionshipPercentageLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostSeasonsWinningRecordLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestWinningRecordPercentageLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostOutstandingPerformancesLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastPointsLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastAveragePointsPerWeekLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostPointsAllowedLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostAveragePointsAllowedPerWeekLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "leastWinsLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostLossesLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "lowestWinPercentageLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostLowestWeeklyScoresLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestPercentageLowestWeeklyScoresLeagueHisotry",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostBlowoutLossesLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostNarrowLossesLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostLastPlacesLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestLastPlacePercentageLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostSeasonsLosingRecordLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "highestLosingRecordPercentageLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "concreteType": "LeagueValueRecord",
                "kind": "LinkedField",
                "name": "mostPoorPerformancesLeagueHistory",
                "plural": false,
                "selections": (v5/*: any*/),
                "storageKey": null
              }
            ],
            "storageKey": null
          },
          (v4/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "4d7ecdaa05c9eff13b66054a343f6dbd",
    "id": null,
    "metadata": {},
    "name": "LeagueDashboardQuery",
    "operationKind": "query",
    "text": "query LeagueDashboardQuery(\n  $leagueId: ID!\n) {\n  league(id: $leagueId) {\n    currentLeagueName\n    recordSummary {\n      mostPointsLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostAveragePointsPerWeekLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      leastPointsAllowedLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      leastAveragePointsAllowedPerWeekLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostWinsLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      leastLossesLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      highestWinPercentageLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostTopWeeklyScoresLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      highestPercentageTopWeeklyScoresLeagueHisotry {\n        ...LeagueRecordCardFragment\n      }\n      mostBlowoutWinsLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostNarrowWinsLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostChampionshipsLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      highestChampionshipPercentageLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostSeasonsWinningRecordLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      highestWinningRecordPercentageLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostOutstandingPerformancesLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      leastPointsLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      leastAveragePointsPerWeekLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostPointsAllowedLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostAveragePointsAllowedPerWeekLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      leastWinsLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostLossesLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      lowestWinPercentageLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostLowestWeeklyScoresLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      highestPercentageLowestWeeklyScoresLeagueHisotry {\n        ...LeagueRecordCardFragment\n      }\n      mostBlowoutLossesLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostNarrowLossesLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostLastPlacesLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      highestLastPlacePercentageLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostSeasonsLosingRecordLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      highestLosingRecordPercentageLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n      mostPoorPerformancesLeagueHistory {\n        ...LeagueRecordCardFragment\n      }\n    }\n    id\n  }\n}\n\nfragment LeagueRecordCardFragment on LeagueValueRecord {\n  value\n  member {\n    id\n    firstName\n    lastName\n  }\n}\n"
  }
};
})();

(node as any).hash = "2ded726bea6f7de66c527b694c2cf8db";

export default node;
