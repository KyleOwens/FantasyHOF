import { createColumnHelper } from "@tanstack/react-table";
import { graphql } from "relay-runtime";
import { RecordDetailsTableFragment$key } from "@/__generated__/RecordDetailsTableFragment.graphql";
import { useFragment, usePaginationFragment } from "react-relay";
import {
  flexRender,
  getCoreRowModel,
  useReactTable,
  getSortedRowModel,
  SortingState,
} from "@tanstack/react-table";

import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { useMemo, useState } from "react";
import { RankCell } from "./RankCell";
import { MemberCell } from "./MemberCell";
import { MemberCellFragment$key } from "@/__generated__/MemberCellFragment.graphql";
import { MemberTenureCell } from "./MemberTenureCell";
import { MemberTenureCellFragment$key } from "@/__generated__/MemberTenureCellFragment.graphql";
import { RecordValueCell } from "./RecordValueCell";
import { RecordValueCellFragment$key } from "@/__generated__/RecordValueCellFragment.graphql";
import { RatioBreakdownCell } from "./RatioBreakdownCell";
import { RatioBreakdownCellFragment$key } from "@/__generated__/RatioBreakdownCellFragment.graphql";
import { PlayerCell } from "./PlayerCell";
import { PlayerCellFragment$key } from "@/__generated__/PlayerCellFragment.graphql";
import {
  RecordDetailsTableRefetchableEntryFragment$data,
  RecordDetailsTableRefetchableEntryFragment$key,
} from "@/__generated__/RecordDetailsTableRefetchableEntryFragment.graphql";
import { RecordDetailsRefetchableEntryQuery } from "@/__generated__/RecordDetailsRefetchableEntryQuery.graphql";
import { InfiniteScrollTrigger } from "../shared/InfiniteScrollTrigger";

type Props = {
  recordDetailsKey: RecordDetailsTableFragment$key;
};

const recordDetailsTableFragment = graphql`
  fragment RecordDetailsTableFragment on RecordDetails {
    metadata {
      unit
      category
      metricType
    }
    ...RecordDetailsTableRefetchableEntryFragment
  }
`;

const recordDetailsRefetchableEntryFragment = graphql`
  fragment RecordDetailsTableRefetchableEntryFragment on RecordDetails
  @refetchable(queryName: "RecordDetailsRefetchableEntryQuery")
  @argumentDefinitions(
    cursor: { type: "String" }
    count: { type: "Int", defaultValue: 20 }
  ) {
    entries(after: $cursor, first: $count)
      @connection(key: "recordDetails_entries") {
      edges {
        cursor
        node {
          key
          rank
          metric {
            value
            unit
            ... on RatioRecordMetric {
              numerator
              numeratorUnit
              denominator
              denominatorUnit
            }
          }
          __typename
          ... on SeasonalRecordEntry {
            year
          }
          ... on WeeklyRecordEntry {
            year
            week
          }
          ... on PlayerRecordEntry {
            year
            week
            player {
              fullName
            }
          }
          ...RecordValueCellFragment
          ...MemberCellFragment
          ...MemberTenureCellFragment
          ...RatioBreakdownCellFragment
          ...PlayerCellFragment
        }
      }
    }
  }
`;

type RecordEntryNode = NonNullable<
  NonNullable<
    NonNullable<
      RecordDetailsTableRefetchableEntryFragment$data["entries"]
    >["edges"]
  >[number]
>["node"];

export type RecordEntry = RecordEntryNode &
  MemberCellFragment$key &
  MemberTenureCellFragment$key &
  RecordValueCellFragment$key &
  RatioBreakdownCellFragment$key &
  PlayerCellFragment$key;

const columnHelper = createColumnHelper<RecordEntry>();

const PAGE_SIZE = 20;

