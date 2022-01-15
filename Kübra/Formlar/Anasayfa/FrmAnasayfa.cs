using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kübra.Formlar.Anasayfa
{
    public partial class FrmAnasayfa : MetroFramework.Forms.MetroForm
    {
        static FrmAnasayfa _instance;
        public static FrmAnasayfa Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FrmAnasayfa();
                return _instance;
            }
        }
        public MetroFramework.Controls.MetroPanel MetroContainer
        {
            get { return metroPanel1; }
            set { metroPanel1 = value; }
        }
        public MetroFramework.Controls.MetroLink MetroBack
        {
            get { return metroLink1; }
            set { metroLink1 = value; }
        }
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            metroLink1.Visible = false;
            _instance = this;
            Anasayfa uc = new Anasayfa();
            uc.Dock = DockStyle.Fill;
            metroPanel1.Controls.Add(uc);
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            metroPanel1.Controls["Anasayfa"].BringToFront();
            metroLink1.Visible = false;
        }
    }
}
