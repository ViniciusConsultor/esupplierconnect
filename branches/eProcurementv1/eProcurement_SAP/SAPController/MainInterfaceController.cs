using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace eProcurement_SAP
{
    public class MainInterfaceController
    {
        private InterfaceForm scheduleInterface;
        private ContractInterfaceController contractController;

        public MainInterfaceController()
        {
            scheduleInterface = new InterfaceForm(this);
            scheduleInterface.Show();
        }

        public void ProcessPurchaseContract()
        {
            try
            {
                contractController = new ContractInterfaceController(scheduleInterface);
                contractController.GetPurchaseContract();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DataTable GetContractHeader()
        {
            return contractController.GetContractHeader();
        }

        public DataTable GetContractItem()
        {
            return contractController.GetContractItem();
        }
    }
}
