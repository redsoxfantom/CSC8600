using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.Logger
{
    /// <summary>
    /// A logger that logs to a text box
    /// </summary>
    public class TextBoxLogger : ILogger
    {
        /// <summary>
        /// The text box to print to
        /// </summary>
        private TextBox mTextBox;

        /// <summary>
        /// The name of the logger
        /// </summary>
        private String mName;

        /// <summary>
        /// Construct the logger
        /// </summary>
        /// <param name="name">The name of the class</param>
        /// <param name="textBox">The logger's text box</param>
        public TextBoxLogger(string name, TextBox textBox)
        {
            mName = name;
            mTextBox = textBox;
        }

        /// <summary>
        /// Prints a debug string
        /// </summary>
        /// <param name="str">The string</param>
        public void Debug(string str)
        {
            Print(string.Format("DEBUG [{0}]: {1}", mName, str));
        }

        /// <summary>
        /// Prints an info string
        /// </summary>
        /// <param name="str">The string</param>
        public void Info(string str)
        {
            Print(string.Format("INFO [{0}]: {1}", mName, str));
        }

        /// <summary>
        /// Prints an error string
        /// </summary>
        /// <param name="str">str</param>
        public void Error(string str)
        {
            Print(string.Format("ERROR [{0}]: {1}", mName, str));
        }

        /// <summary>
        /// Print a string to the text box
        /// </summary>
        /// <param name="str">String to print</param>
        private void Print(string str)
        {
            mTextBox.Text += str + Environment.NewLine;
        }
    }
}
