using FantasyHOF.Infrastructure.Enums;

namespace FantasyHOF.Infrastructure.Exceptions
{
    public interface ICodedException
    {
        public AppErrorCode ErrorCode { get; }
        public string Message { get; }
    }

    public class CodedException(AppErrorCode errorCode, string message)
        : Exception(message), ICodedException
    {
        public AppErrorCode ErrorCode { get; private set; } = errorCode;
    }
}
