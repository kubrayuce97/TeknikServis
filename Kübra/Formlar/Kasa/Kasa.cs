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

namespace Kübra.Formlar.Kasa
{
    public partial class Kasa : UserControl
    {
        public Kasa()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void Kasa_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLURUNHAREKET
                           select new
                           {
                               u.HAREKETID,
                               ÜRÜN=u.TBLURUN.AD,
                               MÜŞTERİ=u.TBLMUSTERILER.AD+" "+u.TBLMUSTERILER.SOYAD,
                               PERSONEL= u.TBLMUSTERILER.AD + " " + u.TBLMUSTERILER.SOYAD,
                               u.TARIH,
                               u.ADET,
                               u.FIYAT,
                               u.URUNSERINO
                           };
            dataGridView2.DataSource = degerler.ToList();
          /*  bgl.Open();
            //SqlDataAdapter da = new SqlDataAdapter("Execute Musterihareketler", bgl);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLURUNHAREKET", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bgl.Close();*/
            //toplam tutar
            bgl.Open();
            SqlCommand komut1 = new SqlCommand("Select sum(TUTAR) from TBLFATURADETAY", bgl);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                label2.Text = dr1[0].ToString() + " TL";
            }
            bgl.Close();

            //son ayın faturaları
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EXTRA) from TBLGIDERLER ORDER BY ID ASC", bgl);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                label3.Text = dr2[0].ToString() + " TL";
            }
            bgl.Close();
            //son ayın personel maaşları
            bgl.Open();
            SqlCommand komut3 = new SqlCommand("Select MAASLAR from TBLGIDERLER ORDER BY ID ASC", bgl);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                label5.Text = dr3[0].ToString() + " TL";
            }
            bgl.Close();

            bgl.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM TBLGIDERLER", bgl);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            bgl.Close();
        }
    }
}