export function RecordDetailsTable({ recordDetailsKey }: Props) {
  const details = useFragment(recordDetailsTableFragment, recordDetailsKey);
  const { data, hasNext, loadNext, isLoadingNext } = usePaginationFragment<
    RecordDetailsRefetchableEntryQuery,
    RecordDetailsTableRefetchableEntryFragment$key
  >(recordDetailsRefetchableEntryFragment, details);

  const tableData = useMemo(() => {
    return data.entries?.edges?.map((edge) => edge?.node) ?? [];
  }, [data.entries?.edges]);

  const [sorting, setSorting] = useState<SortingState>([]);

  const columns = useMemo(() => {
    const allColumns = [
      columnHelper.display({
        id: "rank",
        size: 20,
        maxSize: 10,
        header: () => <span className="pl-4">Rank</span>,
        cell: ({ row }) => <RankCell rowNumber={row.index + 1} />,
      }),
      columnHelper.display({
        id: "member",
        header: "Record Holder",
        cell: ({ row }) => <MemberCell entryKey={row.original} />,
      }),
    ];

    const tenureColumn = columnHelper.display({
      id: "tenure",
      header: "Tenure",
      cell: ({ row }) => <MemberTenureCell entryKey={row.original} />,
    });

    const playerColumn = columnHelper.display({
      id: "player",
      header: "Player",
      cell: ({ row }) => <PlayerCell entryKey={row.original} />,
    });

    const weekColumn = columnHelper.display({
      id: "week",
      header: () => <div className="text-center">Week</div>,
      cell: ({ row }) => (
        <div className="font-medium text-center">{row.original.week}</div>
      ),
    });

    const seasonColumn = columnHelper.display({
      id: "season",
      header: () => <div className="text-center">Season</div>,
      cell: ({ row }) => (
        <div className="font-medium text-center">{row.original.year}</div>
      ),
    });

    const ratioColumn = columnHelper.display({
      id: "ratio-breakdown",
      header: "Breakdown",
      cell: ({ row }) => <RatioBreakdownCell entryKey={row.original} />,
    });

    const vauleColumn = columnHelper.display({
      id: "record.value",
      header: () => (
        <div className="text-right capitalize pr-4">
          {details.metadata.metricType === "RATIO"
            ? "Frequency"
            : details.metadata.unit}
        </div>
      ),
      cell: ({ row }) => (
        <RecordValueCell entryKey={row.original} rowNumber={row.index + 1} />
      ),
    });

    const category = details.metadata.category;

    if (category === "LEAGUE") {
      allColumns.push(tenureColumn);
      if (details.metadata.metricType === "RATIO") allColumns.push(ratioColumn);
    } else if (category === "SEASON") {
      allColumns.push(tenureColumn);
      allColumns.push(seasonColumn);
    } else if (category === "WEEK") {
      allColumns.push(tenureColumn);
      allColumns.push(weekColumn);
      allColumns.push(seasonColumn);
    } else if (category === "PLAYER") {
      allColumns.push(playerColumn);
      allColumns.push(weekColumn);
      allColumns.push(seasonColumn);
    }

    allColumns.push(vauleColumn);

    return allColumns;
  }, [details, columnHelper]);

  const table = useReactTable({
    data: tableData,
    columns,
    getCoreRowModel: getCoreRowModel(),
    onSortingChange: setSorting,
    getSortedRowModel: getSortedRowModel(),
    state: {
      sorting,
    },
  });

  return (
    <div className="py-8 mx-auto">
      <div className="rounded-md border bg-card shadow-sm">
        <Table>
          <TableHeader className="bg-muted/50">
            {table.getHeaderGroups().map((headerGroup) => (
              <TableRow key={headerGroup.id}>
                {headerGroup.headers.map((header) => (
                  <TableHead
                    style={{ width: `${header.getSize()}px` }}
                    key={header.id}
                  >
                    {header.isPlaceholder
                      ? null
                      : flexRender(
                          header.column.columnDef.header,
                          header.getContext(),
                        )}
                  </TableHead>
                ))}
              </TableRow>
            ))}
          </TableHeader>
          <TableBody>
            {table.getRowModel().rows?.length ? (
              table.getRowModel().rows.map((row) => {
                const isFirst = row.index + 1 === 1;
                return (
                  <TableRow
                    key={row.id}
                    className={`group transition-all ${isFirst && "bg-emerald-50"}`}
                  >
                    {row.getVisibleCells().map((cell) => (
                      <TableCell
                        key={cell.id}
                        className={isFirst ? "py-6" : "py-4"}
                      >
                        {flexRender(
                          cell.column.columnDef.cell,
                          cell.getContext(),
                        )}
                      </TableCell>
                    ))}
                  </TableRow>
                );
              })
            ) : (
              <></>
            )}
          </TableBody>
        </Table>
      </div>
      <InfiniteScrollTrigger
        hasNext={hasNext}
        isLoadingNext={isLoadingNext}
        onEndReached={() => loadNext(PAGE_SIZE)}
      />
    </div>
  );
}
