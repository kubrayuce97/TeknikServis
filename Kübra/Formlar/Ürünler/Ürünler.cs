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

namespace Kübra.Formlar.Ürünler
{
    public partial class Ürünler : UserControl
    {
        public Ürünler()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Ürünler_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORI
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
            //listeleme tolist
            var degerler1 = db.TBLURUN.ToList();
            dataGridView1.DataSource = degerler1;

 
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Düzenlemek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var deger = db.TBLURUN.Find(id);
                db.TBLURUN.Add(deger);
                db.SaveChanges();
                MessageBox.Show("Ürün başarıyla güncellendi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Güncelleme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.AD = TxtUrunAd.Text;
            t.MARKA = TxtMarka.Text;
            t.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            t.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.STOK = short.Parse(TxtStok.Text);
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        TBLURUN urun = new TBLURUN();
        private void metroTile7_Click(object sender, EventArgs e)
        {
            TxtUrunAd.Text = TxtMarka.Text = TxtAlisFiyat.Text = TxtSatisFiyat.Text = TxtStok.Text = lookUpEdit1.Text ;
            urun.ID = 0;

        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void metroTile8_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select *from TBLURUN where AD like '%" + TxtUrunAd.Text + "%'", bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.Close();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var deger = db.TBLURUN.Find(id);
                db.TBLURUN.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Ürün başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
