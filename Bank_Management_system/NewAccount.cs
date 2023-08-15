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
    public partial class NewAccount : Form
    {
        public NewAccount()
        {
            InitializeComponent();
            displayAccount();
        }

        
        SqlConnection con=new SqlConnection(@"Data Source=LAPTOP-368VL7FK;Initial Catalog=Bank_M_S;Integrated Security=True");

        private void displayAccount()
        {
            con.Open();
            string query = "select * from AccountTb";
            SqlDataAdapter adapter = new SqlDataAdapter(query,con);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            var ds=new DataSet();
            adapter.Fill(ds);
            AgDV.DataSource=ds.Tables[0];

            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clear()
        {
            acNUM.Text = "";
            Accname.Text = "";
            Accphone.Text = "";
            Accaddress.Text = "";
            occupation.Text = "";
            education.Text = "";
            gender.Text = "";
            income.Text = "";
            balance.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Accname.Text ==""|Accphone.Text ==""|Accaddress.Text ==""|occupation.Text ==""|education.Text ==""|gender.Text==""|income.Text == ""|balance.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try { 

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AccountTb (Acnum,Acname,Acphone,Acaddress,Acgender,Acoccuption,Aceduc,Acinc,Acbal) values(@ACN,@AN,@AP,@AA,@AO,@AE,@AG,@AI,@AB) ", con);
                    cmd.Parameters.AddWithValue("@ACN", acNUM.Text);
                    cmd.Parameters.AddWithValue("@AN",Accname.Text);
                    cmd.Parameters.AddWithValue("@AP", Accphone.Text);
                    cmd.Parameters.AddWithValue("@AA", Accaddress.Text);
                    cmd.Parameters.AddWithValue("@AO", occupation.Text);
                    cmd.Parameters.AddWithValue("@AE", education.Text);

                    cmd.Parameters.AddWithValue("@AG", gender.SelectedText.ToString());
                    cmd.Parameters.AddWithValue("@AI", income.Text);
                    cmd.Parameters.AddWithValue("@AB", balance.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created!!");
                    con.Close();
                    clear();
                    displayAccount();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }            }


        }


        private void AgDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Acnum.Text=

            //acNUM.Text = AgDV.SelectedRows[0].Cells[0].Value.ToString();
            Accname.Text=AgDV.SelectedRows[0].Cells[0].Value.ToString();
            Accphone.Text = AgDV.SelectedRows[0].Cells[1].Value.ToString();
            Accaddress.Text = AgDV.SelectedRows[0].Cells[2].Value.ToString();
            occupation.Text = AgDV.SelectedRows[0].Cells[3].Value.ToString();
            education.Text = AgDV.SelectedRows[0].Cells[4].Value.ToString();
            gender.Text = AgDV.SelectedRows[0].Cells[5].Value.ToString();
            income.Text = AgDV.SelectedRows[0].Cells[6].Value.ToString();
            balance.Text = AgDV.SelectedRows[0].Cells[7].Value.ToString();

            if(Accname.Text=="")
            {
                key = 0;
            }
            else
            {
                key=Convert.ToInt32(AgDV.SelectedRows[0].Cells[0].Value.ToString());
            }


        }
        int key = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Account");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from AccountTb where Accnum=@AcKey",con);
                    cmd.Parameters.AddWithValue("@AcKey", key);
                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Deleted!!");
                    con.Close();
                    clear();
                    displayAccount();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Accname.Text == "" | Accphone.Text == "" | Accaddress.Text == "" | occupation.Text == "" | education.Text == "" | gender.Text == "" | income.Text == "" | balance.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update AccountTb set Accname=@AN,Accphone=@AP,Accaddress=@AA,occupation=@AO,education=@AE,gender=@AG,income=@AI,Acbal=@AB where AcNum=@AcKey", con);
                    cmd.Parameters.AddWithValue("@AN", Accname.Text);
                    cmd.Parameters.AddWithValue("@AP", Accphone.Text);
                    cmd.Parameters.AddWithValue("@AA", Accaddress.Text);
                    cmd.Parameters.AddWithValue("@AO", occupation.Text);
                    cmd.Parameters.AddWithValue("@AE", education.Text);

                    cmd.Parameters.AddWithValue("@AG", gender.SelectedText.ToString());
                    cmd.Parameters.AddWithValue("@AI", income.Text);

                    cmd.Parameters.AddWithValue("@AB", 0);
                    cmd.Parameters.AddWithValue("@AcKey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Updated");
                    con.Close();
                    clear();
                    displayAccount();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MainMenu mm=new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void balance_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else { this.WindowState = FormWindowState.Normal; }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
    }

    //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    //{


  
}
