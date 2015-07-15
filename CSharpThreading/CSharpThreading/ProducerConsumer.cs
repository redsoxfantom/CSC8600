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
        public CancellationToken CancelToken = new CancellationToken();

        public void Run()
        {
            Task.Factory.StartNew(new Action(() => { Produce(); }), CancelToken);
            Task.Factory.StartNew(new Action(() => { Consume(); }), CancelToken);
        }

        void Produce()
        {
            
        }

        void Consume()
        {

        }
    }
}
