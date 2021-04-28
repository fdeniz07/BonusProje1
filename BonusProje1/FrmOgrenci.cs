using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.tbl_OgrencilerTableAdapter ds = new DataSet1TableAdapters.tbl_OgrencilerTableAdapter();

        SqlConnection baglanti = new SqlConnection(@"Data Source=APACHIE;Initial Catalog=BonusOkul;Integrated Security=True");

        void FormTemizle()
        {
            txtOgrenciID.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            cmbKulup.Text = "";//Nasil default olarak bos gelir?
        }

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

        private void dgwOgrenciler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrenciID.Text = dgwOgrenciler.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dgwOgrenciler.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dgwOgrenciler.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbKulup.Text = dgwOgrenciler.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (dgwOgrenciler.Rows[e.RowIndex].Cells[4].Value.ToString() == "Kadin")
            {
                rdbKadin.Checked = true;
            }
            if (dgwOgrenciler.Rows[e.RowIndex].Cells[4].Value.ToString() == "Erkek")
            {
                rdbErkek.Checked = true;
            }
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dgwOgrenciler.DataSource = ds.OgrenciListesi();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_Kulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKulup.DisplayMember = "KulupAd";
            cmbKulup.ValueMember = "KulupId";
            cmbKulup.DataSource = dt;
            baglanti.Close();
        }

        string c = "";

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.OgrenciEkle(txtAd.Text, txtSoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), c);
            MessageBox.Show("Ögrenci ekleme basariyla gerceklesti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormTemizle();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dgwOgrenciler.DataSource = ds.OgrenciListesi();
            FormTemizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtAd.Text, txtSoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), c, int.Parse(txtOgrenciID.Text));
            FormTemizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtOgrenciID.Text));
            MessageBox.Show("Silme islemi basariyla gerceklesmistir", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            FormTemizle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dgwOgrenciler.DataSource= ds.OgrenciGetir(txtAra.Text);
        }

        private void cmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtOgrenciID.Text=cmbKulup.SelectedValue.ToString(); --> Combox dan id okuma
        }

        private void rdbKiz_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbKadin.Checked == true)
            {
                c = "Kadin";
            }
            if (rdbErkek.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void rdbErkek_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbKadin.Checked == true)
            {
                c = "Kadin";
            }
            if (rdbErkek.Checked == true)
            {
                c = "Erkek";
            }
        }
    }
}
