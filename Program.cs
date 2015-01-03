using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string infix = "3^4+(11-(3*2))/4";
            char[] tokens = infix.ToCharArray();
            Stack<char> s = new Stack<char>();
            List<char> outputList = new List<char>();
            int n;
            foreach (char c in tokens)
            {
                if(int.TryParse(c.ToString(), out n))
                {
                    outputList.Add(c);
                }
                if (c == '(')
                {
                    s.Push(c);
                }
                if (c == ')')
                {
                    while (s.Count != 0 && s.Peek() != '(')
                    {
                        outputList.Add(s.Pop());
                    }
                    s.Pop();
                }
                if (isOperator(c) == true)
                {
                    while(s.Count != 0 || Priority(s.Peek()) >= Priority(c))//here OR used to be AND
                    {
                        outputList.Add(s.Pop());
                    }
                    s.Push(c);
                }
            }
            
            for (int i = 0; i < outputList.Count; i++)
            {
                Console.Write("{0}", outputList[i]);
            }
            Console.ReadLine();
        }
        static int Priority(char c)
        {
            if (c == '^')
            {
                return 3;
            }
            else if (c == '*' || c == '/')
            {
                return 2;
            }
            else if (c == '+' || c == '-')
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static bool isOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
