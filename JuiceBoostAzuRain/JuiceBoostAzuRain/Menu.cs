using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;



namespace JuiceBoostAzuRain
{
    public partial class Menu : Form
    {
        double finalTotal;
        
        public string staffid;

        public string PassingId {

            get 
            {
                return staffid;
            }

            set 
            {
                staffid = value;
            }
        }
        int tal;
        
        public Menu()
        {
            InitializeComponent();
            
            MenuList.View = View.Details;
            MenuList.FullRowSelect = true;

            MenuList.Columns.Add("Name", 200);
            MenuList.Columns.Add("Price", 50);
           
           
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            Random slumpGenerator = new Random();
            tal = slumpGenerator.Next(0, 100);
            LabelSalesID.Text = tal.ToString();
            LblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            LabelWelcome.Text = staffid;
   
        }

        private void add(String name, String price)
        {
            String[] row = { name, price };
            ListViewItem item = new ListViewItem(row);
            MenuList.Items.Add(item);
        }


        private void BTNLycheeParadise_Click(object sender, EventArgs e)
        {
            add("Lychee Paradise", "10.90");

        }

        private void BTNRedDragon_Click(object sender, EventArgs e)
        {
            add("Red Dragon", "11.85");
        }

        private void BTNMangoSensation_Click(object sender, EventArgs e)
        {
            add("Mango Sensation", "11.85");
        }

        private void BTNJumpingJack_Click(object sender, EventArgs e)
        {
            add("Jumping Jack", "12.90");
        }

        private void BTNMelonDrops_Click(object sender, EventArgs e)
        {
            add("Melon Drops", "9.90");
        }

        private void BTNCranberry_Click(object sender, EventArgs e)
        {
            add("Cranberry Sparkle", "8.90");
        }

        private void BTNPinkPassion_Click(object sender, EventArgs e)
        {
            add("Pink Passion", "10.80");
        }

        private void BTNKiwiDream_Click(object sender, EventArgs e)
        {
            add("Kiwi Dream", "11.85");
        }

        private void BTNApricot_Click(object sender, EventArgs e)
        {
            add("Apricot Delight", "12.90");
        }

        private void BTNWaterBerry_Click(object sender, EventArgs e)
        {
            add("Water Berry", "9.90");
        }

        private void BTNZestyMelon_Click(object sender, EventArgs e)
        {
            add("Zesty Melon", "8.90");
        }

        private void BTNRainbowCrush_Click(object sender, EventArgs e)
        {
            add("Rainbow Crush", "10.90");
        }

        private void BTNTropicalKiss_Click(object sender, EventArgs e)
        {
            add("Tropical Kiss", "11.85");
        }

        private void BTNDragonTales_Click(object sender, EventArgs e)
        {
            add("Dragon Tales", "11.85");
        }

        private void BTNWaterWorks_Click(object sender, EventArgs e)
        {
            add("Water Works", "8.90");
        }

        private void BTNStarAppeal_Click(object sender, EventArgs e)
        {
            add("Star Appeal", "9.90");
        }

        private void BTNSmoothOperator_Click(object sender, EventArgs e)
        {
            add("Smooth Operator", "9.90");
        }

        private void BTNTummyCalmer_Click(object sender, EventArgs e)
        {
            add("Tummy Calmer", "11.00");
        }

        private void BTNSuperAce_Click(object sender, EventArgs e)
        {
            add("Super Ace", "11.85");
        }

        private void BTNWakeMeUp_Click(object sender, EventArgs e)
        {
            add("Wake Me Up", "13.70");
        }
        private void BTNAddProduct_Click(object sender, EventArgs e)
        {
            int x = 4;
            int y = TropicalTab.Controls.Count * 28;
            Button newButton = new Button();
            newButton.BackColor = Color.LightGray;
            newButton.Font = new Font("Franklin Gothic Book", 9.5f); ;
            newButton.Height = 60;
            newButton.Width = 115;
            newButton.Location = new Point(x, y);
            newButton.Text = (TBName.Text + "    "+"RM" + TBPrice.Text);
            newButton.Click += new
            System.EventHandler(Button_Click);
           

            if (TropicalTab == MenuTab.SelectedTab)
            {
                MenuTab.TabPages[0].Controls.Add(newButton);
            }
            else if (BerryTab == MenuTab.SelectedTab)
            {
                MenuTab.TabPages[1].Controls.Add(newButton);
            }
            else if (FruitTab == MenuTab.SelectedTab)
            {
                MenuTab.TabPages[2].Controls.Add(newButton);
            }
            else
            {
                MenuTab.TabPages[3].Controls.Add(newButton);
            }

        }
        public void Button_Click(object sender, EventArgs e)
        {

            add(TBName.Text, TBPrice.Text);

        }

        private void BTNTotal_Click(object sender, EventArgs e)
        {
            double total = 0;
            double gst = 0;
            
            

                foreach (ListViewItem item in MenuList.Items)
                {
                    total += double.Parse((string)item.SubItems[1].Text);
                    gst = 0.06 * total;
                    gst = Math.Round(gst / 0.05) * 0.05;
                    finalTotal = total + gst;
                }

            LblTotal.Text = finalTotal.ToString("C");
            LblGST.Text = gst.ToString("C");
            
        }

