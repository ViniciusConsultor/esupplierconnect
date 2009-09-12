<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageSimple.master" AutoEventWireup="true" CodeFile="AcknowledgePurchaseOrder.aspx.cs" Inherits="PurchaseOrder_AcknowledgePurchaseOrder" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Acknowledge Order</asp:Label></asp:TableCell>
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
		        <table id="DetailsTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr >
                        <td class="DetailsTableCaption">Vendor Address</td> 
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
                        <td class="DetailsTableCaption" colspan="2">Information</td> 
                        <td>
                            <asp:HyperLink runat="server" ID="hlHeaderText" Text='Texts'></asp:HyperLink>  
                        </td>
                    </tr> 
                    <tr>
                        <td Width="40%"><asp:Label runat="server" ID="Label1">Document Number</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td Width="60%"><asp:Label runat="server" ID="lblOrderNumber" CssClass="labelValue">OrderNumber</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label2">Document Date</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblOrderDate" CssClass="labelValue">Document Date</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label4">Vendor Number</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblSupplierId" CssClass="labelValue">Vendor Number</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label6">Payment Terms</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblPaymentTerm" CssClass="labelValue">Payment Terms</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label8">Description</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblRemarks" CssClass="labelValue">Description</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label10">Buyer Name</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblBuyer" CssClass="labelValue">Buyer Name</asp:Label></td> 
                    </tr>
                     <tr>
                        <td><asp:Label runat="server" ID="Label12">Phone</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblPhone" CssClass="labelValue">Phone</asp:Label></td> 
                    </tr>
                     <tr>
                        <td><asp:Label runat="server" ID="Label14">Currency</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblCurrency" CssClass="labelValue">Currency</asp:Label></td> 
                    </tr>
                </table> 
		    </td>
		</tr> 
	</table> 
	 <table id="tblItemHeader" cellspacing="2" cellpadding="0" width="100%" border="0">
	    <tr class="gridHeader" style="height:25px">
	        <td style="vertical-align:middle; text-align:center;" width="10%">Item No</td>
	        <td style="vertical-align:middle; text-align:center;" width="30%">Material/Description</td>
	        <td style="vertical-align:middle; text-align:center;" width="10%">Quantity</td>
	        <td style="vertical-align:middle; text-align:center;" width="15%">UM</td>
	        <td style="vertical-align:middle; text-align:center;" width="10%">Price Unit</td>
	        <td style="vertical-align:middle; text-align:center;" width="10%">Net Price</td>
	        <td style="vertical-align:middle; text-align:center;" width="15%">Net Amount</td>
	    </tr>
	 </table>
	 <asp:GridView Width="100%" ID="gvItem" runat="server" AllowPaging="false" AutoGenerateColumns="False" 
       AllowSorting="false" CellPadding="2" OnRowDataBound="gvItem_RowDataBound" ShowHeader="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellspacing="2" cellpadding="0" border="0" width="100%">
                         <tr>
                            <td rowspan="3" width="10%">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblItemNo" runat="server" CssClass="" Text=' <%# Eval("PurchaseItemSequenceNumber") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </td>
                            <td width="30%">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblMaterialNumber" runat="server" CssClass="" Text=' <%# Eval("MaterialNumber") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </td>
                            <td width="10%">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap" align="right">
                                            <asp:Label ID="lblOrderQuantity" runat="server" CssClass="" Text=' <%# Eval("OrderQuantity") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </td>
                            <td width="15%">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblUnitofMeasure" runat="server" CssClass="" Text=' <%# Eval("UnitofMeasure") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </td>
                             <td width="10%">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap" align="right">
                                            <asp:Label ID="lblPricePerUnit" runat="server" CssClass="" Text=' <%# Eval("PricePerUnit") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </td>
                             <td width="10%">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap" align="right">
                                            <asp:Label ID="lblNetPrice" runat="server" CssClass="" Text=' <%# Eval("NetPrice") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </td>
                             <td width="15%">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap" align="right">
                                            <asp:Label ID="lblNetAmount" runat="server" CssClass="" Text=''></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblShortText" runat="server" CssClass="" Text=' <%# Eval("ShortText") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </td>
                            <td colspan="5" align="left">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td nowrap="nowrap" align="right">
                                            <asp:HyperLink runat="server" ID="hlItemText" Text='Texts'></asp:HyperLink>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <td nowrap="nowrap" align="right">
                                            <asp:HyperLink runat="server" ID="hlComponent" Text='Components'></asp:HyperLink>
                                        </td>
                                        <td>&nbsp;&nbsp;</td>
                                        <td nowrap="nowrap" align="right">
                                            <asp:HyperLink runat="server" ID="hlService" Text='Services'></asp:HyperLink>
                                        </td>
                                       <td width="100%">&nbsp;</td>
                                    </tr>
                                </table>  
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="left">
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:GridView BorderWidth="0" ShowHeader="false" AllowPaging="false" width="100%" ID="gvSchedule" runat="server" 
                                            AutoGenerateColumns="False" OnRowDataBound="gvSchedule_RowDataBound" >
                                                <HeaderStyle  Height="10px" ForeColor="black"  BackColor="gray"/>
                                                <AlternatingRowStyle CssClass="" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>
                                                                        Delivery
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                            </table> 
                                                        </ItemTemplate>
                                                        <ItemStyle Width = "15%" HorizontalAlign="left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField >
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td Width="100%" nowrap="nowrap">
                                                                        <asp:Label ID="lblPurchaseOrderScheduleSequence" runat="server" CssClass="" Text='<%#  Eval("PurchaseOrderScheduleSequence") %> '></asp:Label>
                                                                    </td>
                                                                   <td>&nbsp;</td>
                                                                </tr>
                                                            </table>  
                                                        </ItemTemplate> 
                                                        <ItemStyle Wrap="false" Width="15%"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Order Date" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td Width="100%" nowrap="nowrap">
                                                                        <asp:Label ID="lblOrderItemScheduleDate" runat="server" CssClass="" Text=' <%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("OrderItemScheduleDate")))) %> '></asp:Label>
                                                                    </td>
                                                                   <td>&nbsp;</td>
                                                                </tr>
                                                            </table>  
                                                        </ItemTemplate> 
                                                        <ItemStyle Wrap="false" Width="25%"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField >
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td Width="100%" nowrap="nowrap">
                                                                        <asp:Label ID="lblDeliveryScheduleQuantity" runat="server" CssClass="" Text=' <%#  Eval("DeliveryScheduleQuantity") %> '></asp:Label>
                                                                    </td>
                                                                   <td>&nbsp;</td>
                                                                </tr>
                                                            </table>  
                                                        </ItemTemplate> 
                                                        <ItemStyle Wrap="false" Width="10%"/>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField >
                                                        <ItemTemplate>
                                                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td nowrap="nowrap">
                                                                        Ack.Dt 
                                                                    </td>
                                                                    <td nowrap="nowrap">&nbsp;&nbsp;</td>
                                                                    <td Width="100%" nowrap="nowrap">
                                                                        <DatePicker:DatePicker ID="dtpAck" runat="server" />
                                                                        <asp:HiddenField ID="hdAckDate" Visible="false" runat="server" Value=' <%# Eval("AcknowledgementDate")%> '></asp:HiddenField>
                                                                    </td>
                                                                   <td>&nbsp;</td>
                                                                </tr>
                                                            </table>  
                                                        </ItemTemplate> 
                                                        <ItemStyle Wrap="false" Width="35%"/>
                                                    </asp:TemplateField>
                                                </Columns> 
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>  
                            </td>
                        </tr>
                    </table> 
                </ItemTemplate>
                <ItemStyle Width = "100%" HorizontalAlign="left" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnReturn" runat="server" Text="Return" onclick="btnReturn_Click"/>
            </td>
            <td nowrap="nowrap">&nbsp;&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"/>
            </td>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
        </tr> 
    </table>
    <br />
	<script language="javascript" type="text/javascript">    
    
        function ShowHeaderText(orderNumber)
        {
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:768px;dialogWidth:1024px;dialogHide:true";    
            MyArgs = window.showModalDialog("PurchaseOrderHeaderText.aspx?" + Math.random()*5 + "&OrderNumber=" + orderNumber , MyArgs, WinSettings);
        }
        
        function ShowItemText(orderNumber,itemNo)
        {
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:768px;dialogWidth:1024px;dialogHide:true";    
            MyArgs = window.showModalDialog("PurchaseOrderItemText.aspx?" + Math.random()*5 + "&OrderNumber=" + orderNumber + "&ItemNo=" + itemNo, MyArgs, WinSettings);
        }
        function ShowComponent(orderNumber,itemNo)
        {
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:768px;dialogWidth:1024px;dialogHide:true";    
            MyArgs = window.showModalDialog("PurchaseOrderComponents.aspx?" + Math.random()*5 + "&OrderNumber=" + orderNumber + "&ItemNo=" + itemNo, MyArgs, WinSettings);
            
        }
         function ShowService(orderNumber,itemNo)
        {
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:768px;dialogWidth:1024px;dialogHide:true";    
            MyArgs = window.showModalDialog("PurchaseOrderServices.aspx?" + Math.random()*5 + "&OrderNumber=" + orderNumber + "&ItemNo=" + itemNo, MyArgs, WinSettings);
            
        }
    </script>	
</asp:Content>

