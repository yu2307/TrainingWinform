using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
namespace BookRentalShop20
{
    public partial class LoginForm :MetroForm
    {
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

            try
            {
                using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
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
                    strUserId = reader["userID"] != null ? reader["userID"].ToString() : "";

                    if (strUserId != "")
                    {
                        Commons.LOGINUSERID = strUserId;
                        MetroMessageBox.Show(this, "접속성공", "로그인 성공");
                        //추가된소스
                        this.Close();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "접속실패", "로그인 실패",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    //위에 추가된 소스로 인해 필요 없는 소스
                    //MetroMessageBox.Show(this, "접속 성공", "로그인");
                    //Debug.WriteLine("On the Debug");

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"Error : {ex.Message}", "오류",  // {ex.StackTrace}개발시 오류 위치 알려줌, 개발자들 유용
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
                
        }
    }
}
