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
        /// Create the form
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
            LoggerFactory.SetLoggerOutput(DebugTextBox);

            mLogger = LoggerFactory.CreateLogger(this.GetType().Name);
            mLogger.Info("========Calculator========");
        }

        /// <summary>
        /// Fired when any number button (0 - 9) is clicked
        /// </summary>
        /// <param name="sender">The button that was pressed</param>
        /// <param name="e">unused</param>
        private void numberBtnClick(object sender, EventArgs e)
        {
            string buttonText = (string)((Button)sender).Tag;

            mLogger.Info(string.Format("{0} clicked", buttonText));
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
    }
}
