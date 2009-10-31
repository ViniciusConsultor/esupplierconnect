using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControls_DualList : System.Web.UI.UserControl
{
    #region properties

    private const string SCRIPT_BLOCK = "DUALLISTV2";
    private const string SCRIPT_BLOCK_MAIN = "MAINDUALLISTV2";

    private int m_iMaxRows = 6;
    private int m_iMaxMoveToRight = 0;
    private string m_TextLeft = "";
    private string m_TextRight = "";

   //public event EventHandler SendMessage;

    #endregion

    #region properties

    public object DataSource
    {
        set { ViewState["Source"] = value; }
        get
        {
            return ViewState["Source"];
        }
    }

    public int Rows
    {
        set { m_iMaxRows = value; }
        get
        {
            if (m_iMaxRows == 0)
                m_iMaxRows = 6;
            return m_iMaxRows;
        }
    }

    public String TextLeft
    {
        set { m_TextLeft = value; }
        get { return m_TextLeft; }
    }

    public String TextRight
    {
        set { m_TextRight = value; }
        get { return m_TextRight; }
    }

    public int MaxMoveToRight
    {
        set { m_iMaxMoveToRight = value; }
        get { return m_iMaxMoveToRight; }
    }

    public String SelectdValues
    {
        set { hidSelected.Value = value; }
        get { return hidSelected.Value; }
    }

    public String AvailableItems
    {
        get
        {
            string items = string.Empty;

            foreach (ListItem li in lbLeft.Items)
            {
                items += li.Value + ",";
            }
            if (items != string.Empty)
                items = items.Substring(0, items.Length - 1);
            return items;
        }
    }

    public int AvailableItemsLength
    {
        get
        {
            return lbLeft.Items.Count;
        }
    }

    public int SelectedItemsLength
    {
        get
        {
            if (string.IsNullOrEmpty(hidSelected.Value))
                return 0;
            return hidSelected.Value.Split(',').Length;
        }
    }

    public bool ReadOnly
    {
        set
        {
            ViewState["ReadOnly"] = value;
            //lbLeft.Enabled = value;
            //lbRight.Enabled = value;
            btnToLeft.Disabled = value;
            btnToLeftAll.Disabled = value;
            btnToRight.Disabled = value;
            btnToRightAll.Disabled = value;
        }
        get
        {
            if (ViewState["ReadOnly"] != null)
                return Convert.ToBoolean(ViewState["ReadOnly"]);
            else
                return false;
        }
    }

    public bool Enabled
    {
        set
        {
            ViewState["Enabled"] = value;
            lbLeft.Enabled = value;
            lbRight.Enabled = value;
            btnToLeft.Disabled = !value;
            btnToLeftAll.Disabled = !value;
            btnToRight.Disabled = !value;
            btnToRightAll.Disabled = !value;
        }
        get
        {
            if (ViewState["Enabled"] != null)
                return Convert.ToBoolean(ViewState["Enabled"]);
            else
                return true;
        }
    }
    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        RegScriptBlock();

        if (IsPostBack) return;

        InitializeControls();

    }

    #endregion

    #region Public Functions and Methods


    public string GetListBoxLeftID()
    {
        return lbLeft.ClientID;
    }

    public string GetListBoxRightID()
    {
        return lbRight.ClientID;
    }

    public string GetAvailableItems()
    {
        string items = string.Empty;

        foreach (ListItem li in lbLeft.Items)
        {
            items += items == string.Empty ? "" : ",";
            items += string.Format("'{0}'", li.Value);
        }
        return items;
    }

    public string GetSelectedValues()
    {
        if (string.IsNullOrEmpty(hidSelected.Value)) return string.Empty;

        string returnValue = "";
        string[] arrValues = hidSelected.Value.Split(',');
        foreach (string value in arrValues)
        {
            returnValue += returnValue == "" ? "" : ",";
            returnValue += string.Format("'{0}'", value);
        }
        return returnValue;
    }

    public void ClearLists()
    {
        try
        {
            SelectdValues = string.Empty;
            lbLeft.Items.Clear();
        }
        catch (Exception ex)
        {
            ////MessageSender.SendMessage(this, SendMessage, "Cleaning Process Fail !", ex);
        }
    }

    public void DataBindLeftBox(object Source, string TextField, string ValueField, bool SaveDataSource)
    {
        try
        {
            if (SaveDataSource)
                DataSource = Source;

            DataBindLeftBox(Source, TextField, ValueField);
        }
        catch
        {

        }
    }

    public void DataBindLeftBox(object Source, string TextField, string ValueField)
    {
        try
        {
            if (Source == null)
            {
                Clear();
                return;
            }

            lbLeft.DataSource = Source;
            lbLeft.DataTextField = TextField;
            lbLeft.DataValueField = ValueField;
            lbLeft.DataBind();
        }
        catch (Exception ex)
        {
            //MessageSender.SendMessage(this, SendMessage, "Data Binding Fail on Dual List !", ex);
        }
    }

    //public String  GetSelectdValues()
    //{
    //   return hidSelected.Value;
    //}

    #endregion

    #region Private Functions and Methods

    private void InitializeControls()
    {
        lbLeft.Rows = Rows;
        lbRight.Rows = Rows;
        if (m_TextLeft.Trim() == string.Empty && m_TextRight.Trim() == string.Empty)
        {
            trLabels.Visible = false;
        }
        else
        {
            lblTextLeft.Text = m_TextLeft;
            lblTextRight.Text = m_TextRight;
        }
    }

    private void Clear()
    {
        lbLeft.Items.Clear();
        lbRight.Items.Clear();
        SelectdValues = string.Empty;
    }

    private void RegScriptBlock()
    {
        string script = "";

        script = string.Format("MoveItems( {0}, {1}, itemsMain{2}, itemsLeft{2}, itemsRight{2});", lbLeft.ClientID, lbRight.ClientID, this.ClientID);
        script += string.Format("GetSelectedItems(itemsRight{0},{1});", this.ClientID, hidSelected.ClientID);
        btnToRight.Attributes.Add("onclick", script);

        script = string.Format("MoveAllItems( {0}, {1} ,itemsMain{2}, itemsLeft{2}, itemsRight{2});", lbRight.ClientID, lbLeft.ClientID, this.ClientID);
        script += string.Format("GetSelectedItems(itemsRight{0},{1});", this.ClientID, hidSelected.ClientID);
        btnToRightAll.Attributes.Add("onclick", script);

        script = string.Format("MoveItems( {0},  {1}, itemsMain{2}, itemsRight{2}, itemsLeft{2});", lbRight.ClientID, lbLeft.ClientID, this.ClientID);
        script += string.Format("GetSelectedItems(itemsRight{0},{1});", this.ClientID, hidSelected.ClientID);
        btnToLeft.Attributes.Add("onclick", script);

        script = string.Format("MoveAllItems( {0}, {1}, itemsMain{2}, itemsRight{2}, itemsLeft{2} );", lbLeft.ClientID, lbRight.ClientID, this.ClientID);
        script += string.Format("GetSelectedItems(itemsRight{0},{1});", this.ClientID, hidSelected.ClientID);
        btnToLeftAll.Attributes.Add("onclick", script);

        ClientScriptManager cs = Page.ClientScript;

        if (!cs.IsClientScriptBlockRegistered(this.ClientID))
        {
            script = string.Format("<script language='javascript'>var itemsMain{0} = new Array();", this.ClientID);
            script += string.Format("var itemsLeft{0} = new Array();", this.ClientID);
            script += string.Format("var itemsRight{0} = new Array();", this.ClientID);
            script += string.Format("var itemsConMain{0} = new Array();</script>", this.ClientID);  //xiaoyi 20080715
            cs.RegisterClientScriptBlock(this.GetType(), this.ClientID, script);
        }

        if (!cs.IsClientScriptBlockRegistered(SCRIPT_BLOCK_MAIN))
        {
            script = "<script language='javascript'>";
            script += " function AddInitValuesToRightListBox(lbFrom, lbTo, hidList, iMain, iFrom, iTo){";
            script += "	    if(hidList==undefined) return;";
            script += "	    var arrSelected = hidList.value.split(\",\");";
            script += "	    for(var i=0; i < arrSelected.length ; i++){";
            script += "		    for(var j=0; j < iMain.length ; j++){";
            script += "			    if( arrSelected[i] == iMain[j].value ){";
            script += "				    iTo[j] = lbFrom.options[j];";
            script += "				    iFrom[j] = null; break;	}			}	}";
            script += "	    for(var i=0; i < iTo.length ; i++)   	{";
            script += "        	if(iTo[i] != null)        	{   lbTo.appendChild(iTo[i],\"<option>\");        	}    	}}";

            script += "function MoveAllItems(listBox1,listBox2, iMain, iFrom, iTo){";
            script += "    for(var i=0; i < iMain.length ; i++){";
            script += "        iFrom[i]=null;";
            script += "        iTo[i]=iMain[i];";
            script += "        if(iMain[i] != null){ listBox1.appendChild(iMain[i],\" < option > \");   }    }";
            script += "	   listBox1.style.width=300; ";
            script += "	   listBox2.style.width=300; ";
            script += " }";

            script += "function LoadListItems(listLeft, iMain,iConMain, iLeft, iRight){";                //xiaoyi 20080715
            script += "    if(listLeft==undefined)  return;";
            script += "    if(iMain.length == 0)    {";
            script += "        for(var i=0; i < listLeft.options.length  ; i++)        {";
            script += "            iMain[i] = listLeft.options[i];";
            script += "            iConMain[i] = listLeft.options[i];";                                  //xiaoyi 20080715
            script += "            iLeft[i] = listLeft.options[i];";
            script += "            iRight[i] = null;        }    }}";

            script += "function MoveItems(lbFrom, lbTo, iMain, iFrom, iTo){";

            script += "    for(var i=0; i < lbFrom.options.length  ; i++)    {";
            script += "        if(lbFrom.options[i].selected)       {";
            script += "            for(var j=0; j < iMain.length ; j++ )            {";
            script += "                if(iMain[j] == lbFrom.options[i])              {";
            script += "                    iTo[j] = lbFrom.options[i];";
            script += "                    iFrom[j]=null;";
            script += "                    break;                }            }        }    }";
            script += "    for(var i=0; i < iTo.length ; i++)    {";
            script += "        if(iTo[i] != null)        {            lbTo.appendChild(iTo[i], \" < option >\" );        }    }";
            script += "	   lbFrom.style.width=300; ";
            script += "	   lbTo.style.width=300; ";
            script += "	   }";

            script += "function GetSelectedItems(iRight, hid){ ";
            script += "    hid.value = \"\";   ";
            script += "    for(var i=0; i < iRight.length  ; i++)    {";
            script += "        if(iRight[i] != null )        {";
            script += "            if(hid.value != \"\")";
            script += "                hid.value = hid.value + \",\";";
            script += "            hid.value = hid.value + iRight[i].value   ;        }    } ";
            script += "    }";

            script += "</script>";

            cs.RegisterClientScriptBlock(this.GetType(), SCRIPT_BLOCK_MAIN, script);
        }

        script = "<script language='javascript'>";
        script += string.Format("LoadListItems( {2}.{0}, itemsMain{1}, itemsConMain{1}, itemsLeft{1}, itemsRight{1}); ", lbLeft.ClientID, this.ClientID, Page.Form.ClientID);                         //xiaoyi 20080715
        script += string.Format("AddInitValuesToRightListBox({4}.{0}, {4}.{1}, {4}.{2}, itemsMain{3}, itemsLeft{3}, itemsRight{3});", lbLeft.ClientID, lbRight.ClientID, hidSelected.ClientID, this.ClientID, Page.Form.ClientID);
        script += "</script>";
        cs.RegisterStartupScript(Page.GetType(), this.ClientID, script);
    }

    #endregion

}