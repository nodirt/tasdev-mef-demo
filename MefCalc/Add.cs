using System.ComponentModel.Composition;
using System.Linq;
using System;

namespace MefCalc
{
    [Export(typeof(IOperator))]
    [ExportMetadata("Symbol", '+')]
    class Add : IOperator
    {
        public int Operate(int left, int right)
        {
            return left + right;
        }
    }
}