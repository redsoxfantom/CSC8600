using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpThreading
{
    public class ProducerConsumer
    {
        private ConcurrentQueue<int> WorkItemQueue = new ConcurrentQueue<int>();
        private CancellationToken CancelToken;
        public CancellationTokenSource CancelTokenSource = new CancellationTokenSource();

        public void Run()
        {
            CancelToken = CancelTokenSource.Token;
            Task.Factory.StartNew(new Action(() => { Produce(); }), CancelToken);
            Task.Factory.StartNew(new Action(() => { Consume(); }), CancelToken);
        }

        void Produce()
        {
            Random gen = new Random();
            while(!CancelToken.IsCancellationRequested)
            {
                Thread.Sleep(gen.Next(20));
                int valToEnqueue = gen.Next();
                Console.WriteLine("Producer Enqueing Value: " + valToEnqueue);
                WorkItemQueue.Enqueue(valToEnqueue);
            }
            Console.WriteLine("Producer Cancelled");
        }

        void Consume()
        {
            while (!CancelToken.IsCancellationRequested)
            {

            }
        }
    }
}
