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
        public List<int> output;

        public SimpleAggregation()
        {
            output = new List<int>();
            List<int> input = new List<int>();
            for(int i = 0; i < 20; i++)
            {
                input.Add(i);
            }

            Parallel.For(0, input.Count, new Action<int>((val) =>
            {
                int newVal = val + 1;
                lock(output)
                {
                    output.Add(newVal);
                }
            }));

            Console.WriteLine(String.Join(", ", output));
        }
    }
}
