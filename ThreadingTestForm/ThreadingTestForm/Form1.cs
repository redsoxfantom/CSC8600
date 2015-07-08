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
            ThreadStart job = new ThreadStart(() =>
            {
                Thread.Sleep(5000);
                ThreadedOutput.Text = "COMPLETE";
            });
            Thread thread = new Thread(job);
            thread.Start();
        }
    }
}
