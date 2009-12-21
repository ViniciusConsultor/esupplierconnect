<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageNoMenu.master" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Common_Logout" Title="Logout Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
         <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnOk" runat="server" Text="Back To Login Page" OnClick="btnOk_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

