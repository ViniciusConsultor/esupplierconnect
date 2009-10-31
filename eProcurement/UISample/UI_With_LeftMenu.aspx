<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="UI_With_LeftMenu.aspx.cs" Inherits="UISample_UI_With_LeftMenu" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<%@ Register Src="~/UserControls/DualList.ascx" TagName="DualList" TagPrefix="DualList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<!--Page title-->
<asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
    <asp:TableHeaderRow>
        <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
            <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Page title</asp:Label></asp:TableCell>
    </asp:TableHeaderRow>
</asp:Table>
<!--Message Panel-->
<asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
</asp:Panel>
<!--Search Criteria Panel-->
 <asp:Panel ID="plSearch" runat="server" Visible="true">
    <table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="top" style="height: 8px">
               <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">
                     <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="Label3" runat="server" Text="Title1"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:Label ID="lblTitle1" runat="server" CssClass="labelValue" >fsdfsfd</asp:Label>
                        </td>
                    </tr>
                    <tr>
                       <td align="left" nowrap Width="130px">
                            <asp:Label ID="Label4" runat="server" Text="Title2"></asp:Label>
                            <span class="redtxt">*</span> 
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:TextBox runat="server" id="textbox1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="Label1" runat="server" Text="Supplier"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%;">
                            <asp:TextBox runat="server" id="TextBox2"></asp:TextBox>
                            <img style="cursor: hand; vertical-align:middle" id="imgSupplierSearch" height="20" src="../Images/Common/Search.gif" runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="lbl1" runat="server" Text="Title3"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:DropDownList ID="ddlIspType" runat="server" AutoPostBack="false">
                                <asp:ListItem value="0" Text=""></asp:ListItem>
                                <asp:ListItem value="1" Text="Text 1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="Label2" runat="server" Text="Title4"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                             <DatePicker:DatePicker ID="DatePicker1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="lblTitleIspDate" runat="server" Text="Title4"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                            <table id="tblDates" cellpadding="0" cellspacing="0">
                                <tr valign="middle">
                                    <td valign="middle">
                                        <asp:Label ID="lblFrom" Text="From" runat="server"></asp:Label>&nbsp;</td>
                                    <td align="center" style="width:150px">
                                         <DatePicker:DatePicker ID="dpIspDateStart" runat="server" />
                                    </td>
                                    <td align="right" valign="middle">
                                        <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>&nbsp;</td>
                                    <td align="center" style="width:150px">
                                        <DatePicker:DatePicker ID="dpIspDateEnd" runat="server" />
                                    </td>
                                </tr>
                           </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="Label5" runat="server" Text="Title4"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                             <DualList:DualList ID="DualList1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:Button ID="btnSearch" runat="server" Text="Search"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel> 
    <br />
    <!--Search Result Panel-->
<asp:Panel ID="plResult" runat="server" > 
    <!--Display Result Number-->
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
                        <asp:TemplateField HeaderText=" Order Number " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:LinkButton runat="server" ID="lbhlOrderNo" Text=' <%# Eval("OrderNumber") %> '></asp:LinkButton>  
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
