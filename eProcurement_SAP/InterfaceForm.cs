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
        private InterfaceMainController mainController;

        public InterfaceForm(InterfaceMainController mainController)
        {
            InitializeComponent();
            this.mainController = mainController;
            this.initForm();
            this.label1.Text = "Execute the options for Interface ...";
        }

        private void initForm()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            groupBox8.Enabled = false;
            groupBox9.Enabled = false;
        }

        private void btn_contract_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.ProcessPurchaseContract();
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox8.Enabled = false;
                groupBox9.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.label1.Text = "Error during retrieving of Purchase Contract Details...";
                this.initForm();
            }
        }


        private void btn_orders_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.ProcessPurchaseOrder();
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox8.Enabled = false;
                groupBox9.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.label1.Text = "Error during retrieving of Purchase Details...";
                this.initForm();
            }
        }

        private void btn_reqn_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.ProcessRequisition();
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = true;
                groupBox5.Enabled = false;
                groupBox8.Enabled = false;
                groupBox9.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.label1.Text = "Error during retrieving of Requisition Details...";
                this.initForm();
            }
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.ProcessSupplier();
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = true;
                groupBox8.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.label1.Text = "Error during retrieving of Supplier Details...";
                this.initForm();
            }
        }

        private void btn_reqmt_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.ProcessMaterialRequirement();
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = true;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox8.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.label1.Text = "Error during retrieving of Requirement Details...";
                this.initForm();
            }
        }

        private void btn_stock_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.ProcessMaterialStock();
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = true;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox8.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.label1.Text = "Error during retrieving of Material Stock Details...";
                this.initForm();
            }
        }

        private void btn_reject_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.ProcessGoodsRejection();
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox8.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.label1.Text = "Error during retrieving of Goods Rejection Details...";
                this.initForm();
            }

        }

        private void btn_ordhst_Click(object sender, EventArgs e)
        {
            try
            {
                mainController.ProcessPurchaseHistory();
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox8.Enabled = false;
                groupBox9.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.label1.Text = "Error during retrieving of Purchase Order History Details...";
                this.initForm();
            }

        }

        private void btn_intall_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                mainController.ProcessPurchaseContract();
                mainController.ProcessPurchaseOrder();
                mainController.ProcessRequisition();
                mainController.ProcessSupplier();
                mainController.ProcessMaterialRequirement();
                mainController.ProcessMaterialStock();
                mainController.ProcessGoodsRejection();
                mainController.ProcessPurchaseHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.label1.Text = "Error during retrieving of Material Stock Details...";
                this.initForm();
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }

        private void btn_vchdr_Click(object sender, EventArgs e)
        {
            mainController.GetContractHeader();
            if (mainController.GetInterfaceData() != null)
            {
                PurchaseGrid.DataSource = mainController.GetInterfaceData();
            }
        }

        private void btn_vcitm_Click(object sender, EventArgs e)
        {
            mainController.GetContractItem();
            if (mainController.GetInterfaceData() != null)
            {
                PurchaseGrid.DataSource = mainController.GetInterfaceData();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btn_vpohdr_Click(object sender, EventArgs e)
        {
            mainController.GetOrderHeader();
            if (mainController.GetInterfaceData() != null)
            {
                PurchaseGrid.Rows.Clear();
                PurchaseGrid.Columns.Clear();
                PurchaseGrid.DataSource = mainController.GetInterfaceData();
            }
        }

        private void btn_vpoitm_Click(object sender, EventArgs e)
        {
            mainController.GetOrderItem();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vposch_Click(object sender, EventArgs e)
        {
            mainController.GetOrderSchedule();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vpocmp_Click(object sender, EventArgs e)
        {
            mainController.GetOrderComponent();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vposrv_Click(object sender, EventArgs e)
        {
            mainController.GetOrderService();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vsrvtsk_Click(object sender, EventArgs e)
        {
            mainController.GetServiceTask();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vhdrtxt_Click(object sender, EventArgs e)
        {
            mainController.GetHeaderText();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vitmtxt_Click(object sender, EventArgs e)
        {
            mainController.GetItemText();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vrhdr_Click(object sender, EventArgs e)
        {
            mainController.GetRequisitionHeader();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vritm_Click(object sender, EventArgs e)
        {
            mainController.GetRequisitionItem();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vstk_Click(object sender, EventArgs e)
        {
            mainController.GetMaterial();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vreqmt_Click(object sender, EventArgs e)
        {
            mainController.GetRequirement();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vsupp_Click(object sender, EventArgs e)
        {
            mainController.GetSupplier();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vreject_Click(object sender, EventArgs e)
        {
            mainController.GetRejection();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }
        }

        private void btn_vhist_Click(object sender, EventArgs e)
        {
            mainController.GetOrderHistory();
            if (mainController.GetInterfaceData() != null)
            {
                this.BindData();
            }

        }

        private void BindData()
        {
            PurchaseGrid.DataSource = mainController.GetInterfaceData();
        }

        public ProgressBar getProgressBar()
        {
            return pbar_sts;
        }

        public Label getLabel()
        {
            return label1;
        }

        public TextBox getTextBox ()
        {
            return txt_record;
        }

        public string GetUserId()
        {
            return mainController.GetUserId();
        }

    }
}