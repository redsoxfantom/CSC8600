using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayIteratorExample ex = new ArrayIteratorExample(10);
            PrintIterable<int>(ex);
            Console.ReadLine();

            LinkedListIteratorExample ex2 = new LinkedListIteratorExample(10);
            PrintIterable<int>(ex2);
            Console.ReadLine();

        }

        public static void PrintIterable<T>(Iterable<T> itr)
        {
            Console.WriteLine("Iterating through " + itr.GetType().Name + " object");
            while(!itr.AtEnd())
            {
                Console.WriteLine(itr.GetCurrent());
                itr.Advance();
            }
        }
    }
}
