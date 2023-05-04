using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casual
{
    internal class SomeArray<T>
    {
        private T[] InnerArray { get; init; }
        public int Size { get; set; }
        public SomeArray(int size)
        {
            InnerArray = new T[size];
            this.Size = size;
        }
        public void SetValueByIndex(int id, T value)
        {
            InnerArray[id] = value;
        }
        public void DeleteValueByIndex(int id)
        {
            InnerArray[id] = default;
        }
        public void Remove(T value)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (InnerArray[i] == null)
                    continue;
                if (InnerArray[i].Equals(value))
                {
                    InnerArray[i] = default;
                    return;
                }
            }
        }
        public T GetValueByIndex(int id)
        {
            return InnerArray[id];
        }
        public void Display()
        {
            foreach (var item in InnerArray)
                if (item != null)
                    Console.Write(item.ToString() + ' ');
                else
                    Console.Write("null ");
            Console.WriteLine();
        }
    }
}
