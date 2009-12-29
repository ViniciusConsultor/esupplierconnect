<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="PurchaseOrderList.aspx.cs" Inherits="PurchaseOrder_PurchaseOrderList" Title="eProcurement System" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Purchase Order List</asp:Label></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
     <asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel>
    <asp:Panel CssClass="GreyTable" ID="plSearch" runat="server" Visible="true">
        <table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top" style="height: 8px">
                   <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">
                         <tr>
                            <td align="left" >
                                <asp:Label ID="Label3" runat="server" Width="130px" Text="Order Number"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <asp:TextBox runat="server" id="txtOrderNumber" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" nowrap>
                                <asp:Label ID="lblTitleIspDate" runat="server" Text="Order Date" Width="130px"></asp:Label>
                                <asp:Label ID="lblFldRequired" CssClass ="redtxt" runat="server" Text="*" Width="5px" Visible="false"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <table id="tblDates" cellpadding="0" cellspacing="0">
                                    <tr valign="middle">
                                        <td valign="middle">
                                            <asp:Label ID="lblFrom" Text="From" runat="server"></asp:Label>&nbsp;</td>
                                        <td align="center" style="width:200px">
                                             <DatePicker:DatePicker ID="dtpFrom" runat="server" />
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>&nbsp;</td>
                                        <td align="center" style="width:200px">
                                            <DatePicker:DatePicker ID="dtpTo" runat="server" />
                                        </td>
                                    </tr>
                               </table>
                            </td>
                        </tr>
                        <asp:Panel runat="server" ID="plshSupplier" Visible="false">
                        <tr>
                            <td align="left" >
                                <asp:Label ID="Label1" runat="server" Width="130px" Text="Supplier"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%;" colspan=4>
                                <asp:TextBox runat="server" id="txtSupplierId" Width="200px"></asp:TextBox>
                                <asp:Image runat="server" ID="imgSupplierSearch" ImageUrl="~/Images/Common/Search.gif" height="20"/>
                            </td>
                        </tr>
                        </asp:Panel> 
                        <asp:Panel runat="server" ID="plshBuyer" Visible="false">
                        <tr>
                            <td align="left" >
                                <asp:Label ID="Label2" runat="server" Width="130px" Text="Buyer"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <asp:TextBox runat="server" id="txtBuyer"  Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        </asp:Panel> 
                        <asp:Panel runat="server" ID="plshStatus" Visible="false">
                        <tr>
                            <td align="left" >
                                <asp:Label ID="Label4" runat="server" Width="130px" Text="Status"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        </asp:Panel> 
                        <tr>
                            <td colspan="9" style="text-align: right">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
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
    
    <script language="javascript" type="text/javascript">    
        function OpenSupplierDialog(txtSupplierId)
        {
            var customerRefNo = document.getElementById(txtSupplierId).value;        
            
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:600px;dialogWidth:720px;dialogHide:true";
            
            MyArgs = window.showModalDialog("../Dialog/SearchSupplier.aspx", MyArgs, WinSettings);
                        
            if(MyArgs != null)
            {
                document.getElementById(txtSupplierId).value = MyArgs[0].toString();
            }
        }
    </script>
</asp:Content>

