<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageSimple.master" AutoEventWireup="true" CodeFile="ProcessQuotationDetail.aspx.cs" Inherits="Quotation_ProcessQuotationDetail" Title="eProcurement System" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Purchase Order Details</asp:Label></asp:TableCell>
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
                        <td>
                            &nbsp;<asp:Label runat="server" ID="lblSupplierId" CssClass="labelValue">Supplier Id</asp:Label></td>
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
                        <td Width="40%"><asp:Label runat="server" ID="Label1">RFQ Number</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td Width="60%"><asp:Label runat="server" ID="lblRequestNumber" CssClass="labelValue">Request Number</asp:Label></td> 
                    </tr>
                    <tr>
                        <td Width="40%"><asp:Label runat="server" ID="Label2">RFQ Date</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblRFQDate" CssClass="labelValue">RFQ Date</asp:Label></td> 
                    </tr>
                    <tr>
                        <td></td> 
                        <td>&nbsp;</td>
                        <td></td> 
                    </tr>
                     <tr>
                        <td style="height: 20px"><asp:Label runat="server" ID="Label4">Expiry Date</asp:Label></td> 
                        <td style="height: 20px">&nbsp;</td>
                        <td style="height: 20px"><asp:Label runat="server" ID="lbExpiryDate" CssClass="labelValue">Expiry Date</asp:Label></td> 
                    </tr>
                     <tr>
                        <td style="height: 20px"><asp:Label runat="server" ID="Label5">Quotation Number</asp:Label></td> 
                        <td style="height: 20px">&nbsp;</td>
                        <td style="height: 20px"><asp:Label runat="server" ID="lblQuotationNo" CssClass="labelValue">Quotation Number</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label14">Quotation Date</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblQuotationDate" CssClass="labelValue">Quotation Date</asp:Label></td> 
                    </tr>
                    <tr>
                        <td style="height: 20px"><asp:Label runat="server" ID="Label6">Attachment</asp:Label></td> 
                        <td style="height: 20px">&nbsp;</td>
                        <td style="height: 20px"><asp:Label runat="server" ID="lblAttachment" CssClass="labelValue">Attachment</asp:Label></td> 
                    </tr>
                    <tr>
                        <td></td> 
                        <td>&nbsp;</td>
                        <td></td> 
                    </tr>
                    <tr>
                        <td></td> 
                        <td>&nbsp;</td>
                        <td></td> 
                    </tr>
                </table> 
		    </td>
		</tr> 
	</table> 
	<table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 20px"> 
                <asp:Repeater ID="gvItem" runat="server" OnItemDataBound="gvItem_ItemDataBound">
                    <HeaderTemplate>
                        <table width="100%">
                            <tr class="gridHeader" style="height:25px">
	                            <td style="vertical-align:middle; text-align:center;" width="15%">Material/<BR>Description</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Plant</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Required<BR>Qty</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Supply<BR>Qty</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">UOM</td>
	                            <td style="vertical-align:middle; text-align:center;" width="15%">Unit Price</td>
	                            <td style="vertical-align:middle; text-align:center;" width="5%">Net Price</td>
	                            <td style="vertical-align:middle; text-align:center;" width="12%">Net Amount</td>
	                       </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr class="odd" style="height:25px; font-weight:normal;">
	                            
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
                                                <asp:Label ID="lblPlant" runat="server" CssClass="" Text='<%# Eval("Plant") %> '></asp:Label> 
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
                                                <asp:Label ID="lblRequiredQuantity" runat="server" CssClass="" Text='<%# Eval("RequiredQuantity") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap" align="right">
                                                <asp:Label ID="lblRQUnitMeasure" runat="server" CssClass="" Text='<%# Eval("UnitMeasure") %> '></asp:Label>  
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
                                                <asp:Label ID="lblSupplyQuantity" runat="server" CssClass="" Text='<%# Eval("SupplyQuantity") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap" align="right">
                                                <asp:Label ID="lblSQUnitMeasure" runat="server" CssClass="" Text='<%# Eval("UnitMeasure") %> '></asp:Label>  
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
                                                <asp:Label ID="lblPriceUnit" runat="server" CssClass="" Text='<%# Eval("PriceUnit") %>'></asp:Label>
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
                                                <asp:Label ID="lblNetAmount" runat="server" CssClass="" Text='<%# Eval("NetAmount") %> '></asp:Label>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                               </td>
                               
	                            
	                        </tr>
	                        <tr>
	                            <td colspan="20"><hr /></td>
	                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                      </table>
                    </FooterTemplate>
                  </asp:Repeater>
                 </td> 
           </tr> 
      </table> 
    <br />
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" width="50%" style="height: 18px">&nbsp;&nbsp;</td>
            <td nowrap="nowrap" style="height: 18px">
                &nbsp;</td>
            <td nowrap="nowrap" style="height: 18px">&nbsp;</td>
             <td nowrap="nowrap" style="height: 18px">
                 &nbsp;</td>
            <td nowrap="nowrap" style="height: 18px">&nbsp;</td>
            <td nowrap="nowrap" style="height: 18px">
               <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnAcknowledge_Click"/>
            </td>
            <td nowrap="nowrap" style="height: 18px">&nbsp;</td>
            <td nowrap="nowrap" style="height: 18px">
               <asp:Button ID="btnReturn" runat="server" Text="Return" onclick="btnReturn_Click"/>
            </td>
            <td nowrap="nowrap" width="50%" style="height: 18px">&nbsp;&nbsp;</td>
        </tr> 
    </table>
    <br />
	<script language="javascript" type="text/javascript">    
    
        function ShowHeaderText()
        {
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:768px;dialogWidth:1024px;dialogHide:true";    
            MyArgs = window.showModalDialog("PurchaseOrderHeaderText.aspx", MyArgs, WinSettings);
        }
        
        function ShowItemText(itemNo)
        {
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:768px;dialogWidth:1024px;dialogHide:true";    
            MyArgs = window.showModalDialog("PurchaseOrderItemText.aspx?" + Math.random()*5 + "&ItemNo=" + itemNo, MyArgs, WinSettings);
        }
        function ShowComponent(itemNo)
        {
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:768px;dialogWidth:1024px;dialogHide:true";    
            MyArgs = window.showModalDialog("PurchaseOrderComponents.aspx?" + Math.random()*5 + "&ItemNo=" + itemNo, MyArgs, WinSettings);
            
        }
         function ShowService(itemNo)
        {
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:768px;dialogWidth:1024px;dialogHide:true";    
            MyArgs = window.showModalDialog("PurchaseOrderServices.aspx?" + Math.random()*5 + "&ItemNo=" + itemNo, MyArgs, WinSettings);
            
        }
    </script>	
</asp:Content>
