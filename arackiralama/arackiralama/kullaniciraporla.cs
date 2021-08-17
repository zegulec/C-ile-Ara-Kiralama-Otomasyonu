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
    public partial class kullaniciraporla : Form
    {
        public kullaniciraporla()
        {
            InitializeComponent();
        }

        private void kullaniciraporla_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.kullanicilar' table. You can move, or remove it, as needed.
            ReportDataSource rsd = new ReportDataSource("DataSet1", kullaniciislemleri.ds.Tables["kullanicilar"]);//veriyi alacağı kaynağı değiştiriyoruz dataset1 form3deki genel tablodan alsın veriyi
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rsd);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport(); 
        }
    }
}
