using System;
using System.Collections.Generic;

namespace T08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> codes = new HashSet<string>();
            HashSet<string> codesVIP = new HashSet<string>();
            string code = Console.ReadLine();

            while (code != "PARTY")
            {
                if (char.IsDigit(code[0]))
                {
                    codesVIP.Add(code);
                }
                else
                {
                    codes.Add(code);
                }
                
                code = Console.ReadLine();  
            }

            code = Console.ReadLine();
            while (code != "END")
            {
                if (char.IsDigit(code[0]))
                {
                    codesVIP.Remove(code);
                }
                else
                {
                    codes.Remove(code);
                }
                code = Console.ReadLine();
            }

            Console.WriteLine(codes.Count + codesVIP.Count);

            foreach (var item in codesVIP)
            {
                Console.WriteLine(item);
            }
            foreach (var item in codes)
            {
                Console.WriteLine(item);
            }
        }
    }
}
