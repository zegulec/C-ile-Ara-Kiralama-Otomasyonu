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
    public partial class arackayit : Form
    {
        public arackayit()
        {
            InitializeComponent();
        }
        bool durum;
        bool durum1;
        string tutplaka = null;
        OleDbConnection kayıt = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\rentacar.mdb"); // yeni bir veri tabanına bağlanma 
        public static DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        int kacincikayit;
        void verileri_cek()
        {
            string sec = "select * from araclar"; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "araclar"); // datasetin bolumler tablosuna doldursun.

        }

        private void arackayit_Load(object sender, EventArgs e)
        {
            pictureBox7.Visible = pbtnkaydet.Visible = pbtndkaydet.Visible = l1.Visible = l2.Visible = false;
            if (kayıt.State == ConnectionState.Closed)
                kayıt.Open();//eğer connection kapalıysa aç demek connection bağlı olup olmadığını kontrol edicek kapalıysa acçıcak.
            verileri_cek();
            bs.DataSource = ds.Tables["araclar"];//BindingSource'un veri kaynağı datasetin bolumler tablosu olsun.
            dataGridView1.DataSource = bs; //BindingSource ile forma arasındaki bağlantı sağlandı.
            tbplaka.DataBindings.Add("Text", bs, "plaka");  //tbadinın text özelliğini databağlantısı BindingSource un badi alanına bağla 
            cbdurum.DataBindings.Add("Text", bs, "durum");
            cbkasatipi.DataBindings.Add("Text", bs, "kasatipi");
            cbmarka.DataBindings.Add("Text", bs, "marka");
            tbmodel.DataBindings.Add("Text", bs, "model");
            cbvites.DataBindings.Add("Text", bs, "vites");
            tbyil.DataBindings.Add("Text", bs, "uretildigiyil");
            tbrenk.DataBindings.Add("Text", bs, "renk");
            tbsigorta.DataBindings.Add("Text", bs, "sigortabitistarihi");
            tbkasko.DataBindings.Add("Text", bs, "kaskotarih");
            cbyakit.DataBindings.Add("Text", bs, "yakit");
            tbucret.DataBindings.Add("Text", bs, "gunluk_ucret");
            tbkilometre.DataBindings.Add("Text", bs, "kilometre");
            


        }

       
     

       
       

        private void tbyil_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbkilometre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbucret_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbkasko_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbsigorta_KeyPress(object sender, KeyPressEventArgs e)
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
            yetkiislem yk = new yetkiislem();
            yk.Show();
            this.Hide();
        }

        private void tbyil_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tbplaka.Enabled = true;
            pictureBox7.Visible = pbtnkaydet.Visible = l1.Visible = l2.Visible = true;
            pbtndkaydet.Visible = false;
            kacincikayit = ds.Tables[0].Rows.Count;//en son eklenen kaydı göstermek için kullanılır.
            tbplaka.Clear();

            tbsigorta.Text = DateTime.Now.ToLongDateString();
            tbkilometre.Clear();
            tbkasko.Text = DateTime.Now.ToLongDateString();

            tbyil.Clear();
            cbvites.SelectedIndex = -1;
            cbdurum.SelectedIndex = -1;
            cbkasatipi.SelectedIndex = -1;
            cbmarka.SelectedIndex = -1;
            cbyakit.SelectedIndex = -1;
            tbmodel.Clear();
            tbrenk.Clear();
            tbucret.Clear();
            tbplaka.Focus();
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pbtndkaydet.Visible = pictureBox7.Visible = l1.Visible = l2.Visible = true;
            pbtnkaydet.Visible = false;

            kacincikayit = bs.Position;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Silmek İstediğinize Emin Misiniz ?", "Soru ?", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = kayıt;//command nesnesini connectiona conn ile ekledik
                cmd.CommandText = "delete from araclar where plaka=@plaka ";
                cmd.Parameters.AddWithValue("@plaka", tbplaka.Text);
                cmd.ExecuteNonQuery();//komutları çalıştırır.
                MessageBox.Show("kayıt silindi.");
                verileri_cek();
            }
        }
      
        void tekrar()
        {
            if (tbplaka.Text != tutplaka)
            {
                durum1 = false;
                if (kayıt.State == ConnectionState.Closed)
                    kayıt.Open();
                OleDbCommand cmd = new OleDbCommand("select * from araclar where plaka=@plaka", kayıt);
                cmd.Parameters.AddWithValue("@plaka", tbplaka.Text);
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
            pbtnkaydet.Visible = pictureBox7.Visible = pbtndkaydet.Visible = l1.Visible = l2.Visible = false;

            tekrar();
            if (durum1 == false)
            {
                if (durum == true)
                {
                    /*if (kayıt.State == ConnectionState.Closed)
                    kayıt.Open();*/
                    OleDbCommand guncelle = new OleDbCommand("update araclar SET plaka=@plaka,marka=@marka,model=@model,uretildigiyil=@uretildigiyil,vites=@vites,renk=@renk,sigortabitistarihi=@sigortabitistarihi,kaskotarih=@kaskotarih,kilometre=@kilometre,kasatipi=@kasatipi,yakit=@yakit,durum=@durum,gunluk_ucret=@gunluk_ucret Where plaka=@plaka1", kayıt);
                    guncelle.Connection = kayıt;
                    guncelle.Parameters.AddWithValue("@plaka", tbplaka.Text);
                    guncelle.Parameters.AddWithValue("@marka", cbmarka.Text);
                    guncelle.Parameters.AddWithValue("@model", tbmodel.Text);
                    guncelle.Parameters.AddWithValue("@uretildigiyil", tbyil.Text);
                    guncelle.Parameters.AddWithValue("@vites", cbvites.Text);
                    guncelle.Parameters.AddWithValue("@renk", tbrenk.Text);
                    guncelle.Parameters.AddWithValue("@sigortabitistarihi", tbsigorta.Text);
                    guncelle.Parameters.AddWithValue("@kaskotarih", tbkasko.Text);
                    guncelle.Parameters.AddWithValue("@kilometre", tbkilometre.Text);
                    guncelle.Parameters.AddWithValue("@kasatipi", cbkasatipi.Text);
                    guncelle.Parameters.AddWithValue("@yakit", cbyakit.Text);
                    guncelle.Parameters.AddWithValue("@durum", cbdurum.Text);
                    guncelle.Parameters.AddWithValue("@gunluk_ucret", tbucret.Text);
                    guncelle.Parameters.AddWithValue("@plaka1", tutplaka);
                    guncelle.ExecuteNonQuery();
                    MessageBox.Show("Araç  Güncellendi.");

                    verileri_cek();
                    //bs.Position = kacincikayit;
                }
                else
                {
                    MessageBox.Show("Bu Plaka Bulunmaktadır.");
                    tbplaka.Clear();
                }
            }
            else
            {

              /*  if (kayıt.State == ConnectionState.Closed) kayıt.Open();*/
                OleDbCommand guncelle = new OleDbCommand("update araclar SET marka=@marka,model=@model,uretildigiyil=@uretildigiyil,vites=@vites,renk=@renk,sigortabitistarihi=@sigortabitistarihi,kaskotarih=@kaskotarih,kilometre=@kilometre,kasatipi=@kasatipi,yakit=@yakit,durum=@durum,gunluk_ucret=@gunluk_ucret Where plaka=@plaka", kayıt);
                guncelle.Connection = kayıt;
                guncelle.Parameters.AddWithValue("@marka", cbmarka.Text);
                guncelle.Parameters.AddWithValue("@model", tbmodel.Text);
                guncelle.Parameters.AddWithValue("@uretildigiyil", tbyil.Text);
                guncelle.Parameters.AddWithValue("@vites", cbvites.Text);
                guncelle.Parameters.AddWithValue("@renk", tbrenk.Text);
                guncelle.Parameters.AddWithValue("@sigortabitistarihi", tbsigorta.Text);
                guncelle.Parameters.AddWithValue("@kaskotarih", tbkasko.Text);
                guncelle.Parameters.AddWithValue("@kilometre", tbkilometre.Text);
                guncelle.Parameters.AddWithValue("@kasatipi", cbkasatipi.Text);
                guncelle.Parameters.AddWithValue("@yakit", cbyakit.Text);
                guncelle.Parameters.AddWithValue("@durum", cbdurum.Text);
                guncelle.Parameters.AddWithValue("@gunluk_ucret", tbucret.Text);
                guncelle.Parameters.AddWithValue("@plaka", tbplaka.Text);
                guncelle.ExecuteNonQuery();
                MessageBox.Show("Araç  Güncellendi.");

                verileri_cek();
                //bs.Position = kacincikayit;

            }
           
        }

        private void pbtnkaydet_Click(object sender, EventArgs e)
        {
            pbtnkaydet.Visible = pictureBox7.Visible = pbtndkaydet.Visible = l1.Visible = l2.Visible = false;
            try
            {
                OleDbCommand ekle = new OleDbCommand("insert into araclar([plaka],[marka],[model],[uretildigiyil],[vites],[renk],[sigortabitistarihi],[kaskotarih],[kilometre],[kasatipi],[yakit],[durum],[gunluk_ucret]) Values (@tbplaka,@tbmarka,@tbmodel,@tbyil,@cbvites,@tbrenk,@tbsigorta,@tbkasko,@tbkilometre,@cbkasatipi,@tbyakit,@cbdurum,@tbucret)", kayıt);
                ekle.Connection = kayıt;
                ekle.Parameters.AddWithValue("@plaka", tbplaka.Text);
                ekle.Parameters.AddWithValue("@marka", cbmarka.Text);
                ekle.Parameters.AddWithValue("@model", tbmodel.Text);
                ekle.Parameters.AddWithValue("@uretildigiyil", tbyil.Text);
                ekle.Parameters.AddWithValue("@vites", cbvites.Text);
                ekle.Parameters.AddWithValue("@renk", tbrenk.Text);
                ekle.Parameters.AddWithValue("@sigortabitistarihi", tbsigorta.Text);
                ekle.Parameters.AddWithValue("@kaskotarih", tbkasko.Text);
                ekle.Parameters.AddWithValue("@kilometre", tbkilometre.Text);
                ekle.Parameters.AddWithValue("@kasatipi", cbkasatipi.Text);
                ekle.Parameters.AddWithValue("@yakit", cbyakit.Text);
                ekle.Parameters.AddWithValue("@durum", cbdurum.Text);
                ekle.Parameters.AddWithValue("@gunluk_ucret", tbucret.Text);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Araç  Eklendi.");
                verileri_cek();
                bs.Position = kacincikayit;
            }
            catch
            {
                MessageBox.Show("Aynı Plakaya Sahip Birden Fazla Araç Ekleyemezsiniz !!!");
            }



        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pbtnkaydet.Visible = pictureBox7.Visible = pbtndkaydet.Visible = l1.Visible = l2.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            aracraporla r = new aracraporla();
            r.Show();
            this.Hide();
        }

        private void marka_TextChanged(object sender, EventArgs e)
        {
            if (tbmarka.Checked)
            {
                string seckomutu = "select * from araclar where marka like '%" + marka.Text + "%'";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
                ds.Clear();
                da.Fill(ds, "araclar");

            }
            else if (rbplaka.Checked)
            {
                string seckomutu = "select * from araclar where plaka like '%" + marka.Text + "%'";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
                ds.Clear();
                da.Fill(ds, "araclar");



            }
            else if (rbtumkayitlar.Checked)
            {
                string seckomutu = "select * from araclar ";
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
                ds.Clear();
                da.Fill(ds, "araclar");
                marka.Clear();
            }
        }

       
        private void rbtumkayitlar_Click(object sender, EventArgs e)
        {
            if (rbtumkayitlar.Checked)
            {
                marka.Clear();
                string seckomutu = "select * from araclar  ";
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
                ds.Clear();
                da.Fill(ds, "araclar");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            tutplaka = tbplaka.Text;
        }

       
    }
}