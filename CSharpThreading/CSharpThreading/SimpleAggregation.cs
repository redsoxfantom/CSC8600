using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpThreading
{
    class SimpleAggregation
    {
        public int[] output;

        public SimpleAggregation()
        {
            output = new int[20];
            List<int> input = new List<int>();
            for(int i = 0; i < 20; i++)
            {
                input.Add(i);
            }

            Parallel.For(0, 20, new Action<int>((val) =>
            {
                output[val] = val + 1;
            }));

            Console.WriteLine(String.Join(", ", output));
        }
    }
}
