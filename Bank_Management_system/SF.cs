using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Management_system
{
    public partial class bp : Form
    {
        public bp()
        {
            InitializeComponent();
        }

        int startp = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startp += 1;
            progressBar1.Value = startp;
            if(progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
               timer1.Stop();
                login obj=new login();
                obj.Show();
                this.Hide();
            }

        }

private void sp_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }
    }
}
