using System;
using System.Drawing;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmDers : Form
    {
        public FrmDers()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.tbl_DerslerTableAdapter();


        #region Kisayollar
        private void btnAnaSayfa_MouseHover(object sender, EventArgs e)
        {
            btnAnaSayfa.BackColor = Color.Green;
        }

        private void btnAnaSayfa_MouseLeave(object sender, EventArgs e)
        {
            btnAnaSayfa.BackColor = Color.Transparent;
        }

        private void btnGeri_MouseHover(object sender, EventArgs e)
        {
            btnGeri.BackColor = Color.Orange;
        }

        private void btnGeri_MouseLeave(object sender, EventArgs e)
        {
            btnGeri.BackColor = Color.Transparent;
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            btnKapat.BackColor = Color.Red;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            btnKapat.BackColor = Color.Transparent;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FrmOgretmen frm = new FrmOgretmen();
            frm.Show();
            this.Hide();
        }
        #endregion

        private void FrmDers_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtDersAd.Text);
            MessageBox.Show("Ders ekleme islemi basariyla yapilmistir");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtDersAd.Text, byte.Parse(txtDersID.Text));
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtDersID.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDersID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
