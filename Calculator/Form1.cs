namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal firstNumber = 0;
        string operation = "";
        bool isOperationClicked = false;

        private void Number_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (txtDisplay.Text == "0")
                txtDisplay.Text = "";

            txtDisplay.Text += btn.Text;
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            firstNumber = decimal.Parse(txtDisplay.Text);
            operation = btn.Text;
            isOperationClicked = true;

            txtDisplay.Text = "0";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            decimal secondNumber = decimal.Parse(txtDisplay.Text);
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
            }

            txtDisplay.Text = result.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            operation = "";
            isOperationClicked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 1)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            else
            {
                txtDisplay.Text = "0";
            }
        }

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
    }
}
