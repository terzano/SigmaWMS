using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigma.Core
{
    public class FakeLogger : ILogger
    {
        public void Info(string message, params object[] args)
        {
            Console.WriteLine(message);
        }

        public void Warn(string message, params object[] args)
        {
            Console.WriteLine(message);
        }

        public void Debug(string message, params object[] args)
        {
            Console.WriteLine(message);
        }

        public void Error(string message, params object[] args)
        {
            Console.WriteLine(message);
        }

        public void Error(Exception x)
        {
            Console.WriteLine(x.Message);
        }

        public void Fatal(string message, params object[] args)
        {
            Console.WriteLine(message);
        }

        public void Fatal(Exception x)
        {
            Console.WriteLine(x.Message);
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
    }
}
