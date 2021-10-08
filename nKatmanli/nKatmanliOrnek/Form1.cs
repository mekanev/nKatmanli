using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nKatmanliOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Ad = txtAd.Text;
            ent.Sehir = txtSehir.Text;
            ent.Maas = int.Parse(txtMaas.Text);
            ent.Soyad = txtSoyad.Text;
            ent.Gorev = txtGorev.Text;
            LogicPersonel.LLPersonelEkle(ent);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(textBox1.Text);
            LogicPersonel.LLPersonelSil(ent.Id);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id =int.Parse(textBox1.Text);
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Sehir = txtMaas.Text;
            ent.Gorev = txtGorev.Text;
            ent.Maas = int.Parse(txtMaas.Text);
            LogicPersonel.LLPersonelGuncelle(ent);
        }
    }
}
