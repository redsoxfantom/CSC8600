using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Calculator.MathOperators
{
    /// <summary>
    /// Factory class that returns a math operator given that operator's symbol.
    /// </summary>
    public class MathOperatorsFactory
    {
        /// <summary>
        /// Stores the list of operators and their symbols
        /// </summary>
        private static Dictionary<string, INaryOperator> operators = null;

        /// <summary>
        /// Given an operator's symbol, return an instance of the INaryOperator represented by that symbol
        /// </summary>
        /// <param name="symbol">The symbol associated with an operator (ex: + => AdditionOperator)</param>
        /// <returns>The N-Ary operator</returns>
        public static INaryOperator GetOperator(string symbol)
        {
            if(operators == null)
            {
                //Lazy initialization of operators dictionary
                InitializeOperators();
            }

            if(operators.ContainsKey(symbol))
            {
                return operators[symbol];
            }
            else
            {
                throw new MathOperatorException(string.Format("Math symbol {0} not supported", symbol));
            }
        }

        /// <summary>
        /// Read in the config file defining the list of operators to support
        /// </summary>
        private static void InitializeOperators()
        {
            operators = new Dictionary<string,INaryOperator>();
            XmlDictionaryReader reader = null;
            
            try
            {
                FileStream sw = new FileStream("Config\\MathOperators.xml", FileMode.Open);
                reader = XmlDictionaryReader.CreateTextReader(sw, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(MathOperatorsDataContract));

                Dictionary<string, string> deserializedFile = (Dictionary<string, string>)ser.ReadObject(reader);
                reader.Close();

                foreach (string operatorSymbol in deserializedFile.Keys)
                {
                    try
                    {
                        string operatorTypeString = deserializedFile[operatorSymbol];
                        Type operatorType = Type.GetType(operatorTypeString);
                        INaryOperator op = (INaryOperator)Activator.CreateInstance(operatorType, new object[] { });

                        operators.Add(operatorSymbol, op);
                    }
                    catch(Exception ex)
                    {
                        //TODO: Come up with a better logging strategy
                        Console.WriteLine(string.Format("Failed to create operator: {0}", ex.Message));
                    }
                }
            }
            catch(IOException ex)
            {
                throw new MathOperatorException(string.Format("Failed to load operators config file: {0}", ex.Message));
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
