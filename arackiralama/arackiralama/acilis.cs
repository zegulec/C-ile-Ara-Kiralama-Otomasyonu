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
    public partial class acilis : Form
    {
        public acilis()
        {
            InitializeComponent();
        }


        private void acilis_Activated(object sender, EventArgs e)
        {
            
  
            progressBar1.Maximum = 400;
            for ( int i = 0; i <= 400; i+=10)
            {
                System.Threading.Thread.Sleep(40);
                panel1.Left = i;
                progressBar1.Value = i;
            }
                ilk ik = new ilk();
                ik.Show();
                this.Hide();




        }
        private void acilis_Load(object sender, EventArgs e)
        {
           
      
          
        }
       }
    }

