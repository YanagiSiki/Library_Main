namespace Library_Main
{
    partial class Member
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Manager_Data_bt = new System.Windows.Forms.Button();
            this.Member_Data_group = new System.Windows.Forms.GroupBox();
            this.M_Mail_Text = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.M_Address_Text = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.M_Passward_Text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.M_Cancel_bt = new System.Windows.Forms.Button();
            this.M_OK_bt = new System.Windows.Forms.Button();
            this.M_Change_Data_bt = new System.Windows.Forms.Button();
            this.M_Account_Text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.M_Name_Text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Search_Reservation_bt = new System.Windows.Forms.Button();
            this.Borrow_Reservation_bt = new System.Windows.Forms.Button();
            this.History_bt = new System.Windows.Forms.Button();
            this.SR_group = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Search_GridView = new System.Windows.Forms.DataGridView();
            this.SR_Search_bt = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.SR_Search_Text = new System.Windows.Forms.TextBox();
            this.BR_group = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BR_Reservation_GridView = new System.Windows.Forms.DataGridView();
            this.BR_Borrow_GridView = new System.Windows.Forms.DataGridView();
            this.H_group = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.H_GridView = new System.Windows.Forms.DataGridView();
            this.Member_Data_group.SuspendLayout();
            this.SR_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Search_GridView)).BeginInit();
            this.BR_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BR_Reservation_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BR_Borrow_GridView)).BeginInit();
            this.H_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.H_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.label2.Location = new System.Drawing.Point(28, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "會員名稱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "會員 :";
            // 
            // Manager_Data_bt
            // 
            this.Manager_Data_bt.Location = new System.Drawing.Point(12, 77);
            this.Manager_Data_bt.Name = "Manager_Data_bt";
            this.Manager_Data_bt.Size = new System.Drawing.Size(126, 53);
            this.Manager_Data_bt.TabIndex = 9;
            this.Manager_Data_bt.Text = "會員資料";
            this.Manager_Data_bt.UseVisualStyleBackColor = true;
            this.Manager_Data_bt.Click += new System.EventHandler(this.Manager_Data_bt_Click);
            // 
            // Member_Data_group
            // 
            this.Member_Data_group.Controls.Add(this.M_Mail_Text);
            this.Member_Data_group.Controls.Add(this.label7);
            this.Member_Data_group.Controls.Add(this.M_Address_Text);
            this.Member_Data_group.Controls.Add(this.label6);
            this.Member_Data_group.Controls.Add(this.M_Passward_Text);
            this.Member_Data_group.Controls.Add(this.label5);
            this.Member_Data_group.Controls.Add(this.M_Cancel_bt);
            this.Member_Data_group.Controls.Add(this.M_OK_bt);
            this.Member_Data_group.Controls.Add(this.M_Change_Data_bt);
            this.Member_Data_group.Controls.Add(this.M_Account_Text);
            this.Member_Data_group.Controls.Add(this.label4);
            this.Member_Data_group.Controls.Add(this.M_Name_Text);
            this.Member_Data_group.Controls.Add(this.label3);
            this.Member_Data_group.Enabled = false;
            this.Member_Data_group.Font = new System.Drawing.Font("新細明體", 12F);
            this.Member_Data_group.Location = new System.Drawing.Point(165, 10);
            this.Member_Data_group.Name = "Member_Data_group";
            this.Member_Data_group.Size = new System.Drawing.Size(680, 430);
            this.Member_Data_group.TabIndex = 10;
            this.Member_Data_group.TabStop = false;
            this.Member_Data_group.Text = "基本資料";
            this.Member_Data_group.Visible = false;
            // 
            // M_Mail_Text
            // 
            this.M_Mail_Text.Enabled = false;
            this.M_Mail_Text.Font = new System.Drawing.Font("新細明體", 9F);
            this.M_Mail_Text.Location = new System.Drawing.Point(75, 217);
            this.M_Mail_Text.Name = "M_Mail_Text";
            this.M_Mail_Text.Size = new System.Drawing.Size(438, 22);
            this.M_Mail_Text.TabIndex = 12;
            this.M_Mail_Text.TextChanged += new System.EventHandler(this.Member_Data_Changed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 12F);
            this.label7.Location = new System.Drawing.Point(15, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Email : ";
            // 
            // M_Address_Text
            // 
            this.M_Address_Text.Enabled = false;
            this.M_Address_Text.Font = new System.Drawing.Font("新細明體", 9F);
            this.M_Address_Text.Location = new System.Drawing.Point(76, 147);
            this.M_Address_Text.Multiline = true;
            this.M_Address_Text.Name = "M_Address_Text";
            this.M_Address_Text.Size = new System.Drawing.Size(437, 52);
            this.M_Address_Text.TabIndex = 10;
            this.M_Address_Text.TextChanged += new System.EventHandler(this.Member_Data_Changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 12F);
            this.label6.Location = new System.Drawing.Point(15, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "地址 :";
            // 
            // M_Passward_Text
            // 
            this.M_Passward_Text.Enabled = false;
            this.M_Passward_Text.Font = new System.Drawing.Font("新細明體", 9F);
            this.M_Passward_Text.Location = new System.Drawing.Point(76, 107);
            this.M_Passward_Text.Name = "M_Passward_Text";
            this.M_Passward_Text.Size = new System.Drawing.Size(100, 22);
            this.M_Passward_Text.TabIndex = 8;
            this.M_Passward_Text.TextChanged += new System.EventHandler(this.Member_Data_Changed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 12F);
            this.label5.Location = new System.Drawing.Point(15, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "密碼 :";
            // 
            // M_Cancel_bt
            // 
            this.M_Cancel_bt.Font = new System.Drawing.Font("新細明體", 9F);
            this.M_Cancel_bt.Location = new System.Drawing.Point(584, 387);
            this.M_Cancel_bt.Name = "M_Cancel_bt";
            this.M_Cancel_bt.Size = new System.Drawing.Size(80, 25);
            this.M_Cancel_bt.TabIndex = 6;
            this.M_Cancel_bt.Text = "取消";
            this.M_Cancel_bt.UseVisualStyleBackColor = true;
            this.M_Cancel_bt.Click += new System.EventHandler(this.M_Cancel_bt_Click);
            // 
            // M_OK_bt
            // 
            this.M_OK_bt.Font = new System.Drawing.Font("新細明體", 9F);
            this.M_OK_bt.Location = new System.Drawing.Point(452, 387);
            this.M_OK_bt.Name = "M_OK_bt";
            this.M_OK_bt.Size = new System.Drawing.Size(80, 25);
            this.M_OK_bt.TabIndex = 5;
            this.M_OK_bt.Text = "確定";
            this.M_OK_bt.UseVisualStyleBackColor = true;
            this.M_OK_bt.Click += new System.EventHandler(this.M_OK_bt_Click);
            // 
            // M_Change_Data_bt
            // 
            this.M_Change_Data_bt.Font = new System.Drawing.Font("新細明體", 9F);
            this.M_Change_Data_bt.Location = new System.Drawing.Point(16, 387);
            this.M_Change_Data_bt.Name = "M_Change_Data_bt";
            this.M_Change_Data_bt.Size = new System.Drawing.Size(80, 25);
            this.M_Change_Data_bt.TabIndex = 4;
            this.M_Change_Data_bt.Text = "更改資料";
            this.M_Change_Data_bt.UseVisualStyleBackColor = true;
            this.M_Change_Data_bt.Click += new System.EventHandler(this.M_Change_Data_bt_Click);
            // 
            // M_Account_Text
            // 
            this.M_Account_Text.Enabled = false;
            this.M_Account_Text.Font = new System.Drawing.Font("新細明體", 9F);
            this.M_Account_Text.Location = new System.Drawing.Point(76, 67);
            this.M_Account_Text.Name = "M_Account_Text";
            this.M_Account_Text.Size = new System.Drawing.Size(100, 22);
            this.M_Account_Text.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F);
            this.label4.Location = new System.Drawing.Point(15, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "帳號 : ";
            // 
            // M_Name_Text
            // 
            this.M_Name_Text.Enabled = false;
            this.M_Name_Text.Font = new System.Drawing.Font("新細明體", 9F);
            this.M_Name_Text.Location = new System.Drawing.Point(76, 27);
            this.M_Name_Text.Name = "M_Name_Text";
            this.M_Name_Text.Size = new System.Drawing.Size(100, 22);
            this.M_Name_Text.TabIndex = 1;
            this.M_Name_Text.TextChanged += new System.EventHandler(this.Member_Data_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F);
            this.label3.Location = new System.Drawing.Point(15, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "姓名 : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 12F);
            this.label8.Location = new System.Drawing.Point(277, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "WELCOME~";
            // 
            // Search_Reservation_bt
            // 
            this.Search_Reservation_bt.Location = new System.Drawing.Point(12, 135);
            this.Search_Reservation_bt.Name = "Search_Reservation_bt";
            this.Search_Reservation_bt.Size = new System.Drawing.Size(126, 53);
            this.Search_Reservation_bt.TabIndex = 9;
            this.Search_Reservation_bt.Text = "查詢/預約";
            this.Search_Reservation_bt.UseVisualStyleBackColor = true;
            this.Search_Reservation_bt.Click += new System.EventHandler(this.Search_Reservation_bt_Click);
            // 
            // Borrow_Reservation_bt
            // 
            this.Borrow_Reservation_bt.Location = new System.Drawing.Point(12, 194);
            this.Borrow_Reservation_bt.Name = "Borrow_Reservation_bt";
            this.Borrow_Reservation_bt.Size = new System.Drawing.Size(126, 53);
            this.Borrow_Reservation_bt.TabIndex = 9;
            this.Borrow_Reservation_bt.Text = "借閱/預約書籍";
            this.Borrow_Reservation_bt.UseVisualStyleBackColor = true;
            this.Borrow_Reservation_bt.Click += new System.EventHandler(this.Borrow_Reservation_bt_Click);
            // 
            // History_bt
            // 
            this.History_bt.Location = new System.Drawing.Point(12, 253);
            this.History_bt.Name = "History_bt";
            this.History_bt.Size = new System.Drawing.Size(126, 53);
            this.History_bt.TabIndex = 9;
            this.History_bt.Text = "歷史紀錄";
            this.History_bt.UseVisualStyleBackColor = true;
            this.History_bt.Click += new System.EventHandler(this.History_bt_Click);
            // 
            // SR_group
            // 
            this.SR_group.Controls.Add(this.checkBox1);
            this.SR_group.Controls.Add(this.Search_GridView);
            this.SR_group.Controls.Add(this.SR_Search_bt);
            this.SR_group.Controls.Add(this.label20);
            this.SR_group.Controls.Add(this.SR_Search_Text);
            this.SR_group.Font = new System.Drawing.Font("新細明體", 12F);
            this.SR_group.Location = new System.Drawing.Point(165, 10);
            this.SR_group.Name = "SR_group";
            this.SR_group.Size = new System.Drawing.Size(680, 430);
            this.SR_group.TabIndex = 12;
            this.SR_group.TabStop = false;
            this.SR_group.Text = "查詢/預約";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(412, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 20);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "進階搜尋";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Search_GridView
            // 
            this.Search_GridView.AllowUserToAddRows = false;
            this.Search_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Search_GridView.Location = new System.Drawing.Point(16, 74);
            this.Search_GridView.Name = "Search_GridView";
            this.Search_GridView.RowHeadersVisible = false;
            this.Search_GridView.RowTemplate.Height = 24;
            this.Search_GridView.Size = new System.Drawing.Size(648, 338);
            this.Search_GridView.TabIndex = 3;
            this.Search_GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Search_GridView_CellContentClick);
            // 
            // SR_Search_bt
            // 
            this.SR_Search_bt.Enabled = false;
            this.SR_Search_bt.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SR_Search_bt.Location = new System.Drawing.Point(515, 27);
            this.SR_Search_bt.Name = "SR_Search_bt";
            this.SR_Search_bt.Size = new System.Drawing.Size(75, 23);
            this.SR_Search_bt.TabIndex = 2;
            this.SR_Search_bt.Text = "搜尋";
            this.SR_Search_bt.UseVisualStyleBackColor = true;
            this.SR_Search_bt.Click += new System.EventHandler(this.SR_Search_bt_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 16);
            this.label20.TabIndex = 1;
            this.label20.Text = "請輸入關鍵字 :";
            // 
            // SR_Search_Text
            // 
            this.SR_Search_Text.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SR_Search_Text.Location = new System.Drawing.Point(142, 27);
            this.SR_Search_Text.Name = "SR_Search_Text";
            this.SR_Search_Text.Size = new System.Drawing.Size(264, 22);
            this.SR_Search_Text.TabIndex = 0;
            this.SR_Search_Text.TextChanged += new System.EventHandler(this.Member_Data_Changed);
            // 
            // BR_group
            // 
            this.BR_group.Controls.Add(this.label10);
            this.BR_group.Controls.Add(this.label9);
            this.BR_group.Controls.Add(this.BR_Reservation_GridView);
            this.BR_group.Controls.Add(this.BR_Borrow_GridView);
            this.BR_group.Font = new System.Drawing.Font("新細明體", 12F);
            this.BR_group.Location = new System.Drawing.Point(165, 10);
            this.BR_group.Name = "BR_group";
            this.BR_group.Size = new System.Drawing.Size(680, 430);
            this.BR_group.TabIndex = 4;
            this.BR_group.TabStop = false;
            this.BR_group.Text = "借閱/預約書籍";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "預約中 :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "借閱中 :";
            // 
            // BR_Reservation_GridView
            // 
            this.BR_Reservation_GridView.AllowUserToAddRows = false;
            this.BR_Reservation_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BR_Reservation_GridView.Location = new System.Drawing.Point(20, 260);
            this.BR_Reservation_GridView.Name = "BR_Reservation_GridView";
            this.BR_Reservation_GridView.RowHeadersVisible = false;
            this.BR_Reservation_GridView.RowTemplate.Height = 24;
            this.BR_Reservation_GridView.Size = new System.Drawing.Size(640, 150);
            this.BR_Reservation_GridView.TabIndex = 0;
            this.BR_Reservation_GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BR_Reservation_GridView_CellContentClick);
            // 
            // BR_Borrow_GridView
            // 
            this.BR_Borrow_GridView.AllowUserToAddRows = false;
            this.BR_Borrow_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BR_Borrow_GridView.Location = new System.Drawing.Point(20, 60);
            this.BR_Borrow_GridView.Name = "BR_Borrow_GridView";
            this.BR_Borrow_GridView.RowHeadersVisible = false;
            this.BR_Borrow_GridView.RowTemplate.Height = 24;
            this.BR_Borrow_GridView.Size = new System.Drawing.Size(640, 160);
            this.BR_Borrow_GridView.TabIndex = 0;
            this.BR_Borrow_GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BR_Borrow_GridView_CellContentClick);
            // 
            // H_group
            // 
            this.H_group.Controls.Add(this.label12);
            this.H_group.Controls.Add(this.H_GridView);
            this.H_group.Font = new System.Drawing.Font("新細明體", 12F);
            this.H_group.Location = new System.Drawing.Point(165, 10);
            this.H_group.Name = "H_group";
            this.H_group.Size = new System.Drawing.Size(680, 430);
            this.H_group.TabIndex = 5;
            this.H_group.TabStop = false;
            this.H_group.Text = "歷史紀錄";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "歷史紀錄 :";
            // 
            // H_GridView
            // 
            this.H_GridView.AllowUserToAddRows = false;
            this.H_GridView.Location = new System.Drawing.Point(20, 65);
            this.H_GridView.Name = "H_GridView";
            this.H_GridView.RowTemplate.Height = 24;
            this.H_GridView.Size = new System.Drawing.Size(643, 345);
            this.H_GridView.TabIndex = 0;
            this.H_GridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.H_GridView_CellContentClick);
            // 
            // Member
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 456);
            this.Controls.Add(this.History_bt);
            this.Controls.Add(this.Borrow_Reservation_bt);
            this.Controls.Add(this.Search_Reservation_bt);
            this.Controls.Add(this.Manager_Data_bt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.H_group);
            this.Controls.Add(this.BR_group);
            this.Controls.Add(this.SR_group);
            this.Controls.Add(this.Member_Data_group);
            this.Controls.Add(this.label8);
            this.Name = "Member";
            this.Text = "Member";
            this.Member_Data_group.ResumeLayout(false);
            this.Member_Data_group.PerformLayout();
            this.SR_group.ResumeLayout(false);
            this.SR_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Search_GridView)).EndInit();
            this.BR_group.ResumeLayout(false);
            this.BR_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BR_Reservation_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BR_Borrow_GridView)).EndInit();
            this.H_group.ResumeLayout(false);
            this.H_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.H_GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Manager_Data_bt;
        private System.Windows.Forms.GroupBox Member_Data_group;
        private System.Windows.Forms.TextBox M_Mail_Text;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox M_Address_Text;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox M_Passward_Text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button M_Cancel_bt;
        private System.Windows.Forms.Button M_OK_bt;
        private System.Windows.Forms.Button M_Change_Data_bt;
        private System.Windows.Forms.TextBox M_Account_Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox M_Name_Text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Search_Reservation_bt;
        private System.Windows.Forms.Button Borrow_Reservation_bt;
        private System.Windows.Forms.Button History_bt;
        private System.Windows.Forms.GroupBox SR_group;
        private System.Windows.Forms.GroupBox BR_group;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView BR_Reservation_GridView;
        private System.Windows.Forms.DataGridView BR_Borrow_GridView;
        private System.Windows.Forms.GroupBox H_group;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView H_GridView;
        private System.Windows.Forms.DataGridView Search_GridView;
        private System.Windows.Forms.Button SR_Search_bt;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox SR_Search_Text;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}