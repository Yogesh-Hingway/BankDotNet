using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalc
{
    public partial class Form1 : Form
    {
        Double result=0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            if (display.Text == "0"||(isOperationPerformed))
            {
                display.Clear();
            }
            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!display.Text.Contains("."))
                {
                    display.Text = display.Text + button.Text;
                    //currentOperation.Text = currentOperation.Text + display.Text;
                }
            }
            else
            {
                display.Text = display.Text + button.Text;
                //currentOperation.Text = currentOperation.Text + display.Text;
            }
        }

        private void operator_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0)
            {
                button18.PerformClick();
                operationPerformed = button.Text;
                currentOperation.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                result = Double.Parse(display.Text);
                currentOperation.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void clear_All(object sender, EventArgs e)
        {
            display.Text = "0";
            result = 0;
        }

        private void clear(object sender, EventArgs e)
        {
            string temp = display.Text;
            display.Clear();
            for(int i = 0; i < temp.Length - 1; i++)
            {
                display.Text += temp[i];
            }
        }

        private void doOperation(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    display.Text=(result+ Double.Parse(display.Text)).ToString();
                    break;
                case "-":
                    display.Text = (result - Double.Parse(display.Text)).ToString();
                    break;
                case "*":
                    display.Text = (result * Double.Parse(display.Text)).ToString();
                    break;
                case "÷":
                    display.Text = (result / Double.Parse(display.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(display.Text);
            currentOperation.Text = "";
        }
    }
}