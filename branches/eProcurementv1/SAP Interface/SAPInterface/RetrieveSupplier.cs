using System;

namespace SAPInterface
{
	/// <summary>
	/// ---------------------------------------------------------------------------------
	/// Summary description for RetrieveSupplier.
	/// This class provides methods to retrieve the Supplier information
	/// from SAP. This class uses SAPProxy5 to execute remote function at SAP
	/// and retrieve the data.
	/// System : eProcurement System
	/// Module : eProcurement and SAP Interface 
	/// Author : Chetan Potnis
	/// Dated  : 30/10/2009
	/// Class  : RetrieveSupplier
	/// ---------------------------------------------------------------------------------
	/// </summary>

	public class RetrieveSupplier
	{
		private SAPProxy5 supplierProxy;
		private string    connectionStr;

		private ZSUPPLIERTable supplier;

		public RetrieveSupplier()
		{
			this.CreateSupplierProxy();
		}

		private void CreateSupplierProxy()	
		{
			try
			{
				SAPLogin login   = new SAPLogin();
				connectionStr    = login.GetSAPConnection();
				supplierProxy = new SAPProxy5();
				supplierProxy.ConnectionString = connectionStr;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		private void OpenConnection ()
		{
			if (supplierProxy.Connection.IsOpen) 
			{
				supplierProxy.Connection.Close();
			}
			supplierProxy.Connection.Open();
		}

		private void CloseConnection ()
		{
			if (supplierProxy.Connection.IsOpen) 
			{
				supplierProxy.Connection.Close();
			}
		}

		public void GetSupplierDetails ()
		{
			try
			{
				this.OpenConnection();
				supplier = new ZSUPPLIERTable();

				supplierProxy.Zretrievesupplier(ref supplier);
				this.CloseConnection();
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		public ZSUPPLIERTable GetSupplier()
		{
			return supplier;
		}
	}
}
