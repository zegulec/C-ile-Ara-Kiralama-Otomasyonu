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
    public partial class kullaniciislemleri : Form
    {
        bool durum1;
        bool durum;
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\rentacar.mdb"); // yeni bir veri tabanına bağlanma 
        public static   DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        int kacincikayit;
        public kullaniciislemleri()
        {
            InitializeComponent();
        }
        void verileri_cek()
        {
            string sec = "select * from kullanicilar"; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, conn); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "kullanicilar"); // datasetin bolumler tablosuna doldursun.
        }

        private void kullaniciislemleri_Load(object sender, EventArgs e)
        {
            pictureBox7.Visible = pbtnkaydet.Visible = pbtndkaydet.Visible = l1.Visible = l2.Visible = false;
            if (conn.State == ConnectionState.Closed) 
            conn.Open();//eğer connection kapalıysa aç demek connection bağlı olup olmadığını kontrol edicek kapalıysa acçıcak.
            verileri_cek();
            bs.DataSource = ds.Tables["kullanicilar"];//BindingSource'un veri kaynağı datasetin bolumler tablosu olsun.
            dataGridView1.DataSource = bs;  //BindingSource ile forma arasındaki bağlantı sağlandı.
            tbadi.DataBindings.Add("Text", bs, "ad"); //tbadinın text özelliğini databağlantısı BindingSource un badi alanına bağla 
            tbsoyadi.DataBindings.Add("Text", bs, "soyad");
            tbtc.DataBindings.Add("Text", bs, "tckimlik");
            tbka.DataBindings.Add("Text", bs, "ka"); //tbadinın text özelliğini databağlantısı BindingSource un badi alanına bağla 
            tbsf.DataBindings.Add("Text", bs, "sifre");
            tbmail.DataBindings.Add("Text", bs, "mail");   
            tbdtarih.DataBindings.Add("Text", bs, "dtarihi");
            tbtelefon.DataBindings.Add("Text", bs, "telefon"); //tbadinın text özelliğini databağlantısı BindingSource un badi alanına bağla 
            cbil.DataBindings.Add("Text", bs, "il");
            tbadres.DataBindings.Add("Text", bs, "adres"); //tbadinın text özelliğini databağlantısı BindingSource un badi alanına bağla 
          
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            yetkiislem yk = new yetkiislem();
            yk.Show();
            this.Close();
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

        private void tbadi_Enter(object sender, EventArgs e)
        {
            if (tbtc.Text.Length < 11)
            {
                MessageBox.Show("TC'yi  Doğru Girdiğinize Emin Olun !!!");
            }
        }

        private void tbtelefon_KeyPress(object sender, KeyPressEventArgs e)
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


        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
            pictureBox7.Visible = pbtnkaydet.Visible = true;
            pbtndkaydet.Visible = false;
            l1.Visible = l2.Visible = true;
            tbadi.Clear();
            tbadres.Clear();
            tbka.Clear();
            tbsf.Clear();
            tbsoyadi.Clear();
            tbmail.Clear();
            tbtelefon.Clear();
            tbtc.Clear();
            cbil.SelectedIndex = -1;
            tbdtarih.Refresh();
            tbtc.Focus();
            tbtc.Enabled = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pbtndkaydet.Visible = pictureBox7.Visible = true;
            pbtnkaydet.Visible = false;
            l1.Visible = l2.Visible = true;
            kacincikayit = bs.Position;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            DialogResult cevap = MessageBox.Show("Kaydı Silmek İstediginize Emin Misiniz ?", "Bilgi", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;//command nesnesini connectiona conn ile ekledik
                cmd.CommandText = "delete from kullanicilar where tckimlik=@tckimlik";
                cmd.Parameters.AddWithValue("@tckimlik", tbtc.Text);
                cmd.ExecuteNonQuery();//komutları çalıştırır.
                MessageBox.Show("Kayıt Silindi.");
                verileri_cek();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pbtnkaydet.Visible = pictureBox7.Visible = pbtndkaydet.Visible = l1.Visible=l2.Visible=false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            kullaniciraporla kr = new kullaniciraporla();
            kr.ShowDialog();
            this.Hide();
        }

        private void pbtnkaydet_Click(object sender, EventArgs e)
        {

            pbtnkaydet.Visible = pictureBox7.Visible = pbtndkaydet.Visible = l1.Visible = l2.Visible = false;
            try
            {
                kacincikayit = ds.Tables[0].Rows.Count;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OleDbCommand ekle = new OleDbCommand("INSERT INTO kullanicilar([tckimlik],[ad],[soyad],[ka],[sifre],[mail],[telefon],[dtarihi],[il],[adres])Values (@tbtc,@tbadi,@tbsoyadi,@tbka,@tbsf,@tbmail,@tbtelefon,@tbdtarih,@cbil,@tbadres)", conn);
                ekle.Connection = conn;
                ekle.Parameters.AddWithValue("@tckimlik", tbtc.Text);
                ekle.Parameters.AddWithValue("@ad", tbadi.Text);
                ekle.Parameters.AddWithValue("@soyad", tbsoyadi.Text);
                ekle.Parameters.AddWithValue("@ka", tbka.Text);
                ekle.Parameters.AddWithValue("@sifre", tbsf.Text);
                ekle.Parameters.AddWithValue("@mail", tbmail.Text);
                ekle.Parameters.AddWithValue("@telefon", tbtelefon.Text);
                ekle.Parameters.AddWithValue("@dtarihi", tbdtarih.Text);
                ekle.Parameters.AddWithValue("@il", cbil.Text);
                ekle.Parameters.AddWithValue("@adres", tbadres.Text);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı  Eklendi.");
                verileri_cek();
                bs.Position = kacincikayit;
               


            }
            catch
            {
                MessageBox.Show("aynı tc kimlik numarsından 2 kayıt oluşturulmaz.");
            }
        }
        string tuttc = null;
        void tekrar()
        {
            if (tbtc.Text != tuttc)
            {
                durum1 = false;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from kullanicilar where tckimlik=@tckimlik", conn);
                cmd.Parameters.AddWithValue("@tckimlik", tbtc.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    durum = false;
                }
                else
                {
                    durum = true;
                }
            }
            else
            {
                durum1 = true;

            }

        }
        private void pbtndkaydet_Click(object sender, EventArgs e)
        {
            kacincikayit = bs.Position;
            pbtndkaydet.Visible = pbtnkaydet.Visible = pictureBox7.Visible=l1.Visible=l2.Visible = false;
            tekrar();
            if (durum1 == false)
            {
                if (durum == true)
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    OleDbCommand guncelle = new OleDbCommand("update kullanicilar SET tckimlik=@tckimlik,ad=@ad,soyad=@soyad,ka=@ka,sifre=@sifre,mail=@mail,telefon=@telefon,dtarihi=@dtarihi,il=@il,adres=@adres where tckimlik=@tckimlik1", conn);
                    guncelle.Connection = conn;
                    guncelle.Parameters.AddWithValue("@tckimlik", tbtc.Text);
                    guncelle.Parameters.AddWithValue("@ad", tbadi.Text);
                    guncelle.Parameters.AddWithValue("@soyad", tbsoyadi.Text);
                    guncelle.Parameters.AddWithValue("@ka", tbka.Text);
                    guncelle.Parameters.AddWithValue("@sifre", tbsf.Text);
                    guncelle.Parameters.AddWithValue("@mail", tbmail.Text);
                    guncelle.Parameters.AddWithValue("@telefon", tbtelefon.Text);
                    guncelle.Parameters.AddWithValue("@dtarihi", tbdtarih.Text);
                    guncelle.Parameters.AddWithValue("@il", cbil.Text);
                    guncelle.Parameters.AddWithValue("@adres", tbadres.Text);
                    guncelle.Parameters.AddWithValue("@tckimlik1", tuttc);
                    guncelle.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Güncellendi.");
                    conn.Close();
                    verileri_cek();
                    bs.Position = kacincikayit;
                }
                else
                {
                    MessageBox.Show("bu Tc Kimlik Numarası Bulunmaktadır.");
                    tbtc.Clear();
                }
            }
            else
            {

                if (conn.State == ConnectionState.Closed) conn.Open();
                OleDbCommand guncelle = new OleDbCommand("update kullanicilar SET ad=@ad,soyad=@soyad,ka=@ka,sifre=@sifre,mail=@mail,telefon=@telefon,dtarihi=@dtarihi,il=@il,adres=@adres where tckimlik=@tckimlik", conn);
                guncelle.Connection = conn;
                guncelle.Parameters.AddWithValue("@ad", tbadi.Text);
                guncelle.Parameters.AddWithValue("@soyad", tbsoyadi.Text);
                guncelle.Parameters.AddWithValue("@ka", tbka.Text);
                guncelle.Parameters.AddWithValue("@sifre", tbsf.Text);
                guncelle.Parameters.AddWithValue("@mail", tbmail.Text);
                guncelle.Parameters.AddWithValue("@telefon", tbtelefon.Text);
                guncelle.Parameters.AddWithValue("@dtarihi", tbdtarih.Text);
                guncelle.Parameters.AddWithValue("@il", cbil.Text);
                guncelle.Parameters.AddWithValue("@adres", tbadres.Text);
                guncelle.Parameters.AddWithValue("@tckimlik", tbtc.Text);
                guncelle.ExecuteNonQuery();
                MessageBox.Show("Kayıt Güncellendi.");
                conn.Close();
                verileri_cek();
                bs.Position = kacincikayit;

            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void ara_TextChanged(object sender, EventArgs e)
        {
            if (rbtc.Checked)
            {
                string seckomutu = "select * from kullanicilar where tckimlik like '%" + ara.Text + "%'";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, conn);
                ds.Clear();
                da.Fill(ds, "kullanicilar");
                
            }
            else if(rbad.Checked)
            {
                string seckomutu = "select * from kullanicilar where ad like '%" + ara.Text + "%'";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, conn);
                ds.Clear();
                da.Fill(ds, "kullanicilar");
                
                

            }
            else if(rbhepsi.Checked)
            {
                string seckomutu = "select * from kullanicilar ";
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, conn);
                ds.Clear();
                da.Fill(ds, "kullanicilar");
                ara.Clear();
            }
           
        }

        private void rbhepsi_Click(object sender, EventArgs e)
        {
            if(rbhepsi.Checked)
            {
                string seckomutu = "select * from kullanicilar ";  
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, conn);
                ds.Clear();
                da.Fill(ds, "kullanicilar");
                ara.Clear();
            }
        }

        private void rbhepsi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            tuttc = tbtc.Text;
        }

    }
}
