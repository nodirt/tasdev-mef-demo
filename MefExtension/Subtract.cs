using System;
using System.ComponentModel.Composition;

namespace MefCalc
{
    [Export(typeof(IOperator))]
    [ExportMetadata("Symbol", '-')]
    class Subtract : IOperator
    {
        public int Operate(int left, int right)
        {
            return left - right;
        }
    }
}