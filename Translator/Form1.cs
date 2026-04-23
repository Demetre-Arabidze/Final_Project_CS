namespace Translator
{
    public partial class Form1 : Form
    {
        string _filePath = @"../../../Dictionary.txt";

        Dictionary<string, string> enToKa = new Dictionary<string, string>();
        Dictionary<string, string> kaToEn = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();

            cmbFrom.Items.Add("Georgian");
            cmbFrom.Items.Add("English");

            cmbTo.Items.Add("Georgian");
            cmbTo.Items.Add("English");

            cmbFrom.SelectedIndex = 1;
            cmbTo.SelectedIndex = 0;

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('=');
                if (parts.Length == 2)
                {
                    string en = parts[0].Trim().ToLower();
                    string ka = parts[1].Trim().ToLower();

                    enToKa[en] = ka;
                    kaToEn[ka] = en;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                lblResult.Text = "Please enter a word";
                return;
            }

            string from = cmbFrom.SelectedItem.ToString();
            string to = cmbTo.SelectedItem.ToString();

            if (from == "English" && to == "Georgian")
            {
                if (enToKa.ContainsKey(input))
                {
                    lblResult.Text = enToKa[input];
                }
                else
                {
                    AddNewWord(input, from, to);
                }
            }
            else if (from == "Georgian" && to == "English")
            {
                if (kaToEn.ContainsKey(input))
                {
                    lblResult.Text = kaToEn[input];
                }
                else
                {
                    AddNewWord(input, from, to);
                }
            }
            else
            {
                lblResult.Text = "Invalid language selection";
            }
        }
        private void AddNewWord(string input, string from, string to)
        {
            DialogResult result = MessageBox.Show(
                "Word not found! Do you want to add it?",
                "Add Word",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                string newTranslation = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter translation:",
                    "New Word"
                );

                if (!string.IsNullOrWhiteSpace(newTranslation))
                {
                    newTranslation = newTranslation.ToLower();

                    if (from == "English" && to == "Georgian")
                    {
                        enToKa[input] = newTranslation;
                        kaToEn[newTranslation] = input;

                        File.AppendAllText(_filePath, $"{input}={newTranslation}\n");
                    }
                    else if (from == "Georgian" && to == "English")
                    {
                        kaToEn[input] = newTranslation;
                        enToKa[newTranslation] = input;

                        File.AppendAllText(_filePath, $"{newTranslation}={input}\n");
                    }

                    lblResult.Text = "Word added!";
                }
            }
        }
    }
}
