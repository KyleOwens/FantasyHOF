using FantasyHOF.Infrastructure.Exceptions;

namespace FantasyHOF.ApplicationExtensions
{
    public static class AddFantasyHOFGraphQLExtension
    {
        public static WebApplicationBuilder AddFantasyHOFGraphQL(this WebApplicationBuilder builder)
        {
            builder.AddGraphQL()
                .AddAuthorization()
                .AddFantasyHOFTypes()
                .AddGlobalObjectIdentification()
                .AddMutationConventions(applyToAllMutations: true)
                .AddErrorInterfaceType<ICodedException>()
                .AddInMemorySubscriptions();

            return builder;
        }
    }
}
