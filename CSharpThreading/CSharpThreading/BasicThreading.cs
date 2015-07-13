using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpThreading
{
    public class BasicThreading
    {
        public BasicThreading()
        {
            Thread t = new Thread(new ParameterizedThreadStart((param)=>
            {
                int val = (int)param;
                Console.WriteLine("Child called with value "+val);
            }));
            t.Start(100);
            t.Join();
            Console.WriteLine("Main Thread Executing");
        }
    }
}
