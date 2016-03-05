using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Main
{
    public partial class Library : Form
    {
        SQLCommandModel _sqlCommandModel = new SQLCommandModel();
        Label Hello = new Label();
        SqlConnection cnn;
        public Library()
        {
            InitializeComponent();
            InitializeMain();
            Initialize_blank(false);
        }

        public void InitializeMain() // 初始化主頁
        {
            groupBox1.Text = "HI";
            Hello.Location = new Point(50, 111);
            Hello.Text = "Hello~";
            groupBox1.Controls.Add(Hello);
            label1.Visible = false;
            label2.Visible = false;
            Account_Text.Visible = false;
            Passward_Text.Visible = false;
            Login_Button.Visible = false;
            Login_Button.Enabled = false;
            Register_Bt.Enabled = false;
        }

        public void Initialize_Choose()
        {
            label1.Visible = true;
            label2.Visible = true;
            Account_Text.Visible = true;
            Account_Text.Text = "";
            Passward_Text.Visible = true;
            Passward_Text.Text = "";
            Login_Button.Visible = true;
            Name_Text.Text = "";
            Address_Text.Text = "";
            Mail_Text.Text = "";
            if (groupBox1.Text == "Register")
            {
                Login_Button.Text = "確認";
            }
            else
            {
                Login_Button.Text = "登錄";
            }
        }

        public void Initialize_blank(bool set_type)
        {
            label3.Visible = set_type;
            label4.Visible = set_type;
            label5.Visible = set_type;
            Name_Text.Visible = set_type;
            Address_Text.Visible = set_type;
            Mail_Text.Visible = set_type;
            Register_Bt.Visible = set_type;
            Hello.Visible = false;
        }

        private void Member_Button_Click(object sender, EventArgs e) //會員按鈕
        {
            groupBox1.Text = "Member_Sign In";
            Initialize_Choose();
            Initialize_blank(false);

        }

        private void Manager_Button_Click(object sender, EventArgs e) //管理員按鈕
        {
            groupBox1.Text = "Manager_Sign In";
            Initialize_Choose();
            Initialize_blank(false);
        }

        private void Regist_Button_Click(object sender, EventArgs e) //註冊按鈕
        {
            groupBox1.Text = "Register";
            Initialize_Choose();
            Initialize_blank(true);
        }

        private void Account_Text_Changed(object sender, EventArgs e)
        {
            switch (groupBox1.Text)
            {
                case "Member_Sign In":
                    if (Account_Text.Text == "" || Passward_Text.Text == "")
                    {
                        Login_Button.Enabled = false;
                    }
                    else
                    {
                        Login_Button.Enabled = true;
                    }
                    break;
                case "Manager_Sign In":
                    if (Account_Text.Text == "" || Passward_Text.Text == "")
                    {
                        Login_Button.Enabled = false;
                    }
                    else
                    {
                        Login_Button.Enabled = true;
                    }
                    break;
                case "Register":
                    if (Account_Text.Text == "")
                    {
                        Login_Button.Enabled = false;
                    }
                    else
                    {
                        Login_Button.Enabled = true;
                    }
                    if (Account_Text.Text == "" || Passward_Text.Text == "" || Name_Text.Text == "" || Address_Text.Text == "" || Mail_Text.Text == "")
                    {
                        Register_Bt.Enabled = false;
                    }
                    else
                    {
                        Register_Bt.Enabled = true;
                    }
                    break;
            }
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            SqlCommand SelectCammand = new SqlCommand();
            switch (groupBox1.Text)
            {
                case "Member_Sign In": //開MEMBER FORM 其他 ENABLE
                    cnn = _sqlCommandModel.OpenSqlConnection();
                    SelectCammand = new SqlCommand("SELECT Member_Account, Member_Password FROM Member WHERE Member_Account = '" + Account_Text.Text + "'AND Member_Password = '" + Passward_Text.Text + "'", cnn);//寫ccod
                    if (_sqlCommandModel.IsLoginSucessful(SelectCammand))
                    {
                        MessageBox.Show("Log in Sucessfully !");
                        Form member = new Member(Account_Text.Text);
                        member.Show();                        
                    }
                    else MessageBox.Show("Log in Failed !");
                    cnn.Close();                    
                    break;
                case "Manager_Sign In"://開MANAGER FORM 其他 ENABLE
                    cnn = _sqlCommandModel.OpenSqlConnection();
                    SelectCammand = new SqlCommand("SELECT Manager_Account, Manager_Password FROM Manager WHERE Manager_Account = '" + Account_Text.Text + "'AND Manager_Password = '" + Passward_Text.Text + "'", cnn);//寫ccod
                    if (_sqlCommandModel.IsLoginSucessful(SelectCammand))
                    {
                        MessageBox.Show("Log in Sucessfully !");
                        Form manager = new Manager(Account_Text.Text);
                        manager.Show();
                    }
                    else MessageBox.Show("Log in Failed !");
                    cnn.Close();
                    break;
                case "Register": //顯示是否有重複帳號
                    cnn = _sqlCommandModel.OpenSqlConnection();
                    SelectCammand = new SqlCommand("SELECT Member_Account FROM Member WHERE Member_Account = '" + Account_Text.Text + "'", cnn);//寫ccod
                    if (!_sqlCommandModel.IsTargetExist(SelectCammand))
                        MessageBox.Show("You can use this account !");
                    else MessageBox.Show("Account have been used !");
                    cnn.Close();
                    break;
            }
        }

        

        
        private void Register_Bt_Click(object sender, EventArgs e)
        {
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCammand = new SqlCommand("SELECT Member_Account FROM Member WHERE Member_Account = '" + Account_Text.Text + "'", cnn);//寫ccod                                
            SqlCommand InsertCammand = new SqlCommand("INSERT INTO Member(Member_Name,Member_Account,Member_Password,Member_Address,Member_Email) VALUES ('" + Name_Text.Text + "' , '" + Account_Text.Text + "' , '" + Passward_Text.Text + "' , '" + Address_Text.Text + "' , '" + Mail_Text.Text + "')", cnn);//寫ccod
            if (_sqlCommandModel.ExecuteInsertCommandForPrimaryKay(InsertCammand, SelectCammand))
            {
                MessageBox.Show("Account Sucessfully Created!");
                
                _sqlCommandModel.SendEmail(Mail_Text.Text);
                Initialize_Choose();
            }
            else 
            {
                MessageBox.Show("Account have been used !");
            }
           
            cnn.Close();
        }

        private void Library_Load(object sender, EventArgs e)
        {

        }

        
    }
}
