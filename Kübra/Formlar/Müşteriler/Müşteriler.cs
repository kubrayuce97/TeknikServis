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

namespace Kübra.Formlar.Müşteriler
{
    public partial class Müşteriler : UserControl
    {
        public Müşteriler()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");

        private void Müşteriler_Load(object sender, EventArgs e)
        {
            //listeleme tolist
            var degerler = from u in db.TBLMUSTERILER
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.TELEFON,
                               u.MAIL,
                               u.IL,
                               u.ILCE,
                               u.VERGIDAIRESI,
                               u.VERGINO,
                               u.STATU,
                               u.ADRES
                           };
            dataGridView1.DataSource = degerler.ToList();

            lookUpEdit1.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.IL
                                                 }).ToList();
        }
        private void metroTile2_Click_1(object sender, EventArgs e)
        {
            TBLMUSTERILER m = new TBLMUSTERILER();
            m.AD = TxtAd.Text;
            m.SOYAD = TxtSoyad.Text;
            m.TELEFON = TxtTelefon.Text;
            m.MAIL = TxtMail.Text;
            m.VERGIDAIRESI = TxtVergiDaire.Text;
            m.VERGINO = TxtVergiNo.Text;
            m.STATU = TxtStatu.Text;
            m.ADRES = TxtAdres.Text;
            m.IL = lookUpEdit1.Text;
            m.ILCE = lookUpEdit2.Text;
            db.TBLMUSTERILER.Add(m);
            db.SaveChanges();
            MessageBox.Show("Müşteri başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            TBLMUSTERILER m = new TBLMUSTERILER();
            m.AD = TxtAd.Text;
            m.SOYAD = TxtSoyad.Text;
            m.TELEFON = TxtTelefon.Text;
            m.MAIL = TxtMail.Text;
            m.VERGIDAIRESI = TxtVergiDaire.Text;
            m.VERGINO = TxtVergiNo.Text;
            m.STATU = TxtStatu.Text;
            m.ADRES = TxtAdres.Text;
            m.IL = lookUpEdit1.Text;
            m.ILCE = lookUpEdit2.Text;
            db.TBLMUSTERILER.Add(m);
            db.SaveChanges();
            MessageBox.Show("Müşteri başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        int secilen;
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit1.EditValue.ToString());
            lookUpEdit2.Properties.DataSource = (from y in db.TBLILCELER
                                                 select new
                                                 {
                                                     y.ID,
                                                     y.ILCE,
                                                     y.IL
                                                 }).Where(z => z.IL == secilen).ToList();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLMUSTERILER
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.TELEFON,
                               u.MAIL,
                               u.IL,
                               u.ILCE,
                               u.VERGIDAIRESI,
                               u.VERGINO,
                               u.STATU,
                               u.ADRES
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var deger = db.TBLMUSTERILER.Find(id);
                db.TBLMUSTERILER.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Müşteri başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        TBLMUSTERILER musteri = new TBLMUSTERILER();
        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                musteri.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
                {
                    musteri = ent.TBLMUSTERILER.Where(p => p.ID == musteri.ID).FirstOrDefault();
                    TxtId.Text = musteri.ID.ToString();
                    TxtAd.Text = musteri.AD;
                    TxtSoyad.Text = musteri.SOYAD;
                    TxtTelefon.Text = musteri.TELEFON;
                    TxtMail.Text = musteri.MAIL;
                    TxtVergiDaire.Text = musteri.VERGIDAIRESI;
                    TxtVergiNo.Text = musteri.VERGINO;
                    TxtStatu.Text = musteri.STATU;
                    TxtAdres.Text = musteri.ADRES;
                    lookUpEdit1.Text = musteri.IL;
                    lookUpEdit2.Text = musteri.ILCE;

                }
            }
        }
        private void metroTile3_Click(object sender, EventArgs e)
        {
            musteri.AD = TxtAd.Text.ToUpper().Trim();
            musteri.SOYAD = TxtSoyad.Text.ToUpper().Trim();
            musteri.TELEFON = TxtTelefon.Text.ToUpper().Trim();
            musteri.MAIL = TxtMail.Text.ToUpper().Trim();
            musteri.VERGIDAIRESI = TxtVergiDaire.Text.ToLower().Trim();
            musteri.VERGINO = TxtVergiNo.Text.ToUpper().Trim();
            musteri.STATU = TxtStatu.Text.ToUpper().Trim();
            musteri.ADRES = TxtAdres.Text.ToUpper().Trim();
            musteri.IL = lookUpEdit1.Text.ToUpper().Trim();
            musteri.ILCE = lookUpEdit2.Text.ToUpper().Trim();
            if (string.IsNullOrEmpty(TxtAd.Text) && string.IsNullOrEmpty(TxtSoyad.Text))
            {
                MessageBox.Show("boş bırakmayınız");
            }
            using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
            {
                // if (musteri.ID == 0) //insert
                //
                //   ent.TBLMUSTERILER.Add(musteri);
                //else //update
                ent.Entry(musteri).State = EntityState.Modified;
                ent.SaveChanges();
            }
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select *from TBLMUSTERILER where AD like '%" + TxtAd.Text + "%'", bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.Close();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {

            TxtId.Text=TxtAd.Text = TxtSoyad.Text = TxtTelefon.Text = TxtMail.Text = TxtVergiDaire.Text =
                TxtVergiNo.Text = TxtStatu.Text = TxtAdres.Text = lookUpEdit1.Text = lookUpEdit2.Text = "";
            musteri.ID = 0;
          
        }
    }
}
