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
using System.Net;
using System.IO;

namespace Library_Main
{
    public partial class Manager : Form
    {
        SQLCommandModel _sqlCommandModel = new SQLCommandModel();
        BindingSource _managerBindingSource = new BindingSource();
        BindingSource _copiesBindingSource = new BindingSource();
        BindingSource _bookInformationBindingSource = new BindingSource();
        SqlConnection cnn;
        string _managerAccount;
        int _managerID;
        bool EditOrAddFlag = true;
        string _imagePath = "http://i.imgur.com/ucj6ueC.png";

        public Manager(string Account)
        {
            _managerAccount = Account;
            InitializeComponent();
            label2.Text = _managerAccount;
            Set_Group();
            UpdateManagerDataSource();
            UpdateBookInformationListboxDataSource();
            UpdateBookInformationDataSource();
            BindingManagerInformation();
            BindingBookInformation();
        }

        private void BindingManagerInformation()
        {
            Name_Text.DataBindings.Add("Text", _managerBindingSource, "Manager_Name");
            Account_Text.DataBindings.Add("Text", _managerBindingSource, "Manager_Account");
            Password_Text.DataBindings.Add("Text", _managerBindingSource, "Manager_Password");
            Address_Text.DataBindings.Add("Text", _managerBindingSource, "Manger_Address");
            Mail_Text.DataBindings.Add("Text", _managerBindingSource, "Manger_Email");
        }

        private void BindingBookInformation()
        {
            EN_Book_ISBN_Text.DataBindings.Add("Text", _bookInformationBindingSource, "Book_ISBN");
            EN_Book_Name_Text.DataBindings.Add("Text", _bookInformationBindingSource, "Book_Title");
            EN_Auther_Name_Text.DataBindings.Add("Text", _bookInformationBindingSource, "Author_Name");
            EN_Publisher_Name_Text.DataBindings.Add("Text", _bookInformationBindingSource, "Publisher_Name");
            EN_Publisher_Address_Text.DataBindings.Add("Text", _bookInformationBindingSource, "Publisher_Address");

        }

        private void UpdateManagerDataSource()
        {
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCommand = new SqlCommand("SELECT * FROM Manager WHERE Manager_Account = '" + _managerAccount + "'", cnn);//寫ccod
            DataTable tt = new DataTable(); //拿出來
            tt = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            _managerBindingSource.DataSource = tt;
            _managerID = int.Parse(tt.Rows[0][0].ToString());
            cnn.Close();
        }

        private void UpdateBookInformationListboxDataSource()
        {
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCommand = new SqlCommand("SELECT	Book_Information.Book_Title FROM	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Author Author,	DatabaseCSIE102.dbo.Publisher Publisher WHERE	Book_Information.Book_ISBN = Author.Book_ISBN AND	Book_Information.Book_ISBN = Publisher.Book_ISBN AND	Author.Book_ISBN = Publisher.Book_ISBN ;", cnn);//寫ccod
            DataTable tt = new DataTable(); //拿出來
            tt = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            Book_ListBox.DisplayMember = "Book_Title";
            Book_ListBox.ValueMember = "Book_Title";
            Book_ListBox.DataSource = tt;
            cnn.Close();
        }

        private void UpdateBookInformationDataSource()
        {
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCommand = new SqlCommand("SELECT Book_Title, Book_Information.Book_ISBN, Book_Image,  Publisher_Name, Publisher_Address, Author_Name	FROM Book_Information,Publisher,Author WHERE Publisher.Book_ISBN = Book_Information.Book_ISBN  AND	Author.Book_ISBN = Book_Information.Book_ISBN AND Book_Title = '" + Book_ListBox.SelectedValue.ToString() + "';", cnn);//寫ccod
            DataTable tt = new DataTable(); //拿出來
            tt = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            //_bookInformationBindingSource.Clear();
            _bookInformationBindingSource.DataSource = tt;
            string image = tt.Rows[0][2].ToString();
            if (image != String.Empty) 
            {
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(image);
                MemoryStream ms = new MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                EN_Book_Image_PictureBox.Image = img;
                _imagePath = image;
            }
                
            cnn.Close();
        }

        /// <summary>
        /// 以上為實作DataBinding
        /// </summary>
        /// <param name="set_type"></param>

        public void Set_Change(bool set_type)
        {
            Name_Text.Enabled = set_type;
            Password_Text.Enabled = set_type;
            Address_Text.Enabled = set_type;
            Mail_Text.Enabled = set_type;
            OK_bt.Enabled = set_type;
            Cancel_bt.Enabled = set_type;
            OK_bt.Visible = set_type;
            Cancel_bt.Visible = set_type;
        }

