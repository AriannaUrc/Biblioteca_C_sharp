namespace Biblioteca
{
    partial class FormLogin
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
            label6 = new Label();
            label5 = new Label();
            textBox_Password = new TextBox();
            textBox_Username = new TextBox();
            Button_Login = new Button();
            label4 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("MS UI Gothic", 11.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(0, 192, 120);
            label6.Location = new Point(185, 432);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 16;
            label6.Text = "Create one";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("MS UI Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(28, 432);
            label5.Name = "label5";
            label5.Size = new Size(160, 15);
            label5.TabIndex = 15;
            label5.Text = "Don't have an account?";
            // 
            // textBox_Password
            // 
            textBox_Password.Location = new Point(26, 315);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.PasswordChar = '*';
            textBox_Password.Size = new Size(225, 29);
            textBox_Password.TabIndex = 14;
            // 
            // textBox_Username
            // 
            textBox_Username.Location = new Point(27, 228);
            textBox_Username.Name = "textBox_Username";
            textBox_Username.Size = new Size(225, 29);
            textBox_Username.TabIndex = 13;
            // 
            // Button_Login
            // 
            Button_Login.BackColor = Color.FromArgb(0, 192, 120);
            Button_Login.FlatStyle = FlatStyle.Flat;
            Button_Login.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Button_Login.ForeColor = Color.Transparent;
            Button_Login.Location = new Point(35, 373);
            Button_Login.Name = "Button_Login";
            Button_Login.Size = new Size(217, 42);
            Button_Login.TabIndex = 12;
            Button_Login.Text = "Login";
            Button_Login.UseVisualStyleBackColor = false;
            Button_Login.Click += Button_Login_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(26, 286);
            label4.Name = "label4";
            label4.Size = new Size(71, 16);
            label4.TabIndex = 11;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(26, 199);
            label3.Name = "label3";
            label3.Size = new Size(74, 16);
            label3.TabIndex = 9;
            label3.Text = "Username";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 192, 120);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 156);
            panel1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.GhostWhite;
            label1.Location = new Point(82, 44);
            label1.Name = "label1";
            label1.Size = new Size(112, 33);
            label1.TabIndex = 0;
            label1.Text = "Sign in";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.GhostWhite;
            label2.Location = new Point(46, 98);
            label2.Name = "label2";
            label2.Size = new Size(205, 21);
            label2.TabIndex = 1;
            label2.Text = "Login to BibliotecaApp";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 484);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBox_Password);
            Controls.Add(textBox_Username);
            Controls.Add(Button_Login);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FormLogin";
            Text = "FrmLogin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private TextBox textBox_Password;
        private TextBox textBox_Username;
        private Button Button_Login;
        private Label label4;
        private Label label3;
        private Panel panel1;
        private Label label1;
        private Label label2;
    }
}