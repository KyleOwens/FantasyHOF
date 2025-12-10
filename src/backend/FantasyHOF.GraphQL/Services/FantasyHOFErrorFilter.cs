using FantasyHOF.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Services
{
    public class FantasyHOFErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception == null) return error;
            if (error.Exception is not ICodedException codedException) return error;

            Enum codeEnum = (Enum)codedException.GetCode();

            return error.WithMessage(error.Exception.Message)
                .WithCode(codeEnum.ToString())
                .SetExtension("errorCode", FormatGraphQLEnumName(codeEnum));
        }

        private string FormatGraphQLEnumName(Enum unformattedEnum)
        {
            string enumName = unformattedEnum.ToString();
            StringBuilder sb = new StringBuilder();

            foreach (char c in enumName)
            {
                if (char.IsUpper(c) && sb.Length > 0)
                    sb.Append('_');

                sb.Append(char.ToUpperInvariant(c));
            }

            return sb.ToString();
        }
    }
}
