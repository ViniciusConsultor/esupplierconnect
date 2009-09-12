using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eProcurement_SAP
{
    public partial class InterfaceForm : Form
    {
        private MainInterfaceController mainController;

        public InterfaceForm(MainInterfaceController mainController)
        {
            InitializeComponent();
            this.mainController = mainController;
        }

        private void btn_contract_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.ProcessPurchaseContract();
                this.btn_vchdr.Enabled = true;
                this.btn_vcitm.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btn_vchdr.Enabled = false;
                this.btn_vcitm.Enabled = false;
                this.label1.Text = "Error during retrieving of Purchase Details...";
            }
        }

        private void btn_vchdr_Click(object sender, EventArgs e)
        {
            PurchaseGrid.DataSource = mainController.GetContractHeader();
        }

        private void btn_vcitm_Click(object sender, EventArgs e)
        {
            PurchaseGrid.DataSource = mainController.GetContractItem();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        public ProgressBar getProgressBar()
        {
            return pbar_sts;
        }

        public Label getLabel()
        {
            return label1;
        }
    }
}