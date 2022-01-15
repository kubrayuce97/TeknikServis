using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kübra.Formlar.İletişim
{
    public partial class İletişim : UserControl
    {
        public İletişim()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void İletişim_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLMUSTERILER
                                     select new
                                     {
                                         x.AD,
                                         x.SOYAD,
                                         x.TELEFON,
                                         x.MAIL
                                     }).ToList();
        }
    }
}
