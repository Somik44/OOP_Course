namespace Lab_6_Internet_Shop
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
            Products = new ListBox();
            Description = new TextBox();
            buy_button = new Button();
            tabControl1 = new TabControl();
            Prod_tab = new TabPage();
            Acc_tab = new TabPage();
            tabControl1.SuspendLayout();
            Prod_tab.SuspendLayout();
            SuspendLayout();
            // 
            // Products
            // 
            Products.FormattingEnabled = true;
            Products.Location = new Point(3, 3);
            Products.Name = "Products";
            Products.Size = new Size(469, 284);
            Products.TabIndex = 0;
            // 
            // Description
            // 
            Description.Location = new Point(510, 6);
            Description.Multiline = true;
            Description.Name = "Description";
            Description.Size = new Size(278, 205);
            Description.TabIndex = 1;
            // 
            // buy_button
            // 
            buy_button.Location = new Point(510, 258);
            buy_button.Name = "buy_button";
            buy_button.Size = new Size(94, 29);
            buy_button.TabIndex = 2;
            buy_button.Text = "Купить";
            buy_button.UseVisualStyleBackColor = true;
            buy_button.Click += buy_button_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Prod_tab);
            tabControl1.Controls.Add(Acc_tab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 3;
            // 
            // Prod_tab
            // 
            Prod_tab.Controls.Add(Products);
            Prod_tab.Controls.Add(buy_button);
            Prod_tab.Controls.Add(Description);
            Prod_tab.Location = new Point(4, 29);
            Prod_tab.Name = "Prod_tab";
            Prod_tab.Padding = new Padding(3);
            Prod_tab.Size = new Size(792, 417);
            Prod_tab.TabIndex = 0;
            Prod_tab.Text = "Товары";
            Prod_tab.UseVisualStyleBackColor = true;
            // 
            // Acc_tab
            // 
            Acc_tab.Location = new Point(4, 29);
            Acc_tab.Name = "Acc_tab";
            Acc_tab.Padding = new Padding(3);
            Acc_tab.Size = new Size(792, 417);
            Acc_tab.TabIndex = 1;
            Acc_tab.Text = "Аккаунт";
            Acc_tab.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            Prod_tab.ResumeLayout(false);
            Prod_tab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox Products;
        private TextBox Description;
        private Button buy_button;
        private TabControl tabControl1;
        private TabPage Acc_tab;
        private TabPage Prod_tab;
    }
}
