namespace Biblioteca
{
    partial class admin_pannel
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
            dgvBooks = new DataGridView();
            txtBookTitle = new TextBox();
            txtAuthorName = new TextBox();
            txtCategoryName = new TextBox();
            cmbAuthor = new ComboBox();
            cmbCategory = new ComboBox();
            btnAddAuthor = new Button();
            btnAddCategory = new Button();
            btnAddBook = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(37, 18);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.Size = new Size(343, 220);
            dgvBooks.TabIndex = 0;
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(433, 54);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(100, 23);
            txtBookTitle.TabIndex = 1;
            // 
            // txtAuthorName
            // 
            txtAuthorName.Location = new Point(631, 54);
            txtAuthorName.Name = "txtAuthorName";
            txtAuthorName.Size = new Size(100, 23);
            txtAuthorName.TabIndex = 2;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(631, 152);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(100, 23);
            txtCategoryName.TabIndex = 3;
            // 
            // cmbAuthor
            // 
            cmbAuthor.FormattingEnabled = true;
            cmbAuthor.Location = new Point(435, 123);
            cmbAuthor.Name = "cmbAuthor";
            cmbAuthor.Size = new Size(121, 23);
            cmbAuthor.TabIndex = 4;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(435, 183);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(121, 23);
            cmbCategory.TabIndex = 5;
            // 
            // btnAddAuthor
            // 
            btnAddAuthor.Location = new Point(633, 83);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new Size(98, 23);
            btnAddAuthor.TabIndex = 6;
            btnAddAuthor.Text = "Add Author";
            btnAddAuthor.UseVisualStyleBackColor = true;
            btnAddAuthor.Click += btnAddAuthor_Click;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(631, 183);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(98, 23);
            btnAddCategory.TabIndex = 7;
            btnAddCategory.Text = "Add Category";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += this.btnAddCategory_Click;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(435, 235);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(98, 23);
            btnAddBook.TabIndex = 8;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // admin_pannel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddBook);
            Controls.Add(btnAddCategory);
            Controls.Add(btnAddAuthor);
            Controls.Add(cmbCategory);
            Controls.Add(cmbAuthor);
            Controls.Add(txtCategoryName);
            Controls.Add(txtAuthorName);
            Controls.Add(txtBookTitle);
            Controls.Add(dgvBooks);
            Name = "admin_pannel";
            Text = "admin";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBooks;
        private TextBox txtBookTitle;
        private TextBox txtAuthorName;
        private TextBox txtCategoryName;
        private ComboBox cmbAuthor;
        private ComboBox cmbCategory;
        private Button btnAddAuthor;
        private Button btnAddCategory;
        private Button btnAddBook;
    }
}