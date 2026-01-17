using FantasyHOF.Infrastructure.Exceptions;


namespace FantasyHOF.ApplicationBuilderExtensions
{
    public static class AddFantasyHOFGraphQLExtension
    {
        public static async Task<WebApplicationBuilder> AddFantasyHOFGraphQL(this WebApplicationBuilder builder)
        {
            builder.AddGraphQL()
                .AddFantasyHOFTypes()
                .AddAuthorization()
                .AddGlobalObjectIdentification()
                .AddMutationConventions(applyToAllMutations: true)
                .AddErrorInterfaceType<ICodedException>()
                .AddInMemorySubscriptions();

            return builder;
        }
    }
}
