using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=APACHIE;Initial Catalog=BonusOkul;Integrated Security=True");

        public string numara;


        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DersAd,Sinav1,Sinav2,Sinav3,Proje,Ortalama,Durum from tbl_Notlar inner join tbl_Dersler on tbl_Notlar.DersId = tbl_Dersler.DersId where OgrId = @id", baglanti);
            komut.Parameters.AddWithValue("@id", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Giris yapan kisinin adini soyadini Formun basligina yazdirma
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from tbl_Ogrenciler where OgrId=@id", baglanti);
            komut2.Parameters.AddWithValue("@id", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[1] + " " + dr[2];
            }
            baglanti.Close();
        }
    }
}
