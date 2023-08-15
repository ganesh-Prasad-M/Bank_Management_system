using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bank_Management_system
{
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-368VL7FK;Initial Catalog=Bank_M_S;Integrated Security=True");

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        int Balance;
        private void checkBalance()
        {
            con.Open();
            string query = "select * from AccountTb where Acnum= '" +checkBal.Text + "' ";
            SqlCommand cmd = new SqlCommand(query,con);
            DataTable dt=new DataTable();
            SqlDataAdapter sda=new SqlDataAdapter(cmd); 
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Balanceb.Text = "RS : "+dr["Acbal"].ToString();
                Balance = Convert.ToInt32(dr["Acbal"].ToString());
            }
            con.Close();

        }

        private void checkAvailableBalance()
        {
            //con.Open();
            string query = "select * from AccountTb where Acnum= '" + from.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                amtL.Text = "RS : " + dr["Acbal"].ToString();
                Balance = Convert.ToInt32(dr["Acbal"].ToString());
            }
            //con.Close();

        }

        private void GetNewBalance()
        {
            try
            {
                con.Open();
                //  string query = "select * from AccountTb where Acbal" + checkBal.Text + "";
                string query = "select * from AccountTb where Acnum = '" + checkBal.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sdaa = new SqlDataAdapter(cmd);
                sdaa.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    //Balanceb.Text = "RS" + dr["Acbal"].ToString();
                    Balance = Convert.ToInt32(dr["Acbal"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void CheckB_Click(object sender, EventArgs e)
        {
            if (checkBal.Text == "")
            {
                MessageBox.Show("Please Enter the A/C No ");
            }
            else
            {
                checkBalance();

                if(Balanceb.Text == "Your Balance")
                {
                    MessageBox.Show("Account not found");
                    Balanceb.Text = "";
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Withdraw()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into TransactionTb (Tname,Tamt,Tacnum,Tdtate) values(@TN,@TAMT,@TAC,@TD) ", con);
                //cmd.Parameters.AddWithValue("@TI",0);
                cmd.Parameters.AddWithValue("@TN", "Withdrwan");
                cmd.Parameters.AddWithValue("@TAMT", wamt.Text);
                cmd.Parameters.AddWithValue("@TAC", wac.Text);

                cmd.Parameters.AddWithValue("@TD", DateTime.Now.Date);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void withdrawB_Click(object sender, EventArgs e)
        {
            if (wac.Text == "" | wamt.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Withdraw();
                GetNewBalance();
                if (Balance < Convert.ToInt32(wamt.Text))
                {
                    MessageBox.Show("Insufisiant Balance ");
                }
                else
                {
                    int newBal = Balance - Convert.ToInt32(wamt.Text);

                    try
                    {

                        con.Open();
                        SqlCommand cmd = new SqlCommand("update AccountTb set Acbal=@AB where Acnum=@AcKey", con);
                        cmd.Parameters.AddWithValue("@AB", newBal);
                        cmd.Parameters.AddWithValue("@AcKey", wac.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Money Withdrawan  !!!!");
                        con.Close();
                        //clear();
                        //displayAccount();
                        wac.Text = "";
                        wamt.Text = "";

                        Balanceb.Text = "Your Balance";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Deposit()
        {
                try
                {
                 con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TransactionTb (Tname,Tamt,Tacnum,Tdtate) values(@TN,@TAMT,@TAC,@TD) ", con);
                cmd.Parameters.AddWithValue("@TN", "DEPOSIT");
                cmd.Parameters.AddWithValue("@TAMT", damt.Text);
                cmd.Parameters.AddWithValue("@TAC", dac.Text);

                cmd.Parameters.AddWithValue("@TD",DateTime.Now.Date);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {

                MessageBox.Show(ex.Message);
                con.Close();
                  }
         }

        private void subtractbal()
        {
            int p = Convert.ToInt32(from.Text);
            GetNewBalance();
            int newBal = Balance + Convert.ToInt32(amountT.Text);
            Deposit();
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("update AccountTb set Acbal=@AB where Acnum=@AcKey", con);
                cmd.Parameters.AddWithValue("@AB", newBal);
                cmd.Parameters.AddWithValue("@AcKey", from.Text);

                cmd.ExecuteNonQuery();
               // MessageBox.Show(" Money Deposited ");
                con.Close();
                //clear();
                //displayAccount();
               // dac.Text = "";
               // damt.Text = "";
               // Balanceb.Text = "Your Balance";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addball()
        {
            string query = "select * from AccountTb where Acnum = '" + checkBal.Text + "' ";
            SqlCommand cmdd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sdaa = new SqlDataAdapter(cmdd);
            sdaa.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                //Balanceb.Text = "RS" + dr["Acbal"].ToString();
                Balance = Convert.ToInt32(dr["Acbal"].ToString());
            }
            //GetNewBalance(to.Text);
            int newBal = Balance + Convert.ToInt32(amountT.Text);
            Deposit();
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("update AccountTb set Acbal=@AB where Acnum=@AcKey", con);
                cmd.Parameters.AddWithValue("@AB", newBal);
                cmd.Parameters.AddWithValue("@AcKey", to.Text);

                cmd.ExecuteNonQuery();
                // MessageBox.Show(" Money Deposited ");
                con.Close();
                //clear();
                //displayAccount();
                // dac.Text = "";
                // damt.Text = "";
                // Balanceb.Text = "Your Balance";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void depositB_Click(object sender, EventArgs e)
        {
            if (dac.Text == "" | damt.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                GetNewBalance();
                int newBal=Balance + Convert.ToInt32(damt.Text);
                Deposit();
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update AccountTb set Acbal=@AB where Acnum=@AcKey", con);
                    cmd.Parameters.AddWithValue("@AB", newBal);
                    cmd.Parameters.AddWithValue("@AcKey", dac.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Money Deposited ");
                    con.Close();
                    //clear();
                    //displayAccount();
                    dac.Text = "";
                    damt.Text = "";
                    Balanceb.Text = "Your Balance";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void TranferMethod()
        {
            try
            {
                con.Open();
                //SqlConnection con = new SqlConnection(@"d");
                string query = "insert into TransferTb (Trsc,Trdest,Tamt,Trdate)values(@TS,@TD,@TA,@TD)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TS", from.Text);

                cmd.Parameters.AddWithValue("@TD", to.Text);

                cmd.Parameters.AddWithValue("@TA", amountT.Text);

                cmd.Parameters.AddWithValue("@TD", DateTime.Now.Date);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Money Transfered ");
                con.Close();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
                if (from.Text == "" )
                {
                    MessageBox.Show("Enter the source account");
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-368VL7FK;Initial Catalog=Bank_M_S;Integrated Security=True");

                    con.Open();
                    string query = "select count(*) from AccountTb where Acnum='" + from.Text + "'  ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    
                if (dt.Rows[0][0].ToString() == "1")
                    {
                    //amtL.Text = "Rs";

                      checkAvailableBalance();
                      con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Account Does not Exit ");
                        from.Text = "";
                    }

                    con.Close();
                }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (to.Text == "")
            {
                MessageBox.Show("Enter the transfer account number");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-368VL7FK;Initial Catalog=Bank_M_S;Integrated Security=True");

                con.Open();
                string query = "select count(*) from AccountTb where Acnum='" + to.Text + "'  ";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    //amtL.Text = "Rs";
                    //checkAvailableBalance();
                    //to.Text =;
                    MessageBox.Show("Account Found");
                    con.Close();
                    if(to.Text ==from.Text)
                    {
                        MessageBox.Show("source and destination accounts are same");
                        to.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Account Does not Exit ");
                    to.Text = "";
                }

                con.Close();
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MainMenu mm=new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else { this.WindowState = FormWindowState.Normal; }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void transferB_Click(object sender, EventArgs e)
        {
            if (from.Text == "" || to.Text == "" || amountT.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if (Convert.ToInt16(amountT.Text) > Balance)
            {
                MessageBox.Show("Insufficient Balance");
            }
            else
            {
                //TransferMethod
                TranferMethod();
                subtractbal();
                addball();

                amountT.Text = "";

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
