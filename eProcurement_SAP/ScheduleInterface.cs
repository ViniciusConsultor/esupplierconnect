using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eProcurement_BLL.UserManagement;
using eProcurement_BLL;

namespace eProcurement_SAP
{
    public partial class ScheduleInterface : Form
    {
        private Button btn_exit;
        private TextBox txt_usrid;
        private Label label1;
        private TextBox txt_pswd;
        private Label label2;
        private Button btn_start;
        
        private int validsts = 0;
        private MainController mainControl;

        public ScheduleInterface()
        {
            mainControl = new MainController();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.txt_usrid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pswd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(292, 7);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(122, 34);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start Interface";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(292, 53);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(122, 34);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "Exit Interface";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // txt_usrid
            // 
            this.txt_usrid.Location = new System.Drawing.Point(95, 12);
            this.txt_usrid.MaxLength = 10;
            this.txt_usrid.Name = "txt_usrid";
            this.txt_usrid.Size = new System.Drawing.Size(167, 24);
            this.txt_usrid.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Id";
            // 
            // txt_pswd
            // 
            this.txt_pswd.Location = new System.Drawing.Point(95, 51);
            this.txt_pswd.MaxLength = 10;
            this.txt_pswd.Name = "txt_pswd";
            this.txt_pswd.PasswordChar = '*';
            this.txt_pswd.Size = new System.Drawing.Size(167, 24);
            this.txt_pswd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // ScheduleInterface
            // 
            this.ClientSize = new System.Drawing.Size(430, 99);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_pswd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_usrid);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_start);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interface Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            this.checkLogin();

            if (validsts == 0)
            {
                InterfaceMainController mainControl = new InterfaceMainController();
            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
       
        }

        private void checkLogin()
        {
            try
            {
                LoginController loginControl = new LoginController(mainControl);
                validsts = loginControl.ValidateLogin(this.txt_usrid.Text.Trim(), this.txt_pswd.Text.Trim());
                if (validsts > 0)
                {
                    MessageBox.Show("User Id and Password Invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                validsts = 1;
                Utility.ExceptionLog(ex);
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
