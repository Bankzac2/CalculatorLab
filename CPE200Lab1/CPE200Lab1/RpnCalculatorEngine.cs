using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // To use Stack Class

namespace CPE200Lab1
{
    class RpnCalculatorEngine : CalculatorEngine
    {
        public string RpnProcess(string stringInput)
        {
            string[] parts = stringInput.Split(' ');
            string result = null;
            Stack rpnStack = new Stack();

            foreach(string input in parts)
            { 
            //for (int i=0; i<parts.Length; i++)
            //{
                //string input = parts[i]; //each parts one-by-one
                if (isNumber(input))
                {
                    rpnStack.Push(input);
                }
                else if (isOperator(input))
                {
                    string rpnOperate = input;
                    string secondRpnOperand = rpnStack.Pop().ToString();
                    string firstRpnOperand = rpnStack.Pop().ToString();
                    result = calculate(rpnOperate, firstRpnOperand, secondRpnOperand, 4);
                    rpnStack.Push(result);
                }
            }

            return result;
        }
    }
}
