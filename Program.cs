using System;

namespace Stack
{
    class Stack <T>
    {
        const int max_size = 10;
        private int stackPtr = -1;
        private T[] theStack = new T[max_size];

        public bool Push (T data)
        {
            if (stackPtr == max_size)
            {
                return (false);
            }
            else
            {
                stackPtr += 1;
                theStack[stackPtr] = data;
                return (true);
            }
        }

        public T Pop()
        {
            if (stackPtr >= 0)
            {
                stackPtr += -1;
                return (theStack[stackPtr + 1]);
            }
            else
            {
                return (default(T));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stack Tester!");
            Stack <char> myStack = new Stack <char>();
            myStack.Push('m');
            myStack.Push('B');
            Console.WriteLine(myStack.Pop());
            myStack.Push('o');
            myStack.Push('o');
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
        }
    }
}
