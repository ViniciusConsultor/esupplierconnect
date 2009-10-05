namespace DAL_TestApp
{
    partial class Form1
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRetriveKey = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRetreiveAll = new System.Windows.Forms.Button();
            this.btnRetreiveQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(39, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(137, 31);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Create New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnRetriveKey
            // 
            this.btnRetriveKey.Location = new System.Drawing.Point(39, 149);
            this.btnRetriveKey.Name = "btnRetriveKey";
            this.btnRetriveKey.Size = new System.Drawing.Size(137, 31);
            this.btnRetriveKey.TabIndex = 1;
            this.btnRetriveKey.Text = "Retreive By Key";
            this.btnRetriveKey.UseVisualStyleBackColor = true;
            this.btnRetriveKey.Click += new System.EventHandler(this.btnRetriveKey_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(39, 223);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(137, 31);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(39, 186);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(137, 31);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRetreiveAll
            // 
            this.btnRetreiveAll.Location = new System.Drawing.Point(39, 49);
            this.btnRetreiveAll.Name = "btnRetreiveAll";
            this.btnRetreiveAll.Size = new System.Drawing.Size(137, 31);
            this.btnRetreiveAll.TabIndex = 4;
            this.btnRetreiveAll.Text = "Retreive All";
            this.btnRetreiveAll.UseVisualStyleBackColor = true;
            this.btnRetreiveAll.Click += new System.EventHandler(this.btnRetreiveAll_Click);
            // 
            // btnRetreiveQuery
            // 
            this.btnRetreiveQuery.Location = new System.Drawing.Point(39, 97);
            this.btnRetreiveQuery.Name = "btnRetreiveQuery";
            this.btnRetreiveQuery.Size = new System.Drawing.Size(137, 31);
            this.btnRetreiveQuery.TabIndex = 5;
            this.btnRetreiveQuery.Text = "Retreive By Query";
            this.btnRetreiveQuery.UseVisualStyleBackColor = true;
            this.btnRetreiveQuery.Click += new System.EventHandler(this.btnRetreiveQuery_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 266);
            this.Controls.Add(this.btnRetreiveQuery);
            this.Controls.Add(this.btnRetreiveAll);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnRetriveKey);
            this.Controls.Add(this.btnNew);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRetriveKey;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRetreiveAll;
        private System.Windows.Forms.Button btnRetreiveQuery;
    }
}

