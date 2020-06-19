﻿using MetroFramework;
using MetroFramework.Forms;
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

namespace BookRentalShop20
{
    public partial class UserForm : MetroForm 
    {
        string strConnString = "Data Source=127.0.0.1;Initial Catalog=BookRentalShopDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        string mode = "";
        private SqlConnection conn;

        public UserForm()
        {
            InitializeComponent();
        }

        private void DivForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }
        private void UpdateData()
        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open(); //DB열기
                string strQuery = " SELECT id,userID,password,lastLoginDt,loginIpAddr " + 
                                  " FROM dbo.userTbl ";
                // SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "usertbl");

                GrdUserTbl.DataSource = ds;
                GrdUserTbl.DataMember = "usertbl";

            }

            DataGridViewColumn column = GrdUserTbl.Columns[0];
            column.Width = 40;
            column.HeaderText = "순번";
            column = GrdUserTbl.Columns[1];
            column.Width = 80;
            column.HeaderText = "아이디";
            column = GrdUserTbl.Columns[2];
            column.Width = 100;
            column.HeaderText = "패스워드";
            column = GrdUserTbl.Columns[3];
            column.Width = 120;
            column.HeaderText = "최종접속시간";
            column = GrdUserTbl.Columns[4];
            column.Width = 150;
            column.HeaderText = "접속 아이피 주소";
            

        }
        /// <summary>
        /// 그리드 셀클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                DataGridViewRow data = GrdUserTbl.Rows[e.RowIndex];
                TxtId.Text = data.Cells[0].Value.ToString();
                TxtUserID.Text = data.Cells[1].Value.ToString();
                TxtPassword.Text = data.Cells[2].Value.ToString();
               

                mode = "UPDATE";
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearTextControls();

            mode = "INSERT"; // 신규는 INSERT
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtUserID.Text)|| string.IsNullOrEmpty(TxtPassword.Text))
            {
                MetroMessageBox.Show(this, "빈값은 저장할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveProcess();
            UpdateData();
            ClearTextControls();

            

            
        }

        private void ClearTextControls()
        {
            TxtId.Text = "";
            TxtUserID.Text = "";
            TxtPassword.Text = "";
            //TxtUserID.ReadOnly = false;
           // TxtUserID.BackColor = Color.White;
            TxtUserID.Focus();
        }

        private void SaveProcess()
        {
            if(string.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 데이터를 저장하십시오", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(strConnString))
            { // using 괄호가 없어서 오류
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = "UPDATE dbo.userTbl" +
                                " SET userID = @UserID," +
                                 " password = @Password" +
                                 " WHERE Id  = @Id";


                }
                else if (mode == "INSERT")
                {
                    strQuery = " INSERT INTO dbo.userTbl(userID, password) " +
                                " VALUES(@userID, @password) ";
                }
                     cmd.CommandText = strQuery;

                SqlParameter parmUserID = new SqlParameter("@UserID", SqlDbType.VarChar,12);
                parmUserID.Value = TxtUserID.Text;
                cmd.Parameters.Add(parmUserID);

                SqlParameter parmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 20);
                parmPassword.Value = TxtPassword.Text;
                cmd.Parameters.Add(parmPassword);

                if (mode == "UPDATE")
                {
                    SqlParameter parmId = new SqlParameter("@Id", SqlDbType.Int);
                    parmId.Value = TxtId.Text;
                    cmd.Parameters.Add(parmId);

                    
                }
                cmd.ExecuteNonQuery();

            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void DeleteProcess()

        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = " DELETE FROM dbo.divtbl " +
                                  " WHERE Division = @Division ";

                SqlParameter parmDivision = new SqlParameter("@Division", SqlDbType.Char, 4);
                parmDivision.Value = TxtUserID.Text;
                cmd.Parameters.Add(parmDivision);

                cmd.ExecuteNonQuery();
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUserID.Text) || string.IsNullOrEmpty(TxtPassword.Text))
            {
                MetroMessageBox.Show(this, "빈값은 저장할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DeleteProcess();
            UpdateData();
            ClearTextControls();
        }
    }
}
