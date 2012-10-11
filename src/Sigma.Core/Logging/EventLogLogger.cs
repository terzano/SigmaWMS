#region License
//-----------------------------------------------------------------------
// <copyright file="EventLogLogger.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System;
using System.Diagnostics;
#endregion 

namespace Sigma.Core
{
    public class EventLogLogger : ILogger
    {
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EventLogLogger"/> class.
        /// </summary>
        public EventLogLogger(ISettings settings)
        {
            this._settings = settings;
        }

        public void Info(string message, params object[] args)
        {
            WriteToEventLog(message, EventLogEntryType.Information);
        }

        public void Warn(string message, params object[] args)
        {
            WriteToEventLog(message, EventLogEntryType.Warning);
        }

        public void Debug(string message, params object[] args)
        {
            //no need to send this to the EventLog - output it 
            //to the DEBUG window
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Error(string message, params object[] args)
        {
            WriteToEventLog(message, EventLogEntryType.Error);
        }

        public void Error(Exception x)
        {
            Error(LogUtility.BuildExceptionMessage(x));
        }

        public void Fatal(string message, params object[] args)
        {
            WriteToEventLog(message, EventLogEntryType.Error);
        }
        public void Fatal(Exception x)
        {
            WriteToEventLog(LogUtility.BuildExceptionMessage(x), EventLogEntryType.Error);
        }

        public bool IsDebugEnabled
        {
            get { return true; }
        }

        public bool IsErrorEnabled
        {
            get { return true; }
        }

        public bool IsFatalEnabled
        {
            get { return true; }
        }

        public bool IsInfoEnabled
        {
            get { return true; }
        }

        public bool IsTraceEnabled
        {
            get { return true; }
        }

        public bool IsWarnEnabled
        {
            get { return true; }
        }

        void WriteToEventLog(string message, EventLogEntryType logType)
        {
            EventLog eventLog = new EventLog();

            //use the app log - you can customize this as you need
            //string storeName = _settings.GetPropertyValue("StoreName");
            //eventLog.Source = storeName;

            eventLog.WriteEntry(message, logType);
        }
    }
}