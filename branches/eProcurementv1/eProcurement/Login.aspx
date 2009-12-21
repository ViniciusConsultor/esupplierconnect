<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageNoMenu.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Login Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<table id="Maintable" width="776" border="0" align="center" cellpadding="0" cellspacing="0" >
    <tr>
        <td valign="middle" align="center">
        <br><br><br><br><br><br><br><br>
        <table id="Table1" border="0" cellpadding="0" cellspacing="0" style="width: 684px">
            <tr>
                <td style="height: 259px; width: 213px;" valign="bottom">
                </td>
                <td  style="height: 259px; width: 350px;" valign="bottom" align="center">
                    <table id="LoginTable" style="height:10px" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top" style="width: 254px; height: 20px;">
                                <table id="tableControls" border="0" cellspacing="0" cellpadding="0" style="width: 238px">
                                      <tr valign="top">
                                        <td width="80" style="height: 38px">User Id</td>
                                        <td width="101" style="height: 38px"> <asp:TextBox ID="txtUserName"  MaxLength="15" runat="server" Width="152px"></asp:TextBox></td>
                                      </tr>
                                      
                                      <tr valign="top">
                                        <td width="80" style="height: 38px">Password</td>
                                        <td width="101" style="height: 38px"> <asp:TextBox ID="txtPassword"  TextMode="Password" runat="server" Width="152px"  MaxLength="36"  ></asp:TextBox></td>
                                      </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td  style="height:46px; width: 254px;">
                                <table id="login" width="227" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="78" style="height: 35px">&nbsp;</td>
                                        <td width="58" style="height: 35px"><asp:ImageButton id="imgbtnLogin" runat="server"  imageurl="~/Images/Common/login.gif" width="58" height="33" OnClick="ImgbtnLogin_Click"  /></td>
                                        <td width="56" style="height: 35px">
                                        <asp:ImageButton id="imgbtnReset" OnClientClick="javascript:document.frmMaster.reset()" runat="server" imageurl="~/Images/Common/reset.gif"  AlternateText="Reset" width="56" height="33"  /></td>
                                        <td width="35" style="height: 35px">&nbsp;</td>
                                    </tr>
                                </table>
                                <br><br><br><br>
                                <table id="Message" width="250" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top"  colspan="5" >By logging on to eProcurement System, you confirm that you are an authorised eProcurement System User. Any misuse may be subjected to disciplinary action.
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="width: 254px; height: 9px;" >
                                <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="303" style="height: 259px" valign="bottom">
                </td>
            </tr>
        </table>
        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName" Display="None" ErrorMessage="Please enter a User ID"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Please enter a Password"></asp:RequiredFieldValidator>&nbsp;<asp:ValidationSummary
            ID="vsyLogin" runat="server" ShowMessageBox="True" ShowSummary="False" />
        </td>
    </tr>
</table>
</asp:Content>

