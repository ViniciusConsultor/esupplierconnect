<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="AckExpeditingList.aspx.cs" Inherits="Expediting_AckExpeditingList" Title="eProcurement System" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Acknowledge Expedite Deliveries</asp:Label></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
     <asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel>

    <br />
    <asp:Panel CssClass="GreyTable" ID="plResult" runat="server" > 
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" >
                <asp:Label ID="lblCount" runat="server" CssClass="labelMessage" ></asp:Label>
            </td>
            <td width="100%"></td>
        </tr> 
    </table>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 20px">
                <asp:GridView Width="100%" ID="gvData" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                   AllowSorting="false" CellPadding="2" OnPageIndexChanging ="gvData_PageIndexChanging" OnRowDataBound="gvData_RowDataBound">
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
                        <asp:TemplateField HeaderText=" Order Number " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:LinkButton runat="server" ID="lbhlOrderNo" Text=' <%# Eval("OrderNumber") %> ' OnClick="hlOrderNo_OnClick"></asp:LinkButton>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="15%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Supplier Id " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblSupplierId" runat="server" CssClass="" Text='<%# Eval("SupplierId") %> '></asp:Label>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="10%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Order Date " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblOrderDate" runat="server" CssClass="" Text=' <%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("OrderDate")))) %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="15%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Order Amount " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                            <asp:Label ID="lblAmount" runat="server" CssClass="" Text='<%# Eval("OrderAmount") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="10%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" GST <br> Amount " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                            <asp:Label ID="lblGSTAmount" runat="server" CssClass="" Text='<%# Eval("GstAmount") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Currency <br> Code " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%">
                                            <asp:Label ID="lblCurrency" runat="server" CssClass="" Text='<%# Eval("CurrencyCode") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Payment Terms " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="lblPaymentTerms" runat="server" CssClass="" Text='<%# Eval("PaymentTerms") %>'></asp:Label>
                                        </tdP
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="15%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Buyer Name " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="lblBuyer" runat="server" CssClass="" Text='<%# Eval("BuyerName") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="15%"/>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
	        </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>
