using System;

namespace SAPInterface
{
	/// <summary>
	/// ---------------------------------------------------------------------------------
	/// Summary description for RetrieveRequisition.
	/// This class provides methods to retrieve the purchase Requisitions information
	/// from SAP. This class uses SAPProxy6 to execute remote function at SAP
	/// and retrieve the data.
	/// System : eProcurement System
	/// Module : eProcurement and SAP Interface 
	/// Author : Chetan Potnis
	/// Dated  : 25/11/2009
	/// Class  : RetrieveRequisition
	/// ---------------------------------------------------------------------------------
	/// </summary>

	public class RetrieveRequisition
	{
		private SAPProxy6 requisitionProxy;
		private string    connectionStr;

		private ZREQN_HDRTable requisitionHeader;
		private ZREQN_ITMTable requisitionItem;

		public RetrieveRequisition()
		{
			this.CreateRequisitionProxy();
		}

		private void CreateRequisitionProxy()	
		{
			try
			{
				SAPLogin login   = new SAPLogin();
				connectionStr    = login.GetSAPConnection();
				requisitionProxy = new SAPProxy6();
				requisitionProxy.ConnectionString = connectionStr;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		private void OpenConnection ()
		{
			if (requisitionProxy.Connection.IsOpen) 
			{
				requisitionProxy.Connection.Close();
			}
			requisitionProxy.Connection.Open();
		}

		private void CloseConnection ()
		{
			if (requisitionProxy.Connection.IsOpen) 
			{
				requisitionProxy.Connection.Close();
			}
		}

		public void GetRequisitionDetails ()
		{
			try
			{
				this.OpenConnection();
				requisitionHeader = new ZREQN_HDRTable();
				requisitionItem   = new ZREQN_ITMTable();

				requisitionProxy.Zretrieverequisition(ref requisitionHeader, ref requisitionItem);
				this.CloseConnection();
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		public ZREQN_HDRTable GetRequisitionHeader()
		{
			return requisitionHeader;
		}

		public ZREQN_ITMTable GetRequisitionItem ()
		{
			return requisitionItem;
		}
	}
}
