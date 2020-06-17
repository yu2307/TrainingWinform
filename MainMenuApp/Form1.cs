using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenuApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void MnuNewFile_Click(object sender, EventArgs e)
        {
            textBox1.Text += MnuNewFile.Text + Environment.NewLine;
            toolStripStatusLabel1.Text = MnuNewFile.Text;
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text += 열기OToolStripMenuItem.Text + Environment.NewLine;
           
        }

        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text += 저장SToolStripMenuItem.Text + Environment.NewLine;
            MessageBox.Show("저장 했습니다");
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + aToolStripMenuItem.Text + Environment.NewLine;
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(e.Location);
            }

        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            LblMouseLocation.Text = $"(X,Y) = ({e.X},{e.Y})";   //e.Location.X
        }

       /* private void Form1_Load(object sender, EventArgs e)
        {
           // button1.Focus();  화면에 마우스 커서
        }*/  

        private void Form1_Activated(object sender, EventArgs e)
        {
            button1.Focus();      // 번튼에 마우스 커서
        }

       
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MnuNewFile_Click(sender, e);
        }
    }
}
