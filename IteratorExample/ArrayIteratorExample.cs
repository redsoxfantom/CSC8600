using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorExample
{
    public class ArrayIteratorExample<int> : Iterable<int>
    {
        private int[] backingArray;

        private int currentIndex;

        public ArrayIteratorExample(int size)
        {
            backingArray = new int[size];
            currentIndex = 0;

            Random gen = new Random();
            for(int i = 0; i < size; i++)
            {
                backingArray[i] = gen.Next(1000);
            }
        }

        public int GetFirst()
        {
            return backingArray[0];
        }

        public void Advance()
        {
            currentIndex++;
        }

        public int GetCurrent()
        {
            return backingArray[currentIndex];
        }

        public bool AtEnd()
        {
            return (currentIndex == backingArray.Length);
        }

        public void Reset()
        {
            currentIndex = 0;
        }
    }
}
