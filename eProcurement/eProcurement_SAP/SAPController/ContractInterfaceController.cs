using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAPInterface;
using SAP.Connector;
using eProcurement_DAL;
using eProcurement_BLL;

namespace eProcurement_SAP
{
    public class ContractInterfaceController
    {
        private RetrieveContract   retrieveContract;
        private ZCONTRACT_HDRTable contractHeader;
        private ZCONTRACT_ITMTable contractItem;

        private string wstr = "";
        private InterfaceForm aForm;

        public ContractInterfaceController(InterfaceForm aForm)
        {
            retrieveContract = new RetrieveContract();
            this.aForm = aForm;
        }

        public void GetPurchaseContract()
        {
            try
            {
                aForm.getLabel().Text = "Retrieval of Purchase Contract Data  in Progress ....";
                aForm.getLabel().Refresh();

                retrieveContract.GetContractDetails();
                contractHeader = retrieveContract.GetContracteHeader();
                contractItem   = retrieveContract.GetContractItem();

                aForm.getLabel().Text = "Update of Purchase Contract Data  in Progress ....";
                aForm.getLabel().Refresh();
                
                this.UpdateContract();
                this.RemoveContractDetails();
                
                aForm.getLabel().Text = "Click related <Button> to view Purchase Contract Data";
                aForm.getLabel().Refresh();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public void UpdateContract ()
        {
            int wstep;

            try
            {
                EpTransaction tran = DataManager.BeginTransaction();
                try
                {
                    wstep = 100 / contractHeader.Count; 
                    foreach (ZCONTRACT_HDR x in contractHeader)
                    {
                        ContractHeader hrd = new ContractHeader();
                        hrd.ContractNumber = x.Ebeln;
                        hrd.ContractDate = Convert.ToInt64(x.Bedat);
                        hrd.ContractCategory = x.Bstyp;
                        hrd.DocumentType = x.Bsart;
                        hrd.ContractValue = x.Ktwrt;
                        hrd.CreatedBy = x.Ernam;
                        hrd.Currency = x.Waers;
                        hrd.ExchangeRate = x.Wkurs;
                        hrd.InternalReference = "";
                        hrd.PaymentTerms = x.Zterm;
                        hrd.PurchasingGroup = x.Ekgrp;
                        hrd.SalesContactPerson = x.Verkf;
                        hrd.SupplierId = x.Lifnr;
                        hrd.Telephone = x.Telf1;
                        hrd.ValidityEnd = Convert.ToInt64(x.Kdate);
                        hrd.ValidityStart = Convert.ToInt64(x.Kdatb);                   

                        if (ContractHeaderDAO.RetrieveByKey(tran,x.Ebeln) != null)  
                            ContractHeaderDAO.Update(tran, hrd);  
                        else
                            ContractHeaderDAO.Insert(tran, hrd);

                        wstr = wstr + x.Ebeln + ", ";
                        aForm.getProgressBar().Increment(wstep);
                    }

                    this.setParameters();
                    wstep = 100 / contractItem.Count; 
                    foreach (ZCONTRACT_ITM x in contractItem)
                    {
                        ContractItem itm = new ContractItem();
                        itm.ContractNumber = x.Ebeln;
                        itm.ContractItemSequence = x.Ebelp;
                        itm.Description = x.Txz01;
                        itm.MaterialGroup = x.Matkl;
                        itm.MaterialNumber = x.Matnr;
                        itm.NetValue = x.Brtwr;
                        itm.Plant = x.Werks;
                        itm.PricePerUnit = x.Peinh;
                        itm.Requisitioner = x.Afnam;
                        itm.RequisitionNumber = x.Banfn;
                        itm.RFQNumber = x.Anfnr;
                        itm.TargetQuantity = x.Ktmng;
                        itm.UnitOfMeasure = x.Meins;
                        itm.UnitPrice = x.Netpr;

                        if (ContractItemDAO.RetrieveByKey(tran,x.Ebeln, x.Ebelp) != null)
                            ContractItemDAO.Update(tran, itm);  
                        else
                            ContractItemDAO.Insert(tran, itm); 

                        wstr = wstr + x.Ebeln + ", ";
                        aForm.getProgressBar().Increment(wstep);
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw (ex);
                }
                finally
                {
                    tran.Dispose();
                } 

                this.RemoveContractDetails();
            }
            catch (Exception ex)
            {
                Utility.ExceptionLog(ex);
                throw (ex);
            }
        }

        public DataTable GetContractHeader()
        {
            return contractHeader.ToADODataTable();
        }

        public DataTable GetContractItem()
        {
            return contractItem.ToADODataTable();
        }

        private void setParameters()
        {
            aForm.getProgressBar().Step = 0;
            aForm.getProgressBar().Maximum = 100;
            aForm.getProgressBar().Minimum = 1;
        }

        private void RemoveContractDetails()
        {
            ClearPurchaseData clearPurchaseData;
            try
            {
                clearPurchaseData = new ClearPurchaseData();
                clearPurchaseData.ClearContractData();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
