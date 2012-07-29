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
        public void Info(string message)
        {
            Console.WriteLine("Info: " + message);
        }
    }
}