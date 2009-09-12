using System;

namespace SAPInterface
{
	/// <summary>
	/// ---------------------------------------------------------------------------------
	/// Summary description for RetrieveContract.
	/// This class provides methods to retrieve the purchase contract information
	/// from SAP. This class uses SAPProxy1 to execute remote function at SAP
	/// and retrieve the data.
	/// System : eProcurement System
	/// Module : eProcurement and SAP Interface 
	/// Author : Chetan Potnis
	/// Dated  : 05/08/2009
	/// Class  : RetrieveContract
	/// ---------------------------------------------------------------------------------
	/// </summary>

	public class RetrieveContract
	{
		private SAPProxy1 contractProxy;
		private string    connectionStr;

		private ZCONTRACT_HDRTable contractHeader;
		private ZCONTRACT_ITMTable contractItem;
		
		public RetrieveContract()
		{
			this.CreateContractProxy();
		}

		private void CreateContractProxy()
		{
			try
			{
				SAPLogin login = new SAPLogin();
				connectionStr  = login.GetSAPConnection();
				contractProxy  = new SAPProxy1();
				contractProxy.ConnectionString = connectionStr;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		private void OpenConnection ()
		{
			if (contractProxy.Connection.IsOpen) 
			{
				contractProxy.Connection.Close();
			}
			contractProxy.Connection.Open();
		}

		private void CloseConnection ()
		{
			if (contractProxy.Connection.IsOpen) 
			{
				contractProxy.Connection.Close();
			}
		}

		public void GetContractDetails ()
		{
			try
			{
				this.OpenConnection();
				contractHeader = new ZCONTRACT_HDRTable();
				contractItem   = new ZCONTRACT_ITMTable();
				contractProxy.Zretrievecontract(ref contractHeader, ref contractItem);
				this.CloseConnection();
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		public ZCONTRACT_HDRTable GetContracteHeader()
		{
			return contractHeader;
		}

		public ZCONTRACT_ITMTable GetContractItem ()
		{
			return contractItem;
		}
	}
}
