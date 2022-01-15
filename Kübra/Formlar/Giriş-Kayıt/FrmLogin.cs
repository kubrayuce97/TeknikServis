using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Kübra.Formlar.Anasayfa;

namespace Kübra.Formlar.Giriş_Kayıt
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-TH9UJHS;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("select * from TBLADMIN WHERE KULLANICIAD=@p1 and SIFRE=@p2", bgl);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnasayfa anasayfa = new FrmAnasayfa();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanı adı ve ya şifre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmRegister Register = new FrmRegister();
            Register.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.FromArgb(0, 192, 192);
            textBox1.ForeColor = Color.FromArgb(0, 192, 192);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.FromArgb(0, 192, 192);
            textBox1.ForeColor = Color.FromArgb(0, 192, 192);
        }
    }
}
