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
        bool IsOperationPerfomed = false;
        bool IspressEqual = false;
        bool IsSignPressed = false;


        public Form1()
        {
            InitializeComponent();
        }

        


        private void button_Click(object sender, EventArgs e)
        {
            IsSignPressed = true;
            Button button = (Button)sender;
            if (IspressEqual)
            {
                if (IsOperationPerfomed)
                {
                    ResultTextBox1.Clear();
                    ResultTextBox1.Text = "0";
                    ResultValue = 0;
                }
            }
            IspressEqual = false;

            if (ResultTextBox1.Text == "0")
            {
                if(button.Text == ",")
                {
                    ResultTextBox1.Text = ResultTextBox1.Text + button.Text;
                }
            }
            
            if (ResultTextBox1.Text == "0" || IsOperationPerfomed)
            {
                ResultTextBox1.Clear();
            }
            IsOperationPerfomed = false;
            
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void operated_click(object sender, EventArgs e)
        {
            IspressEqual = false;
            IsSignPressed = false;

            Button button = (Button)sender;
            if (ResultValue != 0)
            {
                button_Result.PerformClick();
                IsOperationPerfomed = true;
               // ResultValue = double.Parse(ResultTextBox1.Text);
                OperationSign = button.Text;
               
            }
            else
            {
                IsOperationPerfomed = true;
                ResultValue = double.Parse(ResultTextBox1.Text);
                OperationSign = button.Text;
            }
            if(  button.Text == "√")
            {
                linkLabelSign.Text = OperationSign + "(" + ResultValue+")";
            }
            else if(button.Text == "x²")
            {
                linkLabelSign.Text = ResultValue + "²";
            }
            else if(button.Text == "1/x")
            {
                linkLabelSign.Text = "1/" + ResultValue;
            }
            else
            {
                linkLabelSign.Text = ResultValue + " " + OperationSign;

            }
        }

        private void result_click(object sender, EventArgs e)
        {
            IsSignPressed = false;
            IsOperationPerfomed = false;
            IspressEqual = true;
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
                    ResultTextBox1.Text = (Math.Pow(ResultValue ,2)).ToString();
                    break;
                case "√":
                    ResultTextBox1.Text = (Math.Sqrt(  ResultValue)).ToString();
                    break;
                case "1/x":
                    ResultTextBox1.Text = (1/ResultValue).ToString();
                    break;
                default:
                    break;
            }
            ResultValue = double.Parse(ResultTextBox1.Text);
            linkLabelSign.Text = "";
        }

        private void ClickButton_ClearEntry(object sender, EventArgs e)
        {
            ResultTextBox1.Text = "0";
        }

        private void ClickButton_Clean(object sender, EventArgs e)
        {
            ResultTextBox1.Text = "0";
            ResultValue = 0;
            linkLabelSign.Text = "";

        }

        private void Click_Delete(object sender, EventArgs e)
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

        private void button_Negation_Click(object sender, EventArgs e)
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
        


       
    }
}
