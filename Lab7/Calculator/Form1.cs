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
    public partial class Form1 : Form
    {
        double ResultValue = 0;
        string OperationSign = "";
        bool IsOperationPressed = false;
        bool IsEqualPressed = false;
        bool IsSignPressed = false;
        double memory = 0;
        List<double> list = new List<double>();
        public Form1()
        {
            InitializeComponent();
            button_MemoryClean.Enabled = false;
            button_MemoryRead.Enabled = false;
            button_MemoryView.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            IsSignPressed = true;
            Button button = (Button)sender;
            if (IsEqualPressed)
            {
                if (IsOperationPressed)
                {
                    ResultTextBox1.Clear();
                    ResultTextBox1.Text = "0";
                    ResultValue = 0;
                }
            }
            IsEqualPressed = false;

            if (ResultTextBox1.Text == "0")
            {
                if (button.Text == ",")
                {
                    ResultTextBox1.Text = ResultTextBox1.Text + button.Text;
                }
            }

            if (ResultTextBox1.Text == "0" || IsOperationPressed)
            {
                ResultTextBox1.Clear();
            }
            IsOperationPressed = false;

            if (button.Text == ",")
            {
                if (!ResultTextBox1.Text.Contains(","))
                {
                    ResultTextBox1.Text += ",";


                }
            }
            else
                ResultTextBox1.Text = ResultTextBox1.Text + button.Text;
        }

        private void operated_Click(object sender, EventArgs e)
        {

            IsEqualPressed = false;
            IsSignPressed = false;

            Button button = (Button)sender;
            if (ResultValue != 0)
            {
                button_Result.PerformClick();
                IsOperationPressed = true;
                // ResultValue = double.Parse(ResultTextBox1.Text);
                OperationSign = button.Text;

            }
            else
            {
                IsOperationPressed = true;
                ResultValue = double.Parse(ResultTextBox1.Text);
                OperationSign = button.Text;
            }
            if (button.Text == "√")
            {
                linkLabelSign.Text = OperationSign + "(" + ResultValue + ")";
            }
            else if (button.Text == "x²")
            {
                linkLabelSign.Text = ResultValue + "²";
            }
            else if (button.Text == "1/x")
            {
                linkLabelSign.Text = "1/" + ResultValue;
            }
            else
            {
                linkLabelSign.Text = ResultValue + " " + OperationSign;

            }
        }

        private void Result_Click(object sender, EventArgs e)
        {
            IsSignPressed = false;
            IsOperationPressed = false;
            IsEqualPressed = true;
            switch (OperationSign)
            {
                case "+":
                    ResultTextBox1.Text = (ResultValue + double.Parse(ResultTextBox1.Text)).ToString();
                    break;
                case "-":
                    ResultTextBox1.Text = (ResultValue - double.Parse(ResultTextBox1.Text)).ToString();
                    break;
                case "÷":
                    ResultTextBox1.Text = (ResultValue / double.Parse(ResultTextBox1.Text)).ToString();
                    break;
                case "X":
                    ResultTextBox1.Text = (ResultValue * double.Parse(ResultTextBox1.Text)).ToString();
                    break;
                case "x²":
                    ResultTextBox1.Text = (Math.Pow(ResultValue, 2)).ToString();
                    break;
                case "√":
                    ResultTextBox1.Text = (Math.Sqrt(ResultValue)).ToString();
                    break;
                case "1/x":
                    ResultTextBox1.Text = (1 / ResultValue).ToString();
                    break;
                default:
                    break;
            }
            ResultValue = double.Parse(ResultTextBox1.Text);
            linkLabelSign.Text = "";
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string k = "";
            string s = ResultTextBox1.Text;
            for (int i = 0; i < s.Length; i++)
            {
                if (i == s.Length - 1) { continue; }

                k += s[i];

            }
            ResultTextBox1.Text = k;
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            ResultTextBox1.Text = "0";
            ResultValue = 0;
            linkLabelSign.Text = "";
        }

        private void CleanEntry_Click(object sender, EventArgs e)
        {
            ResultTextBox1.Text = "0";
        }

        private void Negation_Click(object sender, EventArgs e)
        {
            if (double.Parse(ResultTextBox1.Text) > 0)
            {
                ResultTextBox1.Text = (-(double.Parse(ResultTextBox1.Text))).ToString();
            }
            else if (double.Parse(ResultTextBox1.Text) < 0)
            {
                ResultTextBox1.Text = (Math.Abs(double.Parse(ResultTextBox1.Text))).ToString();

            }
            else
            {
                ResultTextBox1.Text = "-";
            }
        }

        private void MemorySave_Click(object sender, EventArgs e)
        {
            memory = double.Parse(ResultTextBox1.Text);
            button_MemoryClean.Enabled = true;
            button_MemoryRead.Enabled = true;
            button_MemoryView.Enabled = true;
            list.Add(memory);
        }

        private void MemoryClear_Click(object sender, EventArgs e)
        {
            memory = 0;
            button_MemoryClean.Enabled = false;
            button_MemoryRead.Enabled = false;
            button_MemoryView.Enabled = false;
        }

        private void MemoryRead_Click(object sender, EventArgs e)
        {
            ResultTextBox1.Text = memory.ToString();
        }

        private void MemoryPlus_Click(object sender, EventArgs e)
        {
            button_MemoryClean.Enabled = true;
            button_MemoryRead.Enabled = true;
            button_MemoryView.Enabled = true;
            if (ResultTextBox1.Text == "0")
            {
                memory = 0;
            }
            memory += double.Parse(ResultTextBox1.Text);
            list.Add(memory);

        }

        private void MemoryMinus_Click(object sender, EventArgs e)
        {
            button_MemoryClean.Enabled = true;
            button_MemoryRead.Enabled = true;
            button_MemoryView.Enabled = true;
            if (ResultTextBox1.Text == "0")
            {
                memory = 0;
            }
            memory -= double.Parse(ResultTextBox1.Text);
            list.Add(memory);

        }

        private void MemoryView_Click(object sender, EventArgs e)
        {
            string str="";

            foreach(double p in list)
            {
                str =str+ " \n\n\n " + p.ToString();
         
            }
            MessageBox.Show(str);
        }
    }
}