        public void Set_Data()
        {
            Name_Text.Text = "s"; //內容
            Account_Text.Text = "s";//內容
            Password_Text.Text = "s";//內容
            Address_Text.Text = "s";//內容
            Mail_Text.Text = "s";//內容
        }

        public void Set_Group()
        {
            Manager_Data_group.Enabled = false;
            Manager_Data_group.Visible = false;
            Update_group.Enabled = false;
            Update_group.Visible = false;
            Trace_group.Enabled = false;
            Trace_group.Visible = false;
            Edit_New_group.Enabled = false;
            Edit_New_group.Visible = false;
            Search_group.Enabled = false;
            Search_group.Visible = false;
            Lend_group.Enabled = false;
            Lend_group.Visible = false;
            Return_Book_group.Enabled = false;
            Return_Book_group.Visible = false;
            Manager_Assign_group.Enabled = false;
            Manager_Assign_group.Visible = false;
        }

        public void Set_Trace_Text(bool type)
        {           
            T_Search_Text.Enabled = type;            
        }

        public void Set_EN_Object(bool type)
        {
            EN_Book_Name_Text.Enabled = type;
            EN_Book_ISBN_Text.Enabled = type;
            EN_Auther_Name_Text.Enabled = type;
            EN_Publisher_Address_Text.Enabled = type;
            EN_Publisher_Name_Text.Enabled = type;
            button1.Enabled = type;
            //EN_Date_Text.Enabled = type;
            EN_Cancel_bt.Enabled = type;
            EN_Cancel_bt.Visible = type;
            EN_OK_bt.Enabled = type;
            EN_OK_bt.Visible = type;
            EN_New_bt.Enabled = !type;
            EN_Edit_bt.Enabled = !type;
            Book_ListBox.Enabled = !type;
            EN_Delete_bt.Enabled = !type;
        }

        public void EN_Set_Book_ListBox()
        {
            //Book_ListBox.Items.Clear();
            //要加LISTBOX的內容
        }

        private void Data_Change(object sender, EventArgs e)
        {
            if (Name_Text.Text == "" || Password_Text.Text == "" || Address_Text.Text == "" || Mail_Text.Text == "") //更改管理員資料
            {
                OK_bt.Enabled = false;
            }
            else
            {
                OK_bt.Enabled = true;
            }
            if (U_Isbn_Text.Text == "" || U_Date_Text.Text == "") // 上架資料
            {
                U_Update_bt.Enabled = false;
            }
            else
            {
                U_Update_bt.Enabled = true;
            }
        }

        private void Trace_Text_Change(object sender, EventArgs e)
        {
            
            if (T_Search_Text.Text == "")
            {
                T_trace_bt.Enabled = false;
                Set_Trace_Text(true);
            }
            else
            {
                T_trace_bt.Enabled = true;
            }
        }

        private void EN_Text_Change(object sender, EventArgs e)
        {
            if (EN_Book_Name_Text.Text == "" || EN_Auther_Name_Text.Text == "" || EN_Publisher_Address_Text.Text == "" || EN_Publisher_Name_Text.Text == "" || EN_Date_Text.Text == "" || EN_Book_ISBN_Text.Text == "")
            {
                EN_OK_bt.Enabled = false;
            }
            else
            {
                EN_OK_bt.Enabled = true;
            }
            if (S_Search_Text.Text == "") //搜尋資料
            {
                S_Search_bt.Enabled = false;
            }
            else
            {
                S_Search_bt.Enabled = true;
            }
        }

        private void Lend_Text_Change(object sender, EventArgs e)
        {
            if (L_Book_Isbn_Text.Text == "" || L_Member_ID_Text.Text == "" || L_Date_Text.Text == "") // 把書借出
            {
                L_Lend_bt.Enabled = false;
            }
            else
            {
                L_Lend_bt.Enabled = true;
            }
            if (R_Return_Book_Isbn_Text.Text == "" || R_Return_Date_Text.Text == "")
            {
                R_Return_Book_bt.Enabled = false;
            }
            else
            {
                R_Return_Book_bt.Enabled = true;
            }
        }

        private void Book_Select(object sender, EventArgs e)
        {
            if (Book_ListBox.SelectedIndex != -1)
            {
                EN_Book_ISBN_Text.Text = "b";
                EN_Book_Name_Text.Text = "b";
                EN_Auther_Name_Text.Text = "b";
                EN_Publisher_Name_Text.Text = "b";
                EN_Publisher_Address_Text.Text = "b";
                EN_Book_Image_PictureBox.Image = null;
                button1.Enabled = false;
                EN_Date_Text.Text = DateTime.Now.Date.ToShortDateString();
            }
            UpdateBookInformationDataSource();
        }


