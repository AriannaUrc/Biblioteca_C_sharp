namespace Biblioteca
{
    partial class user_pannel
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
            txtSearch = new TextBox();
            cmbGenre = new ComboBox();
            picBookImage = new PictureBox();
            dgvBooks = new DataGridView();
            btnSearch = new Button();
            Cover = new Label();
            btnBorrow = new Button();
            lblTitle = new Label();
            lblGenre = new Label();
            lblAuthor = new Label();
            lblSuspensionStatus = new Label();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)picBookImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(518, 29);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 0;
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(667, 29);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(121, 23);
            cmbGenre.TabIndex = 1;
            // 
            // picBookImage
            // 
            picBookImage.BackColor = SystemColors.ControlLight;
            picBookImage.Location = new Point(35, 252);
            picBookImage.Name = "picBookImage";
            picBookImage.Size = new Size(240, 158);
            picBookImage.TabIndex = 2;
            picBookImage.TabStop = false;
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(35, 29);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(240, 177);
            dgvBooks.TabIndex = 3;
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(530, 64);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // Cover
            // 
            Cover.AutoSize = true;
            Cover.Location = new Point(131, 234);
            Cover.Name = "Cover";
            Cover.Size = new Size(38, 15);
            Cover.TabIndex = 5;
            Cover.Text = "Cover";
            // 
            // btnBorrow
            // 
            btnBorrow.Location = new Point(453, 252);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(84, 53);
            btnBorrow.TabIndex = 6;
            btnBorrow.Text = "btnBorrow";
            btnBorrow.UseVisualStyleBackColor = true;
            btnBorrow.Click += btnBorrow_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(318, 257);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(59, 15);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "book_title";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(318, 313);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(59, 15);
            lblGenre.TabIndex = 8;
            lblGenre.Text = "book_title";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(318, 381);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(59, 15);
            lblAuthor.TabIndex = 9;
            lblAuthor.Text = "book_title";
            // 
            // lblSuspensionStatus
            // 
            lblSuspensionStatus.AutoSize = true;
            lblSuspensionStatus.Location = new Point(298, 29);
            lblSuspensionStatus.Name = "lblSuspensionStatus";
            lblSuspensionStatus.Size = new Size(100, 15);
            lblSuspensionStatus.TabIndex = 10;
            lblSuspensionStatus.Text = "suspended_status";
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(453, 252);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(84, 53);
            btnReturn.TabIndex = 11;
            btnReturn.Text = "btnReturn";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // user_pannel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReturn);
            Controls.Add(lblSuspensionStatus);
            Controls.Add(lblAuthor);
            Controls.Add(lblGenre);
            Controls.Add(lblTitle);
            Controls.Add(btnBorrow);
            Controls.Add(Cover);
            Controls.Add(btnSearch);
            Controls.Add(dgvBooks);
            Controls.Add(picBookImage);
            Controls.Add(cmbGenre);
            Controls.Add(txtSearch);
            Name = "user_pannel";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)picBookImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private ComboBox cmbGenre;
        private PictureBox picBookImage;
        private DataGridView dgvBooks;
        private Button btnSearch;
        private Label Cover;
        private Button btnBorrow;
        private Label lblTitle;
        private Label lblGenre;
        private Label lblAuthor;
        private Label lblSuspensionStatus;
        private Button btnReturn;
    }
}