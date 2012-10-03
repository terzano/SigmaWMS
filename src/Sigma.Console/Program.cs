#region License
//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives  
using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Sigma.Console
{
    class Program
    {
        static int Main(string[] args)
        {
            // aocate commands avaiable
            var commands = GetCommands();

            // allows to execute commands from an internal console
            ConsoleModeCommand consoleRunner = new ConsoleModeCommand(GetCommands);
            commands = commands.Concat(new[] { consoleRunner });

            // run the command for the console input
            return ConsoleCommandDispatcher.DispatchCommand(commands, args, System.Console.Out);
        }

        /// <summary>
        /// Retrieves commands available from the current assembly
        /// </summary>
        /// <returns></returns>
        static IEnumerable<ConsoleCommand> GetCommands()
        {
            return ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));
        }
    }
}
