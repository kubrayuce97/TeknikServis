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
    public partial class Ürünİst : UserControl
    {
        public Ürünİst()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void Ürünİst_Load(object sender, EventArgs e)
        {
            chart1.Series["Series 1"].Points.AddXY("Ankara", 22);
            chart1.Series["Series 1"].Points.AddXY("İstanbul", 2);
            chart1.Series["Series 1"].Points.AddXY("Bursa", 8);
            chart1.Series["Series 1"].Points.AddXY("İzmir", 14);

            metroGrid1.DataSource = db.TBLMUSTERILER.OrderBy(x => x.IL).GroupBy(y => y.IL)
                .Select(z => new { İL = z.Key, TOPLAM = z.Count() }).ToList();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select IL,COUNT(*) FROM TBLMUSTERILER group by IL", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Series 1"].Points.AddXY(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }
    }
}
