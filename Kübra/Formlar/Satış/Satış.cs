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

namespace Kübra.Formlar.SATIŞ
{
    public partial class Satış : UserControl
    {
        public Satış()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Satış_Load(object sender, EventArgs e)
        {

            lookUpEdit1.Properties.DataSource = (from x in db.TBLURUN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
            lookUpEdit3.Properties.DataSource = (from x in db.TBLMUSTERILER
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            TBLURUNHAREKET t = new TBLURUNHAREKET();
            t.URUN = int.Parse(lookUpEdit1.Text);
            t.MUSTERI = int.Parse(lookUpEdit3.Text);
            t.PERSONEL = short.Parse(lookUpEdit2.Text);
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.ADET = short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.URUNSERINO = TxtSeri.Text;
            db.TBLURUNHAREKET.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Satışı Yapıldı.");
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLURUNHAREKET
                           select new
                           {
                               u.HAREKETID,
                               u.TBLURUN.AD,
                               MUSTERI = u.TBLMUSTERILER.AD + " " + u.TBLMUSTERILER.SOYAD,
                               PERSONEL = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                               u.TARIH,
                               u.ADET,
                               u.FIYAT,
                               u.URUNSERINO
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Düzenlemek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var deger = db.TBLURUN.Find(id);
                db.TBLURUN.Add(deger);
                db.SaveChanges();
                MessageBox.Show("Satış başarıyla güncellendi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Güncelleme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        TBLURUNHAREKET urunhareket = new TBLURUNHAREKET();
        private void metroTile7_Click(object sender, EventArgs e)
        {
            lookUpEdit1.Text = lookUpEdit2.Text = lookUpEdit3.Text = TxtTarih.Text = TxtAdet.Text = TxtFiyat.Text =TxtSeri.Text;
            urunhareket.HAREKETID = 0;
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void metroTile8_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select *from TBLURUN where URUNSERINO like '%" + TxtSeri.Text + "%'", bgl);
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
                var deger = db.TBLURUNHAREKET.Find(id);
                db.TBLURUNHAREKET.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Satış işlemi başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
