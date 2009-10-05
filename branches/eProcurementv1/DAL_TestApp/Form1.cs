using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using eProcurement_DAL;
using eProcurement_BLL;

namespace DAL_TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            PurchaseOrderHeader purchaseOrderHeader = new PurchaseOrderHeader();
            purchaseOrderHeader.OrderNumber = "1000000000";
            purchaseOrderHeader.AcknowledgeStatus = "Y";
            purchaseOrderHeader.AddressNumber = "AddressNumber";
            purchaseOrderHeader.BuyerName = "BuyerName";
            purchaseOrderHeader.CurrencyCode = "SG";
            purchaseOrderHeader.GstAmount = 100;
            purchaseOrderHeader.OrderAmount = 10000;
            purchaseOrderHeader.OrderDate = Utility.GetStoredDateValue(DateTime.Now);
            purchaseOrderHeader.OrderStatus = "P";
            purchaseOrderHeader.PaymentTerms = "30DAY";
            purchaseOrderHeader.RecordStatus = "Y";
            purchaseOrderHeader.Remarks = "Remarks";
            purchaseOrderHeader.SalesPerson = "SalePerson";
            purchaseOrderHeader.ShipmentAddress = "ShipmentAddress";
            purchaseOrderHeader.SupplierId = "0001";

            PurchaseOrderHeaderDAO.Insert(purchaseOrderHeader);

            MessageBox.Show("Created successfully");
        }

        private void btnRetriveKey_Click(object sender, EventArgs e)
        {
            PurchaseOrderHeader purchaseOrderHeader = PurchaseOrderHeaderDAO.RetrieveByKey("1000000000");
            if (purchaseOrderHeader != null)
                MessageBox.Show("Found!");
            else
                MessageBox.Show("Not Found!");
          
        }

        private void btnRetreiveAll_Click(object sender, EventArgs e)
        {
            Collection<PurchaseOrderHeader> purchaseOrderHeaders = PurchaseOrderHeaderDAO.RetrieveAll();

            MessageBox.Show("Total " + purchaseOrderHeaders.Count + " Records.");
          
        }

        private void btnRetreiveQuery_Click(object sender, EventArgs e)
        {
            string whereClause = "EBELN = '1000000000'";
            string orderClause = "EBELN desc";
            Collection<PurchaseOrderHeader> purchaseOrderHeaders = PurchaseOrderHeaderDAO.RetrieveByQuery(whereClause, orderClause);

            MessageBox.Show(purchaseOrderHeaders.Count + " records found.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PurchaseOrderHeader purchaseOrderHeader = PurchaseOrderHeaderDAO.RetrieveByKey("1000000000");
            purchaseOrderHeader.BuyerName = "mahongyu";
            PurchaseOrderHeaderDAO.Update(purchaseOrderHeader);

            MessageBox.Show("Updated successfully");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            PurchaseOrderHeader purchaseOrderHeader = PurchaseOrderHeaderDAO.RetrieveByKey("1000000000");
            PurchaseOrderHeaderDAO.Delete(purchaseOrderHeader);

            MessageBox.Show("Deleted successfully");
        }

       
    }
}