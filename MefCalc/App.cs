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
        // a catalog of textensions
        static DirectoryCatalog _extensionsCatalog;
        // global container
        static CompositionContainer _container;

        ILogger _log;

        [Import]
        ICalculator _calc;

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

            // run calculator on lines entered by the user until an empty line is entered
            Console.WriteLine("Enter expression:");
            string expr;
            while (!string.IsNullOrEmpty(expr = Console.ReadLine()))
            {
                try
                {
                    _extensionsCatalog.Refresh();
                    var text = _calc.Calculate(expr);
                    Console.WriteLine(text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            _log.Info("Finished");
        }

        static void Main(string[] args)
        {
            // create a catalog of DLLs in the Extensions directory
            _extensionsCatalog = new DirectoryCatalog("Extensions");

            // create a catalog that combines this assembly and extensions
            var catalog = new AggregateCatalog(
                new AssemblyCatalog(typeof (App).Assembly),
                _extensionsCatalog
            );

            // create a container with exports from this assembly
            _container = new CompositionContainer(catalog);

            // create and compose an App with a single line
            var app = _container.GetExportedValue<App>();

            app.Run();
        }
    }
}
