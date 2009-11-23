<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="UserManagement_UserList" Title="User Management" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server"><asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
    <asp:TableHeaderRow>
        <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
            <asp:Label ForeColor="White" ID="lblSubPath" runat="server">User List</asp:Label></asp:TableCell>
    </asp:TableHeaderRow>
</asp:Table> <asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel> <asp:Panel CssClass="GreyTable" ID="plResult" runat="server" width="100%" ><table cellspacing="0" cellpadding="0" width="100%" border="0"><tr><td nowrap="nowrap" align="right" style="height:30px" ><asp:HyperLink ID="hypCreateNew" runat="server" Text="Creat New User" NavigateUrl="~/UserManagement/User.aspx" font-bold="True" /> </td></tr></table><table cellspacing="0" cellpadding="0" width="100%" border="0"><tr><td valign="top" colspan="10" style="height: 20px"><asp:GridView Width="100%" ID="gvData" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                       AllowSorting="false" CellPadding="2">
                        <Columns>
                            <asp:TemplateField HeaderText="S/N" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
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
                                            <td Width="100%" nowrap="nowrap">
                                                <asp:LinkButton runat="server" ID="lbhlUserID" Text=' <%# Eval("UserID") %> '></asp:LinkButton>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                                </ItemTemplate> 
                                <ItemStyle Wrap="false" Width="15%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Name" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap">
                                                <asp:Label ID="lblUserName" runat="server" CssClass="" Text='<%# Eval("UserName") %> '></asp:Label>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                                </ItemTemplate> 
                                <ItemStyle Wrap="false" Width="10%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Role" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap">
                                                <asp:Label ID="lblRole" runat="server" CssClass="" Text=' <%# Eval("UserRole") %> '></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                                </ItemTemplate> 
                                <ItemStyle Wrap="false" Width="15%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Email" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblEmail" runat="server" CssClass="" Text='<%# Eval("UserEmail") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </ItemTemplate> 
                                <ItemStyle Width="10%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Status" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" align="right">                                            
                                                <asp:Label ID="lblStatus" runat="server" CssClass="" Text='<%# Eval("UserStatus") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </ItemTemplate> 
                                <ItemStyle Width="5%"/>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView> </td></tr><tr><td valign="top" colspan="10" align="right" style="height: 20px"><asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" /> </td></tr></table></asp:Panel>
</asp:Content>

