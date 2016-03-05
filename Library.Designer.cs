namespace Library_Main
{
    partial class Library
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Member_Button = new System.Windows.Forms.Button();
            this.Manager_Button = new System.Windows.Forms.Button();
            this.Register_Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Mail_Text = new System.Windows.Forms.TextBox();
            this.Address_Text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Name_Text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Register_Bt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Passward_Text = new System.Windows.Forms.TextBox();
            this.Account_Text = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Member_Button
            // 
            this.Member_Button.Location = new System.Drawing.Point(12, 13);
            this.Member_Button.Name = "Member_Button";
            this.Member_Button.Size = new System.Drawing.Size(191, 86);
            this.Member_Button.TabIndex = 0;
            this.Member_Button.Text = "會員登錄";
            this.Member_Button.UseVisualStyleBackColor = true;
            this.Member_Button.Click += new System.EventHandler(this.Member_Button_Click);
            // 
            // Manager_Button
            // 
            this.Manager_Button.Location = new System.Drawing.Point(12, 112);
            this.Manager_Button.Name = "Manager_Button";
            this.Manager_Button.Size = new System.Drawing.Size(191, 86);
            this.Manager_Button.TabIndex = 0;
            this.Manager_Button.Text = "管理員登錄";
            this.Manager_Button.UseVisualStyleBackColor = true;
            this.Manager_Button.Click += new System.EventHandler(this.Manager_Button_Click);
            // 
            // Register_Button
            // 
            this.Register_Button.Location = new System.Drawing.Point(12, 217);
            this.Register_Button.Name = "Register_Button";
            this.Register_Button.Size = new System.Drawing.Size(191, 86);
            this.Register_Button.TabIndex = 0;
            this.Register_Button.Text = "註冊";
            this.Register_Button.UseVisualStyleBackColor = true;
            this.Register_Button.Click += new System.EventHandler(this.Regist_Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Mail_Text);
            this.groupBox1.Controls.Add(this.Address_Text);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Name_Text);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Register_Bt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Login_Button);
            this.groupBox1.Controls.Add(this.Passward_Text);
            this.groupBox1.Controls.Add(this.Account_Text);
            this.groupBox1.Location = new System.Drawing.Point(209, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 296);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Member_Sign In";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email :";
            // 
            // Mail_Text
            // 
            this.Mail_Text.Location = new System.Drawing.Point(50, 180);
            this.Mail_Text.Name = "Mail_Text";
            this.Mail_Text.Size = new System.Drawing.Size(347, 22);
            this.Mail_Text.TabIndex = 8;
            this.Mail_Text.TextChanged += new System.EventHandler(this.Account_Text_Changed);
            // 
            // Address_Text
            // 
            this.Address_Text.Location = new System.Drawing.Point(50, 139);
            this.Address_Text.Name = "Address_Text";
            this.Address_Text.Size = new System.Drawing.Size(347, 22);
            this.Address_Text.TabIndex = 8;
            this.Address_Text.TextChanged += new System.EventHandler(this.Account_Text_Changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "地址 :";
            // 
            // Name_Text
            // 
            this.Name_Text.Location = new System.Drawing.Point(50, 99);
            this.Name_Text.Name = "Name_Text";
            this.Name_Text.Size = new System.Drawing.Size(240, 22);
            this.Name_Text.TabIndex = 6;
            this.Name_Text.TextChanged += new System.EventHandler(this.Account_Text_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "名字 :";
            // 
            // Register_Bt
            // 
            this.Register_Bt.Location = new System.Drawing.Point(322, 267);
            this.Register_Bt.Name = "Register_Bt";
            this.Register_Bt.Size = new System.Drawing.Size(75, 23);
            this.Register_Bt.TabIndex = 4;
            this.Register_Bt.Text = "註冊";
            this.Register_Bt.UseVisualStyleBackColor = true;
            this.Register_Bt.Click += new System.EventHandler(this.Register_Bt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密碼 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "帳號 : ";
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(296, 21);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(75, 23);
            this.Login_Button.TabIndex = 1;
            this.Login_Button.Text = "登錄";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Passward_Text
            // 
            this.Passward_Text.Location = new System.Drawing.Point(50, 60);
            this.Passward_Text.Name = "Passward_Text";
            this.Passward_Text.Size = new System.Drawing.Size(240, 22);
            this.Passward_Text.TabIndex = 0;
            this.Passward_Text.TextChanged += new System.EventHandler(this.Account_Text_Changed);
            // 
            // Account_Text
            // 
            this.Account_Text.Location = new System.Drawing.Point(50, 21);
            this.Account_Text.Name = "Account_Text";
            this.Account_Text.Size = new System.Drawing.Size(240, 22);
            this.Account_Text.TabIndex = 0;
            this.Account_Text.TextChanged += new System.EventHandler(this.Account_Text_Changed);
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.Member_Button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Register_Button);
            this.Controls.Add(this.Manager_Button);
            this.Name = "Library";
            this.Text = "Library";
            this.Load += new System.EventHandler(this.Library_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Member_Button;
        private System.Windows.Forms.Button Manager_Button;
        private System.Windows.Forms.Button Register_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.TextBox Passward_Text;
        private System.Windows.Forms.TextBox Account_Text;
        private System.Windows.Forms.Button Register_Bt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Mail_Text;
        private System.Windows.Forms.TextBox Address_Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Name_Text;
        private System.Windows.Forms.Label label3;

    }
}

