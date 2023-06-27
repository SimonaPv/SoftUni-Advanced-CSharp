using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Stack<T> stack { get; set; } = new Stack<T>();
        public int Count { get { return stack.Count; } }

        public void Add(T element)
        {
            stack.Push(element);
        }
        public T Remove()
        {
            T element = stack.Peek();
            stack.Pop();
            return element;
        }
    }
}
