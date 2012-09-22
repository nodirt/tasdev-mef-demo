using System.Linq;
using System;
using System.ComponentModel.Composition;

namespace MefCalc
{
    // a IConsoleLogger plugin that writes date and time
    [Export(typeof(IConsoleLoggerPlugin))]
    public class ConsoleLoggerTimestamp: IConsoleLoggerPlugin
    {
        public void BeforeWrite()
        {
            Console.Write(DateTime.Now + " ");
        }

        public void AfterWrite()
        {
        }
    }
}