using FantasyHOF.Application.Enums;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace FantasyHOF.Application.Services.Registries
{
    public static class MetricSelectorRegistry<TEntity>
    {
        private static IReadOnlyDictionary<RecordMetricId, Expression<Func<TEntity, decimal>>>? _selectors;
        private static IReadOnlyDictionary<RecordMetricId, Expression<Func<TEntity, bool>>>? _filters;

        private static readonly ConcurrentDictionary<RecordMetricId, Func<TEntity, decimal>> _compiledSelectorCache = new();
        private static readonly ConcurrentDictionary<RecordMetricId, Func<TEntity, bool>> _compiledFilterCache = new();

        public static IReadOnlyDictionary<RecordMetricId, Expression<Func<TEntity, decimal>>> Selectors
        {
            get => _selectors ?? throw new InvalidOperationException($"Selectors for {typeof(TEntity).Name} not registered.");
            set => _selectors = value;
        }

        public static IReadOnlyDictionary<RecordMetricId, Expression<Func<TEntity, bool>>>? Filters
        {
            get => _filters;
            set => _filters = value;
        }

        public static Func<TEntity, decimal> GetCompiledSelector(RecordMetricId id) =>
            _compiledSelectorCache.GetOrAdd(id, key => Selectors[key].Compile());

        public static Func<TEntity, bool> GetCompiledFilter(RecordMetricId id) =>
            _compiledFilterCache.GetOrAdd(id, key => Filters![key].Compile());
    }
}
