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

namespace Kübra.Formlar.Giderler
{
    public partial class Giderler : UserControl
    {
        public Giderler()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Giderler_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLGIDERLER.ToList();
            dataGridView1.DataSource = degerler;
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            var degerler = db.TBLGIDERLER.ToList();
            dataGridView1.DataSource = degerler;
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Düzenlemek istiyor musunuz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var deger = db.TBLGIDERLER.Find(id);
                db.TBLGIDERLER.Add(deger);
                db.SaveChanges();
                MessageBox.Show("Gider işlemi başarıyla güncellendi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Güncelleme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        TBLGIDERLER gider = new TBLGIDERLER();
        private void metroTile7_Click(object sender, EventArgs e)
        {
            TxtUrunAd.Text = TxtMarka.Text = TxtAlisFiyat.Text = TxtSatisFiyat.Text = TxtStok.Text = textEdit2.Text = textEdit1.Text = textEdit3.Text;
            gider.ID = 0;
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            TBLGIDERLER t = new TBLGIDERLER();
            t.TARIH = Convert.ToDateTime(TxtUrunAd.Text);
            t.ELEKTRIK = decimal.Parse(TxtMarka.Text);
            t.SU = decimal.Parse(textEdit2.Text);
            t.DOGALGAZ = decimal.Parse(TxtAlisFiyat.Text);
            t.INTERNET = decimal.Parse(TxtSatisFiyat.Text);
            t.MAASLAR = decimal.Parse(TxtStok.EditValue.ToString());
            t.EXTRA = short.Parse(textEdit1.Text);
            t.NOTLAR = textEdit3.Text;
            db.TBLGIDERLER.Add(t);
            db.SaveChanges();
            MessageBox.Show("Gider işlemi başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void metroTile8_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select *from TBLGIDERLER where TARIH like '%" + TxtUrunAd.Text + "%'", bgl);
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
                var deger = db.TBLGIDERLER.Find(id);
                db.TBLGIDERLER.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Gider işlemi başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
