using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Xml;
using System.Xml.XPath;

using eProcurement_BLL.UserManagement;
using eProcurement_BLL;

public partial class MasterPages_MasterPageWithMenu : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session[SessionKey.LOGIN_USER] == null) 
            {
                Session.Abandon();
                Response.Redirect("~/Common/Timeout.aspx");
            }

            LoginUserVO loginUserVO = (LoginUserVO)Session[SessionKey.LOGIN_USER];
            XmlDocument docMenu = new XmlDocument();
            if (loginUserVO.MenuXML != null)
            {
                docMenu = loginUserVO.MenuXML;
            }
            else 
            {
                docMenu.Load(Server.MapPath("~/App_Data/Menu.xml"));
                Collection<string> funcIdColl = loginUserVO.FuncList;
                FilterFunction(docMenu, funcIdColl);

            }
            loginUserVO.MenuXML = docMenu;
            Session[SessionKey.LOGIN_USER] = loginUserVO;
            CreateMene(docMenu);
        }
    }

    private void CreateMene(XmlDocument menuXML)
    {
        XmlNodeList nodelistItemsTop = menuXML.DocumentElement.SelectNodes("ITEM");
        foreach (XmlNode nodeItem in nodelistItemsTop)
        {
            // Create a new row and add it to the table.
            TableRow tRow = new TableRow();
            tRow.VerticalAlign = VerticalAlign.Middle;
            tRow.Height = Unit.Pixel(25);  
            tblMenu.Rows.Add(tRow);

            TableCell tCell = new TableCell();
            tCell.CssClass = "LeftMenuCaption";
            tCell.Text = "";
            tRow.Cells.Add(tCell);

            TableCell tCel2 = new TableCell();
            tCel2.Text = nodeItem.SelectSingleNode("TITLE").InnerText;
            tCel2.ColumnSpan = 3;
            tCel2.CssClass = "LeftMenuCaption";
            tRow.Cells.Add(tCel2);

            XmlNodeList nodelistItemsSub = nodeItem.SelectNodes("ITEM");
            foreach (XmlNode nodeItemSub in nodelistItemsSub)
            {
                // Create a new row and add it to the table.
                TableRow sRow = new TableRow();
                sRow.VerticalAlign = VerticalAlign.Middle;
                sRow.Height = Unit.Pixel(25);  
                tblMenu.Rows.Add(sRow);

                TableCell sCell = new TableCell();
                sCell.Text = "";
                sCell.CssClass = "LeftMenu";
                sRow.Cells.Add(sCell);

                TableCell sCel2 = new TableCell();
                sCel2.CssClass = "LeftMenu";
                System.Web.UI.WebControls.Image img = new Image();
                img.ImageUrl = "~/Images/common/closed.gif";
                sCel2.Controls.Add(img);
                sRow.Cells.Add(sCel2);

                TableCell sCel3 = new TableCell();
                sCel3.Text = "";
                sCel3.CssClass = "LeftMenu";
                sRow.Cells.Add(sCel3);

                TableCell sCel4 = new TableCell();
                sCel4.CssClass = "LeftMenu";
                System.Web.UI.WebControls.HyperLink hyperLink = new HyperLink();
                hyperLink.Text = nodeItemSub.SelectSingleNode("TITLE").InnerText;
                hyperLink.NavigateUrl = nodeItemSub.SelectSingleNode("HREF").InnerText;
                sCel4.Controls.Add(hyperLink);
                sRow.Cells.Add(sCel4);
            }  
        }
    }

    private void FilterFunction(XmlDocument fullFuncDom, Collection<string> functionIds)
    {
        if (functionIds == null)
        {
            return;
        }

        XPathNavigator root = fullFuncDom.CreateNavigator();
        XPathNodeIterator items = root.Select("//ITEM[@FID]");
        Queue<XPathNavigator> queue = new Queue<XPathNavigator>(items.Count);

        foreach (XPathNavigator item in items)
        {
            bool keepItem;
            
            if (item.GetAttribute("KEEP", String.Empty).Equals("Y"))
            {
                keepItem = true;
            }
            else if (String.IsNullOrEmpty(item.GetAttribute("FID", String.Empty)))
            {
                keepItem = false;
            }
            else
            {
                keepItem = false;
                string[] arrFID = item.GetAttribute("FID", String.Empty).Split(',');

                foreach (string fid in arrFID)
                {
                    if (functionIds.Contains(fid))
                    {
                        keepItem = true;
                        break;
                    }
                }
            }
            
            
            if (!keepItem)
            {
                queue.Enqueue(item.CreateNavigator());
            }
        }

        EmptyQueue(queue);

        queue.Clear();

        XPathNodeIterator titleItems = root.Select("/TREE/ITEM[not(@FID)]");
        // Console.WriteLine("totle level title item count: " + titleItems.Count);
        foreach (XPathNavigator titleItem in titleItems)
        {
            TitleItemDeletable(titleItem, queue);
        }

        EmptyQueue(queue);
    }

    private bool TitleItemDeletable(XPathNavigator titleItem, Queue<XPathNavigator> queue)
    {
        bool canDelete;
        canDelete = (titleItem.Select("ITEM[@FID]").Count > 0) ? false : true;
        XPathNodeIterator childTitleItems = titleItem.Select("ITEM[not(@FID)]");

        foreach (XPathNavigator childTitleItem in childTitleItems)
        {
            canDelete = TitleItemDeletable(childTitleItem, queue) && canDelete;
        }
        if (canDelete)
        {
            queue.Enqueue(titleItem.CreateNavigator());
        }
        
        return canDelete;
    }

    private void EmptyQueue(Queue<XPathNavigator> queue)
    {
        int count = queue.Count;
        for (int i = 0; i < count; ++i)
        {
            queue.Dequeue().DeleteSelf();
        }
    }
}
