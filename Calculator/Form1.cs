using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal firstNumber = 0;
        decimal secondNumber = 0;
        string operation = "";
        bool isOperationClicked = false;

        //NUMBERS
        private void Number_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (txtDisplay.Text == "0" || isOperationClicked)
            {
                txtDisplay.Text = "";
                isOperationClicked = false;
            }

            txtDisplay.Text += btn.Text;
        }

        //OPERATIONS
        private void Operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            decimal.TryParse(txtDisplay.Text, out firstNumber);

            operation = btn.Text;
            isOperationClicked = true;
        }

        //EQUALS 
        private void btnEquals_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtDisplay.Text, out secondNumber);

            decimal result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "*":
                    result = firstNumber * secondNumber;
                    break;

                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Cannot divide by zero!");
                        txtDisplay.Text = "0";
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;

                default:
                    return;
            }

            txtDisplay.Text = result.ToString();
            firstNumber = result;
            operation = "";
            isOperationClicked = true;
        }

        //CLEAR 
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
            isOperationClicked = false;
        }

        //BACKSPACE
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (isOperationClicked)
                return;

            if (txtDisplay.Text.Length <= 1)
            {
                txtDisplay.Text = "0";
                return;
            }

            txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
        }

        //DECIMAL 
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (isOperationClicked)
            {
                txtDisplay.Text = "0";
                isOperationClicked = false;
            }

            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void Form1_Load(object sender, EventArgs e) 
        { 

        }

        private void textBox1_TextChanged(object sender, EventArgs e) 
        {

        }
    }
}