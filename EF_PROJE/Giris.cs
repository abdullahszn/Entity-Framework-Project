using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_PROJE
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        OzcompanyEntities db = new OzcompanyEntities();

        //Tablolar
        Kullanicilar kullanicilar = new Kullanicilar();
        Departman departman = new Departman();
        Personel personel = new Personel();
        
        //Formlar
        Form1 form1 = new Form1();

        private void Giris_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false; // Başlangıçta kullanıcı ekleme grubu gizli
        }
        private bool KullaniciGiris(string kullaniciAdi, string sifre)
        {
            var kullanici = db.Kullanicilars.FirstOrDefault(x => x.KullaniciAd == kullaniciAdi && x.Sifre == sifre);
            if (kullanici != null)
            {
                MessageBox.Show("Giriş Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form1.Show();  
                return true;
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        KullaniciGiris(textBox1.Text, textBox2.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var kullanici = db.Kullanicilars.FirstOrDefault(x => x.KullaniciAd == textBox3.Text && x.Sifre == textBox4.Text);
            if (kullanici != null) { 
            MessageBox.Show("Kullanıcı zaten mevcut", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                Kullanicilar yeniKullanici = new Kullanicilar();
                yeniKullanici.KullaniciAd = textBox3.Text;
                yeniKullanici.Sifre = textBox4.Text;
                db.Kullanicilars.Add(yeniKullanici);
                db.SaveChanges();
                MessageBox.Show("Yeni kullanıcı başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = checkBox1.Checked;
        }
    }
}
