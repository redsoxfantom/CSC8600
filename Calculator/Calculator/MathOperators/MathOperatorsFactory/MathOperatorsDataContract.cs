using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Calculator.MathOperators.MathOperatorsFactory
{
    /// <summary>
    /// Data contract defining a dictionary of symbols an INaryOperators that will be loaded on initialization of the MathOperatorsFactory
    /// </summary>
    [CollectionDataContract(ItemName="OperatorDefinition",Name="MathOperators", KeyName="Symbol", ValueName="Operator", Namespace="")]
    public class MathOperatorsDataContract : Dictionary<string,string>
    {
    }
}