        private void Change_Data_bt_Click(object sender, EventArgs e) //更改管理員資料
        {
            Change_Data_bt.Enabled = false;
            Set_Change(true);
        }

        private void OK_bt_Click(object sender, EventArgs e) //更改管理員資料確定
        {
            //UPDATE
            Set_Change(false);
            Change_Data_bt.Enabled = true;
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand UpdateCommand = new SqlCommand("UPDATE Manager SET Manager_Name = '" + Name_Text.Text + "', " + " Manager_Password = '" + Password_Text.Text + "', Manger_Address = '" + Address_Text.Text + "', Manger_Email = '" + Mail_Text.Text + "' WHERE Manager_Account = '" + Account_Text.Text + "'", cnn);//寫ccod            
            _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
            cnn.Close();
        }

        private void Cancel_bt_Click(object sender, EventArgs e) //更改管理員資料取消
        {
            Set_Change(false);
            Set_Data();
            Change_Data_bt.Enabled = true;
        }

        private void U_Update_bt_Click(object sender, EventArgs e)
        {
            // Update_GridView 輸出我上架的書
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCommand = new SqlCommand("SELECT * FROM Book_Information WHERE Book_ISBN = '" + U_Isbn_Text.Text + "'", cnn);//寫ccod                                
            SqlCommand InsertCommand = new SqlCommand("INSERT INTO Copies(Book_ISBN, Book_state, Manager_ID, Update_Date) VALUES ('" + U_Isbn_Text.Text + "' , 'OnShelf' ,'" + _managerID + "' , '" + DateTime.Parse(U_Date_Text.Text).ToShortDateString() + "')", cnn);//寫ccod
            _sqlCommandModel.ExecuteInsertCommandForForeignKay(InsertCommand, SelectCommand);
            SelectCommand = new SqlCommand("SELECT * FROM Copies WHERE Book_ISBN = '" + U_Isbn_Text.Text + "'", cnn);
            Update_GridView.Columns.Clear();
            Update_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            _sqlCommandModel.AddInformationDetail(Update_GridView);
            cnn.Close();
        }

        private void T_trace_bt_Click(object sender, EventArgs e)
        {
            // Trace_GridView 輸出目前追蹤的書
            int sw = comboBox1.SelectedIndex;
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCommand = new SqlCommand();
            switch (sw)
            {
                case 0:
                    SelectCommand = new SqlCommand("SELECT	Copies.Copies_ID,	Copies.Book_ISBN,	Copies.Book_state,	Book_Information.Book_Title,	Borrow.Return_Date,	Borrow.Start_Date,	Borrow.Due_Date,	Member.Member_Account FROM	DatabaseCSIE102.dbo.Copies Copies,	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Borrow Borrow,	DatabaseCSIE102.dbo.Member Member WHERE	Copies.Copies_ID = Borrow.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN AND	Borrow.Member_Account = Member.Member_Account AND	Copies.Copies_ID = '" + T_Search_Text.Text + "';", cnn);//寫ccod
                    break;
                case 1:
                    SelectCommand = new SqlCommand("SELECT	Copies.Copies_ID ,Book_Information.Book_ISBN,	Book_Information.Book_Title,	Copies.Book_state FROM	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Copies Copies WHERE	Book_Information.Book_ISBN = Copies.Book_ISBN AND	Book_Information.Book_ISBN = '" + T_Search_Text.Text + "';", cnn);//寫ccod
                    break;
                case 2:
                    SelectCommand = new SqlCommand("SELECT	Borrow.Copies_ID , Member.Member_Account,	Member.Member_Email,	Borrow.Start_Date,	Borrow.Due_Date,	Copies.Book_ISBN,	Book_Information.Book_Title FROM	DatabaseCSIE102.dbo.Member Member,	DatabaseCSIE102.dbo.Borrow Borrow,	DatabaseCSIE102.dbo.Copies Copies,	DatabaseCSIE102.dbo.Book_Information Book_Information WHERE	Member.Member_Account = Borrow.Member_Account AND	Borrow.Copies_ID = Copies.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN AND	Member.Member_Account = '" + T_Search_Text.Text + "';", cnn);//寫ccod
                    break;
                case 3:
                    SelectCommand = new SqlCommand("SELECT	Copies.Copies_ID,  Manager.Manager_Name,	Manager.Manager_Account,	Manager.Manger_Email,	Book_Information.Book_Title FROM	DatabaseCSIE102.dbo.Manager Manager,	DatabaseCSIE102.dbo.Lend Lend,	DatabaseCSIE102.dbo.Copies Copies,	DatabaseCSIE102.dbo.Book_Information Book_Information WHERE	Manager.Manager_ID = Lend.Manager_ID AND	Manager.Manager_ID = Copies.Manager_ID AND	Lend.Copies_ID = Copies.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN AND	Manager.Manager_Account = '" + T_Search_Text.Text +"';", cnn);//寫ccod
                    break;
            }
            Trace_GridView.Columns.Clear();
            Trace_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            _sqlCommandModel.AddInformationDetail(Trace_GridView);
            cnn.Close();
        }

