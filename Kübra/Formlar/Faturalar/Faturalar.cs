using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kübra.Formlar.Faturalar
{
    public partial class Faturalar : UserControl
    {
        public Faturalar()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Faturalar_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLFATURABILGI
                           select new
                           {
                               u.ID,
                               u.SERI,
                               u.SIRANO,
                               u.TARIH,
                               u.SAAT,
                               u.VERGIDAIRE,
                               Musteri = u.TBLMUSTERILER.AD + " " + u.TBLMUSTERILER.SOYAD,
                               Personel = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                           };
            dataGridView1.DataSource = degerler.ToList();

            lookUpEdit1.Properties.DataSource = (from x in db.TBLMUSTERILER
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD

                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLFATURABILGI
                           select new
                           {
                               u.ID,
                               u.SERI,
                               u.SIRANO,
                               u.TARIH,
                               u.SAAT,
                               u.VERGIDAIRE,
                               Musteri = u.TBLMUSTERILER.AD + " " + u.TBLMUSTERILER.SOYAD,
                               Personel = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textEdit1.Text);
            var degerler1 = (from u in db.TBLFATURADETAY
                             select new
                             {
                                 u.FATURADETAYID,
                                 u.URUN,
                                 u.ADET,
                                 u.FIYAT,
                                 u.TUTAR,
                                 u.FATURAID
                             }).Where(x => x.FATURAID == id);
            dataGridView2.DataSource = degerler1.ToList();
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI t = new TBLFATURABILGI();
            t.SERI = metroTextBox2.Text;
            t.SIRANO = metroTextBox3.Text;
            t.TARIH = Convert.ToDateTime(metroTextBox6.Text);
            t.SAAT = metroTextBox4.Text;
            t.VERGIDAIRE = metroTextBox5.Text;
            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Sisteme Kaydedildi!");
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUN = txtdetayıd.Text;
            t.ADET = short.Parse(txtadet.Text);
            t.FIYAT = decimal.Parse(txtfiyat.Text);
            t.TUTAR = decimal.Parse(txttutar.Text);
            t.FATURAID = int.Parse(txtfaturaid.Text);
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
            MessageBox.Show("Faturaya ait kale eklendi Sisteme Kaydedildi!");
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            var degerler1 = from u in db.TBLFATURADETAY
                            select new
                            {
                                u.FATURADETAYID,
                                u.URUN,
                                u.ADET,
                                u.FIYAT,
                                u.TUTAR,
                                u.FATURAID
                            };
            dataGridView3.DataSource = degerler1.ToList();
        }
    }
}
