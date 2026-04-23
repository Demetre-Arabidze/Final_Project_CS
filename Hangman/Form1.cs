using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Hangman
{
    public partial class Form1 : Form
    {
        string word;
        string hint;
        char[] display;

        Dictionary<string, string> words = new Dictionary<string, string>
        {
            { "APPLE", "A fruit" },
            { "BANANA", "Yellow fruit" },
            { "ORANGE", "Citrus fruit" },
            { "COMPUTER", "Electronic device" },
            { "PROGRAM", "Code instructions" },
            { "HANGMAN", "Word guessing game" },
            { "KEYBOARD", "Used for typing" },
            { "MOUSE", "Computer accessory" },
            { "WINDOW", "Part of a house or OS" },
            { "MONITOR", "Displays screen output" }
        };

        Random rand = new Random();

        int maxAttempts = 5;
        int attemptsLeft;

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        void StartGame()
        {
            if (words.Count == 0)
            {
                MessageBox.Show("No words available!");
                return;
            }

            var randomPair = words.ElementAt(rand.Next(words.Count));

            word = randomPair.Key;
            hint = randomPair.Value;

            display = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
                display[i] = '_';

            attemptsLeft = maxAttempts;

            lblWord.Text = string.Join(" ", display);
            lblAttempts.Text = "Attempts: " + attemptsLeft;
            lblHint.Text = "";

            btnHint.Enabled = true;

            flpLetters.Controls.Clear();
            CreateLetterButtons();
        }

        void CreateLetterButtons()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Button btn = new Button();
                btn.Text = c.ToString();
                btn.Width = 70;
                btn.Height = 70;

                btn.Click += LetterClick;

                flpLetters.Controls.Add(btn);
            }
        }

        private void LetterClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            char guess = btn.Text[0];

            bool correct = false;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == guess)
                {
                    display[i] = guess;
                    correct = true;
                }
            }

            lblWord.Text = string.Join(" ", display);

            if (correct)
            {
                btn.BackColor = Color.LightGreen;
            }
            else
            {
                btn.BackColor = Color.LightCoral;
                attemptsLeft--;
                lblAttempts.Text = "Attempts: " + attemptsLeft;
            }

            btn.Enabled = false;

            CheckGameStatus();
        }

        void CheckGameStatus()
        {
            if (!display.Contains('_'))
            {
                MessageBox.Show("You Win! Congrats!");
                StartGame();
                return;
            }

            if (attemptsLeft <= 0)
            {
                MessageBox.Show("Game Over! Word was: " + word);
                StartGame();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            lblHint.Text = "Hint: " + hint;
            btnHint.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void lblWord_Click(object sender, EventArgs e) { }
    }
}