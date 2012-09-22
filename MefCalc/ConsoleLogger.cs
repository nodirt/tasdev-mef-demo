using System;
using System.Diagnostics;
using System.ComponentModel.Composition;
using System.Collections.Generic;

namespace MefCalc
{
    // ConsoleLogger provides an ILogger service
    [Export(typeof(ILogger))]
    public class ConsoleLogger: ILogger
    {
        [Import]
        IConsoleLoggerPlugin _plugin;

        public void Info(string message)
        {
            _plugin.BeforeWrite();
            Console.WriteLine("Info: " + message);
            _plugin.AfterWrite();
        }
    }
}