using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JuiceBoostAzuRain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTNExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\NurAzuren\Documents\Logindb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True;");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Count (*) FROM Login WHERE id='" + TBId.Text + "' and password = '" + TBPass.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()== "1")
            {
                this.Hide();
                Menu frmMenu = new Menu();
                frmMenu.staffid = TBId.Text;
                frmMenu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please check your ID and Password");
            }

        }

    }
}
