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


public partial class Expediting_ExpeditingAckConfirm : BaseForm
{
    class TemVO
    {

        private string _Text1;
        public string Text1
        {
            get { return _Text1; }
            set { _Text1 = value; }
        }

        private string _Text2;
        public string Text2
        {
            get { return _Text2; }
            set { _Text2 = value; }
        }

        private string _Text3;
        public string Text3
        {
            get { return _Text3; }
            set { _Text3 = value; }
        }

        private string _Text4;
        public string Text4
        {
            get { return _Text4; }
            set { _Text4 = value; }
        }
    }


    new protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            plMessage.Visible = false;
            lblMessage.Text = string.Empty;
            if (!IsPostBack)
            {
                ShowData();
            }
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
            plMessage.Visible = true;
            string sMessage = ex.Message;
            displayCustomMessage(sMessage, lblMessage, SystemMessageType.Error);
        }
    }

    private void ShowData()
    {
        Collection<TemVO> objs = new Collection<TemVO>();
        int iCount = 6;
        for (int i = 1; i <= iCount; i++)
        {
            TemVO obj = new TemVO();
            obj.Text1 = i.ToString();
            obj.Text2 = "Material " + i;
            obj.Text3 = "Material Desc" + i;
            objs.Add(obj);
        }


        gvItem.DataSource = objs;
        gvItem.DataBind();
        lblCount.Text = string.Format("{0} record(s) found. ", objs.Count.ToString());

    }

    protected void gvItem_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            GridView gvSchedule = (GridView)e.Item.FindControl("gvSchedule");
            Collection<PurchaseExpediting> schedules = new Collection<PurchaseExpediting>();
            int iCount = 3;
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
