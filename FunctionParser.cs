using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalCalculator
{
    internal static class FunctionParser
    {

        internal static Dictionary<char, int> precedence = new Dictionary<char, int>()
        {
            {'+', 2 },
            {'-', 2 },
            {'*', 3 },
            {'/', 3 },
            {'^', 4 }
        };

        internal static Dictionary<string, Func<double, double>> functions = new Dictionary<string, Func<double, double>>()
        {
            {"sin", x => Math.Sin(x)},
            {"cos", x => Math.Cos(x)},
            {"tan", x => Math.Tan(x)},
            {"sqrt", x => Math.Sqrt(x)},
            {"sinh", x => Math.Sinh(x)},
            {"cosh", x => Math.Cosh(x)},
            {"tanh", x => Math.Tanh(x)}
        };

        internal static double EvaluateFunction(List<string> function, double x)
        {
            Stack evalStack = new Stack();
            for(int i = 0; i < function.Count; i++)
            {
                string token = function[i].ToString();
                if (double.TryParse(token, out double number))
                {
                    evalStack.Push(number);
                }
                else if(token == "x")
                {
                    evalStack.Push(x);
                }
                else if(functions.ContainsKey(token))
                {
                    double a = (double)evalStack.Pop();
                    evalStack.Push(functions[token](a));
                }
                else
                {
                    double b = (double)evalStack.Pop();
                    double a = (double)evalStack.Pop();
                    switch (token)
                    {
                        case "+":
                            evalStack.Push(a + b);
                            break;
                        case "-":
                            evalStack.Push(a - b);
                            break;
                        case "*":
                            evalStack.Push(a * b);
                            break;
                        case "/":
                            evalStack.Push(a / b);
                            break;
                        case "^":
                            evalStack.Push(Math.Pow(a, b));
                            break;
                        default:
                            throw new Exception();

                    }
                }
            }
            return (double)evalStack.Pop();
        }


        internal static Queue ShuntingYard(string funcText)
        {
            Stack operatorStack = new Stack();
            Queue outputQueue = new Queue();

            string[] tokens = getTokens(funcText);

            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];
                // Check if numbers
                if (token == "x")
                {
                    outputQueue.Enqueue(token);
                    continue;
                }
                if (double.TryParse(token, out double number))
                {
                    outputQueue.Enqueue(number);
                    continue;
                }

                // Check if function
                if (functions.ContainsKey(token))
                {
                    operatorStack.Push(token);
                    continue;
                }
                // Check if operator
                if (token.Length == 1 && precedence.ContainsKey(token[0]))
                {
                    int tokenPrec = precedence[token[0]];
                    string o2 = operatorStack.Count > 0 ? (string)operatorStack.Peek() : "";

                    while (o2 != "(" && o2.Length == 1 && precedence.ContainsKey(o2[0])  // Operator at top of stack which is not left bracket
                        && (precedence[o2[0]] > tokenPrec // o2 has greater precedence than o1
                        || (precedence[o2[0]] == tokenPrec && token[0] != '^'))) // OR precedence is equal and o1 is left-associative
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                        o2 = operatorStack.Count > 0 ? (string)operatorStack.Peek() : "";
                    }
                    operatorStack.Push(token[0].ToString());
                    continue;
                }
                // Check if left bracket
                if (token == "(")
                {
                    operatorStack.Push(token);
                    continue;
                }
                if (token == ")")
                {
                    while (operatorStack.Peek().ToString() != "(")
                    {
                        Debug.Assert(operatorStack.Count != 0);
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    Debug.Assert(operatorStack.Peek().ToString() == "(");
                    operatorStack.Pop();
                    if (!"+-*/()".Contains(operatorStack.Peek().ToString()))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                }
            }

            while (operatorStack.Count > 0)
            {
                Debug.Assert(operatorStack.Peek().ToString() != "(");
                outputQueue.Enqueue(operatorStack.Pop());
            }


            return outputQueue;
        }

        internal static string replaceConst(string baseStr, string toReplace, int index)
        {
            if (index > 0 && baseStr[index - 1] != ' ')
            {
                toReplace = " * " + toReplace;
            }
            if (index < baseStr.Length - 1 && baseStr[index + 1] != ' ')
            {
                toReplace += " * ";
            }

            string end = index == baseStr.Length - 1 ? "" : baseStr.Substring(index + 1);
            return baseStr.Substring(0, index) + toReplace + end;
        }


        internal static string[] getTokens(string funcText)
        {
            string result = funcText.ToLower();
            result = result.Replace(" ", "");
            foreach (char op in "+-*/()^")
            {
                result = result.Replace(op.ToString(), $" {op} ");
            }
            // Format for constants
            for (int i = result.Length - 1; i >= 0; i--)
            {
                if (result[i] == 'e')
                {
                    // e = 2.718
                    result = replaceConst(result, Math.E.ToString(), i);
                }
                else if (i < result.Length - 1 && result[i] == 'p' && result[i + 1] == 'i')
                {
                    // pi = 3.142
                    result.Remove(i + 1);
                    result = replaceConst(result, Math.PI.ToString(), i);
                }
                else if (result[i] == 'x')
                {
                    // Format x
                    result = replaceConst(result, "x", i);
                }
            }

            return result.Split(' ');
        }
    }
}
