<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="CreateDeliveryOrder.aspx.cs" Inherits="CreateDeliveryOrder" %>


<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server"><asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
    <asp:TableHeaderRow>
        <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
            <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Create Delivery Order</asp:Label>
            </asp:TableCell>
    </asp:TableHeaderRow>
    </asp:Table> 
    <asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel> 
    <asp:Panel CssClass="GreyTable" ID="plSearch" runat="server" Visible="true" width="100%">
    <table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
    <td valign="top" style="height: 8px">
    <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">
    <tr>
    <td align="left" style="height: 20px" ><asp:Label ID="lblOrderNo" runat="server" Width="130px" Text="Order No"></asp:Label> </td>
    <td  align="left" style="width: 70%; height: 20px;" ><asp:Label runat="server" id="lblOrderNoValue"></asp:Label> </td></tr>
    <tr>
    <td align="left" style="height: 4px" ><asp:Label ID="lblItemSequence" runat="server" Width="130px" Text="Item Sequence"></asp:Label> </td>
    <td align="left" style="width: 70%; height: 4px;"><asp:Label runat="server" id="lblItemSequenceValue"></asp:Label> </td>
    </tr>
    <tr><td align="left" ><asp:Label ID="lblMaterialNo" runat="server" Text="Material No" Width="130px"></asp:Label> </td>
    <td align="left" style="width: 70%; height: 20px;"><asp:Label runat="server" id="lblMaterialNoValue"></asp:Label></td>
    </tr>
    <tr><td align="left" ><asp:Label ID="lblDeliveryNo" runat="server" Width="130px" Text="Delivery No"></asp:Label> </td>
    <td  align="left" style="width: 70%;" ><asp:TextBox runat="server" id="txtDeliveryNo"></asp:TextBox>  </td>
    </tr>
    <tr><td align="left" ><asp:Label ID="lblDeliveryDate" runat="server" Width="130px" Text="Delivery Date"></asp:Label> </td>
     
                                        <td align="left" style="width:200px">
                                             <DatePicker:DatePicker ID="dtpFrom" runat="server" />
                                        </td>
    </tr>
    <tr style="display:none"><td align="left" ><asp:Label ID="lblDeliveryQty" runat="server" Width="130px" Text="Delivery Qty"></asp:Label> </td>
    <td  align="left" style="width: 100%" colspan=4><asp:TextBox runat="server" id="txtDeliveryQty" Width="90px"></asp:TextBox> </td>
    </tr>
    
    <tr><td colspan="9" style="text-align: right"><asp:Button ID="btnSave" runat="server" Text="Save"/> <asp:Button ID="btnCancel" runat="server" Text="Cancel"/> </td>
    </tr>
    </table>
    </td>
    </tr>
    </table></asp:Panel> 
</asp:Content>
