<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageSimple.master" AutoEventWireup="true" CodeFile="AttachmentSample.aspx.cs" Inherits="UISample_AttachmentSample" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/AttachmentPanel.ascx" TagName="AttachmentPanel" TagPrefix="AttachmentPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
    <asp:TableHeaderRow>
        <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
            <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Purchase Order List</asp:Label></asp:TableCell>
    </asp:TableHeaderRow>
</asp:Table>

<table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td valign="top" style="height: 8px">
             RFQ Number: <asp:TextBox runat="server" ID="txtNo"></asp:TextBox>                 
        </td>
    </tr>
    <tr>
        <td valign="top" style="height: 8px">
             ReadOnly:  <asp:DropDownList ID="ddlReadonly" runat="server" AutoPostBack="false">
                                <asp:ListItem Value ="Y" Text="Y"></asp:ListItem>
                                <asp:ListItem Value ="N" Text="N"></asp:ListItem>
                                </asp:DropDownList>               
        </td>
    </tr>
    <tr>
        <td valign="top" style="height: 8px">
             New Attachment IDs : <asp:TextBox runat="server" ID="txtIds" Width="500px"></asp:TextBox>                 
        </td>
    </tr>
     <tr>
        <td valign="top" style="height: 8px">
             <asp:Button ID="btnInit" runat="server" Text="Init Attachment Panel" OnClick="btnInit_Click"/>      
        </td>
    </tr>
    <tr>
        <td valign="top" style="height: 8px">
             <asp:Button ID="btnGet" runat="server" Text="Get New Attachment IDs" OnClick="btnGet_Click"/>      
        </td>
    </tr>
    <tr>
        <td valign="top" style="height: 8px">
             <AttachmentPanel:AttachmentPanel ID="attPanel" runat="server" />                   
        </td>
    </tr>
</table>


</asp:Content>

