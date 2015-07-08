using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadingTestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NonThreadedButton_Click(object sender, EventArgs e)
        {
            NonThreadedOutput.Text = "RUNNING";
            Thread.Sleep(5000);
            NonThreadedOutput.Text = "COMPLETE";
        }

        private void ThreadedButton_Click(object sender, EventArgs e)
        {
            ThreadedOutput.Text = "RUNNING";
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ThreadedOutput.Text = "COMPLETE";
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
        }
    }
}
