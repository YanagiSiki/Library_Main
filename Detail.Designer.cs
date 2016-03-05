namespace Library_Main
{
    partial class Detail
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
            this.Copies_ID = new System.Windows.Forms.Label();
            this.Book_ISBN = new System.Windows.Forms.Label();
            this.Book_Title = new System.Windows.Forms.Label();
            this.Book_Author = new System.Windows.Forms.Label();
            this.Book_Publisher = new System.Windows.Forms.Label();
            this.Book_State = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Publisher_Address = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Copies_ID
            // 
            this.Copies_ID.AutoSize = true;
            this.Copies_ID.Location = new System.Drawing.Point(28, 20);
            this.Copies_ID.Name = "Copies_ID";
            this.Copies_ID.Size = new System.Drawing.Size(55, 12);
            this.Copies_ID.TabIndex = 0;
            this.Copies_ID.Text = "Copies_ID";
            this.Copies_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Book_ISBN
            // 
            this.Book_ISBN.AutoSize = true;
            this.Book_ISBN.Location = new System.Drawing.Point(28, 61);
            this.Book_ISBN.Name = "Book_ISBN";
            this.Book_ISBN.Size = new System.Drawing.Size(63, 12);
            this.Book_ISBN.TabIndex = 1;
            this.Book_ISBN.Text = "Book_ISBN";
            this.Book_ISBN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Book_Title
            // 
            this.Book_Title.AutoSize = true;
            this.Book_Title.Location = new System.Drawing.Point(29, 95);
            this.Book_Title.Name = "Book_Title";
            this.Book_Title.Size = new System.Drawing.Size(58, 12);
            this.Book_Title.TabIndex = 2;
            this.Book_Title.Text = "Book_Title";
            this.Book_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Book_Author
            // 
            this.Book_Author.AutoSize = true;
            this.Book_Author.Location = new System.Drawing.Point(28, 171);
            this.Book_Author.Name = "Book_Author";
            this.Book_Author.Size = new System.Drawing.Size(70, 12);
            this.Book_Author.TabIndex = 3;
            this.Book_Author.Text = "Book_Author";
            this.Book_Author.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Book_Publisher
            // 
            this.Book_Publisher.AutoSize = true;
            this.Book_Publisher.Location = new System.Drawing.Point(28, 206);
            this.Book_Publisher.Name = "Book_Publisher";
            this.Book_Publisher.Size = new System.Drawing.Size(80, 12);
            this.Book_Publisher.TabIndex = 4;
            this.Book_Publisher.Text = "Book_Publisher";
            this.Book_Publisher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Book_State
            // 
            this.Book_State.AutoSize = true;
            this.Book_State.Location = new System.Drawing.Point(28, 134);
            this.Book_State.Name = "Book_State";
            this.Book_State.Size = new System.Drawing.Size(59, 12);
            this.Book_State.TabIndex = 5;
            this.Book_State.Text = "Book_State";
            this.Book_State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(145, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Publisher_Address
            // 
            this.Publisher_Address.AutoSize = true;
            this.Publisher_Address.Location = new System.Drawing.Point(28, 244);
            this.Publisher_Address.Name = "Publisher_Address";
            this.Publisher_Address.Size = new System.Drawing.Size(91, 12);
            this.Publisher_Address.TabIndex = 7;
            this.Publisher_Address.Text = "Publisher_Address";
            this.Publisher_Address.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 295);
            this.Controls.Add(this.Publisher_Address);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Book_State);
            this.Controls.Add(this.Book_Publisher);
            this.Controls.Add(this.Book_Author);
            this.Controls.Add(this.Book_Title);
            this.Controls.Add(this.Book_ISBN);
            this.Controls.Add(this.Copies_ID);
            this.Name = "Detail";
            this.Text = "Detail";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Copies_ID;
        private System.Windows.Forms.Label Book_ISBN;
        private System.Windows.Forms.Label Book_Title;
        private System.Windows.Forms.Label Book_Author;
        private System.Windows.Forms.Label Book_Publisher;
        private System.Windows.Forms.Label Book_State;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Publisher_Address;
    }
}