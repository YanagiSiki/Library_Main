using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Xml.Linq;

namespace Library_Main
{
    class SQLCommandModel
    {
        public SqlConnection OpenSqlConnection()
        {
            SqlConnection cnn = new SqlConnection("server=DatabaseCSIE102.mssql.somee.com; database=DatabaseCSIE102; UID=ce678013_SQLLogin_1; PWD=y6sitr5wq2");

            try
            {
                cnn.Open();
                //MessageBox.Show("Connection Open ! ");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Can not open connection ! ");
            }
            return cnn;
        }

        public DataTable ExecuteSelectCommand(SqlCommand SelectCommand)
        {
            DataTable tt = new DataTable(); //拿出來
            Console.WriteLine(SelectCommand.CommandText);
            tt.Load(SelectCommand.ExecuteReader());
            return tt;
        }

        public bool ExecuteInsertCommand(SqlCommand InsertCommand)
        {
            InsertCommand.ExecuteNonQuery();
            return true;
        }

        public bool ExecuteInsertCommandForPrimaryKay(SqlCommand InsertCommand, SqlCommand SelectCommand)
        {
            DataTable tt = new DataTable(); //拿出來
            if (!IsTargetExist(SelectCommand))
            {
                InsertCommand.ExecuteNonQuery();
                return true;
            }
            else
            {
                MessageBox.Show("Connection Failed");
                return false;
            } 
        }

        public bool ExecuteInsertCommandForForeignKay(SqlCommand InsertCommand, SqlCommand SelectCommand)
        {
            DataTable tt = new DataTable(); //拿出來
            if (IsTargetExist(SelectCommand))
            {
                InsertCommand.ExecuteNonQuery();
                return true;
            }
            else 
            {
                MessageBox.Show("Connection Failed");
                return false;
            }           

        }

        public bool ExecuteUpdateCommand(SqlCommand UpdateCommand)
        {
            try
            {
                UpdateCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed");
                Console.WriteLine(UpdateCommand.CommandText.ToString());
                return false;
            }

        }

        public bool ExecuteDeleteCommand(SqlCommand DeleteCommand)
        {
            try
            {
                DeleteCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed");
                Console.WriteLine(DeleteCommand.CommandText.ToString());
                return false;
            }

        }

        public bool IsTargetExist(SqlCommand SelectCommand)
        {
            DataTable tt = new DataTable(); //拿出來                       
            try
            {
                tt.Load(SelectCommand.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed");
            }
            if (tt.Rows.Count == 0)
                return false;
            else return true;
        }

        public bool IsLoginSucessful(SqlCommand SelectCommand)
        {
            DataTable tt = new DataTable(); //拿出來            
            try
            {
                tt.Load(SelectCommand.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed");
            }
            if (tt.Rows.Count == 1)
                return true;
            else return false;
        }


        public void SendEmail(string MailList)
        {
            string Subject = "Old Lan Library";
            string Body = "恭喜成功成為Old Lan Library 的會員 !";
            MailMessage msg = new MailMessage();
            //收件者，以逗號分隔不同收件者 ex "test@gmail.com,test2@gmail.com"
            msg.To.Add(MailList);
            msg.From = new MailAddress("DatabaseCSIE102@gmail.com", "註冊成功", System.Text.Encoding.UTF8);
            //郵件標題 
            msg.Subject = Subject;
            //郵件標題編碼  
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //郵件內容
            msg.Body = Body;
            msg.IsBodyHtml = true;
            msg.BodyEncoding = System.Text.Encoding.UTF8;//郵件內容編碼 
            msg.Priority = MailPriority.Normal;//郵件優先級 
            //建立 SmtpClient 物件 並設定 Gmail的smtp主機及Port 
            #region 其它 Host
            /*
             *  outlook.com smtp.live.com port:25
             *  yahoo smtp.mail.yahoo.com.tw port:465
            */
            #endregion
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);
            //設定你的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("DatabaseCSIE102@gmail.com", "DatabaseCSIE102");
            //Gmial 的 smtp 使用 SSL
            MySmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            MySmtp.EnableSsl = true;
            MySmtp.Send(msg);
        }

        public string UploadImage(string DataPath)
        {
            try
            {
                using (var w = new WebClient())
                {
                    var values = new NameValueCollection
                {
                {"image", Convert.ToBase64String(File.ReadAllBytes(DataPath))}
                //I only needed to send the image, if you want to send other values, just add them here
                };

                    w.Headers.Add("Authorization", "Client-ID " + "21950a90d0ba1a0");
                    byte[] response = w.UploadValues("https://api.imgur.com/3/upload.xml", values);

                    string str = XDocument.Load(new MemoryStream(response)).ToString();
                    //Console.WriteLine(str);


                    string[] strReturn = str.Split(new string[] { "<link>" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] strReturnn = strReturn[1].Split(new string[] { "</link>" }, StringSplitOptions.RemoveEmptyEntries);

                    string ImageURL = strReturnn[0];
                    return ImageURL;
                    // ""
                    //now process response as you'd like. the link is encapsulated by <link></link> in the response.
                }
            }
            catch
            {
                return String.Empty;
            }
            
        }


        public void AddInformationDetail(DataGridView GridView)
        {
            DataGridViewButtonColumn Column1 = new DataGridViewButtonColumn();
            Column1.HeaderText = "詳細";
            Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            Column1.Text = "詳細";
            GridView.Columns.Add(Column1);
        }


        public void CreateDetailForm(int copies_ID)
        {
            Form detail = new Detail(copies_ID);
            detail.Show();      
        }
    }
}
