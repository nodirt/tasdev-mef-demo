using System;
using System.ComponentModel.Composition;
namespace MefCalc
{
    // a contract for a IConsoleLogger plugin
    public interface IConsoleLoggerPlugin
    {
        void BeforeWrite();
        void AfterWrite();
    }

    // an plugin that makes the console log text green colored
    [Export(typeof(IConsoleLoggerPlugin))]
    public class GreenConsoleLogger: IConsoleLoggerPlugin
    {
        ConsoleColor _origColor;
        public void BeforeWrite()
        {
            // set console color to green before writing
            _origColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void AfterWrite()
        {
            // restore the console color after writing
            Console.ForegroundColor = _origColor;
        }
    }
}