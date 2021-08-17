using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arackiralama
{
    public partial class sec : Form
    {
        public sec()
        {
            InitializeComponent();
        }
        public  string gonder { get; set; }
        public string gonder3 { get; set; }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            kullanicirezervasyonislemleri kri = new kullanicirezervasyonislemleri();
            kri.gonder2 = tc1.Text;
            this.Hide();
            kri.ShowDialog();
           
        }
        string kelime;
        private void pictureBox2_Click(object sender, EventArgs e)

        {

           /* if (tc1.Text != " ")
            {
                aracara a = new aracara();
                a.gonder4 = tc1.Text;
                this.Hide();
                a.ShowDialog();
            }
            else if (tc.Text != " ")
            {*/
               
           // } 
            if (tc.Text != "")
            {
                kelime = tc.Text;
            }
            else
            {
                kelime = tc1.Text;
            }
            aracara a = new aracara();
            a.gonder4 = kelime;
            this.Hide();
            a.ShowDialog();

           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ilk i = new ilk();
            i.Show();
            this.Hide();
        }

        private void sec_Load(object sender, EventArgs e)
        {
            tc1.Text = gonder;
            tc.Text = gonder3;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
