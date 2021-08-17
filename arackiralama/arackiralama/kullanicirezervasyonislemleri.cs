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
    public partial class kullanicirezervasyonislemleri : Form
    {
        OleDbConnection kayıt = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\rentacar.mdb"); // yeni bir veri tabanına bağlanma 
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public string gonder2 { get; set; }
        public string gonder5 { get; set; }
        public kullanicirezervasyonislemleri()
        {
            InitializeComponent();
        }
        void verileri_cek()
        {
            string sec = "select * from kirala "; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "kirala"); // datasetin bolumler tablosuna doldursun.
        }
        void verileri_cek2()
        {
            string sec = "select * from araclar "; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "araclar"); // datasetin bolumler tablosuna doldursun.
        }
        void verileri_cek3()
        {
            string sec = "select * from kirala "; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "kirala"); // datasetin bolumler tablosuna doldursun.
        }
        private void kullanicirezervasyonislemleri_Load(object sender, EventArgs e)
        {
            aranan.Focus();
           
            tbplaka.ReadOnly = true;
            if (kayıt.State == ConnectionState.Closed)
            kayıt.Open();//eğer connection kapalıysa aç demek connection bağlı olup olmadığını kontrol edicek kapalıysa acçıcak.
            verileri_cek();
            bs.DataSource = ds.Tables["kirala"];//BindingSource'un veri kaynağı datasetin bolumler tablosu olsun.
            dataGridView1.DataSource = bs; //BindingSource ile forma arasındaki bağlantı sağlandı.
            tbplaka.DataBindings.Add("Text", bs, "plaka");
            basla.DataBindings.Add("Text", bs, "basla");
            bitis.DataBindings.Add("Text", bs, "bitis");
            OleDbCommand cmd = new OleDbCommand("select count(*) from kirala", kayıt);
            if (kayıt.State == ConnectionState.Closed)
            kayıt.Open();
            int kayitSayisi = Convert.ToInt32(cmd.ExecuteScalar());
            
            for(int i=0;i<kayitSayisi;i++)
            {
                bs.Position = i;
                string sec = "SELECT bitis FROM kirala where plaka='" + tbplaka.Text + "'";
                OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // seckomutunu uygulamak için kullanılır.
                da.Fill(ds, "kirala");
                cbekle.DataSource = ds.Tables["kirala"];//cbplaka combobaxına datasoruce sinin veri kaynağı araclar tablosu olsun.
                cbekle.DisplayMember = "bitis";//bizim gördüğümüz ön planda olan değer
                cbekle.SelectedIndex = i;
                string zaman = cbekle.Text.ToString();
                DateTime zaman2 = DateTime.Parse(zaman);
                DateTime simdi = DateTime.Now;
                TimeSpan zaman4 = DateTime.Parse(zaman)-simdi;
                int gun = zaman4.Days;
                if(gun<=0)
                {
                    OleDbCommand guncelle = new OleDbCommand("update araclar SET durum=@durum where plaka=@plaka", kayıt);
                    guncelle.Parameters.AddWithValue("@durum", "Kiralık");
                    guncelle.Parameters.AddWithValue("@plaka", tbplaka.Text);
                    guncelle.ExecuteNonQuery();
                    OleDbCommand degistir = new OleDbCommand();
                    degistir.Connection = kayıt;//command nesnesini connectiona conn ile ekledik
                    degistir.CommandText = "delete from kirala where plaka=@plaka ";
                    degistir.Parameters.AddWithValue("@plaka", tbplaka.Text);
                    degistir.ExecuteNonQuery();//komutları çalıştırır.
                  

                }

                verileri_cek3();
               
            }
      
            kayıt.Close();
            tc2.Text = gonder2;
            tc5.Text = gonder5;
            if (tc2.Text != "")
            {
                kelime = tc2.Text;
            }
            else 
            {
                kelime = tc5.Text;
            }
            aranan.Text = kelime;
           
          }
        string kelime;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Rezervasyonu İptal Etmek İstediğinize Emin Misiniz ?", "Soru ?", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                if (kayıt.State == ConnectionState.Closed)
                    kayıt.Open();
                OleDbCommand guncelle = new OleDbCommand("update araclar SET durum=@durum where plaka=@plaka", kayıt);
                guncelle.Parameters.AddWithValue("@durum", "Kiralık");
                guncelle.Parameters.AddWithValue("@plaka", tbplaka.Text);
                guncelle.ExecuteNonQuery();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = kayıt;//command nesnesini connectiona conn ile ekledik
                cmd.CommandText = "delete from kirala where plaka=@plaka ";
                cmd.Parameters.AddWithValue("@plaka", tbplaka.Text);
                cmd.ExecuteNonQuery();//komutları çalıştırır.
                
                MessageBox.Show("Rezervasyon İptal Edildi.");
                verileri_cek2();
                verileri_cek();
            }
        }
        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (tc2.Text != "")
            {
                kelime = tc2.Text;
            }
            else
            {
                kelime = tc5.Text;
            }
            sec s = new sec();
            s.gonder3 = kelime;
            this.Hide();
            s.ShowDialog();
           
        }
       private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       private void aranan_KeyPress(object sender, KeyPressEventArgs e)
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

       private void aranan_TextChanged(object sender, EventArgs e)
       {
           string seckomutu = "select * from kirala where tckimlik like '%" + aranan.Text + "%'";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
           OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
           ds.Clear();
           da.Fill(ds, "kirala");
       }

       private void groupBox1_Enter(object sender, EventArgs e)
       {

       }

       private void pictureBox1_Click(object sender, EventArgs e)
       {
           if (kayıt.State == ConnectionState.Closed) kayıt.Open();
           OleDbCommand guncelle = new OleDbCommand("update kirala SET basla=@basla,bitis=@bitis where plaka=@plaka", kayıt);
           guncelle.Connection = kayıt;
           guncelle.Parameters.AddWithValue("@basla", basla.Text);
           guncelle.Parameters.AddWithValue("@bitis", bitis.Text);
           guncelle.Parameters.AddWithValue("@plaka", tbplaka.Text);
          
           guncelle.ExecuteNonQuery();
           MessageBox.Show("Kayıt Güncellendi.");
           kayıt.Close();
           verileri_cek3();
       }

    }
}
