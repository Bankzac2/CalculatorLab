using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            if (str == null || str == "")
            {
                return "E";
            }

            if (str == "0")
            {
                return "0";
            }

            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();

            parts.Remove("");

            // This works only with binary operators since we need at least 3 parts.
            if (parts.Count < 3) 
            {
                return "E";
            }

            string result = "E";
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    if (rpnStack.Count >= 2)
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        if (isNumber(secondOperand) && isNumber(firstOperand))
                        {
                            result = calculate(token, firstOperand, secondOperand, 4);
                            if (result is "E")
                            {
                                return result;
                            }
                            rpnStack.Push(result);
                        }
                        else
                        {
                            return "E";
                        }
                    }
                    else
                    {
                        return "E";
                    }
                }
                else // case of "++"
                {
                    return "E";
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if (rpnStack.Count == 1)
            {
                result = rpnStack.Pop();
            }
            else
            {
                result = "E";
            }
            return result;
        }
    }
}