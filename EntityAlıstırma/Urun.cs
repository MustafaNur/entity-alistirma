using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EntityAlıstırma
{
    public partial class Urun : Form
    {
        public Urun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void Urun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Kategori
                               select new
                               {
                                   x.ID,
                                   x.Ad
                               }).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Ad";
            comboBox1.DataSource = kategoriler;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= db.Urunler.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urunler t = new Urunler();
            t.UrunAd = txtUrunAd.Text;
            t.Marka= txtMarka.Text;
            t.Stok = short.Parse(txtStok.Text);
            t.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            t.Fiyat = decimal.Parse(txtFiyat.Text);
            t.Durum = true;
            db.Urunler.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtID.Text);
            var urun = db.Urunler.Find(x);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");
            
        }

        private void butonGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtID.Text);
            var urun = db.Urunler.Find(x);
            urun.UrunAd = txtUrunAd.Text;
            urun.Stok = short.Parse(txtStok.Text);
            urun.Marka = txtMarka.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }
    }
}