        private void EN_Edit_bt_Click(object sender, EventArgs e)
        {
            if (Book_ListBox.SelectedIndex != -1)
            {
                Set_EN_Object(true);
            }
            else
            {
                MessageBox.Show("請選擇要編輯的書");
            }
            EditOrAddFlag = true;//編輯模式
        }

        private void EN_New_bt_Click(object sender, EventArgs e)
        {
            Set_EN_Object(true);
            EN_Book_Name_Text.Text = "";
            EN_Book_ISBN_Text.Text = "";
            EN_Auther_Name_Text.Text = "";
            EN_Publisher_Name_Text.Text = "";
            EN_Publisher_Address_Text.Text = "";
            button1.Enabled = true;
            EN_Book_Image_PictureBox.Image = null;
            EN_Date_Text.Text = DateTime.Now.Date.ToShortDateString();
            EditOrAddFlag = false;//新增模式
        }

        private void EN_OK_bt_Click(object sender, EventArgs e)
        {
            //存上去
            EN_Set_Book_ListBox();

            if (EditOrAddFlag)//編輯模式
            {
                cnn = _sqlCommandModel.OpenSqlConnection();

                SqlCommand UpdateCommand = new SqlCommand("UPDATE Book_Information SET  Book_Title = '" + EN_Book_Name_Text.Text + "' , Book_Image = '" + _imagePath + "' WHERE Book_ISBN = '" + EN_Book_ISBN_Text.Text + "'", cnn);//寫ccod       
                _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
                UpdateCommand = new SqlCommand("UPDATE Publisher SET Publisher_Name = '" + EN_Publisher_Name_Text.Text + "' , Publisher_Address = '" + EN_Publisher_Address_Text.Text + "' WHERE Book_ISBN = '" + EN_Book_ISBN_Text.Text + "'", cnn);//寫ccod       
                _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
                UpdateCommand = new SqlCommand("UPDATE Author SET  Author_Name = '" + EN_Auther_Name_Text.Text + "' WHERE Book_ISBN = '" + EN_Book_ISBN_Text.Text + "'", cnn);//寫ccod       
                _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
                SqlCommand InsertCommand = new SqlCommand("INSERT INTO Edit(Edit_Date, Book_ISBN, Manager_ID) VALUES ('" + DateTime.Parse(EN_Date_Text.Text).ToShortDateString() + "' ,'" + EN_Book_ISBN_Text.Text + "','" + _managerID + "')", cnn);//寫ccod
                _sqlCommandModel.ExecuteInsertCommand(InsertCommand);
                cnn.Close();
            }
            else //新增
            {
                cnn = _sqlCommandModel.OpenSqlConnection();
                SqlCommand SelectCommand = new SqlCommand("SELECT	Book_ISBN FROM	Book_Information WHERE	Book_ISBN = '" + EN_Book_ISBN_Text.Text + "';", cnn);//寫ccod
                SqlCommand InsertCommand = new SqlCommand("INSERT INTO Book_Information (Book_ISBN, Book_Title, Book_Image) VALUES ('" + EN_Book_ISBN_Text.Text + "', '" + EN_Book_Name_Text.Text + "', '" + _imagePath + "');", cnn);//寫ccod                

                if (_sqlCommandModel.ExecuteInsertCommandForPrimaryKay(InsertCommand, SelectCommand))
                {
                    InsertCommand = new SqlCommand("INSERT INTO Author (Book_ISBN, Author_Name) VALUES ('" + EN_Book_ISBN_Text.Text + "', '" + EN_Auther_Name_Text.Text + "');", cnn);//寫ccod                
                    _sqlCommandModel.ExecuteInsertCommand(InsertCommand);
                    InsertCommand = new SqlCommand("INSERT INTO Publisher (Book_ISBN, Publisher_Name, Publisher_Address) VALUES ('" + EN_Book_ISBN_Text.Text + "', '" + EN_Publisher_Name_Text.Text + "', '" + EN_Publisher_Address_Text.Text + "');", cnn);//寫ccod                
                    _sqlCommandModel.ExecuteInsertCommand(InsertCommand);
                }
                cnn.Close();
            }
            UpdateBookInformationListboxDataSource();
            Set_EN_Object(false);
        }

        private void EN_Cancel_bt_Click(object sender, EventArgs e)
        {
            Set_EN_Object(false);
        }

