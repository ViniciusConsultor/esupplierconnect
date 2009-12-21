<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageNoMenu.master" AutoEventWireup="true" CodeFile="Timeout.aspx.cs" Inherits="Common_Timeout" Title="TimeOut Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <table align="center" border="1" cellpadding="0" cellspacing="0" width="80%" style="height:300px; margin-top:100px;">
        <tr>
            <!-- image -->
            <td align="center" valign="middle" style="width:20%">
                <asp:Image ID="Image3" ImageUrl="~/Images/Common/timeOut.jpg" runat="server" />
            </td>
            <!-- content -->
            <td align="center" valign="middle" style="width:60%">
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td valign="middle">
                            <div class="labelErrorMessage" style="font-size:14px;">Sorry, you have no access to this page!</div>
                        </td>
                    </tr>
                    <tr>
                        <td class="labelMessage">
                            You have no access to this page, Due to any of the following reasons:
                        </td>
                    </tr>
                    <tr>
                        <td class="timeOutText">
                            <ul>
                                <li>You do not have enough privilege to access this page</li>
                                <li>You may have logged out of the System</li>
                                <li>You may have not used the system for more than 30 minutes</li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td class="timeOutText">Please <a href="..\login.aspx">Re-Login</a> to continue your session</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

