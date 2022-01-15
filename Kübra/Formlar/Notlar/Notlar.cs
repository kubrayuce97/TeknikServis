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

namespace Kübra.Formlar.Notlar
{
    public partial class Notlar : UserControl
    {
        public Notlar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Notlar_Load(object sender, EventArgs e)
        {
            /*var degerler = from u in db.TBLNOTLARIM
                           select new
                           {
                               u.ID,
                               PERSONEL = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                               u.BASLIK,
                               u.ICERIK,
                               u.DURUM,
                               u.TARIH
                           };
            metroGrid1.DataSource = degerler.ToList();

            var degerler1 = from u in db.TBLNOTLARIM
                           select new
                           {
                               u.ID,
                               PERSONEL = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                               u.BASLIK,
                               u.ICERIK,
                               u.DURUM,
                               u.TARIH
                           };
            metroGrid2.DataSource = degerler1.ToList();*/
           
            metroGrid1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            metroGrid2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == true).ToList();
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            TBLNOTLARIM t = new TBLNOTLARIM();
            t.PERSONELID = Convert.ToInt16(metroTextBox8.Text.ToString());
            t.BASLIK = metroTextBox3.Text;
            t.ICERIK = metroTextBox4.Text;
            t.DURUM = false;
            t.TARIH = DateTime.Parse(metroTextBox6.Text);
            db.TBLNOTLARIM.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {/*
            var degerler = from u in db.TBLNOTLARIM
                           select new
                           {
                               u.ID,
                               PERSONEL = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                               u.BASLIK,
                               u.ICERIK,
                               u.DURUM,
                               u.TARIH
                           };
            metroGrid1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();

            var degerler1 = from u in db.TBLNOTLARIM
                            select new
                            {
                                u.ID,
                                PERSONEL = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                                u.BASLIK,
                                u.ICERIK,
                                u.DURUM,
                                u.TARIH
                            };
            metroGrid2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == true).ToList();*/

            metroGrid1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            metroGrid2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == true).ToList(); 
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                int id = int.Parse(metroTextBox1.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Not Durumu Değiştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            /*  if (MessageBox.Show("Düzenlemek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              {
                  int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                  var deger = db.TBLNOTLARIM.Find(id);
                  db.TBLNOTLARIM.Add(deger);
                  db.SaveChanges();
                  MessageBox.Show("Gider işlemi başarıyla güncellendi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
              else
              {
                  MessageBox.Show("Güncelleme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
              if (MessageBox.Show("Düzenlemek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              {
                  int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                  var deger = db.TBLNOTLARIM.Find(id);
                  db.TBLNOTLARIM.Add(deger);
                  db.SaveChanges();
                  MessageBox.Show("Not işlemi başarıyla güncellendi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
              else
              {
                  MessageBox.Show("Güncelleme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }*/
        }
        TBLNOTLARIM notlarım = new TBLNOTLARIM();
        private void metroTile7_Click(object sender, EventArgs e)
        {/*
            lookUpEdit2.Text = metroLabel3.Text = metroTextBox4.Text = metroCheckBox1.Text = metroLabel6.Text;
            notlarım.ID = 0;*/
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void metroTile8_Click(object sender, EventArgs e)
        {
            /* bgl.Open();
             SqlCommand komut = new SqlCommand("Select *from TBLNOTLARIM where PERSONELID like " + lookUpEdit2.Text + "%'", bgl);
             SqlDataAdapter da = new SqlDataAdapter(komut);
             DataSet ds = new DataSet();
             da.Fill(ds);
             dataGridView1.DataSource = ds.Tables[0];
             bgl.Close();

             bgl.Open();
             SqlCommand komut2 = new SqlCommand("Select *from TBLNOTLARIM where PERSONELID like " + lookUpEdit2.Text + "%'", bgl);
             SqlDataAdapter da2 = new SqlDataAdapter(komut2);
             DataSet ds2 = new DataSet();
             da2.Fill(ds2);
             dataGridView2.DataSource = ds2.Tables[0];
             bgl.Close();*/
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            /* if (MessageBox.Show("Silmek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                 var deger = db.TBLNOTLARIM.Find(id);
                 db.TBLNOTLARIM.Remove(deger);
                 db.SaveChanges();
                 MessageBox.Show("Not işlemi başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else
             {
                 MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }


             if (MessageBox.Show("Silmek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 int id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                 var deger = db.TBLNOTLARIM.Find(id);
                 db.TBLNOTLARIM.Remove(deger);
                 db.SaveChanges();
                 MessageBox.Show("Not işlemi başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else
             {
                 MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }*/
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {/*
            if (dataGridView1.CurrentRow.Index != -1)
            {
                notlarım.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
                {
                    notlarım = ent.TBLNOTLARIM.Where(p => p.ID == notlarım.ID).FirstOrDefault();
                    metroTextBox1.Text = notlarım.ID.ToString();
                    metroTextBox3.Text = notlarım.BASLIK;
                    metroTextBox4.Text = notlarım.ICERIK;
                    metroCheckBox1.Text=notlarım.DURUM.ToString();
                    metroTextBox6.Text = notlarım.TARIH.ToString();
                    lookUpEdit2.Text = notlarım.PERSONELID.ToString();

                }
            }
            if (dataGridView1.CurrentRow.Index != -1)
            {
                notlarım.ID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value);
                using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
                {
                    notlarım = ent.TBLNOTLARIM.Where(p => p.ID == notlarım.ID).FirstOrDefault();
                    metroTextBox1.Text = notlarım.ID.ToString();
                    metroTextBox3.Text = notlarım.BASLIK;
                    metroTextBox4.Text = notlarım.ICERIK;
                    metroCheckBox1.Text = notlarım.DURUM.ToString();
                    metroTextBox6.Text = notlarım.TARIH.ToString();
                    lookUpEdit2.Text = notlarım.PERSONELID.ToString();

                }
            }*/
        }
    }
}
