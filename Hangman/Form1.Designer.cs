namespace Hangman
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWord = new Label();
            flpLetters = new FlowLayoutPanel();
            btnRestart = new Button();
            lblAttempts = new Label();
            lblHint = new Label();
            lblHintText = new Label();
            SuspendLayout();
            // 
            // lblWord
            // 
            lblWord.AutoSize = true;
            lblWord.Font = new Font("Consolas", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWord.Location = new Point(193, 64);
            lblWord.Name = "lblWord";
            lblWord.Size = new Size(84, 94);
            lblWord.TabIndex = 0;
            lblWord.Text = "_";
            lblWord.TextAlign = ContentAlignment.MiddleCenter;
            lblWord.Click += lblWord_Click;
            // 
            // flpLetters
            // 
            flpLetters.Location = new Point(38, 195);
            flpLetters.Name = "flpLetters";
            flpLetters.Size = new Size(878, 240);
            flpLetters.TabIndex = 1;
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRestart.Location = new Point(38, 529);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(239, 69);
            btnRestart.TabIndex = 2;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // lblAttempts
            // 
            lblAttempts.AutoSize = true;
            lblAttempts.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAttempts.Location = new Point(12, 9);
            lblAttempts.Name = "lblAttempts";
            lblAttempts.Size = new Size(166, 46);
            lblAttempts.TabIndex = 3;
            lblAttempts.Text = "Attempts:";
            lblAttempts.Click += LetterClick;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHint.Location = new Point(564, 541);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(103, 46);
            lblHint.TabIndex = 4;
            lblHint.Text = "(Hint)";
            lblHint.Click += LetterClick;
            // 
            // lblHintText
            // 
            lblHintText.AutoSize = true;
            lblHintText.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHintText.Location = new Point(569, 487);
            lblHintText.Name = "lblHintText";
            lblHintText.Size = new Size(98, 54);
            lblHintText.TabIndex = 5;
            lblHintText.Text = "Hint";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(924, 652);
            Controls.Add(lblHintText);
            Controls.Add(lblHint);
            Controls.Add(lblAttempts);
            Controls.Add(btnRestart);
            Controls.Add(flpLetters);
            Controls.Add(lblWord);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWord;
        private FlowLayoutPanel flpLetters;
        private Button btnRestart;
        private Label lblAttempts;
        private Label lblHint;
        private Label lblHintText;
    }
}
