using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace BookRentalShop20
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroMessageBox.Show(this,"정말 종료하시겠습니까?","종료",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form item in this.MdiChildren)
                {
                    item.Close();
                }
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true; //  true만 존재시 X번튼 눌러도 종료가 안된다.
            }
        }

        private void InitChildForm(Form form, string strFormTitle)
        {
            form.Text = strFormTitle;
            form.Dock = DockStyle.Fill;
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }


        private void MnuItemDivMng_Click(object sender, EventArgs e)
        {
            DivForm form = new DivForm();
            InitChildForm(form, "구분코드 관리");

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

        }

        private void 사용자관리UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            InitChildForm(form, "사용자관리 관리");
            //form.Text = "사용자관리 관리";
            // form.Dock = DockStyle.Fill;
            // form.MdiParent = this;
            // form.Show();
            // form.WindowState = FormWindowState.Maximized;
        }

        private void 회원관리MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberForm form = new MemberForm();
            InitChildForm(form, "회원관리");
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            LblUserID.Text = Commons.LOGINUSERID;
        }

        private void 책관리BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BooksForm form = new BooksForm();
            InitChildForm(form, "책관리");
        }

        private void 책대여관리RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentalForm form = new RentalForm();
            InitChildForm(form, "책대여관리");
        }
    }
}
