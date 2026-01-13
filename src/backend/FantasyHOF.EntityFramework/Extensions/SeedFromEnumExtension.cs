using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Extensions
{
    internal static class SeedFromEnumExtension
    {
        internal static EntityTypeBuilder<TEntity> SeedFromEnum<TEnum, TEntity>(this EntityTypeBuilder<TEntity> builder, Func<TEnum, TEntity> factory)
            where TEnum : Enum
            where TEntity : class
        {
            var values = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(factory)
                .ToArray();

            builder.HasData(values);

            return builder;
        }
    }
}