        private void EN_Delete_bt_Click(object sender, EventArgs e)
        {
            if (Book_ListBox.SelectedIndex != -1)
            {
                //刪除
                cnn = _sqlCommandModel.OpenSqlConnection();
                SqlCommand SelectCommand = new SqlCommand("SELECT	* FROM	Book_Information Book_Information,	Copies Copies WHERE	Book_Information.Book_ISBN = Copies.Book_ISBN AND Copies.Book_state = 'OnLoan' AND Copies.Book_ISBN = '" + EN_Book_ISBN_Text.Text + "';", cnn);//寫ccod
                if (!_sqlCommandModel.IsTargetExist(SelectCommand)) 
                {
                    SqlCommand DeleteCommand = new SqlCommand("DELETE FROM DatabaseCSIE102.dbo.Book_Information WHERE Book_ISBN = '" + EN_Book_ISBN_Text.Text + "' ;", cnn);
                    _sqlCommandModel.ExecuteDeleteCommand(DeleteCommand);
                }
                cnn.Close();
                UpdateBookInformationListboxDataSource();
            }
            else
            {
                MessageBox.Show("請選擇要刪除的書");
            }            
        }

        private void S_Search_bt_Click(object sender, EventArgs e)
        {
            //Search_GridView 輸出查詢到的書
            bool check = checkBox1.Checked;
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCommand = new SqlCommand();
            if (check) //進階
            {
                SelectCommand = new SqlCommand("SELECT	Copies.Copies_ID,	Book_Information.Book_ISBN ,Book_Information.Book_Title,	Author.Author_Name,	Publisher.Publisher_Name,	Copies.Book_state FROM	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Author Author,	DatabaseCSIE102.dbo.Publisher Publisher,	DatabaseCSIE102.dbo.Copies Copies WHERE	Book_Information.Book_ISBN = Author.Book_ISBN AND	Book_Information.Book_ISBN = Publisher.Book_ISBN AND	Book_Information.Book_ISBN = Copies.Book_ISBN AND	Author.Book_ISBN = Publisher.Book_ISBN AND	Author.Book_ISBN = Copies.Book_ISBN AND	Publisher.Book_ISBN = Copies.Book_ISBN AND        (Book_Information.Book_ISBN LIKE '" + S_Search_Text.Text + "' OR	Book_Information.Book_Title LIKE '" + S_Search_Text.Text + "' OR	Author.Author_Name LIKE '" + S_Search_Text.Text + "' OR	Publisher.Publisher_Name LIKE '" + S_Search_Text.Text + "');", cnn);
            }
            else
                SelectCommand = new SqlCommand("SELECT	Copies.Copies_ID,	Book_Information.Book_ISBN ,Book_Information.Book_Title,	Author.Author_Name,	Publisher.Publisher_Name,	Copies.Book_state FROM	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Author Author,	DatabaseCSIE102.dbo.Publisher Publisher,	DatabaseCSIE102.dbo.Copies Copies WHERE	Book_Information.Book_ISBN = Author.Book_ISBN AND	Book_Information.Book_ISBN = Publisher.Book_ISBN AND	Book_Information.Book_ISBN = Copies.Book_ISBN AND	Author.Book_ISBN = Publisher.Book_ISBN AND	Author.Book_ISBN = Copies.Book_ISBN AND	Publisher.Book_ISBN = Copies.Book_ISBN AND        (Book_Information.Book_ISBN LIKE '%" + S_Search_Text.Text + "%' OR	Book_Information.Book_Title LIKE '%" + S_Search_Text.Text + "%' OR	Author.Author_Name LIKE '%" + S_Search_Text.Text + "%' OR	Publisher.Publisher_Name LIKE '%" + S_Search_Text.Text + "%');", cnn);
            Search_GridView.Columns.Clear();
            Search_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            _sqlCommandModel.AddInformationDetail(Search_GridView);
            cnn.Close();
        }

