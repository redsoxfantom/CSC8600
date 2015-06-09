using Calculator.Calculator;
using Calculator.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        /// <summary>
        /// This class's logger
        /// </summary>
        private ILogger mLogger;

        /// <summary>
        /// The calculator
        /// </summary>
        private ICalculatorServer mCalc;

        /// <summary>
        /// Create the form
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
            LoggerFactory.SetLoggerOutput(DebugTextBox);
            mLogger = LoggerFactory.CreateLogger(this.GetType().Name);
            mLogger.Info("========Calculator========");

            mCalc = new CalculatorServer();
            mCalc.Updated += NewNumberReceived;
            mCalc.Initialize();
        }

        /// <summary>
        /// Update the calculator's number
        /// </summary>
        /// <param name="newNum">The new number</param>
        private void NewNumberReceived(string newNum)
        {
            AnswerField.Text = newNum;
        }

        /// <summary>
        /// Fired when any number button (0 - 9 and decimal) is clicked
        /// </summary>
        /// <param name="sender">The button that was pressed</param>
        /// <param name="e">unused</param>
        private void numberBtnClick(object sender, EventArgs e)
        {
            string buttonText = (string)((Button)sender).Tag;

            mLogger.Info(string.Format("{0} clicked", buttonText));
            mCalc.AcceptNumber(buttonText);
        }

        /// <summary>
        /// Fired when the user selects "Show Debug Menu"
        /// </summary>
        /// <param name="sender">The menu item</param>
        /// <param name="e">unused</param>
        private void showDebugConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem debugMenuItem = (ToolStripMenuItem)sender;
            if(debugMenuItem.Checked)
            {
                DebugTextBox.Visible = true;
            }
            else
            {
                DebugTextBox.Visible = false;
            }
        }

        /// <summary>
        /// Fired when the user pressed an operator key
        /// </summary>
        /// <param name="sender">The button that was pressed</param>
        /// <param name="e">unused</param>
        private void operatorBtnClicked(object sender, EventArgs e)
        {
            string buttonText = (string)((Button)sender).Tag;

            mLogger.Info(string.Format("{0} clicked", buttonText));
            mCalc.AcceptOperator(buttonText);
        }
    }
}
