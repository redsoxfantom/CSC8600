using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockObjectDemo
{
    public class ClassUnderTest
    {
        public int Search(int indexToSearchFor, IInterfaceToMock databaseInterface)
        {
            return databaseInterface.PerformExpensiveDatabaseLookup(indexToSearchFor);
        }
    }
}
