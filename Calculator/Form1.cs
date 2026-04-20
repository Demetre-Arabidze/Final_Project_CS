namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double firstNumber = 0;
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

            firstNumber = double.Parse(txtDisplay.Text);
            operation = btn.Text;
            isOperationClicked = true;

            txtDisplay.Text = "0";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(txtDisplay.Text);
            double result = 0;

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
    }
}
