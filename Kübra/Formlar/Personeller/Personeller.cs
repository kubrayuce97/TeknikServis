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

namespace Kübra.Formlar.Personeller
{
    public partial class Personeller : UserControl
    {
        public Personeller()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void metroTile11_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
            t.AD = TxtAd.Text;
            t.SOYAD = textEdit1.Text;
        //  t.BIRTHDATE = Convert.ToDateTime(textEdit3.Text.ToString());
            t.ADRES = textEdit5.Text;
            t.IL = lookUpEdit3.Text;
            t.ILCE = lookUpEdit2.Text;
            t.EVTEL = textEdit10.Text;
            t.TELEFON = textEdit9.Text;
            t.MAIL = textEdit8.Text;
            t.SKYPE = textEdit2.Text;
            t.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.GÖREV = textEdit11.Text;
            t.ŞUBE = textEdit12.Text;
           // t.ISEGIRISTARIHI = Convert.ToDateTime(textEdit4.Text.ToString());
            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Personeller_Load(object sender, EventArgs e)
        {
            //listeleme tolist
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.TELEFON,
                               u.MAIL,
                               u.IL,
                               u.ILCE,
                               u.BIRTHDATE,
                               u.ADRES,
                               u.SKYPE,
                               DEPARTMAN = u.TBLDEPARTMAN.AD,
                               u.GÖREV,
                               u.ŞUBE

                           };
            dataGridView1.DataSource = degerler.ToList();

            lookUpEdit3.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.IL
                                                 }).ToList();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }
        int secilen;
        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit3.EditValue.ToString());
            lookUpEdit2.Properties.DataSource = (from y in db.TBLILCELER
                                                 select new
                                                 {
                                                     y.ID,
                                                     y.ILCE,
                                                     y.IL
                                                 }).Where(z => z.IL == secilen).ToList();
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            //listeleme tolist
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.TELEFON,
                               u.MAIL,
                               u.IL,
                               u.ILCE,
                               u.BIRTHDATE,
                               u.ADRES,
                               u.SKYPE,
                               u.DEPARTMAN,
                               u.GÖREV,
                               u.ŞUBE

                           };
            dataGridView1.DataSource = degerler.ToList();

            lookUpEdit3.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.IL
                                                 }).ToList();
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            personel.AD = TxtAd.Text.ToUpper().Trim();
            personel.SOYAD = textEdit1.Text.ToUpper().Trim();
         //   personel.BIRTHDATE = Convert.ToDateTime(textEdit3.Text.Trim().ToString());
            personel.ADRES = textEdit5.Text.ToUpper().Trim();
            personel.IL = lookUpEdit3.Text.ToUpper().Trim();
            personel.ILCE = lookUpEdit2.Text.ToUpper().Trim();
            personel.EVTEL = textEdit10.Text.ToUpper().Trim();
            personel.TELEFON = textEdit9.Text.ToUpper().Trim();
            personel.MAIL = textEdit8.Text.ToUpper().Trim();
            personel.SKYPE = textEdit2.Text.ToUpper().Trim();
         //   personel.DEPARTMAN = lookUpEdit1.Text;
            personel.GÖREV = textEdit11.Text;
            personel.ŞUBE = textEdit12.Text;
        //    personel.ISEGIRISTARIHI = Convert.ToDateTime(textEdit4.Text.Trim().ToString());
            if (string.IsNullOrEmpty(TxtAd.Text) && string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("boş bırakmayınız");
            }
            using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
            {
                ent.Entry(personel).State = EntityState.Modified;
                ent.SaveChanges();
            }
        }
        TBLPERSONEL personel = new TBLPERSONEL();
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                personel.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
                {
                    personel = ent.TBLPERSONEL.Where(p => p.ID == personel.ID).FirstOrDefault();
                    TxtId.Text = personel.ID.ToString();
                    TxtAd.Text = personel.AD;
                    textEdit1.Text = personel.SOYAD;
                    textEdit3.Text = personel.BIRTHDATE.ToString();
                    textEdit5.Text = personel.ADRES;
                    lookUpEdit3.Text = personel.IL;
                    lookUpEdit2.Text = personel.ILCE;
                    textEdit10.Text = personel.EVTEL;
                    textEdit9.Text = personel.TELEFON;
                    textEdit8.Text = personel.MAIL;
                    textEdit2.Text = personel.SKYPE;
                    lookUpEdit1.Text = personel.DEPARTMAN.ToString();
                    textEdit11.Text = personel.GÖREV;
                    textEdit12.Text = personel.ŞUBE;
                    textEdit4.Text = personel.ISEGIRISTARIHI.ToString();
                }
            }
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            TxtId.Text = TxtAd.Text = textEdit1.Text = textEdit3.Text = textEdit5.Text = lookUpEdit3.Text =
           lookUpEdit2.Text = textEdit10.Text = textEdit9.Text = textEdit8.Text = textEdit2.Text = lookUpEdit1.Text = textEdit11.Text = textEdit12.Text = textEdit4.Text = "";
            personel.ID = 0;

        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var deger = db.TBLPERSONEL.Find(id);
                db.TBLPERSONEL.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Personel başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select *from TBLPERSONEL where AD like '%" + TxtAd.Text + "%'", bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.Close();
        }
    }
}
