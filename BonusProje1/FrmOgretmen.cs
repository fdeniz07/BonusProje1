using System;
using System.Drawing;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void btnKulupIslemleri_Click(object sender, EventArgs e)
        {
            FrmKulup frm = new FrmKulup();
            frm.Show();
            this.Close();
        }

        #region Kisayollar
        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnAnaSayfa_MouseHover(object sender, EventArgs e)
        {
            btnAnaSayfa.BackColor = Color.Green;
        }

        private void btnAnaSayfa_MouseLeave(object sender, EventArgs e)
        {
            btnAnaSayfa.BackColor = Color.Transparent;
        }
        #endregion
        private void btnDersIslemleri_Click(object sender, EventArgs e)
        {
            FrmDers frm = new FrmDers();
            frm.Show();
            this.Close();
        }

        private void btnOgrenciIslemleri_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm = new FrmOgrenci();
            frm.Show();
            this.Close();
        }

        private void btnSinavNotlari_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar frm = new FrmSinavNotlar();
            frm.Show();
            this.Close();
        }
    }
}
