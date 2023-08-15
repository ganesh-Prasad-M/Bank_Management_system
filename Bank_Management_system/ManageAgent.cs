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
    public partial class ManageAgent : Form
    {
        public ManageAgent()
        {
            InitializeComponent();
            displayAccount();
        }
        SqlConnection con=new SqlConnection(@"Data Source=LAPTOP-368VL7FK;Initial Catalog=Bank_M_S;Integrated Security=True");

        private void displayAccount()
        {
            con.Open();
            string query = "select * from AgentTb";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            AgDV.DataSource = ds.Tables[0];

            con.Close();
        }

        private void clear()
        {
            user.Text = "";
            pass.Text = "";
            address.Text = "";
            phone.Text = "";
            

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "" | pass.Text == "" | address.Text == "" | phone.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AgentTb (Aname,Apass,Aaddress,Aphone) values(@AN,@AP,@AA,@APH) ", con);
                    cmd.Parameters.AddWithValue("@AN", user.Text);
                    cmd.Parameters.AddWithValue("@AP", pass.Text);
                    cmd.Parameters.AddWithValue("@AA", address.Text);
                    cmd.Parameters.AddWithValue("@APH", phone.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Created!!");
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
            if (user.Text == "" | pass.Text == "" | address.Text == "" | phone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update AgentTb set Aname=@AN,Apass=@AP,Aaddress=@AA,Aphone=@APH  where Aid=@AcKey", con);
                    cmd.Parameters.AddWithValue("@AN", user.Text);
                    cmd.Parameters.AddWithValue("@AP", pass.Text);
                    cmd.Parameters.AddWithValue("@AA", address.Text);
                    cmd.Parameters.AddWithValue("@APH", phone.Text);
                    cmd.Parameters.AddWithValue("@AcKey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Updated");
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
                    SqlCommand cmd = new SqlCommand("delete from AgentTb where Aid=@AcKey", con);
                    cmd.Parameters.AddWithValue("@AcKey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Deleted!!");
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

        private void AgDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            user.Text = AgDV.SelectedRows[0].Cells[0].Value.ToString();
            pass.Text = AgDV.SelectedRows[0].Cells[1].Value.ToString();
            address.Text = AgDV.SelectedRows[0].Cells[2].Value.ToString();
            phone.Text = AgDV.SelectedRows[0].Cells[3].Value.ToString();
            

            if (user.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AgDV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
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
}
