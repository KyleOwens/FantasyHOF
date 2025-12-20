using FantasyHOF.Domain.ComplexIds;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.TypeConverters
{
    public static class RegisterConvertersExtension
    {
        public static IRequestExecutorBuilder AddFantasyHOFTypeConverters(this IRequestExecutorBuilder builder)
        {
            //builder.BindRuntimeType<LeagueSeasonMemberId, string>();
            builder.AddTypeConverter<LeagueSeasonMemberId, string>(test);
            builder.AddTypeConverter<string, LeagueSeasonMemberId>(LeagueSeasonMemberId.Parse);

            return builder;
        }

        public static string test(LeagueSeasonMemberId id)
        {
            return id.ToString();
        }
    }
}
