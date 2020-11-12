using System;
using System.Linq.Expressions;

namespace Stack
{
    class Stack <T>
    {
        private const int _MaxSize = 10;
        private int _stackPtr = -1;
        private T[] _theStack = new T[_MaxSize];

        public bool Push (T data)
        {
            if (_stackPtr == _MaxSize)
            {
                return (false);
            }
            else
            {
                _stackPtr += 1;
                _theStack[_stackPtr] = data;
                return (true);
            }
        }

        public T Pop()
        {
            if (_stackPtr >= 0)
            {
                _stackPtr += -1;
                return (_theStack[_stackPtr + 1]);
            }
            else
            {
                throw new Exception("Stack Empty");
            }
        }

        public T Peep()
        {
            if (_stackPtr >= 0)
            {
                return (_theStack[_stackPtr]);
            }
            else
            {
                throw new Exception("Stack Empty");
            }
        }

        public bool IsEmpty()
        {
            if (_stackPtr == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            string expression = "";
            Stack <string> rpnStack = new Stack <string>();
            Console.WriteLine("Stack Tester!");

            // Get the expression and tokenize it by splitting
            Console.WriteLine("Enter an RPN expression string delimited by spaces");
            string[] expressionTokens = Console.ReadLine().Split(" ");

            foreach (string token in expressionTokens)
            {
                // test to see if the token is an integer, if so, push to stack
                if (int.TryParse(token, out var n))
                {
                    rpnStack.Push(token);
                }
                else
                {
                    // deal with operator; pop two operands from stack and push result
                    int operand2 = int.Parse(rpnStack.Pop());
                    int operand1 = int.Parse(rpnStack.Pop());
                    int result = 0;
                    if (token == "+")
                    {
                        result = operand1 + operand2;
                    }
                    else if (token == "-")
                    {
                        result = operand1 - operand2;
                    }
                    else if (token == "*")
                    {
                        result = operand1 * operand2;
                    }
                    else if (token == "/")
                    {
                        result = operand1 / operand2;
                    }
                    // convert the result back to a string and push to stack
                    rpnStack.Push(result.ToString());
                }
            }
            // Pop the item left on the stack which is the result
            Console.WriteLine("Result: "+ rpnStack.Pop());

        }
    }
}
