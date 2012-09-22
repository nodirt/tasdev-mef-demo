using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MefCalc
{
    // The App class exports itself
    [Export]
    class App
    {
        // global container
        static CompositionContainer _container;

        // App requires an ILogger service
        [Import]
        ILogger _log;

        void Run()
        {
            _log.Info("Started");

            Console.WriteLine("2 + 2 = {0}", 2 + 2);

            _log.Info("Finished");
        }

        static void Main(string[] args)
        {
            // create a container with exports from this assembly
            _container = new CompositionContainer(new AssemblyCatalog(typeof (App).Assembly));

            // create and compose an App with a single line
            var app = _container.GetExportedValue<App>();

            app.Run();
        }
    }
}
