using Calculator.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Calculator.MathOperators.MathOperatorsFactory
{
    /// <summary>
    /// Factory class that returns a math operator given that operator's symbol.
    /// </summary>
    public class MathOperatorsFactory : IMathOperatorsFactory
    {
        /// <summary>
        /// Stores the list of operators and their symbols
        /// </summary>
        private Dictionary<string, INaryOperator> operators;

        /// <summary>
        /// A logger for the factory
        /// </summary>
        private ILogger mLogger;

        /// <summary>
        /// Construct the Factory. Call InitializeOperators to load config
        /// </summary>
        public MathOperatorsFactory()
        {
            operators = new Dictionary<string, INaryOperator>();
            mLogger = LoggerFactory.CreateLogger(this.GetType().Name);
        }

        /// <summary>
        /// Given an operator's symbol, return an instance of the INaryOperator represented by that symbol
        /// </summary>
        /// <param name="symbol">The symbol associated with an operator (ex: + => AdditionOperator)</param>
        /// <returns>The N-Ary operator</returns>
        public INaryOperator GetOperator(string symbol)
        {
            if(operators.ContainsKey(symbol))
            {
                return operators[symbol];
            }
            else
            {
                mLogger.Error(string.Format("Math symbol {0} not supported", symbol));
                //Todo: this should really return a Null Operator...
                return null;
            }
        }

        /// <summary>
        /// Read in the config file defining the list of operators to support
        /// </summary>
        public void InitializeOperators()
        {
            mLogger.Info("Initializing MathOperatorsFactory");
            XmlDictionaryReader reader = null;
            
            using( FileStream sw = new FileStream("Config\\MathOperators.xml", FileMode.Open))
            {
                reader = XmlDictionaryReader.CreateTextReader(sw, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(MathOperatorsDataContract));

                Dictionary<string, string> deserializedFile = (Dictionary<string, string>)ser.ReadObject(reader);

                foreach (string operatorSymbol in deserializedFile.Keys)
                {
                    mLogger.Debug(string.Format("Attempting to create operator {0}", operatorSymbol));
                    try
                    {
                        string operatorTypeString = deserializedFile[operatorSymbol];
                        Type operatorType = Type.GetType(operatorTypeString);
                        INaryOperator op = (INaryOperator)Activator.CreateInstance(operatorType, new object[] { });

                        operators.Add(operatorSymbol, op);
                        mLogger.Debug(string.Format("Successfully created operator {0}", operatorSymbol));
                    }
                    catch(Exception ex)
                    {
                        mLogger.Error(string.Format("Failed to create operator: {0}", ex.Message));
                    }
                }
            }
            string operatorsString = String.Join(", ", operators.Keys.ToArray());
            mLogger.Info(string.Format("Done initializing MathOperatorsFactory with following operators: [{0}]",operatorsString));
        }
    }
}
