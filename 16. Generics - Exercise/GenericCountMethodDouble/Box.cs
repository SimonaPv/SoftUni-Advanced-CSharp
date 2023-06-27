using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        public List<T> List { get; set; } = new List<T>();

        public int Count(T itemToCompare)
        {
            int count = 0;

            foreach (var item in List)
            {
                if (item.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
