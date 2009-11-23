<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="UserPassword.aspx.cs" Inherits="UserManagement_UserPassword" Title="User Management" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server"><asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
    <asp:TableHeaderRow>
        <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
            <asp:Label ForeColor="White" ID="lblSubPath" runat="server">User List</asp:Label></asp:TableCell>
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
                        <td align="left" >
                            <asp:Label ID="Label4" runat="server" Width="130px" Text="User ID"></asp:Label> 
                        </td>
                        <td  align="left" style="width: 70%" >
                            <asp:Label runat="server" id="lblUserID"></asp:Label> 
                        </td>
                    </tr>                    
                    <tr><td align="left" ><asp:Label ID="lblCurrPassword" runat="server" Text="Current Password" Width="130px"></asp:Label> </td><td  align="left" style="width: 70%"><asp:TextBox runat="server" id="txtCurrPassword" textmode="Password"></asp:TextBox> </td></tr>
                    <tr><td align="left" ><asp:Label ID="lblNewPassword" runat="server" Text="New Password" Width="130px"></asp:Label> </td><td  align="left" style="width: 70%"><asp:TextBox runat="server" id="txtPassword" textmode="Password"></asp:TextBox> </td></tr>
                    <tr><td align="left" ><asp:Label ID="lblConfirmPSWD" runat="server" Width="130px" Text="Confirm Password"></asp:Label> </td><td  align="left" style="width: 70%;" ><asp:TextBox runat="server" id="txtConfirmPSWD" textmode="Password"></asp:TextBox> </td></tr>
                    <tr><td colspan="9" style="text-align: right"><asp:Button ID="btnUpdate" runat="server" Text="Update"/> <asp:Button ID="btnCancel" runat="server" Text="Cancel"/> </td></tr></table></td></tr></table></asp:Panel> 
</asp:Content>

