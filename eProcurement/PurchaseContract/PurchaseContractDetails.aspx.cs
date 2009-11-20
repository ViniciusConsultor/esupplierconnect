using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using eProcurement_BLL;
using eProcurement_DAL;

public partial class PurchaseContract_PurchaseContractDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gvItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView gvSchedule = (GridView)e.Item.FindControl("gvSchedule");
            Collection<PurchaseExpediting> schedules = new Collection<PurchaseExpediting>();
            int iCount = 2;
            for (int i = 1; i <= iCount; i++)
            {
                PurchaseExpediting obj = new PurchaseExpediting();
                obj.OrderNumber = "000000000" + i;
                obj.ItemSequence = "000" + i;
                obj.ScheduleSequence = "0" + i;
                schedules.Add(obj);
            }
            gvSchedule.DataSource = schedules;
            gvSchedule.DataBind();
        }
    }
}
