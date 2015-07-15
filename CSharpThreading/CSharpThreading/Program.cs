using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select an example program:");
            Console.WriteLine("1) Basic example");
            Console.WriteLine("2) For loop example");
            Console.WriteLine("3) Producer Consumer example");
            String input = Console.ReadLine();

            if (input == "1")
            {
                BasicThreading b = new BasicThreading();
            }
            if (input == "2")
            {
                ForLoopThreading f = new ForLoopThreading(100);
            }
            if(input == "3")
            {
                ProducerConsumer p = new ProducerConsumer();
                p.Run();
                Thread.Sleep(2500);
                p.CancelTokenSource.Cancel();
            }
            Console.ReadLine();
        }
    }
}
