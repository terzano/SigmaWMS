#region License
//-----------------------------------------------------------------------
// <copyright file="NLogLogger.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
using NLog;
#endregion

namespace Sigma.Core
{
    public class NLogLogger : ILogger
    {
        private readonly Logger _logger;

        public NLogLogger()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Info(string message, params object[] args)
        {
            if (IsInfoEnabled)
            {
                Write(LogLevel.Info, message, args);
            }
        }

        public void Warn(string message, params object[] args)
        {
            if (IsWarnEnabled)
            {
                Write(LogLevel.Warn, message, args);
            }
        }

        public void Debug(string message, params object[] args)
        {
            if (IsDebugEnabled)
            {
                Write(LogLevel.Debug, message, args);
            }
        }

        public void Error(string message, params object[] args)
        {
            if (IsErrorEnabled)
            {
                Write(LogLevel.Error, message, args);
            }
        }
        public void Error(Exception x)
        {
            if (IsErrorEnabled)
            {
                Write(LogLevel.Error, LogUtility.BuildExceptionMessage(x));
            }
        }
        public void Fatal(string message, params object[] args)
        {
            if (IsFatalEnabled)
            {
                Write(LogLevel.Fatal, message, args);
            }
        }
        public void Fatal(Exception x)
        {
            if (IsFatalEnabled)
            {
                Write(LogLevel.Fatal, LogUtility.BuildExceptionMessage(x));
            }
        }

        public bool IsDebugEnabled
        {
            get { return _logger.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return _logger.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return _logger.IsFatalEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return _logger.IsInfoEnabled; }
        }

        public bool IsTraceEnabled
        {
            get { return _logger.IsTraceEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return _logger.IsWarnEnabled; }
        }

        private void Write(LogLevel level, string format, params object[] args)
        {
            LogEventInfo le = new LogEventInfo(level, _logger.Name, null, format, args);
            _logger.Log(typeof(NLogLogger), le);
        }
    }
}