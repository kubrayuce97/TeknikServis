using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kübra.Formlar.Giriş_Kayıt
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
      
        private void button2_Click(object sender, EventArgs e)
        {
            TBLADMIN a = new TBLADMIN();
            a.KULLANICIAD = textBox1.Text;
            a.SIFRE = textBox2.Text;
            db.TBLADMIN.Add(a);
            db.SaveChanges();
            MessageBox.Show("Kullanıcı adı ve parola eklndi!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Hide();
        }
    }
}
