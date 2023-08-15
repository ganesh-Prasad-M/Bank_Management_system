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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-368VL7FK;Initial Catalog=Bank_M_S;Integrated Security=True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(LRole.SelectedIndex == -1)
            {
                MessageBox.Show(" Select the Role");
            }
            else if(LRole.SelectedIndex == 0)
            {
                if(Luser.Text ==""|Lpass.Text == "")
                {
                    MessageBox.Show("Please enter the both username and password");
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-368VL7FK;Initial Catalog=Bank_M_S;Integrated Security=True");

                    con.Open();
                    string query = "select count(*) from AdminTb where Adname='"+Luser.Text+"' and adpass='"+Lpass.Text+"' ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt=new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        ManageAgent ag = new ManageAgent();
                        ag.Show();
                        this.Hide();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("wrong username or password ");
                        Luser.Text = "";
                        Lpass.Text = "";
                    }

                    con.Close();

                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //LRole.SelectedItem = "";
            LRole.SelectedIndex = -1;
            LRole.Text = "Role";
            Luser.Text = "";
            Lpass.Text = "";
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if(this.WindowState!=FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else { this.WindowState = FormWindowState.Normal; }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState=FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
