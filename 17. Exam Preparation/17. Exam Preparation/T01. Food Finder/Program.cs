using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace T01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));

            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            int pearCount = pear.Count();
            int flourCount = flour.Count();
            int porkCount = pork.Count();
            int oliveCount = olive.Count();

            while (consonants.Count > 0)
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();

                if (pear.Contains(vowel) && pearCount > 0)
                {
                    pear = pear.Replace(vowel.ToString(), "");
                    pearCount--;
                }
                if (flour.Contains(vowel) && flourCount > 0)
                {
                    flour = flour.Replace(vowel.ToString(), "");
                    flourCount--;
                }
                if (pork.Contains(vowel) && porkCount > 0)
                {
                    pork = pork.Replace(vowel.ToString(), "");
                    porkCount--;
                }
                if (olive.Contains(vowel) && oliveCount > 0)
                {
                    olive = olive.Replace(vowel.ToString(), "");
                    oliveCount--;
                }

                if (pear.Contains(consonant) && pearCount > 0)
                {
                    pear = pear.Replace(consonant.ToString(), "");
                    pearCount--;
                }
                if (flour.Contains(consonant) && flourCount > 0)
                {
                    flour = flour.Replace(consonant.ToString(), "");
                    flourCount--;
                }
                if (pork.Contains(consonant) && porkCount > 0)
                {
                    pork = pork.Replace(consonant.ToString(), "");
                    porkCount--;
                }
                if (olive.Contains(consonant) && oliveCount > 0)
                {
                    olive = olive.Replace(consonant.ToString(), "");
                    oliveCount--;
                }

                vowels.Enqueue(vowel);
            }

            List<string> words = new List<string>();

            if (pearCount == 0)
            {
                words.Add("pear");
            }
            if (flourCount == 0)
            {
                words.Add("flour");
            }
            if (porkCount == 0)
            {
                words.Add("pork");
            }
            if (oliveCount == 0)
            {
                words.Add("olive");
            }

            Console.WriteLine($"Words found: {words.Count}");
            foreach (var w in words)
            {
                Console.WriteLine(w);
            }
        }
    }
}
