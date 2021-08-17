using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace arackiralama
{
    public partial class kirala : Form
    {
        OleDbConnection kayıt = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\rentacar.mdb"); // yeni bir veri tabanına bağlanma 
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

     
        public kirala()
        {
            InitializeComponent();
        }
        public string gonder5 { get; set; }
        private void kirala_Load(object sender, EventArgs e)
        {
            textucret.ReadOnly = true;
            pictureBox2.Visible = pictureBox3.Visible = false;
            verileri_cek();
            if (kayıt.State == ConnectionState.Closed)
            kayıt.Open();//eğer connection kapalıysa aç demek connection bağlı olup olmadığını kontrol edicek kapalıysa acçıcak.
            verileri_cek();
            bs.DataSource = ds.Tables["kirala"];//BindingSource'un veri kaynağı datasetin bolumler tablosu olsun.

            tbucret.DataBindings.Add("Text", bs, "ucret");
            tbbasla.DataBindings.Add("Text", bs, "basla");
            tbgun.DataBindings.Add("Text", bs, "bitis");
            tbsk.DataBindings.Add("Text", bs, "kkodu");
            tbtc.DataBindings.Add("Text", bs, "tckimlik");
            cbplaka.DataBindings.Add("Text", bs, "plaka");
           
            string seckomutu = "SELECT * FROM araclar where durum='Kiralık'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt); // seckomutunu uygulamak için kullanılır.
            da.Fill(ds, "araclar");
            cbplaka.DataSource = ds.Tables["araclar"];//cbplaka combobaxına datasoruce sinin veri kaynağı araclar tablosu olsun.
            cbplaka.DisplayMember = "plaka";//bizim gördüğümüz ön planda olan değer
           
            if (kayıt.State!= ConnectionState.Closed)
            kayıt.Close();
            cbplaka.SelectedIndex = -1;
            tbsk.Clear();
            tbtc.Clear();
            tbucret.SelectedIndex=-1;
            tbgun.Text = DateTime.Now.ToLongDateString();
            tbbasla.Text = DateTime.Now.ToLongDateString();
            textucret.Clear();
            tbtc.Focus();
            tbtc.Text = gonder5;
            tc6.Text = tbtc.Text;
            
        }
        void verileri_cek()
    {
            string sec = "select * from kirala"; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "kirala"); // datasetin bolumler tablosuna doldursun.
    }
        void verileri_cek2()
        {
            string sec = "select * from araclar"; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "araclar"); // datasetin bolumler tablosuna doldursun.
        }
        private void btniptal_Click(object sender, EventArgs e)
        {
            cbplaka.SelectedIndex=-1;
            tbsk.Clear();
            tbtc.Clear();
            tbucret.SelectedIndex=-1;

            tbgun.Text = DateTime.Now.ToLongDateString();
            tbbasla.Text = DateTime.Now.ToLongDateString();
            textucret.Clear();
            tbtc.Focus();
           

        }

        private void tbgun_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnonayla_Click(object sender, EventArgs e)
        {
           
            if (kayıt.State == ConnectionState.Closed)
                kayıt.Open();
            try
            {
                OleDbCommand ekle = new OleDbCommand("insert into kirala([tckimlik],[plaka],[basla],[bitis],[ucret]) Values (@tbtc,@tbplaka,@tbbasla,@tbgun,@textucret)", kayıt);
                ekle.Connection = kayıt;
                ekle.Parameters.AddWithValue("@tckimlik", tbtc.Text);
               
                ekle.Parameters.AddWithValue("@plaka", cbplaka.Text);
                ekle.Parameters.AddWithValue("@basla", tbbasla.Text);
                ekle.Parameters.AddWithValue("@bitis", tbgun.Text);
                ekle.Parameters.AddWithValue("@ucret", textucret.Text);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Rezervasyon Yapıldı.");

                OleDbCommand guncelle = new OleDbCommand("update araclar SET durum=@durum where plaka=@plaka", kayıt);
                guncelle.Parameters.AddWithValue("@durum", "Kiralandı");
                guncelle.Parameters.AddWithValue("@plaka", cbplaka.Text);
                guncelle.ExecuteNonQuery();
                verileri_cek();
                verileri_cek2();
              
                kullanicirezervasyonislemleri kri = new kullanicirezervasyonislemleri();
                kri.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Tc Kimlik Numarasına Ait Kayıt Bulunumadı !!!");
            }


        }

        private void tbtc_TextChanged(object sender, EventArgs e)
        {

            if (tbtc.Text.Length > 11)
            {
                MessageBox.Show("Doğru Girdiğinize Emin Olun !!!");
            }
        }

        private void tbtc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            aracara a = new aracara();
            a.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (kayıt.State == ConnectionState.Closed)
                kayıt.Open();
           
                OleDbCommand ekle = new OleDbCommand("insert into kirala([tckimlik],[plaka],[basla],[bitis],[ucret]) Values (@tbtc,@tbplaka,@tbbasla,@tbgun,@textucret)", kayıt);
                ekle.Connection = kayıt;
                ekle.Parameters.AddWithValue("@tckimlik", tbtc.Text);
                ekle.Parameters.AddWithValue("@plaka", cbplaka.Text);
                ekle.Parameters.AddWithValue("@basla", tbbasla.Text);
                ekle.Parameters.AddWithValue("@bitis", tbgun.Text);
                ekle.Parameters.AddWithValue("@ucret", textucret.Text);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Rezervasyon Yapıldı.");

                OleDbCommand guncelle = new OleDbCommand("update araclar SET durum=@durum where plaka=@plaka", kayıt);
                guncelle.Parameters.AddWithValue("@durum", "Kiralandı");
                guncelle.Parameters.AddWithValue("@plaka", cbplaka.Text);
                guncelle.ExecuteNonQuery();
                verileri_cek();
                verileri_cek2();

             
            
            kullanicirezervasyonislemleri kri = new kullanicirezervasyonislemleri();
            kri.gonder5 = tc6.Text;
            this.Hide();
            kri.ShowDialog();
           

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            cbplaka.SelectedIndex = -1;
            tbsk.Clear();
            tbtc.Clear();
            tbucret.SelectedIndex = -1;
            tbgun.Text = DateTime.Now.ToLongDateString();
            tbbasla.Text = DateTime.Now.ToLongDateString();
            textucret.Clear();
            tbtc.Focus();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            int ucret;
            TimeSpan zaman = DateTime.Parse(tbgun.Text) - DateTime.Parse(tbbasla.Text);
            int gun = zaman.Days;
            string seckomutu = "SELECT gunluk_ucret FROM araclar where plaka='" + cbplaka.SelectedItem + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt); // seckomutunu uygulamak için kullanılır.
            da.Fill(ds, "araclar");
            tbucret.DataSource = ds.Tables["araclar"];//cbplaka combobaxına datasoruce sinin veri kaynağı araclar tablosu olsun.
            tbucret.DisplayMember = "gunluk_ucret";//bizim gördüğümüz ön planda olan değer
            int deger = int.Parse(tbucret.Text);
            ucret = deger * gun;
            textucret.Text = ucret.ToString();
            pictureBox3.Visible = pictureBox2.Visible = true;
        }
    }
}
