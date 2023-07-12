using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityAlıstırma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.Kategori.ToList();
            dataGridView1.DataSource= kategoriler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kategori t = new Kategori();
            t.Ad = textBox2.Text;
            db.Kategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktg = db.Kategori.Find(x);
            db.Kategori.Remove(ktg);
            db.SaveChanges();
            MessageBox.Show("Kategori silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktg = db.Kategori.Find(x);
            ktg.Ad= textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme yapıldı");
        }
    }
}
