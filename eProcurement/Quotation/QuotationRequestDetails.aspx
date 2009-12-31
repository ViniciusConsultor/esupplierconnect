<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="QuotationRequestDetails.aspx.cs" Inherits="Quotation_QuotationRequestDetails" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Enquiry Quotation Details</asp:Label></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
     <asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel>
    <table id="DetailsTable" width="100%" border="2" cellspacing="2" cellpadding="2" bordercolor="Gainsboro">
		<tr>
		    <td class="DetailsTableCaption">Quotation Request Information</td>
		</tr>
		<tr>
		    <td width="50%" style="vertical-align:top">
		        <table id="tabl1" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <%--<tr>
                        <td class="DetailsTableCaption" style="height: 20px">Information</td> 
                        <td style="height: 20px">
                            <asp:HyperLink runat="server" ID="hlHeaderText" Text='Texts'></asp:HyperLink>  
                        </td>
                    </tr> --%>
                    <tr>
                        <td Width="40%" style="height: 20px"><asp:Label runat="server" ID="Label1">Quotation Number</asp:Label></td> 
                        <td Width="60%" style="height: 20px"><asp:Label runat="server" ID="lblQuotationNumber" CssClass="labelValue"></asp:Label></td> 
                    </tr>
                    <tr>
                        <td Width="40%" style="height: 19px"><asp:Label runat="server" ID="Label3">Quotation Date</asp:Label></td> 
                        <td style="height: 19px"><asp:Label runat="server" ID="lblQuotationDate" CssClass="labelValue"></asp:Label></td> 
                    </tr>
                    <tr>
                        <td style="height: 20px"><asp:Label runat="server" ID="Label2">Expiry Date</asp:Label></td> 
                        <td style="height: 20px"><asp:Label runat="server" ID="lblExpiryDate" CssClass="labelValue"></asp:Label></td> 
                    </tr>
                     <tr>
                        <td style="height: 20px"><asp:Label runat="server" ID="Label4">Request No</asp:Label></td> 
                        <td style="height: 20px"><asp:Label runat="server" ID="lblRequestNo" CssClass="labelValue"></asp:Label></td> 
                    </tr>
                     <tr>
                        <td style="height: 22px"><asp:Label runat="server" ID="Label5">Supplier ID</asp:Label></td> 
                        <td style="height: 22px"><asp:Label runat="server" ID="lblSupplierID" CssClass="labelValue"></asp:Label></td> 
                    </tr>
                </table> 
		    </td>
		</tr> 
	</table> 
	<table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 17px">
                <asp:Repeater ID="gvItem" runat="server">
                    <HeaderTemplate>
                        <table width="100%">
                            <tr class="gridHeader" style="height:25px">
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Request Seq</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Material</td>
	                            <td style="vertical-align:middle; text-align:center;" width="20%">Description</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Plant</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Required Qty</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Unit Measure</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Net Price</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Unit Price</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">NetValue</td>
	                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
	                            <td>
	                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td >
                                                <asp:Label ID="lblItemSequence" runat="server" CssClass="" Text='<%# Eval("RequestSequence") %> '></asp:Label> 
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr> 
                                    </table>  
	                            </td>
	                            <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td >
                                                <asp:Label ID="lblMaterialNumber" runat="server" CssClass="" Text='<%# Eval("MaterialNumber") %> '></asp:Label> 
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>                                    
                               </td>
                               <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td >
                                                <asp:Label ID="lblMaterialDescr" runat="server" CssClass="" Text='<%# Eval("MaterialDescription") %> '></asp:Label> 
                                            </td>
                                            <td>&nbsp;</td>                                           
                                        </tr>
                                    </table>
                                </td>
                               <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" align="center">
                                                <asp:Label ID="lblPlant" runat="server" CssClass="" Text='<%# Eval("Plant") %>'></asp:Label>
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
                                    </table>
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap" align="center">
                                                <asp:Label ID="lblUnitMeasure" runat="server" CssClass="" Text='<%# Eval("UnitMeasure") %> '></asp:Label>  
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </td>
                                 <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td width="100%" align="right">
                                                <asp:Label ID="lblNetPrice" runat="server" CssClass="" Text='<%# Eval("NetPrice") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td width="100%" align="right">
                                                <asp:Label ID="lblUnitPrice" runat="server" CssClass="" Text='<%# Eval("PriceUnit") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td width="100%" align="right">
                                                <asp:Label ID="lblNetValue" runat="server" CssClass="" Text='<%# Eval("NetValue") %>'></asp:Label>
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
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnReturn" runat="server" Text="Return" onclick="btnReturn_Click"/>
            </td>
            <td nowrap="nowrap">&nbsp;&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" Visible="false" />
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
