using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpThreading
{
    public class SpeculativeProcessing
    {
        public SpeculativeProcessing()
        {
            List<Func<int>> input = new List<Func<int>>();
            Random gen = new Random();
            for(int i = 1; i < 4; i++)
            {
                input.Add(() =>
                {
                    int amountToSleep = gen.Next(1000);
                    Thread.Sleep(amountToSleep);
                    return Thread.CurrentThread.ManagedThreadId;
                });
            }
            int res = SpeculativeForEach(input, function => function());

            Console.WriteLine("Thread " + res + " finished first");
        }

        public TResult SpeculativeForEach<TSource,TResult>(IEnumerable<TSource> src, Func<TSource,TResult> body)
        {
            // Be warned: calling "First()" in .NET 4.0 will most likely be "optimized" to a sequential operation
            return src.AsParallel().Select(i => body(i)).First();
        }
    }
}
