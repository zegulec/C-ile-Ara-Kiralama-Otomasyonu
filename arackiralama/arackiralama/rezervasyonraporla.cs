using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace arackiralama
{
    public partial class rezervasyonraporla : Form
    {
        public rezervasyonraporla()
        {
            InitializeComponent();
        }

        private void rezervasyonraporla_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet3.kirala' table. You can move, or remove it, as needed.
            ReportDataSource rsd = new ReportDataSource("DataSet1", rezerve.ds.Tables["kirala"]);//veriyi alacağı kaynağı değiştiriyoruz dataset1 form3deki genel tablodan alsın veriyi
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rsd);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport(); 
        }
    }
}
