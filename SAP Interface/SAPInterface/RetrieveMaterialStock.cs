using System;

namespace SAPInterface
{
	/// <summary>
	/// ---------------------------------------------------------------------------------
	/// Summary description for RetrieveMaterialStock.
	/// This class provides methods to retrieve the Material Stock information
	/// from SAP. This class uses SAPProxy4 to execute remote function at SAP
	/// and retrieve the data.
	/// System : eProcurement System
	/// Module : eProcurement and SAP Interface 
	/// Author : Chetan Potnis
	/// Dated  : 27/11/2009
	/// Class  : RetrieveMaterialStock
	/// ---------------------------------------------------------------------------------
	/// </summary>

	public class RetrieveMaterialStock
	{
		private SAPProxy4 materialProxy;
		private string    connectionStr;

		private ZMATL_STOCKTable materialStock;

		public RetrieveMaterialStock()
		{
			this.CreateMaterialProxy();
		}

		private void CreateMaterialProxy()	
		{
			try
			{
				SAPLogin login   = new SAPLogin();
				connectionStr    = login.GetSAPConnection();
				materialProxy = new SAPProxy4();
				materialProxy.ConnectionString = connectionStr;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		private void OpenConnection ()
		{
			if (materialProxy.Connection.IsOpen) 
			{
				materialProxy.Connection.Close();
			}
			materialProxy.Connection.Open();
		}

		private void CloseConnection ()
		{
			if (materialProxy.Connection.IsOpen) 
			{
				materialProxy.Connection.Close();
			}
		}

		public void GetMaterialDetails ()
		{
			try
			{
				this.OpenConnection();
				materialStock = new ZMATL_STOCKTable();

				materialProxy.Zretrievestock(ref materialStock);
				this.CloseConnection();
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		public ZMATL_STOCKTable GetMaterialStock()
		{
			return materialStock;
		}
	}
}
