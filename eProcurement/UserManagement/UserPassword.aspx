<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="UserPassword.aspx.cs" Inherits="UserManagement_UserPassword" Title="User Management" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server"><asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
    <asp:TableHeaderRow>
        <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
            <asp:Label ForeColor="White" ID="lblSubPath" runat="server">User List</asp:Label></asp:TableCell>
    </asp:TableHeaderRow>
    </asp:Table> 
    <asp:Panel ID="plMessage" runat="server" Visible="false"></asp:Label>
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
                        <tr>
                            <td align="left" >
                                <asp:Label ID="lblCurrPassword" runat="server" Text="Current Password" Width="130px"></asp:Label>
                            </td>
                            <td  align="left" style="width: 70%">
                                <asp:TextBox runat="server" id="txtCurrPassword" MaxLength="10" textmode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtCurrPassword" ErrorMessage="<br />Please enter current password."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" >
                                <asp:Label ID="lblNewPassword" runat="server" Text="New Password" Width="130px"></asp:Label> 
                            </td>
                            <td align="left" style="width: 70%">
                                <asp:TextBox runat="server" id="txtNewPassword" MaxLength="10" textmode="Password"></asp:TextBox> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtNewPassword" ErrorMessage="<br />Please enter new password."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" >
                                <asp:Label ID="lblConfirmPSWD" runat="server" Width="130px" Text="Confirm Password"></asp:Label> 
                            </td>
                            <td  align="left" style="width: 70%;" >
                                <asp:TextBox runat="server" id="txtConfirmPSWD" MaxLength="10" textmode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtNewPassword" ErrorMessage="<br />Please enter confirm password."></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ControlToCompare="txtConfirmPSWD" ControlToValidate="txtNewPassword" Type="String" Operator="Equal" ErrorMessage="<br />The New password and Confirm password does not match."></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /> 
                                <asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false" OnClientClick="javascript:history.go(-1);" /> 
                                <asp:Label ID="lblError" runat="server" CssClass="labelErrorMessage" />
                                <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel> 
</asp:Content>

