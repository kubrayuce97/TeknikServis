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

namespace Kübra.Formlar.İstatistikler
{
    public partial class Markaİst : UserControl
    {
        public Markaİst()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Markaİst_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).
               Select(z => new
               {
                   Marka = z.Key,
                   Toplam = z.Count()
               });
            metroGrid1.DataSource = degerler.ToList();
            labelControl2.Text = db.TBLURUN.Count().ToString();
            labelControl3.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString();
            labelControl7.Text = (from x in db.TBLURUN
                                  orderby x.SATISFIYAT descending
                                  select x.MARKA).FirstOrDefault();
            labelControl5.Text = db.MAXURUNMARKA().FirstOrDefault();

            //chart1.Series["MARKALAR"].Points.AddXY("Arçelik", 6);
            //chart1.Series["MARKALAR"].Points.AddXY("Beko", 2);
            //chart1.Series["MARKALAR"].Points.AddXY("Toshiba", 1);
            //chart1.Series["MARKALAR"].Points.AddXY("Lenovo", 1);
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT MARKA,COUNT(*) FROM TBLURUN GROUP BY MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["MARKALAR"].Points.AddXY(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
            //chart2.Series["KATEGORİLER"].Points.AddXY("Beyaz Eşya ", 1);
            //chart2.Series["KATEGORİLER"].Points.AddXY("Bilgisayar", 1);
            //chart2.Series["KATEGORİLER"].Points.AddXY("Küçük Ev Aletleri", 6);
            //chart2.Series["KATEGORİLER"].Points.AddXY("TV", 2);
            //chart2.Series["KATEGORİLER"].Points.AddXY("Telefon", 1);
            //chart2.Series["KATEGORİLER"].Points.AddXY("Diğer", 2);

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT TBLKATEGORI.AD,COUNT(*) FROM TBLURUN INNER JOIN TBLKATEGORI ON TBLKATEGORI.ID=TBLURUN.KATEGORI " +
                "GROUP BY TBLKATEGORI.AD", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["KATEGORİLER"].Points.AddXY(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();
        }
    }
}
