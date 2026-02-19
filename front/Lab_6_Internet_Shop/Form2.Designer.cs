namespace Lab_6_Internet_Shop
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Purchases = new ListBox();
            Purch_text = new TextBox();
            Name_Text = new TextBox();
            loginPromptLabel = new Label();
            loginButton = new Button();
            SuspendLayout();
            // 
            // Purchases
            // 
            Purchases.FormattingEnabled = true;
            Purchases.Location = new Point(0, 51);
            Purchases.Name = "Purchases";
            Purchases.Size = new Size(267, 164);
            Purchases.TabIndex = 0;
            // 
            // Purch_text
            // 
            Purch_text.Location = new Point(273, 51);
            Purch_text.Multiline = true;
            Purch_text.Name = "Purch_text";
            Purch_text.Size = new Size(218, 164);
            Purch_text.TabIndex = 1;
            // 
            // Name_Text
            // 
            Name_Text.Location = new Point(0, 0);
            Name_Text.Name = "Name_Text";
            Name_Text.Size = new Size(284, 27);
            Name_Text.TabIndex = 2;

            // loginPromptLabel
            // 
            loginPromptLabel.AutoSize = true;
            loginPromptLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            loginPromptLabel.Location = new Point(50, 50);
            loginPromptLabel.Name = "loginPromptLabel";
            loginPromptLabel.Size = new Size(159, 28);
            loginPromptLabel.TabIndex = 3;
            loginPromptLabel.Text = "Войдите в аккаунт";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(80, 100);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(94, 35);
            loginButton.TabIndex = 4;
            loginButton.Text = "Войти";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginButton);
            Controls.Add(loginPromptLabel);
            Controls.Add(Name_Text);
            Controls.Add(Purch_text);
            Controls.Add(Purchases);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox Purchases;
        private TextBox Purch_text;
        private TextBox Name_Text;
        private Label loginPromptLabel;
        private Button loginButton;
    }
}