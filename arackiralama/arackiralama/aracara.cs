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
    public partial class aracara : Form
    {   
        OleDbConnection kayıt = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\rentacar.mdb"); // yeni bir veri tabanına bağlanma 
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public aracara()
        {
            InitializeComponent();
        }
        public string gonder4 { get; set; }
        private void aracara_Load(object sender, EventArgs e)
        {
            if (kayıt.State == ConnectionState.Closed)
                kayıt.Open();//eğer connection kapalıysa aç demek connection bağlı olup olmadığını kontrol edicek kapalıysa acçıcak.
                verileri_cek();
                bs.DataSource = ds.Tables["araclar"];//BindingSource'un veri kaynağı datasetin bolumler tablosu olsun.
                dataGridView1.DataSource = bs; //BindingSource ile forma arasındaki bağlantı sağlandı.
                tc3.Text = gonder4;
        } 
        void verileri_cek()
        {
            string sec = "select * from araclar where durum='Kiralık'"; // bolumler tablosundaki bütüm kayıtları seç.
            OleDbDataAdapter da = new OleDbDataAdapter(sec, kayıt); // yeni bir adaptör tanımladık. veri çektik.
            ds.Clear();
            da.Fill(ds, "araclar"); // datasetin bolumler tablosuna doldursun.
        }
       
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if (checkBox1.Checked == false)
            {
                string seckomutu = "select * from araclar where marka like '%"+aranan.Text +"%'";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
                ds.Clear();
                da.Fill(ds, "araclar");
            }
        }
      private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                aranan.Clear();
                string seckomutu = "select * from araclar where durum='Kiralık' ";  // %= aranan kelimenin herhangi bir yerinde gecmesini sağlıyor.
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, kayıt);
                ds.Clear();
                da.Fill(ds, "araclar");
            }
        }
       


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            aranan.Clear();
            aranan.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            kirala kira = new kirala();
            kira.gonder5=tc3.Text;
            this.Hide();
            kira.ShowDialog();
            
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

      

     
    }
}