        private void L_Lend_bt_Click(object sender, EventArgs e)
        {
            //Len_dGridView 輸出該目前會員借的書
            L_Date_Text.Text = DateTime.Now.Date.ToShortDateString();   
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectBookCommand = new SqlCommand("SELECT	Copies_ID,	Book_state FROM	Copies WHERE	Copies_ID = '" + L_Book_Isbn_Text.Text + "' AND Book_state = 'OnShelf'", cnn);
            SqlCommand SelectMemberCommand = new SqlCommand("SELECT	* FROM	Member WHERE	Member_Account = '" + L_Member_ID_Text.Text + "';", cnn);
            SqlCommand SelectReserveCommand = new SqlCommand("SELECT	Copies.Copies_ID,	Copies.Book_state,	Reserve.Member_Account FROM	Copies,	Reserve WHERE	Copies.Copies_ID = Reserve.Copies_ID AND	Copies.Copies_ID = '" + L_Book_Isbn_Text.Text + "' AND	Copies.Book_state = 'OnHold' AND	Reserve.Member_Account = '" + L_Member_ID_Text.Text + "'", cnn);
            if (_sqlCommandModel.IsTargetExist(SelectBookCommand) && _sqlCommandModel.IsTargetExist(SelectMemberCommand))//普通借書
            {
                SqlCommand UpdateCommand = new SqlCommand("UPDATE Copies SET Book_state = 'OnLoan' WHERE Copies_ID = '" + L_Book_Isbn_Text.Text + "' AND Book_state = 'OnShelf';", cnn);//寫ccod       
                _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
                SqlCommand InsertCommand = new SqlCommand("INSERT INTO Lend (Copies_ID, Manager_ID) VALUES ('" + L_Book_Isbn_Text.Text + "', '" + _managerID + "');", cnn);//寫ccod
                _sqlCommandModel.ExecuteInsertCommand(InsertCommand);
                InsertCommand = new SqlCommand("INSERT INTO Borrow (Copies_ID, Member_Account, Start_Date, Due_Date) VALUES ('" + L_Book_Isbn_Text.Text + "', '" + L_Member_ID_Text.Text + "', '" + L_Date_Text.Text + "', '" + DateTime.Now.Date.AddDays(21).ToShortDateString() + "');", cnn);//寫ccod                
                _sqlCommandModel.ExecuteInsertCommand(InsertCommand);
                SqlCommand SelectCommand = new SqlCommand("SELECT	Borrow.Copies_ID,	Borrow.Member_Account,	Borrow.Start_Date,	Borrow.Due_Date,	Lend.Manager_ID,	Book_Information.Book_Title FROM	Borrow Borrow,	Lend Lend,	Copies Copies,	Book_Information Book_Information WHERE	Borrow.Copies_ID = Lend.Copies_ID AND	Borrow.Copies_ID = Copies.Copies_ID AND	Lend.Copies_ID = Copies.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN AND	Borrow.Start_Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND Copies.Copies_ID = '" + L_Book_Isbn_Text.Text + "';", cnn);
                Lend_GridView.Columns.Clear();
                Lend_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
                _sqlCommandModel.AddInformationDetail(Lend_GridView);
            }
            else if (_sqlCommandModel.IsTargetExist(SelectReserveCommand))//預約者取走放在櫃檯的預約書籍
            {
                SqlCommand UpdateCommand = new SqlCommand("UPDATE Copies SET Book_state = 'OnLoan' WHERE Copies_ID = '" + L_Book_Isbn_Text.Text + "' AND Book_state = 'OnHold';", cnn);//寫ccod       
                _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
                SqlCommand InsertCommand = new SqlCommand("INSERT INTO Lend (Copies_ID, Manager_ID) VALUES ('" + L_Book_Isbn_Text.Text + "', '" + _managerID + "');", cnn);//寫ccod
                _sqlCommandModel.ExecuteInsertCommand(InsertCommand);
                InsertCommand = new SqlCommand("INSERT INTO Borrow (Copies_ID, Member_Account, Start_Date, Due_Date) VALUES ('" + L_Book_Isbn_Text.Text + "', '" + L_Member_ID_Text.Text + "', '" + L_Date_Text.Text + "', '" + DateTime.Now.Date.AddDays(21).ToShortDateString() + "');", cnn);//寫ccod                
                _sqlCommandModel.ExecuteInsertCommand(InsertCommand);
                SqlCommand SelectCommand = new SqlCommand("SELECT	Borrow.Copies_ID,	Borrow.Member_Account,	Borrow.Start_Date,	Borrow.Due_Date,	Lend.Manager_ID,	Book_Information.Book_Title FROM	Borrow Borrow,	Lend Lend,	Copies Copies,	Book_Information Book_Information WHERE	Borrow.Copies_ID = Lend.Copies_ID AND	Borrow.Copies_ID = Copies.Copies_ID AND	Lend.Copies_ID = Copies.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN AND	Borrow.Start_Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND Copies.Copies_ID = '" + L_Book_Isbn_Text.Text + "';", cnn);                
                Lend_GridView.Columns.Clear();
                Lend_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
                _sqlCommandModel.AddInformationDetail(Lend_GridView);
                SqlCommand DeleteCommand = new SqlCommand("DELETE FROM	Reserve WHERE	Copies_ID = '" + L_Book_Isbn_Text.Text + "' AND Member_Account = '" + L_Member_ID_Text.Text + "';", cnn);//寫ccod
                _sqlCommandModel.ExecuteDeleteCommand(DeleteCommand);
            }   
            cnn.Close();
        }

