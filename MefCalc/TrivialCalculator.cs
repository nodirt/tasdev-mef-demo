using System;
using System.ComponentModel.Composition;
using System.Collections.Generic;

namespace MefCalc
{
    public interface ICalculator
    {
        string Calculate(string input);
    }

    // a contract for an operator
    public interface IOperator
    {
        int Operate(int left, int right);
    }

    // each operator must provide metadata
    public interface IOperatorMetadata
    {
        // symbol to identify the operator
        Char Symbol { get; }
    }

    [Export(typeof(ICalculator))]
    public class TrivialCalculator : ICalculator
    {
        // import all found operators.
        // Lazy means that instances of IOperator will be created on demand, 
        // when Lazy<`2>.Value property value is requested
        [ImportMany]
        IEnumerable<Lazy<IOperator, IOperatorMetadata>> _operator;

        public string Calculate(string input)
        {
            // find an operator
            int opPos = FindFirstNonDigitAndWhitespace(input);
            if (opPos < 0) 
                return "Could not parse command.";

            // parse operands
            int left, right;
            try
            {
                left = int.Parse(input.Substring(0, opPos).Trim());
                right = int.Parse(input.Substring(opPos + 1).Trim());
            }
            catch (FormatException)
            {
                return "Could not parse command.";
            }

            char operatorSymbol = input[opPos];
            // find an IOperator for the operator symbol
            foreach (Lazy<IOperator, IOperatorMetadata> op in _operator)
            {
                if (op.Metadata.Symbol == operatorSymbol)
                {
                    // execute and return
                    return op.Value.Operate(left, right).ToString();
                }
            }

            return "Operator Not Found!";
        }

        private int FindFirstNonDigitAndWhitespace(string text)
        {
            for (var i = 0; i < text.Length; i++)
            {
                if (!char.IsDigit(text[i]) && !char.IsWhiteSpace(text[i]))
                    return i;
            }
            return -1;
        }
    }
}