using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eProcurement_DAL;

namespace eProcurement_BLL.PurchaseContract
{
    public class PurchaseContractController
    {
        MainController mainController = null;
        public PurchaseContractController(MainController mainController) 
        {
            this.mainController = mainController;
        }


    }
}
