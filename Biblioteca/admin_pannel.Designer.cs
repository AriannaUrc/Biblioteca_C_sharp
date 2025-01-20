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
            label1 = new Label();
            dgvUsers = new DataGridView();
            dgvBorrowedBooks = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            textBoxUrl = new TextBox();
            btnModifyBook = new Button();
            btnDeleteBook = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBorrowedBooks).BeginInit();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(37, 36);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(343, 202);
            dgvBooks.TabIndex = 0;
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(433, 54);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(121, 23);
            txtBookTitle.TabIndex = 1;
            // 
            // txtAuthorName
            // 
            txtAuthorName.Location = new Point(657, 59);
            txtAuthorName.Name = "txtAuthorName";
            txtAuthorName.Size = new Size(100, 23);
            txtAuthorName.TabIndex = 2;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(657, 134);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(100, 23);
            txtCategoryName.TabIndex = 3;
            // 
            // cmbAuthor
            // 
            cmbAuthor.FormattingEnabled = true;
            cmbAuthor.Location = new Point(433, 94);
            cmbAuthor.Name = "cmbAuthor";
            cmbAuthor.Size = new Size(121, 23);
            cmbAuthor.TabIndex = 4;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(433, 134);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(121, 23);
            cmbCategory.TabIndex = 5;
            // 
            // btnAddAuthor
            // 
            btnAddAuthor.Location = new Point(659, 88);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new Size(98, 23);
            btnAddAuthor.TabIndex = 6;
            btnAddAuthor.Text = "Add Author";
            btnAddAuthor.UseVisualStyleBackColor = true;
            btnAddAuthor.Click += btnAddAuthor_Click;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(657, 165);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(98, 23);
            btnAddCategory.TabIndex = 7;
            btnAddCategory.Text = "Add Category";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(416, 215);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(85, 23);
            btnAddBook.TabIndex = 8;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(463, 36);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 9;
            label1.Text = "Book Title";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(37, 288);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(244, 150);
            dgvUsers.TabIndex = 10;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // dgvBorrowedBooks
            // 
            dgvBorrowedBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBorrowedBooks.Location = new Point(307, 288);
            dgvBorrowedBooks.Name = "dgvBorrowedBooks";
            dgvBorrowedBooks.Size = new Size(460, 150);
            dgvBorrowedBooks.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(486, 270);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 12;
            label2.Text = "Borrowing history";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(115, 270);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 13;
            label3.Text = "Registered users";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(189, 18);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 14;
            label4.Text = "Books";
            // 
            // button1
            // 
            button1.Location = new Point(560, 163);
            button1.Name = "button1";
            button1.Size = new Size(61, 39);
            button1.TabIndex = 15;
            button1.Text = "Choose cover";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxUrl
            // 
            textBoxUrl.Location = new Point(433, 172);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.ReadOnly = true;
            textBoxUrl.Size = new Size(121, 23);
            textBoxUrl.TabIndex = 16;
            // 
            // btnModifyBook
            // 
            btnModifyBook.Location = new Point(508, 215);
            btnModifyBook.Name = "btnModifyBook";
            btnModifyBook.Size = new Size(87, 23);
            btnModifyBook.TabIndex = 17;
            btnModifyBook.Text = "Modify Book";
            btnModifyBook.UseVisualStyleBackColor = true;
            btnModifyBook.Click += btnModifyBook_Click;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(282, 244);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(98, 23);
            btnDeleteBook.TabIndex = 18;
            btnDeleteBook.Text = "Delete Book";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // admin_pannel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteBook);
            Controls.Add(btnModifyBook);
            Controls.Add(textBoxUrl);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvBorrowedBooks);
            Controls.Add(dgvUsers);
            Controls.Add(label1);
            Controls.Add(btnAddBook);
            Controls.Add(btnAddCategory);
            Controls.Add(btnAddAuthor);
            Controls.Add(cmbCategory);
            Controls.Add(cmbAuthor);
            Controls.Add(txtCategoryName);
            Controls.Add(txtAuthorName);
            Controls.Add(txtBookTitle);
            Controls.Add(dgvBooks);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "admin_pannel";
            Text = "admin";
            FormClosed += admin_pannel_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBorrowedBooks).EndInit();
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
        private Label label1;
        private DataGridView dgvUsers;
        private DataGridView dgvBorrowedBooks;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private TextBox textBoxUrl;
        private Button btnModifyBook;
        private Button btnDeleteBook;
    }
}