using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T: IComparable
    {
        public T Left { get; set; }
        public T Right { get; set; }

        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        public bool AreEqual()
        {
            if (this.Left.CompareTo(this.Right) == 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
