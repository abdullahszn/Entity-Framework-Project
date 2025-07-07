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
    public partial class Form1 : Form
    {
        //entity framework 
        //Orm araçlarından biridir ORM(Object Relation Mapping) araçlarından biridir.
        //ilişkisel veritabanı ile nesneye yönelimli programlamam(oop) arasında  bir köprü görevi görürür.Bu orm sisteminde veritabanındaki bilgilerlimizi yönetmek ve nesneleri modellemek için kullandıgımız yapıdır. 

        //ef:veritabanımızdaki nesnelerimi baglamak ve veritabanıyla veri alışverişisini yapan Microsoft tarafından geliştirmiş bir framework.Ado.net yapısını kullanaktadır.
        //ef 4 e ayrılır 
        //model first : tüm veri işleri vs de gerçekleşir
        //db :database first:sql veritabanı olusturulur. vs kısmına varolan veritabanı çekilir.
        //codefirst (yeni veri tabanı class ve nesneler ile oluşturulur)
        //codefirst (var olan veri tabanı  kullanma özelliği  vardır.)

        //avantajları
        //oop olarak rahat kod geliştirme sağlar
        //sql bilgisi olmayan kişide ef ile veritabanı işlemlerini yapabilir
        //herhangi bir veritabanına balılık yok
        //yazılım geliştirme zamnını hızlandır.
        //Yazılım geliştirme  maaliyetini azaltır

        //dezavantajları
        //en büyük problem performnsıdır.Ado.net  kadar hızlı performansı yok.
        //veritabanı işlemleri schema olarak yapıldıgı için değişiklik konusunda sorunlar çıkabilir.
        //LINQ(lANGUAGE  INTEGRATED QUERY-DİL İLE TÜMLEŞİK SORGU ):VERİ KOLEKSİYONLARINI VERİTABANINDAKİ VERİLERDE  SORGULAMAK,FİLTRELEMK İÇİN KULLANULAN VE İŞLMELERİMİZİ KOLAYLAŞTIRAN TEKNOLOJİDİR.
        //SingleOrDeafult() : veri işelmerini yönetirken sorgu sonucunda yanlız bir eleman bekler.Birden fazla elemena bulunursa yada hiç eleman buunmaz hata fırlatır
        //FirstOrDefault():yönetimi sorgu sonucunda  yanlızcam bir eleman bekler.birden fazla bulursa  yaznlızca ilk elemanı geri döndürür.eger hic eleman bulamamaz  varsayılan  degeri  null olarak getirir.

        //c# Lambda Expression 
        //c# dilinde lamda  fonksiyonlar  gibi kullanılır.Tek fark :degerin tümünü belirtmemize gerek yoktur buda bize kullanım sırasında daha esnek bir yapı sunar. =>
        //n=>n*n

        public Form1()
        {
            InitializeComponent();
        }
        OzcompanyEntities db = new OzcompanyEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.Departmen.ToList();
            comboBox1.ValueMember = "DepartmanNo";

            //pastane ,cafe ,yemek  üzerine olucak
            //yönetici kısmı olucak ürün malzeme raporlar
            //kullanıcılar kısmında sipariş kısmı var olan ürümnleri şubeleri görsün



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.AdSoyad = textBox1.Text;
            personel.Yas = Convert.ToInt32(textBox2.Text);
            personel.Meslek = textBox3.Text;
            personel.Mezuniyet = textBox4.Text;
            personel.Maas = Convert.ToDecimal(textBox5.Text);
            personel.DepartmanNo = Convert.ToInt32(comboBox1.SelectedItem);
            db.Personels.Add(personel); //ekleme işlemi
            db.SaveChanges(); //veritabanına kaydetme işlemi
            MessageBox.Show("Personel Eklendi");
            dataGridView1.DataSource = db.Personels.ToList(); //veritabanındaki personel listesini datagridview'e yükleme



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Personels.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["PersonelNo"].Value.ToString();
            textBox1.Text = row.Cells["AdSoyad"].Value.ToString();
            textBox2.Text = row.Cells["Yas"].Value.ToString();
            textBox3.Text = row.Cells["Meslek"].Value.ToString();
            textBox4.Text = row.Cells["Mezuniyet"].Value.ToString();
            textBox5.Text = row.Cells["Maas"].Value.ToString();
            comboBox1.SelectedItem = row.Cells["DepartmanNo"].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int PersonelNo = Convert.ToInt32(textBox1.Tag);
            var result = db.Personels.Where(x => x.PersonelNo == PersonelNo).FirstOrDefault();
            result.AdSoyad = textBox1.Text;
            result.Yas = Convert.ToInt32(textBox2.Text);
            result.Meslek = textBox3.Text;
            result.Mezuniyet = textBox4.Text;
            result.Maas = Convert.ToDecimal(textBox5.Text);
            result.DepartmanNo = Convert.ToInt32(comboBox1.SelectedItem);
            db.SaveChanges();
            dataGridView1.DataSource = db.Personels.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int PersonelNo = Convert.ToInt32(textBox1.Tag);
            var result = db.Personels.Where(x => x.PersonelNo == PersonelNo).FirstOrDefault();
            db.Personels.Remove(result);
            db.SaveChanges();
            dataGridView1.DataSource = db.Personels.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Personels.Where(x => x.AdSoyad.ToLower().Contains(textBox1.Text)).ToList();
        }
    }
}
