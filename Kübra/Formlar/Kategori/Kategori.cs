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

namespace Kübra.Formlar.Kategori
{
    public partial class Kategori : UserControl
    {
        public Kategori()
        {
            InitializeComponent();
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void metroTile5_Click(object sender, EventArgs e)
        {
            if (textEdit4.Text != "" && textEdit4.Text.Length <= 30)
            {
                TBLKATEGORI k = new TBLKATEGORI();
                k.AD = textEdit4.Text;
                db.TBLKATEGORI.Add(k);
                db.SaveChanges();
                MessageBox.Show("Kategori başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kategori Adı Boş Geçilemez ve 30 Karakterden Uzun Olamaz");
            }
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            //listeleme
            var degerler = from u in db.TBLKATEGORI
                           select new
                           {
                               u.ID,
                               u.AD,
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void Kategori_Load(object sender, EventArgs e)
        {
            //listeleme
            var degerler = from u in db.TBLKATEGORI
                           select new
                           {
                               u.ID,
                               u.AD,
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        TBLKATEGORI kategori = new TBLKATEGORI();
        private void metroTile1_Click(object sender, EventArgs e)
        {
            textEdit4.Text = textEdit2.Text = "";
            kategori.ID = 0;
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            kategori.AD = textEdit4.Text;
           
            if (string.IsNullOrEmpty(textEdit4.Text))
            {
                MessageBox.Show("boş bırakmayınız");
            }
            using (DbTeknikServisEntities ent = new DbTeknikServisEntities())
            {
                ent.Entry(kategori).State = EntityState.Modified;
                ent.SaveChanges();
            }
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void metroTile2_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select *from TBLPERSONEL where AD like '%" + textEdit4.Text + "%'", bgl);
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
                var deger = db.TBLKATEGORI.Find(id);
                db.TBLKATEGORI.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Kategori başarıyla silindi!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemini iptal ettiniz!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
