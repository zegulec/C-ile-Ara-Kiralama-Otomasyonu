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
    public partial class yetkiislem : Form
    {
        public yetkiislem()
        {
            InitializeComponent();
        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            arackayit ak = new arackayit();
            ak.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            rezerve r = new rezerve();
            r.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            kullaniciislemleri ki = new kullaniciislemleri();
            ki.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ilk i = new ilk();
            i.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
