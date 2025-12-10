using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FantasyHOF.Infrastructure.Extensions
{
    public static class URIBuilderExtensions
    {
        public static void AddQueryParameter(this UriBuilder builder, string property, string value)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(builder.Query);

            query.Add(property, value);

            builder.Query = query.ToString();
        }
    }
}
