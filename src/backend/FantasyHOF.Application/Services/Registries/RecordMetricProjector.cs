using FantasyHOF.Application.Enums;
using FantasyHOF.Application.Types.Queries.Records;
using System.Linq.Expressions;

namespace FantasyHOF.Application.Services.Registries
{
    public class RecordMetricProjector<TEntity>(RecordTypeId recordType)
    {
        private readonly RecordMetadataAttribute _metadata = recordType.GetMetadata();
        private readonly RatioRecordMetadataAttribute? _ratioMetadata =
            recordType.GetMetadata().MetricType == RecordMetricType.Ratio ? recordType.GetRatioMetadta() : null;

        public Expression<Func<TEntity, decimal>> SortExpression => MetricSelectorRegistry<TEntity>.Selectors[_metadata.Metric];
        public SortDirection SortDirection => _metadata.SortDirection;

        public TEntity ExtractWinnerFromList(IEnumerable<TEntity> allStats)
        {
            IEnumerable<TEntity> filteredStats = ApplyFilter(allStats);
            Func<TEntity, decimal> valueSelector = MetricSelectorRegistry<TEntity>.GetCompiledSelector(_metadata.Metric);

            return _metadata.SortDirection == SortDirection.Ascending
                ? filteredStats.MinBy(valueSelector)!
                : filteredStats.MaxBy(valueSelector)!;
        }

        public IQueryable<TEntity> ApplySort(
            IQueryable<TEntity> baseQuery)
        {
            return SortDirection == SortDirection.Descending ?
                baseQuery.OrderByDescending(SortExpression) :
                baseQuery.OrderBy(SortExpression);
        }

        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> source)
        {
            var filterExpr = GetFilterExpression();

            if (filterExpr == null) return source;

            return source.Where(filterExpr);
        }

        public IEnumerable<TEntity> ApplyFilter(IEnumerable<TEntity> source)
        {
            if (GetFilterExpression() == null) return source;

            var compiled = MetricSelectorRegistry<TEntity>.GetCompiledFilter(_metadata.Metric);
            return source.Where(compiled);
        }

        private Expression<Func<TEntity, bool>>? GetFilterExpression()
        {
            var filters = MetricSelectorRegistry<TEntity>.Filters;

            if (filters == null) return null;
            if (!filters.TryGetValue(_metadata.Metric, out Expression<Func<TEntity, bool>>? filterExpression)) return null;

            return filterExpression;
        }

        public RecordMetric GetMetric(TEntity entity)
        {
            var mainVal = MetricSelectorRegistry<TEntity>.GetCompiledSelector(_metadata.Metric)(entity);

            if (_metadata.MetricType == RecordMetricType.Scalar)
                return new ScalarRecordMetric(mainVal, _metadata.Metric);

            return new RatioRecordMetric(
                _metadata.Metric,
                MetricSelectorRegistry<TEntity>.GetCompiledSelector(_ratioMetadata!.NumeratorMetric)(entity),
                _ratioMetadata.NumeratorMetric,
                MetricSelectorRegistry<TEntity>.GetCompiledSelector(_ratioMetadata.DenominatorMetric)(entity),
                _ratioMetadata.DenominatorMetric);
        }
    }
}
