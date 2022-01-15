using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kübra.Formlar.Arızalı_Ürün
{
    public partial class ArızalıÜrün : UserControl
    {
        public ArızalıÜrün()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        TBLURUNKABUL kabul = new TBLURUNKABUL();
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow.Index != -1)
            {
                kabul.ISLEMID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ISLEMID"].Value);
                using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
                {
                    kabul = ent.TBLURUNKABUL.Where(p => p.ISLEMID == kabul.ISLEMID).FirstOrDefault();
                 
                    lookUpEdit1.Text = kabul.ISLEMID.ToString();
                    lookUpEdit2.Text = kabul.PERSONEL.ToString();
                    TxtTarih.Text = kabul.ToString();
                    TxtSeri.Text = kabul.ToString();
                }
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                kabul.ISLEMID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ISLEMID"].Value);
                using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
                {
                    kabul = ent.TBLURUNKABUL.Where(p => p.ISLEMID == kabul.ISLEMID).FirstOrDefault();

                    lookUpEdit1.Text = kabul.ISLEMID.ToString();
                    lookUpEdit2.Text = kabul.PERSONEL.ToString();
                    TxtTarih.Text = kabul.ToString();
                    TxtSeri.Text = kabul.ToString();
                }
            }
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void metroTile6_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLURUNKABUL
                           select new
                           {
                               x.ISLEMID,
                               MÜŞTERİ = x.TBLMUSTERILER.AD + " " + x.TBLMUSTERILER.SOYAD,
                               PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                               x.GELISTARIHI,
                               x.CIKISTARIHI,
                               x.URUNSERINO
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            TBLURUNKABUL t = new TBLURUNKABUL();
            t.CARI = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.PERSONEL = byte.Parse(lookUpEdit2.EditValue.ToString());
            t.GELISTARIHI = DateTime.Parse(TxtTarih.Text);
            t.URUNSERINO = TxtSeri.Text;
            t.URUNDURUMDETAY = "Ürün Kaydoldu";
            db.TBLURUNKABUL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Arızalı Ürün Eklendi.");
        }
        public string id;
        private void ArızalıÜrün_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLMUSTERILER
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from y in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     y.ID,
                                                     AD = y.AD + " " + y.SOYAD
                                                 }).ToList();
            richTextBox1.Text = id;
        }
        
        private void metroTile4_Click(object sender, EventArgs e)
        {
            kabul.CARI = Convert.ToInt32(lookUpEdit1.Text.ToUpper().Trim());
            kabul.PERSONEL = Convert.ToInt16(lookUpEdit2.Text.ToUpper().Trim());
            kabul.GELISTARIHI = Convert.ToDateTime(TxtTarih.Text.ToString());
            kabul.URUNSERINO = TxtSeri.Text;
  
  
            kabul.URUNSERINO = lookUpEdit2.Text.ToUpper().Trim();
            if (string.IsNullOrEmpty(TxtSeri.Text))
            {
                MessageBox.Show("boş bırakmayınız");
            }
            using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
            {
                // if (musteri.ID == 0) //insert
                //
                //   ent.TBLMUSTERILER.Add(musteri);
                //else //update
                ent.Entry(kabul).State = EntityState.Modified;
                ent.SaveChanges();
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

            lookUpEdit1.Text = lookUpEdit2.Text = TxtTarih.Text = TxtSeri.Text ="";
            kabul.ISLEMID = 0;
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void metroTile2_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select *from TBLURUNKABUL where URUNSERINO like '%" + TxtSeri.Text + "%'", bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.Close();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var deger = db.TBLURUNKABUL.Find(id);
                db.TBLURUNKABUL.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Arızalı Ürün başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLURUNTAKIP
                                     select new
                                     {
                                         x.TAKIPID,
                                         x.SERINO,
                                         x.TARIH,
                                         x.ACIKLAMA
                                     }).ToList();
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            TBLURUNTAKIP t = new TBLURUNTAKIP();
            t.ACIKLAMA = richTextBox1.Text;
            t.SERINO = textEdit1.Text;
            t.TARIH = DateTime.Parse(dateEdit1.Text);
            db.TBLURUNTAKIP.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Detay Güncellendi!");

          
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            // 2.GÜNCELLEME
            TBLURUNKABUL TB = new TBLURUNKABUL();
            string kod = textEdit1.Text;
            var deger = db.TBLURUNKABUL.Find(kod);
            deger.URUNDURUMDETAY = comboBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Detayları Güncellendi");
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            textEdit1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateEdit1_Click(object sender, EventArgs e)
        {
            dateEdit1.Text = DateTime.Now.ToShortDateString();
        }
        TBLURUNTAKIP takıp = new TBLURUNTAKIP();
        private void metroTile7_Click(object sender, EventArgs e)
        {
            textEdit1.Text = comboBox1.Text = richTextBox1.Text = "";
            takıp.TAKIPID = 0;
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select *from TBLURUNTAKIP where SERINO like '%" + TxtSeri.Text + "%'", bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            bgl.Close();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var deger = db.TBLURUNTAKIP.Find(id);
                db.TBLURUNTAKIP.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Arızalı Ürün Takibi başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
