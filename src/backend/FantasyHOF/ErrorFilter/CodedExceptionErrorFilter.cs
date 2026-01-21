using FantasyHOF.Infrastructure.Exceptions;

namespace FantasyHOF.ErrorFilter
{
    public class CodedExceptionErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is not ICodedException codedException) return error;

            return ErrorBuilder
                .FromError(error)
                .SetMessage(codedException.Message)
                .SetCode(codedException.ErrorCode.ToString())
                .Build();
        }
    }
}
