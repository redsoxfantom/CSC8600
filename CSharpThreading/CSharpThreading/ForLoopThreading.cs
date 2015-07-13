using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpThreading
{
    public class ForLoopThreading
    {
        public ForLoopThreading(int numIters)
        {
            Console.WriteLine("Creating child threads");
            Parallel.For(0, numIters, new Action<int>((iters) =>
            {
                Console.WriteLine("Thread "+Thread.CurrentThread.ManagedThreadId+" processing iteration "+iters);
                Thread.Sleep(10);
            }));
            Console.WriteLine("All child threads complete");
        }
    }
}
