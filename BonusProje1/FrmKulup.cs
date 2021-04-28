using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=APACHIE;Initial Catalog=BonusOkul;Integrated Security=True");
        string durum = "1";

       void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_Kulupler where durum=1", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into tbl_Kulupler (KulupAd,durum) values (@ad,@durum)", baglanti);
            komut.Parameters.AddWithValue("@ad", txtKulupAd.Text);
            komut.Parameters.AddWithValue("@durum", durum);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            btnKapat.BackColor = Color.Red;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            btnKapat.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tbl_Kulupler set durum=0 where KulupId=@id", baglanti);
            komut.Parameters.AddWithValue("@id", txtKulupID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kulüp Silme Islemi Gerceklesti" ,"Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tbl_Kulupler set KulupAd=@ad where KulupId=@id", baglanti);
            komut.Parameters.AddWithValue("@ad", txtKulupAd.Text);
            komut.Parameters.AddWithValue("@id", txtKulupID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
        }

        private void btnAnaSayfa_MouseHover(object sender, EventArgs e)
        {
            btnAnaSayfa.BackColor = Color.Green;
        }

        private void btnAnaSayfa_MouseLeave(object sender, EventArgs e)
        {
            btnAnaSayfa.BackColor = Color.Transparent;
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnGeri_MouseHover(object sender, EventArgs e)
        {
            btnGeri.BackColor = Color.Orange;
        }

        private void btnGeri_MouseLeave(object sender, EventArgs e)
        {
            btnGeri.BackColor = Color.Transparent;
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FrmOgretmen frm = new FrmOgretmen();
            frm.Show();
            this.Hide();
        }
    }
}
