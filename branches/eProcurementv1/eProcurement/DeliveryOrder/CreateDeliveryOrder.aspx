<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="CreateDeliveryOrder.aspx.cs" Inherits="DeliveryOrder_CreateDeliveryOrder" %>


<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">

        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Create Delivery Order</asp:Label></asp:TableCell>
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
                        <td class="DetailsTableCaption" colspan="2">Information</td> 
                        <td>
                            <asp:HyperLink runat="server" ID="hlHeaderText" Text=''></asp:HyperLink>  
                        </td>
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
	<table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
	     <td style="height: 20px"><asp:Label runat="server" ID="lblDeliveryNo">Delivery No</asp:Label></td> 
                        <td style="height: 20px">&nbsp;</td>
                        <td style="height: 20px">
                            <asp:TextBox ID="txtDeliveryNo" runat="server" Width="142px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDeliveryNo" runat="server" ErrorMessage="Please enter Delivery No" ControlToValidate="txtDeliveryNo"></asp:RequiredFieldValidator></td> 
	    </tr>
	     <tr>
	     <td><asp:Label runat="server" ID="lblDeliveryDate">Delivery Date</asp:Label></td> 
                         <td>&nbsp; </td>
                            <td align="left" style="width:200px">
                                             <DatePicker:DatePicker ID="dtpDeliveryDate" runat="server" />
                                        </td> 
	    </tr>
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
                        <asp:TemplateField HeaderText=" Item Sequence " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblItemSequence" runat="server" CssClass="" Text='<%# Eval("ItemSequence") %> '></asp:Label>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="10%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Material Number " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblMaterialNumber" runat="server" CssClass="" Text='<%# Eval("MaterialNumber")  %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="15%"/>
                        </asp:TemplateField>
                        
                            
                        <asp:TemplateField HeaderText="Open Quantity / Delivery Quantity " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%">
                                            <asp:Label ID="lblOpenQuantity" runat="server" CssClass="" Text='<%# Eval("OpenQuantity") %>'>/</asp:Label>
                                        </td>
                                       <td>
                                           <asp:TextBox ID="txtDeliveryQuantity" runat="server" Width="100"></asp:TextBox></td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/>
                        </asp:TemplateField>
                        
                            
                    </Columns>
                </asp:GridView>
                 </td> 
           </tr> 
      </table> 
    <br />
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" width="50%" style="height: 20px">&nbsp;&nbsp;</td>
            
            
             <td nowrap="nowrap" style="height: 20px">
               <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"/>
            </td>
            
            <td nowrap="nowrap" style="height: 20px">
               <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
            </td>
            
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
