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
    public partial class rezerve : Form
    {
        OleDbConnection kayıt = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\rentacar.mdb"); // yeni bir veri tabanına bağlanma 
         public static DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public rezerve()
        {
            InitializeComponent();
        }
        void verileri_cek()
        {
            string sec = "select * from kirala"; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "kirala"); // datasetin bolumler tablosuna doldursun.

        }
        private void rezerve_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            yetkiislem yk = new yetkiislem();
            yk.Show();
            this.Hide();
        }
        void verileri_cek3()
        {
            string sec = "select * from kirala "; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "kirala"); // datasetin bolumler tablosuna doldursun.
        }
        private void rezerve_Load_1(object sender, EventArgs e)
        {
            if (kayıt.State == ConnectionState.Closed)
            kayıt.Open();//eğer connection kapalıysa aç demek connection bağlı olup olmadığını kontrol edicek kapalıysa acçıcak.
            verileri_cek();
            bs.DataSource = ds.Tables["kirala"];//BindingSource'un veri kaynağı datasetin bolumler tablosu olsun.
            dataGridView1.DataSource = bs; //BindingSource ile forma arasındaki bağlantı sağlandı.
            tbsk.DataBindings.Add("Text", bs, "kkodu");
            tbtc.DataBindings.Add("Text", bs, "tckimlik");
            cbplaka.DataBindings.Add("Text", bs, "plaka");
            tbbasla.DataBindings.Add("Text", bs, "basla");
            bitis.DataBindings.Add("Text", bs, "bitis");
            tbucret.DataBindings.Add("Text", bs, "ucret");
            OleDbCommand cmd = new OleDbCommand("select count(*) from kirala", kayıt);
            if (kayıt.State == ConnectionState.Closed)
                kayıt.Open();
            int kayitSayisi = Convert.ToInt32(cmd.ExecuteScalar());

            for (int i = 0; i < kayitSayisi; i++)
            {
                bs.Position = i;
                string sec = "SELECT bitis FROM kirala where plaka='" + cbplaka.Text + "'";
                OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // seckomutunu uygulamak için kullanılır.
                da.Fill(ds, "kirala");
                cbekle.DataSource = ds.Tables["kirala"];//cbplaka combobaxına datasoruce sinin veri kaynağı araclar tablosu olsun.
                cbekle.DisplayMember = "bitis";//bizim gördüğümüz ön planda olan değer
                cbekle.SelectedIndex = i;
                string zaman = cbekle.Text.ToString();
                DateTime zaman2 = DateTime.Parse(zaman);
                DateTime simdi = DateTime.Now;
                TimeSpan zaman4 = DateTime.Parse(zaman) - simdi;
                int gun = zaman4.Days;
                if (gun <= 0)
                {
                    OleDbCommand guncelle = new OleDbCommand("update araclar SET durum=@durum where plaka=@plaka", kayıt);
                    guncelle.Parameters.AddWithValue("@durum", "Kiralık");
                    guncelle.Parameters.AddWithValue("@plaka", cbplaka.Text);
                    guncelle.ExecuteNonQuery();
                    OleDbCommand degistir = new OleDbCommand();
                    degistir.Connection = kayıt;//command nesnesini connectiona conn ile ekledik
                    degistir.CommandText = "delete from kirala where plaka=@plaka ";
                    degistir.Parameters.AddWithValue("@plaka", cbplaka.Text);
                    degistir.ExecuteNonQuery();//komutları çalıştırır.


                }

                verileri_cek3();

            }
         

        }

       

        private void bitis_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            rezervasyonraporla rr = new rezervasyonraporla();
            rr.Show();
            this.Hide();
        }

        private void aranan_TextChanged_1(object sender, EventArgs e)
        {
            if (rbplaka.Checked )
            {
                string seckomutu = "select * from kirala where plaka like '%" + aranan.Text + "%'";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
                ds.Clear();
                da.Fill(ds, "kirala");
            }
            else if (rbbtc.Checked)
            {
                string seckomutu = "select * from kirala where tckimlik like '%" + aranan.Text + "%'";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
                ds.Clear();
                da.Fill(ds, "kirala");
            }
            else if (rbhepsi.Checked)
            {
                aranan.Clear();
                string seckomutu = "select * from kirala ";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
                ds.Clear();
                da.Fill(ds, "kirala");
                aranan.Clear();
            }
        }

        private void rbhepsi_Click(object sender, EventArgs e)
        {
             if (rbhepsi.Checked)
            {
                aranan.Clear();
                string seckomutu = "select * from kirala ";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
                ds.Clear();
                da.Fill(ds, "kirala");
                aranan.Clear();
            }
        }
    }
}
