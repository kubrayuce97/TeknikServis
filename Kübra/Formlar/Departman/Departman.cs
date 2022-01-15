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

namespace Kübra.Formlar.Departman
{
    public partial class Departman : UserControl
    {
        public Departman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void metroTile11_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();
            t.AD = TxtAd.Text;
            db.TBLDEPARTMAN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Departman başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            //listeleme
            var degerler = from u in db.TBLDEPARTMAN
                           select new
                           {
                               u.ID,
                               u.AD,
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void Departman_Load(object sender, EventArgs e)
        {
            //listeleme
            var degerler = from u in db.TBLDEPARTMAN
                           select new
                           {
                               u.ID,
                               u.AD,
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        TBLDEPARTMAN departman = new TBLDEPARTMAN();
        private void metroTile10_Click(object sender, EventArgs e)
        {
            departman.AD = TxtAd.Text;

            if (string.IsNullOrEmpty(TxtAd.Text))
            {
                MessageBox.Show("boş bırakmayınız");
            }
            using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
            {
                ent.Entry(departman).State = EntityState.Modified;
                ent.SaveChanges();
            }
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            TxtAd.Text = "";
            departman.ID = 0;
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void metroTile8_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select *from TBLDEPARTMAN where AD like '%" + TxtAd.Text + "%'", bgl);
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
                var deger = db.TBLDEPARTMAN.Find(id);
                db.TBLDEPARTMAN.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Departman başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
