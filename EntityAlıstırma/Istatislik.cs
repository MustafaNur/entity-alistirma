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
    public partial class Istatislik : Form
    {
        public Istatislik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void Istatislik_Load(object sender, EventArgs e)
        {
            label2.Text = db.Kategori.Count().ToString();
            label3.Text = db.Urunler.Count().ToString();
            label13.Text = (from x in db.Urunler orderby x.Fiyat descending select x.UrunAd).FirstOrDefault();
            label15.Text = (from x in db.Urunler orderby x.Fiyat ascending select x.UrunAd).FirstOrDefault();
            label9.Text = db.Urunler.Count(x => x.Kategori == 1).ToString();
        }
    }
}
