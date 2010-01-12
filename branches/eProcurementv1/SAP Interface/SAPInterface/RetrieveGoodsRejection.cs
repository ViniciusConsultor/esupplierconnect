using System;

namespace SAPInterface
{
	/// <summary>
	/// ---------------------------------------------------------------------------------
	/// Summary description for RetrieveGoodsRejection.
	/// This class provides methods to retrieve the Goods Rejections information
	/// from SAP. This class uses SAPProxy4 to execute remote function at SAP
	/// and retrieve the data.
	/// System : eProcurement System
	/// Module : eProcurement and SAP Interface 
	/// Author : Chetan Potnis
	/// Dated  : 30/10/2009
	/// Class  : RetrieveGoodsRejection.
	/// ---------------------------------------------------------------------------------
	/// </summary>

	/// </summary>
	public class RetrieveGoodsRejection
	{
		private SAPProxy7 rejectionProxy;
		private string    connectionStr;

		private ZORDER_REJECTTable orderRejection;

		public RetrieveGoodsRejection()
		{
			this.CreateRejectionProxy();
		}


		private void CreateRejectionProxy()	
		{
			try
			{
				SAPLogin login   = new SAPLogin();
				connectionStr    = login.GetSAPConnection();
				rejectionProxy = new SAPProxy7();
				rejectionProxy.ConnectionString = connectionStr;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		private void OpenConnection ()
		{
			if (rejectionProxy.Connection.IsOpen) 
			{
				rejectionProxy.Connection.Close();
			}
			rejectionProxy.ConnectionString = connectionStr;
			rejectionProxy.Connection.Open();
		}

		private void CloseConnection ()
		{
			if (rejectionProxy.Connection.IsOpen) 
			{
				rejectionProxy.Connection.Close();
			}
		}

		public void GetRejectionDetails ()
		{
			try
			{
				this.OpenConnection();
				orderRejection = new ZORDER_REJECTTable();
				rejectionProxy.Zretrieverejection(ref orderRejection);
				this.CloseConnection();
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		public ZORDER_REJECTTable GetOrderRejection()
		{
			return orderRejection;
		}

		public void UpdateRejectControlDate()
		{
			try
			{
				if (rejectionProxy != null)
				{
					this.OpenConnection();
					rejectionProxy.Zupd_Rejectctl();
					this.CloseConnection();
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}
	}
}
