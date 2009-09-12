using System;

namespace SAPInterface
{
	/// <summary>
	/// --------------------------------------------------------------------------------
	/// Summary description for ClearPurchaseData.
	/// This class provides methods to clean up the purchase contract information
	/// from temporary tables in SAP. This class uses SAPProxy2 to execute remote function 
	/// at SAP and clear the purchase data from the temporary tables
	/// System : eProcurement System
	/// Module : eProcurement and SAP Interface 
	/// Author : Chetan Potnis
	/// Dated  : 05/08/2009
	/// Class  : ClearPurchaseData
	/// --------------------------------------------------------------------------------
	/// </summary>
	public class ClearPurchaseData
	{
		private SAPProxy2 clearPurchaseProxy;
		private string    connectionStr;

		public ClearPurchaseData()
		{
			this.CreateClearProxy();
		}

		private void CreateClearProxy()
		{
			try
			{
				SAPLogin login = new SAPLogin();
				connectionStr  = login.GetSAPConnection();
				clearPurchaseProxy  = new SAPProxy2();
				clearPurchaseProxy.ConnectionString = connectionStr;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		private void OpenConnection ()
		{
			if (clearPurchaseProxy.Connection.IsOpen) 
			{
				clearPurchaseProxy.Connection.Close();
			}
			clearPurchaseProxy.Connection.Open();
		}

		private void CloseConnection ()
		{
			if (clearPurchaseProxy.Connection.IsOpen) 
			{
				clearPurchaseProxy.Connection.Close();
			}
		}

		public void ClearContractData ()
		{
			try
			{
				this.OpenConnection();
				clearPurchaseProxy.Zremovecontract();
				this.CloseConnection();
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

	}
}
