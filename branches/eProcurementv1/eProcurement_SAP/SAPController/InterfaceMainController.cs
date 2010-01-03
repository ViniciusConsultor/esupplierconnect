using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using eProcurement_BLL;

namespace eProcurement_SAP
{
    public class InterfaceMainController
    {
        private InterfaceForm scheduleInterface;
        private MainController mainController = null;
        private DataTable interfaceTbl;

        // SAP Interface Controllers

        private InterfaceContractController contractController;
        private InterfaceOrderController orderController;
        private InterfaceRequisitionController requisitionController;
        private InterfaceSupplierController supplierController;
        private InterfaceRequirementController requirementController;
        private InterfaceMaterialController materialController;

        public InterfaceMainController()
        {
            interfaceTbl = new DataTable();
            mainController = new MainController();
            scheduleInterface = new InterfaceForm(this);
            scheduleInterface.Show();
        }

        public void ProcessPurchaseContract()
        {
            try
            {
                if (contractController == null)
                {
                    contractController = new InterfaceContractController(scheduleInterface, mainController);
                 }
                 contractController.GetPurchaseContract();
             }
            catch (Exception ex)
            {
                if (ex.Message != "RECORDNOTFOUND")
                {
                    throw (ex);
                }
            }
        }

        public void ProcessPurchaseOrder()
        {
            try
            {
                if (orderController == null)
                {
                    orderController = new InterfaceOrderController(scheduleInterface, mainController);
                }
                orderController.GetPurchaseOrder();
            }
            catch (Exception ex)
            {
                if (ex.Message != "RECORDNOTFOUND")
                {
                    throw (ex);
                }
            }
        }

        public void ProcessRequisition()
        {
            try
            {
                if (requisitionController == null)
                {
                    requisitionController = new InterfaceRequisitionController(scheduleInterface, mainController);
                }
                requisitionController.GetRequisition();
            }
            catch (Exception ex)
            {
                if (ex.Message != "RECORDNOTFOUND")
                {
                    throw (ex);
                }
            }
        }

        public void ProcessMaterialRequirement()
        {
            try
            {
                if (requirementController == null)
                {
                    requirementController = new InterfaceRequirementController(scheduleInterface, mainController);
                }
                requirementController.GetMaterialRequirement();
            }
            catch (Exception ex)
            {
                if (ex.Message != "RECORDNOTFOUND")
                {
                    throw (ex);
                }
            }
        }

        public void ProcessMaterialStock()
        {
            try
            {
                if (materialController == null)
                {
                    materialController = new InterfaceMaterialController(scheduleInterface, mainController);
                }
                materialController.GetMaterialStock();
            }
            catch (Exception ex)
            {
                if (ex.Message != "RECORDNOTFOUND")
                {
                    throw (ex);
                }
            }
        }

        public void ProcessSupplier()
        {
            try
            {
                if (supplierController == null)
                {
                    supplierController = new InterfaceSupplierController(scheduleInterface, mainController);
                }
                supplierController.GetSupplierDetail();
            }
            catch (Exception ex)
            {
                if (ex.Message != "RECORDNOTFOUND")
                {
                    throw (ex);
                }
            }
        }

        /* Get the Contract Information retireved from SAP */

        public void GetContractHeader()
        {
            interfaceTbl =  contractController.GetContractHeader();
        }

        /* Get Contract Information */

        public void GetContractItem()
        {
            interfaceTbl = contractController.GetContractItem();
        }

        /* Get Requisition Information */

        public void  GetRequisitionHeader()
        {
            interfaceTbl =  requisitionController.GetRequisitionHeader();
        }

        public void GetRequisitionItem()
        {
            interfaceTbl = requisitionController.GetRequisitionItem();
        }

        /* Get Supplier Information */

        public void GetSupplier()
        {
            interfaceTbl =  supplierController.GetSupplier();
        }

        /* Get Material Stock Information */

        public void GetMaterial()
        {
            interfaceTbl = materialController.GetMaterial();
        }

        /* Get Material Requirement Information */

        public void GetRequirement()
        {
            interfaceTbl = requirementController.GetRequirement();
        }

        /* Get Purchase Order Information */

        public void GetOrderHeader()
        {
            if (orderController.GetOrderHeader() != null)
            {
                interfaceTbl = orderController.GetOrderHeader();
            }
        }

        public void GetOrderItem()
        {
            interfaceTbl =  orderController.GetOrderItem();
        }

        public void GetOrderSchedule()
        {
            interfaceTbl = orderController.GetOrderSchedule();
        }

        public void GetOrderComponent()
        {
            interfaceTbl = orderController.GetOrderComponent();
        }

        public void GetOrderService()
        {
            interfaceTbl = orderController.GetOrderService();
        }

        public void GetServiceTask()
        {
            interfaceTbl = orderController.GetServiceTask();
        }

        public void GetHeaderText()
        {
            interfaceTbl = orderController.GetOrderHeader();
        }

        public void GetItemText()
        {
            interfaceTbl = orderController.GetOrderItem();
        }

        public void GetOrderHistory()
        {
            interfaceTbl = orderController.GetHistory();
        }

        public DataTable GetInterfaceData()
        {
            return interfaceTbl;
        }
    }
}
