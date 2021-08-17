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
    public partial class aracraporla : Form
    {
        public aracraporla()
        {
            InitializeComponent();
        }

        private void aracraporla_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.araclar' table. You can move, or remove it, as needed.
            ReportDataSource rsd = new ReportDataSource("DataSet1", arackayit.ds.Tables["araclar"]);//veriyi alacağı kaynağı değiştiriyoruz dataset1 form3deki genel tablodan alsın veriyi
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rsd);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport(); 
        }
    }
}
