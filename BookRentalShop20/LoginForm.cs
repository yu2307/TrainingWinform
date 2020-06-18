using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
namespace BookRentalShop20
{
    public partial class LoginForm :MetroForm
    {
        string strConnString = "Data Source=127.0.0.1;Initial Catalog=BookRentalShopDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        public LoginForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 종료 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();       //종료가 잘 안될때가 있음
            Environment.Exit(0);
        }
        /// <summary>
        /// 로그인 처리버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void TxtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                TxtPassword.Focus();    // ID 입력후 엔터 하면 커서 위치가 PW로 이동
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                LoginProcess();
            }
        }

        private void LoginProcess()
        {
            // if((TxtUserID.Text == null || TxtUserID.Text == "")||
            //  (TxtPassword.Text == null || TxtPassword.Text == ""))

            if (String.IsNullOrEmpty(TxtUserID.Text) || String.IsNullOrEmpty(TxtPassword.Text))

            {
                MetroMessageBox.Show(this, "아이디/패스워드를 입력하세요!", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strUserId = string.Empty;

            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT userID FROM userTbl " +
                                  " WHERE userID = @userID " +
                                  "  AND password = @Password";
                SqlParameter parmUserId = new SqlParameter("@userID", SqlDbType.VarChar, 12);
                parmUserId.Value = TxtUserID.Text;
                cmd.Parameters.Add(parmUserId);

                SqlParameter parmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 12);
                parmPassword.Value = TxtPassword.Text;
                cmd.Parameters.Add(parmPassword);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                strUserId = reader["userID"].ToString();

                MetroMessageBox.Show(this, "접속 성공", "로그인");
                Debug.WriteLine("On the Debug");

            }
                
        }
    }
}
