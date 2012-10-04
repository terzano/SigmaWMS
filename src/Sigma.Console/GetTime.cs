using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManyConsole;
using Sigma.Core;

namespace Sigma.Console
{
    /// <summary>
    /// As an example of ManyConsole usage, get-time is meant to show the simplest case possible usage.
    /// </summary>
    public class GetTime : ConsoleCommand
    {
        public GetTime()
        {
            this.IsCommand("get-time", "Returns the current system time");
        }

        public override int Run(string[] remainingArguments)
        {
            System.Console.WriteLine(DateTime.UtcNow);
            var nlog = new NLogLogger();
            nlog.Info("Testing Logger");

            return 0;
        }
    }
}
