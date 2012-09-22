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

        ILogger _log;

        // the attribute specified that this constructor must be used when creating an instance of the class.
        // All parameters of such a constructor must be importable. In this case a ConsoleLogger is created.
        [ImportingConstructor]
        public App(ILogger log)
        {
            _log = log;
        }

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
