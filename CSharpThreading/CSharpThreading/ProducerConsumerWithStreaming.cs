using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpThreading
{
    public class ProducerConsumerWithStreaming
    {
        private BlockingCollection<int> WorkItemQueue = new BlockingCollection<int>();
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
                WorkItemQueue.Add(valToEnqueue);
            }
            WorkItemQueue.CompleteAdding();
            Console.WriteLine("Producer Cancelled");
        }

        void Consume()
        {
            Random gen = new Random();
            foreach(int item in WorkItemQueue.GetConsumingEnumerable())
            {
                Console.WriteLine("Consumer Dequeued Value: " + item);
                Thread.Sleep(gen.Next(100));
            }
            Console.WriteLine("Consumer Cancelled");
        }
    }
}
