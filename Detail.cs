using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Main
{
    public partial class Detail : Form
    {
        SQLCommandModel _sqlCommandModel = new SQLCommandModel();
        SqlConnection cnn;
        BindingSource _informationBindingSource = new BindingSource();
        int _copies_ID;

        public Detail(int copies_ID)
        {
            InitializeComponent();
            _copies_ID = copies_ID;
            BindingBookInformation();
            UpdateBookDataSource();

        }

        private void BindingBookInformation()
        {
            Copies_ID.DataBindings.Add("Text", _informationBindingSource, "Copies_ID");
            Book_ISBN.DataBindings.Add("Text", _informationBindingSource, "Book_ISBN");
            Book_Title.DataBindings.Add("Text", _informationBindingSource, "Book_Title");
            Book_State.DataBindings.Add("Text", _informationBindingSource, "Book_state");
            Book_Author.DataBindings.Add("Text", _informationBindingSource, "Author_Name");
            Book_Publisher.DataBindings.Add("Text", _informationBindingSource, "Publisher_Name");
            Publisher_Address.DataBindings.Add("Text", _informationBindingSource, "Publisher_Address");
        }

        private void UpdateBookDataSource()
        {
            cnn = _sqlCommandModel.OpenSqlConnection();
            SqlCommand SelectCommand = new SqlCommand("SELECT	Book_Information.Book_ISBN,	Book_Information.Book_Title,	Book_Information.Book_Image,	Author.Author_Name,	Copies.Copies_ID,	Copies.Book_state,	Publisher.Publisher_Name,	Publisher.Publisher_Address FROM	Book_Information,	Author,	Copies,	Publisher WHERE	Book_Information.Book_ISBN = Author.Book_ISBN AND	Book_Information.Book_ISBN = Copies.Book_ISBN AND	Book_Information.Book_ISBN = Publisher.Book_ISBN AND	Author.Book_ISBN = Copies.Book_ISBN AND	Author.Book_ISBN = Publisher.Book_ISBN AND	Copies.Book_ISBN = Publisher.Book_ISBN AND	Copies.Copies_ID = '" + _copies_ID + "';", cnn);//寫ccod
            DataTable tt = new DataTable(); //拿出來
            tt = _sqlCommandModel.ExecuteSelectCommand(SelectCommand);
            _informationBindingSource.DataSource = tt;
            string image = tt.Rows[0][2].ToString();
            if (image != String.Empty)
            {
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(image);
                MemoryStream ms = new MemoryStream(bytes);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                pictureBox1.Image = img;
            }
            cnn.Close();
        }
    }
}
