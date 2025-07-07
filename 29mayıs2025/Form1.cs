using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _29mayıs2025
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NorthwindEntities con = new NorthwindEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var result = from ü in con.Urunlers
                         orderby ü.BirimFiyati ascending
                         select ü;
            dataGridView1.DataSource = result.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = from ü in con.Urunlers 
                         orderby ü.UrunAdi descending
                         select ü;
            dataGridView1.DataSource = result.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = from ü in con.Satislars
                         orderby ü.NakliyeUcreti descending
                         select ü;
            dataGridView1.DataSource = result.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = con.Musterilers.Where(x => x.Ulke == textBox1.Text).GroupBy(y=>y.Sehir);
            if (result.Any())
            {
                dataGridView1.DataSource = result.ToList();
            }
            else
            {
                MessageBox.Show("Bu ülkeye ait müşteri bulunamadı.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = from s in con.Satislars
                         join p in con.Personellers
                         on s.PersonelID equals p.PersonelID
                         select new { 
                         p.Adi,p.SoyAdi,
                         s.SevkAdi,s.SevkAdresi
                         };
            dataGridView1.DataSource = result.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var result = from ü in con.Urunlers join t in con.Tedarikcilers
                         on ü.TedarikciID equals t.TedarikciID
                         join k in con.Kategorilers
                         on ü.KategoriID equals k.KategoriID
                         select new
                         {
                             ü.UrunAdi,
                             t.MusteriAdi,
                             k.KategoriAdi,
                             ü.BirimFiyati
                         };
            dataGridView1.DataSource = result.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var result = from s in con.Satislars
                         join m in con.Musterilers on s.MusteriID equals m.MusteriID 
                         group s by m.SirketAdi into grup 
                         select new
                         {
                             SirketAdi = grup.Key,
                             ToplamNakliyeUcreti = grup.Sum(x => x.NakliyeUcreti)
                         };
            
            dataGridView1.DataSource = result.ToList();
        }

        /*
         

1.ado .net store prclu proje

2.ado.net  proje

3.entityfrme dbfirst proje

4.entitiy modekfirst proj

5.entity proclu proje
         */
    }
}
