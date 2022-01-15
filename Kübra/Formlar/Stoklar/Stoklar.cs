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

namespace Kübra.Formlar.Stoklar
{
    public partial class Stoklar : UserControl
    {
        public Stoklar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void Stoklar_Load(object sender, EventArgs e)
        {
            bgl.Open();
            SqlDataAdapter da = new SqlDataAdapter("select AD,SUM(STOK) AS 'Miktar' FROM  TBLURUN GROUP BY AD", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.Close();
        }
    }
}
