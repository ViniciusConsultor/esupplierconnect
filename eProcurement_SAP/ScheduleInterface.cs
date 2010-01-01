using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eProcurement_SAP
{
    public partial class ScheduleInterface : Form
    {
        private Button btn_exit;
        private Button btn_start;
    
        public ScheduleInterface()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(40, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(122, 34);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start Interface";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(40, 71);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(122, 34);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "Exit Interface";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // ScheduleInterface
            // 
            this.ClientSize = new System.Drawing.Size(196, 121);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_start);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interface Scheduler";
            this.ResumeLayout(false);

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            InterfaceMainController mainControl = new InterfaceMainController();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
       
        }
    }
}
