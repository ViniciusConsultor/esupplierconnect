<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="UserManagement_UserList" Title="User Management" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">User List</asp:Label></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table> 
    <asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel> 
    <asp:Panel CssClass="GreyTable" ID="plResult" runat="server" width="100%" >
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr valign="middle">
                <td align="right" style="height:30px;" >
                    <asp:HyperLink ID="hypCreateNew" runat="server" Text="Create New User" NavigateUrl="~/UserManagement/User.aspx?Type=New" font-bold="True" /> 
                </td>
            </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr><td valign="top">
                <asp:GridView Width="100%" ID="gvData" runat="server" OnRowDataBound="gvData_RowDataBound" AllowPaging="True" AutoGenerateColumns="False" 
                        DataKeyNames="UserID" AllowSorting="false" CellPadding="2" EmptyDataText="No users found.">
                        <Columns>
                            <asp:TemplateField HeaderText="S/N" HeaderStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <span><%# Container.DataItemIndex + 1 %></span>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </ItemTemplate>
                                <ItemStyle Width = "5%" HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User ID" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td width="100%" nowrap="nowrap">
                                                <asp:HyperLink runat="server" ID="lbhlUserID" Text='<%# Eval("UserID") %>' ></asp:HyperLink>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                                </ItemTemplate> 
                                <ItemStyle Wrap="false" Width="12%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Name" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td width="100%" nowrap="nowrap">
                                                <asp:Label ID="lblUserName" runat="server" CssClass="" Text='<%# Eval("UserName") %> '></asp:Label>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                                </ItemTemplate> 
                                <ItemStyle Wrap="false" Width="17%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Email" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td width="100%" align="left">
                                                <asp:Label ID="lblEmail" runat="server" CssClass="" Text='<%# Eval("UserEmail") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </ItemTemplate> 
                                <ItemStyle Width="25%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Role" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td width="100%" nowrap="nowrap">
                                                <asp:Label ID="lblRole" runat="server" CssClass="" Text=' <%# Eval("UserRole") %> '></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                                </ItemTemplate> 
                                <ItemStyle Wrap="false" Width="15%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Profile Type" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td width="100%" nowrap="nowrap">
                                                <asp:Label ID="lblType" runat="server" CssClass="" Text=' <%# Eval("ProfileType") %> '></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                                </ItemTemplate> 
                                <ItemStyle Wrap="false" Width="16%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Active?" HeaderStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td width="100%" align="center">                                            
                                                <asp:Label ID="lblStatus" runat="server" CssClass="" Text='<%# Eval("UserStatus") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </ItemTemplate> 
                                <ItemStyle Width="5%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                <HeaderTemplate>
                                    Select<%--&nbsp;<input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />--%>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkDelete" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView> 
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="10" align="left" style="height: 20px">
                    <asp:Button ID="btnReset" runat="server" Text="Reset Password" OnClick="btnReset_Click" /> 
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /> 
                    <asp:Label ID="lblError" runat="server" CssClass="labelErrorMessage" />
                    <asp:Label runat="server" ID="lblMsg" CssClass="" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

