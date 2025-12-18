using FantasyHOF.ESPN.Enums;
using FantasyHOF.Infrastructure.Enums;
using FantasyHOF.Infrastructure.Exceptions;
using System.Net;

namespace FantasyHOF.ESPN.Errors
{
    [Serializable]
    public class ESPNHttpException : CodedException
    {
        public ESPNHttpException(HttpStatusCode statusCode, string httpMessage) 
            : base(AppErrorCode.ESPNGeneralHttpError, $"Failed with Http status: {statusCode} and response data: {httpMessage}")
        {
        }
    }
}