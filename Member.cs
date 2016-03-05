using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Main
{
    public partial class Member : Form
    {
        BindingSource _memberBindingSource = new BindingSource();
        SQLCommandModel _sqlCommandModel = new SQLCommandModel();
        SqlConnection cnn;
        int _memberID;
        string _managerAccount;
        BindingSource _historyBindingSource = new BindingSource();


        public Member(string Account)
        {
            InitializeComponent();
            _managerAccount = Account;
            label2.Text = _managerAccount;
            Set_Group();
            BindingMemberInformation();
            UpdateMemberDataSource();


        }

        private void InitializeSearchGridview()
        {
            DataGridViewButtonColumn Column1 = new DataGridViewButtonColumn();
            Column1.HeaderText = "預約";
            Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            Column1.Text = "預約";
            Search_GridView.Columns.Add(Column1);
        }

        private void InitializeBR_Reservation_GridView()
        {
            DataGridViewButtonColumn Column1 = new DataGridViewButtonColumn();
            Column1.HeaderText = "取消預約";
            Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            Column1.Text = "取消預約";
            BR_Reservation_GridView.Columns.Add(Column1);
        }

        private void UpdateMemberDataSource()
        {
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCommand = new SqlCommand("SELECT * FROM Member WHERE Member_Account = '" + _managerAccount + "'", cnn);//寫ccod
            DataTable tt = new DataTable(); //拿出來
            tt = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            _memberBindingSource.DataSource = tt;
            _memberID = int.Parse(tt.Rows[0][0].ToString());
            cnn.Close();
        }

        private void BindingMemberInformation()
        {
            M_Name_Text.DataBindings.Add("Text", _memberBindingSource, "Member_Name");
            M_Account_Text.DataBindings.Add("Text", _memberBindingSource, "Member_Account");
            M_Passward_Text.DataBindings.Add("Text", _memberBindingSource, "Member_Password");
            M_Address_Text.DataBindings.Add("Text", _memberBindingSource, "Member_Address");
            M_Mail_Text.DataBindings.Add("Text", _memberBindingSource, "Member_Email");
        }



        public void Set_Group()
        {
            Member_Data_group.Enabled = false;
            Member_Data_group.Visible = false;
            SR_group.Enabled = false;
            SR_group.Visible = false;
            BR_group.Enabled = false;
            BR_group.Visible = false;
            H_group.Enabled = false;
            H_group.Visible = false;
        }

        public void Set_Member_Data()
        {
            UpdateMemberDataSource();
        }

        public void Set_Member_Data_Change(bool type)
        {
            M_Name_Text.Enabled = type;
            M_Passward_Text.Enabled = type;
            M_Address_Text.Enabled = type;
            M_Mail_Text.Enabled = type;
            M_OK_bt.Enabled = type;
            M_Cancel_bt.Enabled = type;
            M_OK_bt.Visible = type;
            M_Cancel_bt.Visible = type;
            M_Change_Data_bt.Enabled = !type;
        }

        private void M_Change_Data_bt_Click(object sender, EventArgs e)
        {
            M_Change_Data_bt.Enabled = false;
            Set_Member_Data_Change(true);
        }

        private void M_OK_bt_Click(object sender, EventArgs e)
        {
            //Update
            Set_Member_Data_Change(false);
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand UpdateCommand = new SqlCommand("UPDATE Member SET Member_Name = '" + M_Name_Text.Text + "', " + " Member_Password = '" + M_Passward_Text.Text + "', Member_Address = '" + M_Address_Text.Text + "', Member_Email = '" + M_Mail_Text.Text + "' WHERE Member_Account = '" + M_Account_Text.Text + "'", cnn);//寫ccod            
            _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
            cnn.Close();
        }

        private void M_Cancel_bt_Click(object sender, EventArgs e)
        {
            Set_Member_Data_Change(false);
            Set_Member_Data();
            M_Change_Data_bt.Enabled = true;
        }

        private void Member_Data_Changed(object sender, EventArgs e)
        {
            if (M_Name_Text.Text == "" || M_Passward_Text.Text == "" || M_Address_Text.Text == "" || M_Mail_Text.Text == "")
            {
                M_OK_bt.Enabled = false;
            }
            else
            {
                M_OK_bt.Enabled = true;
            }
            if (SR_Search_Text.Text == "")
            {
                SR_Search_bt.Enabled = false;
            }
            else
            {
                SR_Search_bt.Enabled = true;
            }
        }

        private void Manager_Data_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            Member_Data_group.Enabled = true;
            Member_Data_group.Visible = true;
            M_Account_Text.Enabled = false;
            Set_Member_Data();
            Set_Member_Data_Change(false);

        }

        private void Search_Reservation_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            SR_Search_Text.Text = "";
            SR_group.Enabled = true;
            SR_group.Visible = true;
            SR_Search_bt.Enabled = false;
        }

        private void Borrow_Reservation_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            BR_group.Enabled = true;
            BR_group.Visible = true;
            cnn = _sqlCommandModel.OpenSqlConnection();
            BR_Reservation_GridView.Columns.Clear();
            SqlCommand SelectCommand = new SqlCommand("SELECT	Reserve.Copies_ID,	Reserve.Reserve_Date,	Copies.Book_state FROM	Reserve,	Copies,	Book_Information WHERE	Reserve.Copies_ID = Copies.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN AND	Reserve.Member_Account = '" + _managerAccount + "' AND	Copies.Book_state IN ('OnLoanAndOnHold', 'OnHold') ;", cnn);
            BR_Reservation_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            InitializeBR_Reservation_GridView();
            _sqlCommandModel.AddInformationDetail(BR_Reservation_GridView);

            SelectCommand = new SqlCommand("SELECT	Borrow.Copies_ID,	Borrow.Start_Date,	Borrow.Due_Date,	Book_Information.Book_Title FROM	Borrow,	Copies,	Book_Information WHERE	Borrow.Copies_ID = Copies.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN AND	Borrow.Member_Account = '" + _managerAccount + "' AND	Borrow.Return_Date IS NULL ;", cnn);
            BR_Borrow_GridView.Columns.Clear();
            BR_Borrow_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            _sqlCommandModel.AddInformationDetail(BR_Borrow_GridView);
            cnn.Close();
        }

        private void History_bt_Click(object sender, EventArgs e)
        {
            Set_Group();
            H_group.Enabled = true;
            H_group.Visible = true;
            cnn = _sqlCommandModel.OpenSqlConnection();
            H_GridView.Columns.Clear();
            SqlCommand SelectCommand = new SqlCommand("SELECT	Copies.Copies_ID  ,	Borrow.Start_Date,	Borrow.Due_Date, Borrow.Return_Date,	Book_Information.Book_Title FROM	Borrow,	Copies,	Book_Information WHERE	Borrow.Copies_ID = Copies.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN AND	Borrow.Member_Account = '" + _managerAccount + "';", cnn);
            _historyBindingSource.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            H_GridView.DataSource = _historyBindingSource;
            _sqlCommandModel.AddInformationDetail(H_GridView);
        }

        private void SR_Search_bt_Click(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCommand /*= new SqlCommand("SELECT	Copies.Copies_ID,	Book_Information.Book_ISBN ,Book_Information.Book_Title,	Author.Author_Name,	Publisher.Publisher_Name,	Copies.Book_state FROM	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Author Author,	DatabaseCSIE102.dbo.Publisher Publisher,	DatabaseCSIE102.dbo.Copies Copies WHERE	Book_Information.Book_ISBN = Author.Book_ISBN AND	Book_Information.Book_ISBN = Publisher.Book_ISBN AND	Book_Information.Book_ISBN = Copies.Book_ISBN AND	Author.Book_ISBN = Publisher.Book_ISBN AND	Author.Book_ISBN = Copies.Book_ISBN AND	Publisher.Book_ISBN = Copies.Book_ISBN AND        (Book_Information.Book_ISBN LIKE '" + SR_Search_Text.Text + "' OR	Book_Information.Book_Title LIKE '" + SR_Search_Text.Text + "' OR	Author.Author_Name LIKE '" + SR_Search_Text.Text + "' OR	Publisher.Publisher_Name LIKE '" + SR_Search_Text.Text + "');", cnn)*/;
            if (check) //進階
            {
                SelectCommand = new SqlCommand("SELECT	Copies.Copies_ID,	Book_Information.Book_ISBN ,Book_Information.Book_Title,	Author.Author_Name,	Publisher.Publisher_Name,	Copies.Book_state FROM	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Author Author,	DatabaseCSIE102.dbo.Publisher Publisher,	DatabaseCSIE102.dbo.Copies Copies WHERE	Book_Information.Book_ISBN = Author.Book_ISBN AND	Book_Information.Book_ISBN = Publisher.Book_ISBN AND	Book_Information.Book_ISBN = Copies.Book_ISBN AND	Author.Book_ISBN = Publisher.Book_ISBN AND	Author.Book_ISBN = Copies.Book_ISBN AND	Publisher.Book_ISBN = Copies.Book_ISBN AND        (Book_Information.Book_ISBN LIKE '" + SR_Search_Text.Text + "' OR	Book_Information.Book_Title LIKE '" + SR_Search_Text.Text + "' OR	Author.Author_Name LIKE '" + SR_Search_Text.Text + "' OR	Publisher.Publisher_Name LIKE '" + SR_Search_Text.Text + "');", cnn);
            }
            else
                SelectCommand = new SqlCommand("SELECT	Copies.Copies_ID,	Book_Information.Book_ISBN ,Book_Information.Book_Title,	Author.Author_Name,	Publisher.Publisher_Name,	Copies.Book_state FROM	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Author Author,	DatabaseCSIE102.dbo.Publisher Publisher,	DatabaseCSIE102.dbo.Copies Copies WHERE	Book_Information.Book_ISBN = Author.Book_ISBN AND	Book_Information.Book_ISBN = Publisher.Book_ISBN AND	Book_Information.Book_ISBN = Copies.Book_ISBN AND	Author.Book_ISBN = Publisher.Book_ISBN AND	Author.Book_ISBN = Copies.Book_ISBN AND	Publisher.Book_ISBN = Copies.Book_ISBN AND        (Book_Information.Book_ISBN LIKE '%" + SR_Search_Text.Text + "%' OR	Book_Information.Book_Title LIKE '%" + SR_Search_Text.Text + "%' OR	Author.Author_Name LIKE '%" + SR_Search_Text.Text + "%' OR	Publisher.Publisher_Name LIKE '%" + SR_Search_Text.Text + "%');", cnn);

            Search_GridView.Columns.Clear();
            Search_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            InitializeSearchGridview();
            _sqlCommandModel.AddInformationDetail(Search_GridView);
            cnn.Close();
        }

        private void Search_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex != -1)
            {
                int Copies_ID = int.Parse(Search_GridView[0, e.RowIndex].Value.ToString());
                cnn = _sqlCommandModel.OpenSqlConnection();
                SqlCommand SelectCopiesCommand = new SqlCommand("SELECT	Borrow.Copies_ID FROM	Borrow,	Copies WHERE	Borrow.Copies_ID = Copies.Copies_ID AND	Borrow.Copies_ID = '" + Copies_ID + "' AND	Borrow.Member_Account NOT IN ('" + _managerAccount + "') AND	Copies.Book_state = 'OnLoan'  AND	Borrow.Return_Date IS NULL  ;", cnn);//寫ccod
                SqlCommand InsertCommand = new SqlCommand("INSERT INTO Reserve	(Copies_ID, Member_Account, Reserve_Date) VALUES	('" + Copies_ID + "', '" + _managerAccount + "', '" + DateTime.Now.Date.ToShortDateString() + "')", cnn);//寫ccod
                if (_sqlCommandModel.IsTargetExist(SelectCopiesCommand))
                {
                    _sqlCommandModel.ExecuteInsertCommand(InsertCommand);
                    SqlCommand UpdateCommand = new SqlCommand("UPDATE	Copies SET	Book_state = 'OnLoanAndOnHold' WHERE	Copies_ID = '" + Copies_ID + "' AND	Book_state = 'OnLoan'", cnn);//寫ccod       
                    _sqlCommandModel.ExecuteUpdateCommand(UpdateCommand);
                    SqlCommand SelectCommand = new SqlCommand("SELECT	Copies.Copies_ID,	Book_Information.Book_ISBN ,Book_Information.Book_Title,	Author.Author_Name,	Publisher.Publisher_Name,	Copies.Book_state FROM	DatabaseCSIE102.dbo.Book_Information Book_Information,	DatabaseCSIE102.dbo.Author Author,	DatabaseCSIE102.dbo.Publisher Publisher,	DatabaseCSIE102.dbo.Copies Copies WHERE	Book_Information.Book_ISBN = Author.Book_ISBN AND	Book_Information.Book_ISBN = Publisher.Book_ISBN AND	Book_Information.Book_ISBN = Copies.Book_ISBN AND	Author.Book_ISBN = Publisher.Book_ISBN AND	Author.Book_ISBN = Copies.Book_ISBN AND	Publisher.Book_ISBN = Copies.Book_ISBN AND        (Book_Information.Book_ISBN LIKE '" + SR_Search_Text.Text + "' OR	Book_Information.Book_Title LIKE '" + SR_Search_Text.Text + "' OR	Author.Author_Name LIKE '" + SR_Search_Text.Text + "' OR	Publisher.Publisher_Name LIKE '" + SR_Search_Text.Text + "');", cnn);
                    Search_GridView.Columns.Clear();
                    Search_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
                    InitializeSearchGridview();
                    MessageBox.Show("Reserve Sucessfully !");
                }
                else MessageBox.Show("Reserve Faild !");
                cnn.Close();
            }
            if (e.ColumnIndex == 7 && e.RowIndex != -1)
            {
                int Copies_ID = int.Parse(Search_GridView[0, e.RowIndex].Value.ToString());
                _sqlCommandModel.CreateDetailForm(Copies_ID);
            }

        }

        private void BR_Reservation_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex != -1)
            {
                cnn = _sqlCommandModel.OpenSqlConnection();
                int Copies_ID = int.Parse(BR_Reservation_GridView[0, e.RowIndex].Value.ToString());
                SqlCommand UpdateReserveCommand = new SqlCommand("UPDATE	Copies SET	Book_state = 'OnLoan' WHERE	Copies_ID = '" + Copies_ID + "' AND	Book_state = 'OnLoanAndOnHold'", cnn);//寫ccod       
                SqlCommand UpdateCanBorrowCommand = new SqlCommand("UPDATE	Copies SET	Book_state = 'OnShelf' WHERE	Copies_ID = '" + Copies_ID + "' AND	Book_state = 'OnHold'", cnn);//寫ccod       
                if (_sqlCommandModel.ExecuteUpdateCommand(UpdateReserveCommand) || _sqlCommandModel.ExecuteUpdateCommand(UpdateCanBorrowCommand))
                {
                    SqlCommand DeleteCommand = new SqlCommand("DELETE FROM	Reserve WHERE	Copies_ID = '" + Copies_ID + "'", cnn);
                    _sqlCommandModel.ExecuteDeleteCommand(DeleteCommand);
                    SqlCommand SelectCommand = new SqlCommand("SELECT	Reserve.Copies_ID,	Reserve.Reserve_Date,	Copies.Book_state FROM	Reserve,	Copies,	Book_Information WHERE	Reserve.Copies_ID = Copies.Copies_ID AND	Copies.Book_ISBN = Book_Information.Book_ISBN AND	Reserve.Member_Account = 1 AND	Copies.Book_state IN ('OnLoanAndOnHold', 'OnHold') ;", cnn);
                    BR_Reservation_GridView.Columns.Clear();
                    BR_Reservation_GridView.DataSource = _sqlCommandModel.ExecuteSelectCommand(SelectCommand); ;
                    InitializeBR_Reservation_GridView();
                    MessageBox.Show("Cancel Sucessfully !");
                }
                else MessageBox.Show("Cancel Faild !");
                cnn.Close();
            }
            if (e.ColumnIndex == 4 && e.RowIndex != -1)
            {
                int Copies_ID = int.Parse(BR_Reservation_GridView[0, e.RowIndex].Value.ToString());
                _sqlCommandModel.CreateDetailForm(Copies_ID);
            }
        }

        private void H_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex != -1)
            {
                int Copies_ID = int.Parse(H_GridView[0, e.RowIndex].Value.ToString());
                _sqlCommandModel.CreateDetailForm(Copies_ID);
            }
        }

        private void BR_Borrow_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != -1)
            {
                int Copies_ID = int.Parse(BR_Borrow_GridView[0, e.RowIndex].Value.ToString());
                _sqlCommandModel.CreateDetailForm(Copies_ID);
            }
        }




    }
}
