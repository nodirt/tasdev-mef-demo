using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MefCalc
{
    class App
    {
        ILogger _log;

        void Run()
        {
            _log.Info("Started");

            Console.WriteLine("2 + 2 = {0}", 2 + 2);

            _log.Info("Finished");
        }

        static void Main(string[] args)
        {
            var app = new App();
            app._log = new ConsoleLogger();

            app.Run();
        }
    }
}
