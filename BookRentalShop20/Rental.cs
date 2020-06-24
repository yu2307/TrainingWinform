using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class RentalForm : MetroForm 
    {
        string mode = "";
        private SqlConnection conn;

        public RentalForm()
        {
            InitializeComponent();
        }
        private void UpdateData()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open(); // DB 열기
                //string strQuery = "SELECT Idx, Author, Division, Names, ReleaseDate, ISBN, Price "
                //                 + " FROM bookstbl ";
                string strQuery = "SELECT r.idx AS '대여번호', m.Names AS '대여회원', "
                                  + " t.Names AS '장르', "
                                    + " b.Names AS '대여책제목'  ,b.ISBN, "
                                      + " r.rentalDate AS '대여일' , r.returnDate AS '반납일'"
                                 + " FROM rentaltbl AS r "
                                + " INNER JOIN membertbl AS m "
                                   + " ON r.memberIdx = m.Idx "
                                + " INNER JOIN bookstbl AS b "
                                   + " ON r.bookIdx = b.Idx "
                                + " INNER JOIN divtbl AS t "
                                  + " ON b.division = t.division";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "bookstbl");

                GrdrentalTbl.DataSource = ds;
                GrdrentalTbl.DataMember = "bookstbl";
            }
         
        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                DataGridViewRow data = GrdrentalTbl.Rows[e.RowIndex];
                TxtIdx.Text = data.Cells[0].Value.ToString();
              //  TxtAuthor.Text = data.Cells[1].Value.ToString();
                TxtIdx.ReadOnly = true;
                TxtIdx.BackColor = Color.Beige;
                CboBook.SelectedIndex = CboBook.FindString(data.Cells[3].Value.ToString());
                CboMember.SelectedIndex = CboMember.FindString(data.Cells[1].Value.ToString());
              //  TxtNames.Text = data.Cells[4].Value.ToString();

                DtpRentalDate.CustomFormat = "yyyy-MM-dd";
                DtpRentalDate.Format = DateTimePickerFormat.Custom;
                DtpRentalDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());

                if (string.IsNullOrEmpty(data.Cells[6].Value.ToString()))
                {
                    DtpReturnDate.CustomFormat = " ";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;

                }
                else
                {
                    DtpReturnDate.CustomFormat = "yyyy-MM-dd";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                    DtpReturnDate.Value = DateTime.Parse(data.Cells[6].Value.ToString());
                }
             

                //  TxtISBN.Text = data.Cells[6].Value.ToString();
                // TxtPrice.Text = data.Cells[7].Value.ToString();

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
            if (CboMember.SelectedIndex == -1 || CboBook.SelectedIndex == -1)
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
            TxtIdx.Text = "";
            CboMember.SelectedIndex = -1;
            CboBook.SelectedIndex = -1;
            TxtIdx.ReadOnly = true;
            TxtIdx.BackColor = Color.Beige;

            DtpRentalDate.CustomFormat = " ";
            DtpReturnDate.CustomFormat = " ";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;
            DtpReturnDate.Format = DateTimePickerFormat.Custom;

            CboMember.Focus();
        }

        private void SaveProcess()
        {
            if(string.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 데이터를 저장하십시오", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            { // using 괄호가 없어서 오류
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = " UPDATE dbo.rentaltbl SET memberIdx = @memberIdx, bookIdx = @bookIdx, rentalDate = @rentalDate, returnDate = @returnDate "
                             + " WHERE Idx = @Idx ";

                }
                else if (mode == "INSERT")
                {
                    strQuery =  " INSERT INTO dbo.rentaltbl(memberIdx, bookIdx, rentalDate, returnDate)"
                              + " VALUES(@memberIdx, @bookIdx, @rentalDate, @returnDate) ";

                }
                cmd.CommandText = strQuery;

                SqlParameter parmmemberIdx = new SqlParameter("@memberIdx", SqlDbType.Int);
                parmmemberIdx.Value = CboMember.SelectedValue;
                cmd.Parameters.Add(parmmemberIdx);

                SqlParameter parmbookIdx = new SqlParameter("@bookIdx", SqlDbType.Int);
                parmbookIdx.Value = CboBook.SelectedValue;
                cmd.Parameters.Add(parmbookIdx);

                SqlParameter parmrentalDate = new SqlParameter("@rentalDate", SqlDbType.Date);
                parmrentalDate.Value = DtpRentalDate.Value;
                cmd.Parameters.Add(parmrentalDate);

                SqlParameter parmreturnDate = new SqlParameter("@returnDate", SqlDbType.Date);
                parmreturnDate.Value = DtpReturnDate.Value;
                cmd.Parameters.Add(parmreturnDate);

               

                if (mode == "UPDATE")
                {
                    SqlParameter parmIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    parmIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(parmIdx);
                }

                cmd.ExecuteNonQuery();
            }
        }

        private void TxtNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                BtnSave_Click(sender, new EventArgs());
            }
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void DeleteProcess()

        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = " DELETE FROM dbo.divtbl " +
                                  " WHERE Division = @Division ";

                SqlParameter parmDivision = new SqlParameter("@Division", SqlDbType.Char, 4);
                parmDivision.Value = TxtIdx.Text;
                cmd.Parameters.Add(parmDivision);

                cmd.ExecuteNonQuery();
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(TxtIdx.Text) || string.IsNullOrEmpty(TxtAuthor.Text))
            //{
            //    MetroMessageBox.Show(this, "빈값은 저장할 수 없습니다.", "경고",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            DeleteProcess();
            UpdateData();
            ClearTextControls();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {

            DtpRentalDate.CustomFormat = " ";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;

            UpdateData();
            UpdataCboDivision();
        }

        private void UpdataCboDivision()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = " SELECT Idx, Names, Levels, Addr, Mobile, Email "
                                 + " FROM dbo.membertbl ";
                SqlDataReader reader = cmd.ExecuteReader();
                Dictionary<string, string> temps = new Dictionary<string, string>();
                while (reader.Read())
                {
                    temps.Add(reader[0].ToString(), reader[1].ToString());
                }
                CboMember.DataSource = new BindingSource(temps, null);
                CboMember.DisplayMember = "value";
                CboMember.ValueMember = "key";
                CboMember.SelectedIndex = -1;

            }

            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = " SELECT Idx, Author, Division, Names, ReleaseDate, ISBN, Price "
                              + " FROM dbo.bookstbl ";
                SqlDataReader reader = cmd.ExecuteReader();
                Dictionary<string, string> temps = new Dictionary<string, string>();
                while (reader.Read())
                {
                    temps.Add(reader[0].ToString(), reader[3].ToString());
                }
                CboBook.DataSource = new BindingSource(temps, null);
                CboBook.DisplayMember = "value";
                CboBook.ValueMember = "key";
                CboBook.SelectedIndex = -1;

            }

        }

        private void DtpReleaseDate_ValueChanged(object sender, EventArgs e)
        {

            DtpRentalDate.CustomFormat = "yyyy-MM-dd";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;

        }

        private void CboDivision_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
