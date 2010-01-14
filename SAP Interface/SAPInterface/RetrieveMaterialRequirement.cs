using System;
using System.Data;

namespace SAPInterface
{
	/// <summary>
	/// ---------------------------------------------------------------------------------
	/// Summary description for RetireveMaterialRequirement.
	/// This class provides methods to retrieve the Material Requirement information
	/// from SAP. This class uses SAPProxy4 to execute remote function at SAP
	/// and retrieve the data.
	/// System : eProcurement System
	/// Module : eProcurement and SAP Interface 
	/// Author : Chetan Potnis
	/// Dated  : 28/10/2009
	/// Class  : RetrieveMaterialRequirement
	/// ---------------------------------------------------------------------------------
	/// </summary>

	public class RetrieveMaterialRequirement
	{
		private SAPProxy4 requirementProxy;
		private string    connectionStr;

		private ZMATL_REQUIRETable materialRequirement;

		public RetrieveMaterialRequirement()
		{
			this.CreateRequirementProxy();
		}

		private void CreateRequirementProxy()	
		{
			try
			{
				SAPLogin login   = new SAPLogin();
				connectionStr    = login.GetSAPConnection();
				requirementProxy = new SAPProxy4();
				requirementProxy.ConnectionString = connectionStr;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		private void OpenConnection ()
		{
			if (requirementProxy.Connection.IsOpen) 
			{
				requirementProxy.Connection.Close();
			}
			requirementProxy.Connection.Open();
		}

		private void CloseConnection ()
		{
			if (requirementProxy.Connection.IsOpen) 
			{
				requirementProxy.Connection.Close();
			}
		}

		public void GetRequirementDetails ()
		{
			try
			{
				this.OpenConnection();
				materialRequirement = new ZMATL_REQUIRETable();
				requirementProxy.Zretrieverequirement(ref materialRequirement);
				this.CloseConnection();
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}
		
		public ZMATL_REQUIRETable GetMaterialRequirement()
		{
			return materialRequirement;
		}
	}
}
