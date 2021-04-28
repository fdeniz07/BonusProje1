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

namespace BonusProje1
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.tbl_NotlarTableAdapter();

        SqlConnection baglanti = new SqlConnection(@"Data Source=APACHIE;Initial Catalog=BonusOkul;Integrated Security=True");

        private void btnAra_Click(object sender, EventArgs e)
        {
            dgwNotlar.DataSource = ds.NotListesi(int.Parse(txtOgrenciID.Text));
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

        private void btnKapat_MouseHover(object sender, EventArgs e)
        {
            btnKapat.BackColor = Color.Red;
        }

        private void btnKapat_MouseLeave(object sender, EventArgs e)
        {
            btnKapat.BackColor = Color.Transparent;
        }

        private void btnKapat_Click(object sender, EventArgs e)
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

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {

            //Combobox in icerisini veritabanindaki degerlerle doldurma

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbDers.DisplayMember = "DersAd";
            cmbDers.ValueMember = "DersId";
            cmbDers.DataSource = dt;
            baglanti.Close();
        }
        int notId;

        void Temizle()
        {
            txtOgrenciID.Clear();
            txtSinav1.Clear();
            txtSinav2.Clear();
            txtSinav3.Clear();
            txtProje.Clear();
            txtOrtalama.Clear();
            txtDurum.Clear();
        }
        private void dgwNotlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notId = int.Parse(dgwNotlar.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtOgrenciID.Text = dgwNotlar.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSinav1.Text = dgwNotlar.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dgwNotlar.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSinav3.Text = dgwNotlar.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dgwNotlar.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dgwNotlar.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dgwNotlar.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        string durum;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            sinav1 = Convert.ToInt16(txtSinav1.Text);
            sinav2 = Convert.ToInt16(txtSinav2.Text);
            sinav3 = Convert.ToInt16(txtSinav3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4.00;
            txtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtDurum.Text = "true";
            }
            else
            {
                txtDurum.Text = "false";
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbDers.SelectedValue.ToString()), int.Parse(txtOgrenciID.Text), byte.Parse(txtSinav1.Text), byte.Parse(txtSinav2.Text), byte.Parse(txtSinav3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrtalama.Text), bool.Parse(txtDurum.Text), notId);
            MessageBox.Show("Kayit Güncellenmistir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Temizle();
        }
    }
}
