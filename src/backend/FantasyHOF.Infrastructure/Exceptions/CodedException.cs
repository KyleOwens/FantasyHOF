using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Infrastructure.Exceptions
{
    public interface ICodedException
    {
        object GetCode();
    }
    
    public class CodedException<TCodeEnum>(TCodeEnum errorCode, string message) : Exception(message), ICodedException where TCodeEnum : Enum
    {
        public TCodeEnum ErrorCode { get; private set; } = errorCode;

        public object GetCode() => ErrorCode;
    }
}
