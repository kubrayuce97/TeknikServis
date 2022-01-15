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
    public partial class Anasayfa : UserControl
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        private void metroTile2_Click_1(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Müşteriler"))
            {
                Müşteriler.Müşteriler müşteri = new Müşteriler.Müşteriler();
                müşteri.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(müşteri);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Müşteriler"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Personeller"))
            {
                Personeller.Personeller personeller = new Personeller.Personeller();
                personeller.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(personeller);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Personeller"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Stoklar"))
            {
                Stoklar.Stoklar stoklar = new Stoklar.Stoklar();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Stoklar"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile16_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Kategori"))
            {
                Kategori.Kategori stoklar = new Kategori.Kategori();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Kategori"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile15_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Departman"))
            {
                Departman.Departman stoklar = new Departman.Departman();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Departman"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Kasa"))
            {
                Kasa.Kasa stoklar = new Kasa.Kasa();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Kasa"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Ürünler"))
            {
                Ürünler.Ürünler stoklar = new Ürünler.Ürünler();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Ürünler"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile22_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Satış"))
            {
                SATIŞ.Satış stoklar = new SATIŞ.Satış();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Satış"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("İletişim"))
            {
                İletişim.İletişim stoklar = new İletişim.İletişim();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["İletişim"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Giderler"))
            {
               Giderler.Giderler stoklar = new Giderler.Giderler();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Giderler"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile21_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("ArızalıÜrün"))
            {
               Arızalı_Ürün.ArızalıÜrün stoklar = new Arızalı_Ürün.ArızalıÜrün();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["ArızalıÜrün"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Araçlar"))
            {
                Araçlar.Araçlar stoklar = new Araçlar.Araçlar();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Araçlar"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Faturalar"))
            {
                Faturalar.Faturalar stoklar = new Faturalar.Faturalar();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Faturalar"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Notlar"))
            {
                Notlar.Notlar stoklar = new Notlar.Notlar();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Notlar"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile14_Click(object sender, EventArgs e)
        {
            Ayarlar.Ayarlar ayar = new Ayarlar.Ayarlar();
            ayar.ShowDialog();
        }

        private void metroTile18_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Markaİst"))
            {
                İstatistikler.Markaİst stoklar = new İstatistikler.Markaİst();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Markaİst"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            if (!FrmAnasayfa.Instance.MetroContainer.Controls.ContainsKey("Ürünİst"))
            {
                İstatistikler.Ürünİst stoklar = new İstatistikler.Ürünİst();
                stoklar.Dock = DockStyle.Fill;
                FrmAnasayfa.Instance.MetroContainer.Controls.Add(stoklar);
            }
            FrmAnasayfa.Instance.MetroContainer.Controls["Ürünİst"].BringToFront();
            FrmAnasayfa.Instance.MetroBack.Visible = true;
        }
    }
}
