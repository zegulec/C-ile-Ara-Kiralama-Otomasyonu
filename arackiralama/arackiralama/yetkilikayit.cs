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
    public partial class yetkilikayit : Form
    {
        public yetkilikayit()
        {
            InitializeComponent();
        }
        OleDbConnection kayıt = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\rentacar.mdb"); // yeni bir veri tabanına bağlanma 
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        private void verileri_cek()
        {
            string sec = "select * from yetkili"; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "yetkili"); // datasetin bolumler tablosuna doldursun.
        }
        private void yetkilikayit_Load(object sender, EventArgs e)
        {
            if (kayıt.State == ConnectionState.Closed) kayıt.Open();//eğer connection kapalıysa aç demek connection bağlı olup olmadığını kontrol edicek kapalıysa acçıcak.
            verileri_cek();
            bs.DataSource = ds.Tables["yetkili"];//BindingSource'un veri kaynağı datasetin bolumler tablosu olsun.
            tbno.DataBindings.Add("Text", bs, "yno"); 
            tbadi.DataBindings.Add("Text", bs, "adi"); //tbadinın text özelliğini databağlantısı BindingSource un badi alanına bağla 
            tbsoyadi.DataBindings.Add("Text", bs, "soyadi");
            tbka.DataBindings.Add("Text", bs, "ka"); //tbadinın text özelliğini databağlantısı BindingSource un badi alanına bağla 
            tbsf.DataBindings.Add("Text", bs, "sifre");
            tbmail.DataBindings.Add("Text", bs, "mail");
            tbtelefon.DataBindings.Add("Text", bs, "telefon"); //tbadinın text özelliğini databağlantısı BindingSource un badi alanına bağla 
            tbno.Clear();
            tbadi.Clear();
            tbka.Clear();
            tbsf.Clear();
            tbsoyadi.Clear();
            tbtelefon.Clear();
            tbmail.Clear();
            tbno.Focus();
        } 
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            yetkili y = new yetkili();
            y.Show();
            this.Hide();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {   
            tbno.Clear();
            tbadi.Clear();
            tbka.Clear();
            tbsf.Clear();
            tbsoyadi.Clear();
            tbtelefon.Clear();
            tbmail.Clear();
            tbno.Focus();
        }
       //  OleDbConnection kayıt = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=rentacar.mdb"); // kayıt eklemek için kullandım
        private void pictureBox2_Click(object sender, EventArgs e)
        {   
        
            try
            {
                OleDbCommand ekle = new OleDbCommand("INSERT INTO yetkili([yno],[adi],[soyadi],[ka],[sifre],[mail],[telefon])Values (@tbno,@tbadi,@tbsoyadi,@tbka,@tbsf,@tbmail,@tbtelefon)", kayıt);
                ekle.Connection = kayıt;
                ekle.Parameters.AddWithValue("@yno", tbno.Text);
                ekle.Parameters.AddWithValue("@adi", tbadi.Text);
                ekle.Parameters.AddWithValue("@soyadi", tbsoyadi.Text);
                ekle.Parameters.AddWithValue("@ka", tbka.Text);
                ekle.Parameters.AddWithValue("@sifre", tbsf.Text);
                ekle.Parameters.AddWithValue("@mail", tbmail.Text);
                ekle.Parameters.AddWithValue("@telefon", tbtelefon.Text);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Yetkili Eklendi");
                kayıt.Close();
                yetkili y = new yetkili();
                y.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Tc Kimlik Numarasını Kontrol Ediniz !!!");
            }
        }
       
       

        private void tbno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbno_TextChanged(object sender, EventArgs e)
        {
            if (tbno.Text.Length > 11)
            {
                MessageBox.Show("Doğru Girdiğinize Emin Olun !!!");
            }
        }

        private void tbka_Enter(object sender, EventArgs e)
        {
            if (tbno.Text.Length < 11)
            {
                MessageBox.Show("TC'yi  Doğru Girdiğinize Emin Olun !!!");
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            ilk i = new ilk();
            i.Show();
            this.Hide();
        }

        private void tbka_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
