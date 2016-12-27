using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JuiceBoostAzuRain
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.TBLTrans' table. You can move, or remove it, as needed.
            this.TBLTransTableAdapter.Fill(this.DataSet1.TBLTrans);

            this.reportViewer1.RefreshReport();
        }
    }
}
