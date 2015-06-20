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
            int returnedValue;

            try
            {
                returnedValue = databaseInterface.PerformExpensiveDatabaseLookup(indexToSearchFor);
            }
            catch(Exception)
            {
                return -1;
            }

            if(returnedValue < 0)
            {
                return 0;
            }
            if(returnedValue > 100)
            {
                return 100;
            }
            return returnedValue;
        }
    }
}
