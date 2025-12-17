using FantasyHOF.ESPN.Enums;
using FantasyHOF.Infrastructure.Exceptions;
using System.Net;

namespace FantasyHOF.ESPN.Errors
{
    [Serializable]
    internal class ESPNHttpException : CodedException<ESPNErrorCode>
    {
        public ESPNHttpException(HttpStatusCode statusCode, string httpMessage) 
            : base(ESPNErrorCode.GeneralHttpError, $"Failed with Http status: {statusCode} and response data: {httpMessage}")
        {
        }
    }
}