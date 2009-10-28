<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageSimple.master" AutoEventWireup="true" CodeFile="PurchaseOrderItemText.aspx.cs" Inherits="PurchaseOrder_PurchaseOrderItemText" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Purchase Order Item Line Text</asp:Label></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel>
    <table id="DetailsTable" width="100%" border="2" cellspacing="2" cellpadding="2" bordercolor="Gainsboro">
		<tr>
		    <td colspan=2 align="center" class="DetailsTableCaption">Purchase Order Information</td>
		</tr>
		<tr>
		    <td width="50%">
		        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr >
                        <td class="DetailsTableCaption">Supplier Address</td> 
                    </tr> 
                    <tr>
                        <td><asp:Label runat="server" ID="lblSupplierName" CssClass="labelValue">SupplierName</asp:Label></td> 
                    </tr> 
                    <tr>
                        <td><asp:Label runat="server" ID="lblSupplierAddress" CssClass="labelValue">SupplierAddress</asp:Label></td> 
                    </tr> 
                    <tr>
                        <td><asp:Label runat="server" ID="lblPostalCode" CssClass="labelValue">PostalCode</asp:Label></td> 
                    </tr> 
                    <tr>
                        <td><asp:Label runat="server" ID="lblCountry" CssClass="labelValue">Country</asp:Label></td> 
                    </tr> 
                    <tr>
                        <td class="DetailsTableCaption">Shipping Address</td> 
                    </tr> 
                    <tr>
                        <td><asp:Label runat="server" ID="lblShipmentAddress" CssClass="labelValue">ShipmentAddress</asp:Label></td> 
                    </tr> 
                </table> 
		    </td>
		    <td width="50%" style="vertical-align:top">
		        <table id="tabl1" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td colspan="3" class="DetailsTableCaption" colspan="2">Information</td> 
                    </tr> 
                    <tr>
                        <td Width="40%"><asp:Label runat="server" ID="Label1">Order Number</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td Width="60%"><asp:Label runat="server" ID="lblOrderNumber" CssClass="labelValue">Order Number</asp:Label></td> 
                    </tr>
                    <tr>
                        <td Width="40%"><asp:Label runat="server" ID="Label3">Supplier Id</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblSupplierId" CssClass="labelValue">Supplier Id</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label2">Order Date</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblOrderDate" CssClass="labelValue">Order Date</asp:Label></td> 
                    </tr>
                     <tr>
                        <td><asp:Label runat="server" ID="Label4">Order Amount</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblOrderAmount" CssClass="labelValue">Order Amount</asp:Label></td> 
                    </tr>
                     <tr>
                        <td><asp:Label runat="server" ID="Label5">GST Amount</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblGSTAmount" CssClass="labelValue">GST Amount</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label14">Currency Code</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblCurrency" CssClass="labelValue">Currency</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label6">Payment Terms</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblPaymentTerm" CssClass="labelValue">Payment Terms</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label10">Buyer Name</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblBuyer" CssClass="labelValue">Buyer Name</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label12">Sale Person</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblSalePerson" CssClass="labelValue">Sale Person</asp:Label></td> 
                    </tr>
                     <tr>
                        <td><asp:Label runat="server" ID="Label7">Remarks</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblRemarks" CssClass="labelValue">Remarks</asp:Label></td> 
                    </tr>
                </table> 
		    </td>
		</tr> 
	</table> 
	<br/>
	<table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 20px">
                <asp:Repeater ID="gvItem" runat="server">
                    <HeaderTemplate>
                        <table width="100%">
                            <tr class="gridHeader" style="height:25px">
	                            <td style="vertical-align:middle; text-align:center;" width="5%">Item<BR>Seq</td>
	                            <td style="vertical-align:middle; text-align:center;" width="15%">Material/<BR>Description</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Order Qty/<BR>Unit Measure</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Price<BR>Unit</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Net<BR>Price</td>
	                            <td style="vertical-align:middle; text-align:center;" width="15%">Remarks</td>
	                            <td style="vertical-align:middle; text-align:center;" width="5%">Delivery<BR>Qty</td>
	                            <td style="vertical-align:middle; text-align:center;" width="12%">Long Text</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Ref. Order</td>
	                            <td style="vertical-align:middle; text-align:center;" width="13%">Storage Location</td>
	                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr class="odd" style="height:25px; font-weight:normal;">
	                            <td>
	                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap">
                                                <asp:Label ID="lblItemSequence" runat="server" CssClass="" Text='<%# Eval("PurchaseItemSequenceNumber") %> '></asp:Label> 
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
	                            </td>
	                            <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap">
                                                <asp:Label ID="lblMaterialNumber" runat="server" CssClass="" Text='<%# Eval("MaterialNumber") %> '></asp:Label> 
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%">
                                                <asp:Label ID="lblShortText" runat="server" CssClass="" Text='<%# Eval("ShortText") %> '></asp:Label> 
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                               </td> 
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblOrderQuantity" runat="server" CssClass="" Text='<%# Eval("OrderQuantity") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap" align="right">
                                                <asp:Label ID="lblUnitMeasure" runat="server" CssClass="" Text='<%# Eval("UnitofMeasure") %> '></asp:Label>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </td>
                                 <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblPricePer" runat="server" CssClass="" Text='<%# Eval("PricePerUnit") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblNetPrice" runat="server" CssClass="" Text='<%# Eval("NetPrice") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%">
                                                <asp:Label ID="lblRemark" runat="server" CssClass="" Text='<%# Eval("Remarks") %> '></asp:Label>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                               </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblDeliverQuantity" runat="server" CssClass="" Text='<%# Eval("DeliveredQuantity") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%">
                                                <asp:Label ID="lblLongText" runat="server" CssClass="" Text='<%# Eval("LongTextDescription") %> '></asp:Label>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                               </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%">
                                                <asp:Label ID="lblReferenceOrder" runat="server" CssClass="" Text='00000000002 '></asp:Label>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                               </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%">
                                                <asp:Label ID="lblStorageLocation" runat="server" CssClass="" Text='<%# Eval("StorageLocation") %> '></asp:Label>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                                </td>
	                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                      </table>
                    </FooterTemplate>
                  </asp:Repeater>
                 </td> 
           </tr> 
      </table> 
      <br/>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 20px">
                <asp:GridView Width="100%" ID="gvData" runat="server" AllowPaging="false" AutoGenerateColumns="False" 
                   AllowSorting="false" CellPadding="2" OnRowDataBound="gvData_RowDataBound" >
                    <Columns>
                        <asp:TemplateField HeaderText="Text Sequence Number" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblTextSerialNumber" runat="server" CssClass="" Text='<%# Eval("TextSequence") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="20%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Long Text" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" wrap="wrap">
                                            <asp:Label ID="lblLongText" runat="server" CssClass="" Text=' <%# Eval("LongText") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="80%"/>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
	        </td>
        </tr>
    </table>
    <br />
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
            <td nowrap="nowrap">
                <Input class="formbutton" type=button name="rtnbtn" value="Return" onclick="javascript:window.close();">
            </td>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
        </tr> 
    </table>
</asp:Content>

