namespace eProcurement_SAP
{
    partial class InterfaceForm
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
            this.PurchaseGrid = new System.Windows.Forms.DataGridView();
            this.btn_contract = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.pbar_sts = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_vchdr = new System.Windows.Forms.Button();
            this.btn_vcitm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PurchaseGrid
            // 
            this.PurchaseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PurchaseGrid.Location = new System.Drawing.Point(13, 13);
            this.PurchaseGrid.Margin = new System.Windows.Forms.Padding(4);
            this.PurchaseGrid.Name = "PurchaseGrid";
            this.PurchaseGrid.Size = new System.Drawing.Size(971, 351);
            this.PurchaseGrid.TabIndex = 0;
            // 
            // btn_contract
            // 
            this.btn_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_contract.Location = new System.Drawing.Point(13, 373);
            this.btn_contract.Margin = new System.Windows.Forms.Padding(4);
            this.btn_contract.Name = "btn_contract";
            this.btn_contract.Size = new System.Drawing.Size(199, 31);
            this.btn_contract.TabIndex = 1;
            this.btn_contract.Text = "Purchase Contract";
            this.btn_contract.UseVisualStyleBackColor = true;
            this.btn_contract.Click += new System.EventHandler(this.btn_contract_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(220, 373);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(186, 31);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit Interface";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // pbar_sts
            // 
            this.pbar_sts.Location = new System.Drawing.Point(542, 373);
            this.pbar_sts.Name = "pbar_sts";
            this.pbar_sts.Size = new System.Drawing.Size(442, 31);
            this.pbar_sts.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(543, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Interface in Progress ...";
            // 
            // btn_vchdr
            // 
            this.btn_vchdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_vchdr.Location = new System.Drawing.Point(13, 412);
            this.btn_vchdr.Margin = new System.Windows.Forms.Padding(4);
            this.btn_vchdr.Name = "btn_vchdr";
            this.btn_vchdr.Size = new System.Drawing.Size(199, 31);
            this.btn_vchdr.TabIndex = 6;
            this.btn_vchdr.Text = "View Contract Header";
            this.btn_vchdr.UseVisualStyleBackColor = true;
            this.btn_vchdr.Click += new System.EventHandler(this.btn_vchdr_Click);
            // 
            // btn_vcitm
            // 
            this.btn_vcitm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_vcitm.Location = new System.Drawing.Point(220, 412);
            this.btn_vcitm.Margin = new System.Windows.Forms.Padding(4);
            this.btn_vcitm.Name = "btn_vcitm";
            this.btn_vcitm.Size = new System.Drawing.Size(186, 31);
            this.btn_vcitm.TabIndex = 7;
            this.btn_vcitm.Text = "View Contract Items";
            this.btn_vcitm.UseVisualStyleBackColor = true;
            this.btn_vcitm.Click += new System.EventHandler(this.btn_vcitm_Click);
            // 
            // InterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 449);
            this.Controls.Add(this.btn_vcitm);
            this.Controls.Add(this.btn_vchdr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbar_sts);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_contract);
            this.Controls.Add(this.PurchaseGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "InterfaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eProcurement Interface Module";
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PurchaseGrid;
        private System.Windows.Forms.Button btn_contract;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ProgressBar pbar_sts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_vchdr;
        private System.Windows.Forms.Button btn_vcitm;
    }
}