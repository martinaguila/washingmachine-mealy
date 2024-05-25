using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WashingDryerApp
{
    public partial class Form1 : Form
    {
        private WashingMachine washingMachine;

        public Form1()
        {
            InitializeComponent();
            washingMachine = new WashingMachine();
            washingMachine.StatusChanged += OnStatusChanged;
            washingMachine.TimeLeftChanged += OnTimeLeftChanged;
        }

        private void OnStatusChanged(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnStatusChanged), status);
            }
            else
            {
                textBox1.Text = status;
            }
        }

        private void OnTimeLeftChanged(int timeLeft)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(OnTimeLeftChanged), timeLeft);
            }
            else
            {
                textBox2.Text = timeLeft.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            washingMachine.StartWashing(15);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            washingMachine.StartDrying(10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            washingMachine.Stop();
        }
    }
}
