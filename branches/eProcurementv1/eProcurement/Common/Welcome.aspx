<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Common_Welcome" Title="Welcome Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<br />
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left" valign="top">
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>&nbsp;&nbsp;</td>
                        <td></td>
                        <td>&nbsp;&nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                             <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="style1">
                                        <asp:Literal ID="UserNameLiteral" runat="server"></asp:Literal>Welcome to 
                                        <span class="style4">eProcurement System
                                        <asp:Label ID="Label5" runat="server" Width="100px"></asp:Label>
                                        <asp:Label ID="lblMessage" runat="server" BackColor="White" Visible="False"></asp:Label>
                                            &nbsp;
                                         </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Literal ID="LastLoginTimeLiteral" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr><td></td></tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Literal ID="PrivacyStatementLiteral" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td></td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                 <tr><td></td></tr>
                                  <tr><td></td></tr>
                                <tr>
                                    <td>
                                        <asp:Image runat="server" ID="index_graphic" ImageUrl="~/Images/common/Welcome-2.jpg"
                                        Width="250" Height="350" />
                                    </td> 
                                 </tr> 
                             </table> 
                        </td>
                    </tr>
               </table>  
            </td>
        </tr>
    </table> 

</asp:Content>

