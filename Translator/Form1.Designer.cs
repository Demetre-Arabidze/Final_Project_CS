namespace Translator
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
            cmbFrom = new ComboBox();
            txtInput = new TextBox();
            btnTranslate = new Button();
            lblResult = new Label();
            cmbTo = new ComboBox();
            SuspendLayout();
            // 
            // cmbFrom
            // 
            cmbFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFrom.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbFrom.FormattingEnabled = true;
            cmbFrom.Location = new Point(12, 50);
            cmbFrom.Name = "cmbFrom";
            cmbFrom.Size = new Size(160, 39);
            cmbFrom.TabIndex = 0;
            // 
            // txtInput
            // 
            txtInput.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInput.Location = new Point(12, 113);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(324, 160);
            txtInput.TabIndex = 2;
            txtInput.Text = "Enter here";
            // 
            // btnTranslate
            // 
            btnTranslate.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTranslate.Location = new Point(344, 12);
            btnTranslate.Name = "btnTranslate";
            btnTranslate.Size = new Size(141, 45);
            btnTranslate.TabIndex = 3;
            btnTranslate.Text = "Translate";
            btnTranslate.UseVisualStyleBackColor = true;
            btnTranslate.Click += btnTranslate_Click;
            // 
            // lblResult
            // 
            lblResult.BackColor = SystemColors.Window;
            lblResult.BorderStyle = BorderStyle.Fixed3D;
            lblResult.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResult.ForeColor = SystemColors.ActiveCaptionText;
            lblResult.Location = new Point(499, 115);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(313, 160);
            lblResult.TabIndex = 4;
            lblResult.Text = "Result will appear here";
            // 
            // cmbTo
            // 
            cmbTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTo.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTo.FormattingEnabled = true;
            cmbTo.Location = new Point(652, 50);
            cmbTo.Name = "cmbTo";
            cmbTo.Size = new Size(160, 39);
            cmbTo.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 454);
            Controls.Add(cmbTo);
            Controls.Add(lblResult);
            Controls.Add(btnTranslate);
            Controls.Add(txtInput);
            Controls.Add(cmbFrom);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbFrom;
        private TextBox txtInput;
        private Button btnTranslate;
        private Label lblResult;
        private ComboBox cmbTo;
    }
}
