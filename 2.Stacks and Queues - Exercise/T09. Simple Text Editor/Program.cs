using System;
using System.Collections.Generic;
using System.Text;

namespace T09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> text = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            text.Push(sb.ToString());

            int numbOperations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbOperations; i++)
            {
                string[] comand = Console.ReadLine().Split();
                switch (comand[0])
                {
                    case "1":
                        sb.Append(comand[1]);
                        text.Push(sb.ToString());
                        break;
                    case "2":
                        int delit = int.Parse(comand[1]);
                        sb.Remove(sb.Length - delit, delit);

                        text.Push(sb.ToString());

                        break;
                    case "3":
                        int charPrint = int.Parse(comand[1]);
                        Console.WriteLine(sb[charPrint - 1]);

                        break;
                    case "4":
                        text.Pop();
                        sb = new StringBuilder();
                        sb.Append(text.Peek());

                        break;
                }
            }
        }
    }
}
