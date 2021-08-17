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
    public partial class yetkili : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "//rentacar.mdb");
       
        public yetkili()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ilk ik = new ilk();
            ik.Show();
            this.Hide();
        }

        private void btnkaydol_Click(object sender, EventArgs e)
        {
            yetkilikayit yk = new yetkilikayit();
            yk.Show();
            this.Hide();
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

        private void tbsf_Enter(object sender, EventArgs e)
        {
            if (tbtc.Text.Length < 11)
            {
                MessageBox.Show("11 haneli Tc Kimlik Numarasını Giriniz !!!");
                tbtc.Focus();
            }
        }

        private void tbtc_TextChanged(object sender, EventArgs e)
        {
            if (tbtc.Text.Length > 11)
            {
                MessageBox.Show("11 haneli Tc Kimlik Numarasını Giriniz !!!");
            }
        }

        private void tbsf_TextChanged(object sender, EventArgs e)
        {
            tbsf.PasswordChar = '*';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (tbtc.Text == "" && tbsf.Text == "")
            {
                MessageBox.Show("Lütfen Giriş Bilgilerini Yazın!");
            }
            else if (tbtc.Text == "")
            {
                MessageBox.Show("Kullanıcı Adını Giriniz.");
            }
            else if (tbsf.Text == "")
            {
                MessageBox.Show("Şifrenizi Giriniz.");
            }
            else
            {


                conn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from yetkili where yno='" + tbtc.Text.ToString() + "'", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    if (tbtc.Text.ToString() == dr["yno"].ToString() && tbsf.Text.ToString() == dr["sifre"].ToString())
                    {

                        yetkiislem yi = new yetkiislem();
                        yi.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tc Kmlik No veya şifre yanlıştır.");
                        tbtc.Clear(); tbsf.Clear();
                    }
                }

                else
                {
                    MessageBox.Show("Tc Kimlik No  veya şifre yanlıştır.");
                    tbtc.Clear(); tbsf.Clear();
                }
                conn.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            yetkilikayit yk = new yetkilikayit();
            yk.Show();
            this.Hide();
        }
    }
}
