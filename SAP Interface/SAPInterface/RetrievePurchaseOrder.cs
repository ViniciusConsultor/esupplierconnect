using System;

namespace SAPInterface
{
	/// <summary>
	/// ---------------------------------------------------------------------------------
	/// Summary description for RetrievePurchaseOrder.
	/// This class provides methods to retrieve the purchase orders information
	/// from SAP. This class uses SAPProxy3 to execute remote function at SAP
	/// and retrieve the data.
	/// System : eProcurement System
	/// Module : eProcurement and SAP Interface 
	/// Author : Chetan Potnis
	/// Dated  : 20/11/2009
	/// Class  : RetrievePurchaseOrder
	/// ---------------------------------------------------------------------------------
	/// </summary>

	public class RetrievePurchaseOrder
	{

		private SAPProxy3 orderProxy;
		private string    connectionStr;

		private ZORDER_HDRTable     orderHeader;
		private ZORDER_ITMTable     orderItem;
		private ZORDER_SCHTable     orderSchedule;
		private ZORDER_COMPTable    orderComponent;
		private ZORDER_SRVTable     orderService;
		private ZORDER_SRVTSKTable  serviceTask;
		private ZORDER_HDRTXTTable  orderHeaderTxt;
		private ZORDER_ITMTXTTable  orderItemTxt;
		private ZORDER_HISTORYTable orderHistory;
		private ZORDER_CLOSETable   orderClose;

		public RetrievePurchaseOrder()
		{
				this.CreateOrderProxy();
		}

			
		private void CreateOrderProxy()	
		{
			try
			{
				SAPLogin login = new SAPLogin();
				connectionStr  = login.GetSAPConnection();
				orderProxy     = new SAPProxy3();
				orderProxy.ConnectionString = connectionStr;
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		private void OpenConnection ()
		{
			if (orderProxy.Connection.IsOpen) 
			{
				orderProxy.Connection.Close();
			}
			orderProxy.ConnectionString = connectionStr;
			orderProxy.Connection.Open();
		}

		private void CloseConnection ()
		{
			if (orderProxy.Connection.IsOpen) 
			{
				orderProxy.Connection.Close();
			}
		}

		public void GetPurchaseDetails ()
		{
			try
			{
				this.OpenConnection();
				orderHeader    = new ZORDER_HDRTable();
				orderItem      = new ZORDER_ITMTable();
				orderSchedule  = new ZORDER_SCHTable();
				orderComponent = new ZORDER_COMPTable();
				orderService   = new ZORDER_SRVTable();
				serviceTask    = new ZORDER_SRVTSKTable();
				orderHeaderTxt = new ZORDER_HDRTXTTable();
				orderItemTxt   = new ZORDER_ITMTXTTable();

				orderProxy.Zretrieveorder(ref orderComponent, ref orderHeader,   ref orderHeaderTxt, ref orderItem,
					                      ref orderItemTxt,   ref orderSchedule, ref orderService,   ref serviceTask);
				this.CloseConnection();
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		public void GetPurchaseHistoryDetails ()
		{
			try
			{
				this.OpenConnection();
				orderHistory = new ZORDER_HISTORYTable();
				orderClose   = new ZORDER_CLOSETable();
				orderProxy.Zretrieveorderhistory(ref orderClose, ref orderHistory);
				this.CloseConnection();
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		public void UpdateHistoryControlDate()
		{
			try
			{
				if (orderProxy != null)
				{
					this.OpenConnection();
					orderProxy.Zupd_Historyctl();
					this.CloseConnection();
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}

		public ZORDER_HDRTable GetOrderHeader()
		{
			return orderHeader;
		}

		public ZORDER_ITMTable GetOrderItem ()
		{
			return orderItem;
		}

   		public ZORDER_SCHTable GetOrderSchedule ()
		{
			return orderSchedule;
		}

		public ZORDER_COMPTable GetOrderComponent ()
		{
			return orderComponent;
		}

		public ZORDER_SRVTable GetOrderService ()
		{
			return orderService;
		}

		public ZORDER_SRVTSKTable GetServiceTask ()
		{
			return serviceTask;
		}   		

		public ZORDER_HDRTXTTable GetOrderHeaderText ()
		{
			return orderHeaderTxt;
		}

		public ZORDER_ITMTXTTable GetOrderItemText ()
		{
			return orderItemTxt;
		}

		public ZORDER_HISTORYTable GetOrderHistory ()
		{
			return orderHistory;
		}

		public ZORDER_CLOSETable GetOrderClosed ()
		{
			return orderClose;
		}
	}
}
