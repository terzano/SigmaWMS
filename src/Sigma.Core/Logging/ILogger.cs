using System;

namespace Sigma.Core
{
    public interface ILogger
    {
        void Info(string message, params object[] args);
        void Warn(string message, params object[] args);
        void Debug(string message, params object[] args);
        void Error(string message, params object[] args);
        void Error(Exception x);
        void Fatal(string message, params object[] args);
        void Fatal(Exception x);

        bool IsDebugEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsTraceEnabled { get; }
        bool IsWarnEnabled { get; }
    }
}