        private void R_Return_Book_bt_Click(object sender, EventArgs e)
        {
            //Return_GridView 輸出目前還的書            
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectReturnCommand = new SqlCommand("SELECT	Copies_ID,	Book_state FROM	Copies WHERE	Copies_ID = '" + R_Return_Book_Isbn_Text.Text + "' AND Book_state = 'OnLoan'", cnn);
            SqlCommand SelectReserveCommand = new SqlCommand("SELECT	Copies_ID,	Book_state FROM	Copies WHERE	Copies_ID = '" + R_Return_Book_Isbn_Text.Text + "' AND Book_state = 'OnLoanAndOnHold'", cnn);
            //SqlCommand SelectMemberCommand = new SqlCommand("SELECT	* FROM	Member WHERE	Member_ID = '" + L_Member_ID_Text.Text + "';", cnn);
            if (_sqlCommandModel.IsTargetExist(SelectReturnCommand) /*&& _sqlCommandModel.IsTargetExist(SelectMemberCommand)*/)//單純還書
            {
                SqlCommand UpdateCommand = new SqlCommand("UPDATE Copies SET Book_state = 'OnShelf' WHERE Copies_ID = '" + R_Return_Book_Isbn_Text.Text + "' AND Book_state = 'OnLoan';", cnn);//寫ccod       
                _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
                UpdateCommand = new SqlCommand("UPDATE	Borrow SET	Return_Date = '" + R_Return_Date_Text.Text + "' WHERE	Copies_ID = '" + R_Return_Book_Isbn_Text.Text + "';", cnn);//寫ccod       
                _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
                SelectReturnCommand = new SqlCommand("SELECT	Copies.Copies_ID,	Copies.Book_ISBN,	Copies.Book_state,	Book_Information.Book_Title,	Borrow.Return_Date FROM	DatabaseCSIE102.dbo.Copies Copies,	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Borrow Borrow WHERE	Copies.Copies_ID = Borrow.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN  AND	Borrow.Return_Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND Copies.Copies_ID LIKE '" + R_Return_Book_Isbn_Text.Text + "';", cnn);
                Return_GridView.Columns.Clear();
                Return_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectReturnCommand);
                _sqlCommandModel.AddInformationDetail(Return_GridView);
            }
            if (_sqlCommandModel.IsTargetExist(SelectReserveCommand) /*&& _sqlCommandModel.IsTargetExist(SelectMemberCommand)*/)//還書時發現有人預約了，所以把書放櫃台
            {
                SqlCommand UpdateCommand = new SqlCommand("UPDATE Copies SET Book_state = 'OnHold' WHERE Copies_ID = '" + R_Return_Book_Isbn_Text.Text + "' AND Book_state = 'OnLoanAndOnHold';", cnn);//寫ccod       
                _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
                UpdateCommand = new SqlCommand("UPDATE	Borrow SET	Return_Date = '" + R_Return_Date_Text.Text + "' WHERE	Copies_ID = '" + R_Return_Book_Isbn_Text.Text + "';", cnn);//寫ccod       
                _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
                SelectReturnCommand = new SqlCommand("SELECT	Copies.Copies_ID,	Copies.Book_ISBN,	Copies.Book_state,	Book_Information.Book_Title,	Borrow.Return_Date FROM	DatabaseCSIE102.dbo.Copies Copies,	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Borrow Borrow WHERE	Copies.Copies_ID = Borrow.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN  AND	Borrow.Return_Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND Copies.Copies_ID = '" + R_Return_Book_Isbn_Text.Text + "';", cnn);
                Return_GridView.Columns.Clear();
                Return_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectReturnCommand);
                _sqlCommandModel.AddInformationDetail(Return_GridView);
            }
            cnn.Close();
        }

        private void Manager_Data_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            Manager_Data_group.Enabled = true;
            Manager_Data_group.Visible = true;
            Account_Text.Enabled = false;
            Set_Data();
            Set_Change(false);
            UpdateManagerDataSource();
        }

        private void Update_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            U_Isbn_Text.Text = "";
            Update_group.Enabled = true;
            Update_group.Visible = true;
            U_Date_Text.Text = DateTime.Now.Date.ToShortDateString();            
        }

        private void Trace_bt_Click(object sender, EventArgs e)
        {
            Set_Group();           
            Trace_group.Enabled = true;
            Trace_group.Visible = true;
            T_trace_bt.Enabled = false;
        }

        private void Edit_New_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            Edit_New_group.Enabled = true;
            Edit_New_group.Visible = true;
            Set_EN_Object(false);
            EN_Date_Text.Text = DateTime.Now.Date.ToShortDateString();
            UpdateBookInformationDataSource();
        }

        private void Search_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            S_Search_Text.Text = "";
            Search_group.Enabled = true;
            Search_group.Visible = true;
            S_Search_bt.Enabled = false;
        }

        private void Lend_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            L_Book_Isbn_Text.Text = "";
            L_Member_ID_Text.Text = "";
            Lend_group.Enabled = true;
            Lend_group.Visible = true;
            L_Lend_bt.Enabled = false;
            L_Date_Text.Text = DateTime.Now.Date.ToShortDateString();
        }

        private void Return_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            R_Return_Book_Isbn_Text.Text = "";
            Return_Book_group.Enabled = true;
            Return_Book_group.Visible = true;
            R_Return_Book_bt.Enabled = false;
            R_Return_Date_Text.Text = DateTime.Now.Date.ToShortDateString();
        }

        private void MA_Sign_Data_Change(object sender, EventArgs e)
        {
            if (MA_Account_Text.Text == "" || MA_Passward_Text.Text == "" || MA_Name_Text.Text == "" || MA_Mail_Text.Text == "" || MA_Address_Text.Text=="")
            {
                MA_Register_Bt.Enabled = false;
            }
            else
            {
                MA_Register_Bt.Enabled = true;
            }
        }

        private void MA_Register_Bt_Click(object sender, EventArgs e)
        {
            //註冊
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCammand = new SqlCommand("SELECT Manager_Account FROM Manager WHERE Manager_Account = '" + MA_Account_Text.Text + "'", cnn);//寫ccod                                
            SqlCommand InsertCammand = new SqlCommand("INSERT INTO Manager(Manager_Name, Manager_Account, Manager_Password, Manger_Address, Manger_Email) VALUES ('" + MA_Name_Text.Text + "' , '" + MA_Account_Text.Text + "' , '" + MA_Passward_Text.Text + "' , '" + MA_Address_Text.Text + "' , '" + MA_Mail_Text.Text + "')", cnn);//寫ccod
            if (!_sqlCommandModel.IsTargetExist(SelectCammand))
            {
                MessageBox.Show("Account Sucessfully Created!");
                MA_Sign_Initialization();
            }
            else MessageBox.Show("Account have been used !");
            _sqlCommandModel.ExecuteInsertCommandForPrimaryKay(InsertCammand, SelectCammand);
            cnn.Close();
        }

        private void Sign_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            MA_Sign_Initialization();
            Manager_Assign_group.Enabled = true;
            Manager_Assign_group.Visible = true;
            MA_Register_Bt.Enabled = false;
        }

        public void MA_Sign_Initialization()
        {
            MA_Account_Text.Text = "";
            MA_Address_Text.Text = "";
            MA_Mail_Text.Text = "";
            MA_Name_Text.Text = "";
            MA_Passward_Text.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _openImageDialog = new System.Windows.Forms.OpenFileDialog();
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            _openImageDialog.InitialDirectory = projectPath;
            _openImageDialog.Multiselect = false;
            _openImageDialog.Filter = "Image|*.png;*.jpg;*.jpeg";
            DialogResult result = _openImageDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                EN_Book_Image_PictureBox.Image = Image.FromFile(_openImageDialog.FileName);
                _imagePath = _openImageDialog.FileName;
                _imagePath = _sqlCommandModel.UploadImage(_imagePath);
            }
            
        }

        private void Return_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex != -1)
            {
                int Copies_ID = int.Parse(Return_GridView[0, e.RowIndex].Value.ToString());
                _sqlCommandModel.CreateDetailForm(Copies_ID);
            }
        }

        private void Trace_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //Console.WriteLine(Trace_GridView.Columns[e.ColumnIndex].HeaderText);
            if( Trace_GridView.Columns[e.ColumnIndex].HeaderText == "詳細" && e.RowIndex != -1)
            {
                int Copies_ID = int.Parse(Trace_GridView[0, e.RowIndex].Value.ToString());
                _sqlCommandModel.CreateDetailForm(Copies_ID);
            }
        }

        private void Update_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex != -1)
            {
                int Copies_ID = int.Parse(Update_GridView[0, e.RowIndex].Value.ToString());
                _sqlCommandModel.CreateDetailForm(Copies_ID);
            }
        }

        private void Lend_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex != -1)
            {
                int Copies_ID = int.Parse(Lend_GridView[0, e.RowIndex].Value.ToString());
                _sqlCommandModel.CreateDetailForm(Copies_ID);
            }
        }

        private void Search_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex != -1)
            {
                int Copies_ID = int.Parse(Search_GridView[0, e.RowIndex].Value.ToString());
                _sqlCommandModel.CreateDetailForm(Copies_ID);
            }
        }


    }
}
