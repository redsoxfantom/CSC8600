using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockObjectDemo
{
    public class StubbedOutInterfaceClass : IInterfaceToMock
    {
        public int PerformExpensiveDatabaseLookup(int index)
        {
            return 5;
        }
    }
}