        private void BTNDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in MenuList.SelectedItems)
            {
                MenuList.Items.Remove(eachItem);
            }
        }

        private void BTNCalculate_Click(object sender, EventArgs e)
        {

            double Pay = double.Parse(TBPay.Text);
          
                
                double Change = Pay - finalTotal;
                Change = Math.Round(Change / 0.05) * 0.05;


                MessageBox.Show("Balance: RM " + Change.ToString("0.00"), "Payment", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
           

        }

        private void BTNNeworder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Proceed to make new order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MenuList.Items.Clear();
                LblTotal.Text = "RM ";
                TBPay.Text = "";
                TBExtra.Text = "";
                LblGST.Text = "";
                Random slumpGenerator = new Random();
                int tal = slumpGenerator.Next(0, 100);
                LabelSalesID.Text = tal.ToString();

            }
            else
            {
            }
        }

        private void BTNExtra_Click(object sender, EventArgs e)
        {
            add(TBExtra.Text, TBSurcharge.Text);
            
            TBSurcharge.Text = "";
            TBExtra.Text = "";
        }

        private void BTNPrint_Click(object sender, EventArgs e)
        {
            double Pay = double.Parse(TBPay.Text);
            for (int i = 0; i < MenuList.Items.Count; i++)

            {
                string custmenu = (MenuList.Items[i].SubItems[0].Text);
                //string custmenu2 = (MenuList.Items[i].SubItems[1].Text);
                SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;
                                                    AttachDBFilename=|DataDirectory|\Sales.mdf;
                                                    Integrated Security=True; User Instance = True");

                //creating sql string
                //string sqlInsert = "INSERT INTO TBLTrans VALUES (" + "'" + Convert.ToChar(staffid) + "'," + "'" + custmenu + "'," + "'" + float.Parse(LblTotal.Text) + "'," + "'" + float.Parse(TBPay.Text) + "')";

                string sqlInsert = "INSERT INTO TBLTrans VALUES (@SalesID, @Staffid, @CustMenu, @TotalPrice, @CustPay)";

                SqlCommand cmd = new SqlCommand(sqlInsert, conn);

                cmd.Parameters.Add("@SalesID", SqlDbType.Char).Value = tal;
                cmd.Parameters.Add("@Staffid", SqlDbType.Char).Value = staffid;
                cmd.Parameters.Add("@CustMenu", SqlDbType.VarChar).Value = custmenu;
                cmd.Parameters.Add("@TotalPrice", SqlDbType.Float).Value = finalTotal;
                cmd.Parameters.Add("@CustPay", SqlDbType.Float).Value = Pay;

                

                try
                {
                    conn.Open();
                    //untuk insert, update and deleted
                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "Exception Details");
                }
                finally
                {
                    conn.Close();

                }

                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument;

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt);

                DialogResult result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    printDocument.Print();

                }


            }
        }
        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string GST = LblGST.Text;
            double Pay = double.Parse(TBPay.Text);
            double change = 0.00;

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); 

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startz = 300;
            int startY = 150;
            int offset = 40;

            string tarikhPayment = LblDate.Text;
            string waktuPayment = lblTime.Text;
            string salesid = LabelSalesID.Text;

            
            graphic.DrawString(" Juice Work ", new Font("Courier New", 12), new SolidBrush(Color.Black), 130, 10);
            graphic.DrawString(" LG-25, (Kiosk), 1018, Jalan Sultan Ismail", new Font("Courier New", 12), new SolidBrush(Color.Black), startX, 25);
            graphic.DrawString(" 50250 Kuala Lumpur ", new Font("Courier New", 12), new SolidBrush(Color.Black), 100, 40);
            graphic.DrawString(" (603) 7710 5654", new Font("Courier New", 12), new SolidBrush(Color.Black), 100, 55);
            graphic.DrawString(" Nicksy F&B Sdn. Bhd (1138321 - V)", new Font("Courier New", 12), new SolidBrush(Color.Black), 20, 70);
            string top = "Item Name".PadRight(30) + "Price";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, 50 + offset);
            graphic.DrawString(tarikhPayment, new Font("Courier New", 12), new SolidBrush(Color.Black), startX, 120);
            graphic.DrawString("Sales ID: ".PadRight(1) + String.Format("{0:c}", salesid), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX + 200, 120);
           // graphic.DrawString(salesid, new Font("Courier New", 12), new SolidBrush(Color.Black), startX+200, 120);
            graphic.DrawString(waktuPayment, new Font("Courier New", 12), new SolidBrush(Color.Black), startX, 140);

            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, 100 + offset);
            offset = offset + (int)fontHeight + 5;

            double totalprice = 0.00;
            
            foreach (ListViewItem item in MenuList.Items)
            {
                
                string productDescription = item.SubItems[0].Text;
                string productPrice = item.SubItems[1].Text;
                string productTotal = LblTotal.Text;
                totalprice = finalTotal;
                
                

                if (productDescription.Contains("-"))
                {
                   

                    graphic.DrawString(productDescription, new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5;
                    graphic.DrawString(productPrice, new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Black), startz, 126 + offset);
                    offset = offset + (int)fontHeight + 5; 
                }
                else
                {

                    string productLine = productDescription;
                    graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5;

                    graphic.DrawString(productPrice, font, new SolidBrush(Color.Black), startz, 130 + offset);
                    offset = offset + (int)fontHeight + 5;
                }
           }
            
            

            change = (Pay - totalprice);

            offset = offset + 20;
            graphic.DrawString("GST ".PadRight(30) + String.Format("{0:c}", GST), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY-20 + offset);
            graphic.DrawString("Total to pay ".PadRight(30) + String.Format("{0:c}", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 30; 
            graphic.DrawString("CASH ".PadRight(30) + String.Format("{0:c}",Pay), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("Change ".PadRight(30) + String.Format("{0:c}", change), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 30; 
            graphic.DrawString("            Thank you", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("       Please Come Again", font, new SolidBrush(Color.Black), startX, startY + offset);

        }

        private void BTNLogout_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void BTNReport_Click(object sender, EventArgs e)
        {
            Report frmReport = new Report();
            frmReport.Show();
        }



        }

    }
