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
        // import many plugins. All found plugins will be included in _plugins.
        // If a plugin is found but cannot be composed (due to errors), it won't be included
        // and no exception will be thrown.
        [ImportMany]
        IEnumerable<Lazy<IConsoleLoggerPlugin>> _plugins;

        [Export("LogColor")]
        public ConsoleColor DefaultColor
        {
            get { return ConsoleColor.Blue; }
        }

        public void Info(string message)
        {
            foreach (var plugin in _plugins)
                plugin.Value.BeforeWrite();
            Console.WriteLine("Info: " + message);
            foreach (var plugin in _plugins)
                plugin.Value.AfterWrite();
        }
    }
}