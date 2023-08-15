namespace Bank_Management_system
{
    partial class bp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sp = new System.Windows.Forms.Panel();
            this.develop = new System.Windows.Forms.Label();
            this.loading = new System.Windows.Forms.Label();
            this.SpashPage = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sp.SuspendLayout();
            this.SuspendLayout();
            // 
            // sp
            // 
            this.sp.BackColor = System.Drawing.Color.Green;
            this.sp.Controls.Add(this.develop);
            this.sp.Controls.Add(this.loading);
            this.sp.Controls.Add(this.SpashPage);
            this.sp.Controls.Add(this.progressBar1);
            this.sp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp.Location = new System.Drawing.Point(0, 0);
            this.sp.Name = "sp";
            this.sp.Size = new System.Drawing.Size(800, 450);
            this.sp.TabIndex = 3;
            this.sp.Paint += new System.Windows.Forms.PaintEventHandler(this.sp_Paint);
            // 
            // develop
            // 
            this.develop.AutoSize = true;
            this.develop.BackColor = System.Drawing.Color.Green;
            this.develop.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.develop.ForeColor = System.Drawing.Color.White;
            this.develop.Location = new System.Drawing.Point(359, 394);
            this.develop.Name = "develop";
            this.develop.Size = new System.Drawing.Size(392, 31);
            this.develop.TabIndex = 6;
            this.develop.Text = "Developed by : Ganesh prasad M";
            // 
            // loading
            // 
            this.loading.AutoSize = true;
            this.loading.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading.ForeColor = System.Drawing.Color.Black;
            this.loading.Location = new System.Drawing.Point(297, 187);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(133, 39);
            this.loading.TabIndex = 5;
            this.loading.Text = "Loading...";
            // 
            // SpashPage
            // 
            this.SpashPage.AutoSize = true;
            this.SpashPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpashPage.ForeColor = System.Drawing.Color.White;
            this.SpashPage.Location = new System.Drawing.Point(87, 57);
            this.SpashPage.Name = "SpashPage";
            this.SpashPage.Size = new System.Drawing.Size(606, 54);
            this.SpashPage.TabIndex = 4;
            this.SpashPage.Text = "Bank Management System";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Tomato;
            this.progressBar1.Location = new System.Drawing.Point(245, 229);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(280, 26);
            this.progressBar1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "bp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.sp.ResumeLayout(false);
            this.sp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sp;
        private System.Windows.Forms.Label develop;
        private System.Windows.Forms.Label loading;
        private System.Windows.Forms.Label SpashPage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}

