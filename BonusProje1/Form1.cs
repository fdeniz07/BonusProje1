using System;
using System.Drawing;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciNotlar frm = new FrmOgrenciNotlar();
            frm.numara = textBox1.Text;
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen frm = new FrmOgretmen();
            frm.Show();
            this.Hide();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKapat_MouseHover_1(object sender, EventArgs e)
        {
            btnKapat.BackColor = Color.Red;
        }

        private void btnKapat_MouseLeave_1(object sender, EventArgs e)
        {
            btnKapat.BackColor = Color.Transparent;
        }
    }
}
