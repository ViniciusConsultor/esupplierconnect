<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageSimple.master" AutoEventWireup="true" CodeFile="PurchaseOrderDetail.aspx.cs" Inherits="PurchaseOrder_PurchaseOrderDetail" Title="eProcurement System" %>
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
                        <td class="DetailsTableCaption">Supplier</td> 
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
	</table> <br />
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnAccept1" runat="server" Text="Accept" onclick="btnAcceptReject_Click"/>
            </td>
            <td nowrap="nowrap">&nbsp;</td>
             <td nowrap="nowrap">
               <asp:Button ID="btnReject1" runat="server" Text="Reject" onclick="btnAcceptReject_Click"/>
            </td>
            <td nowrap="nowrap">&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnAcknowledge1" runat="server" Text="Acknowledge" onclick="btnAcknowledge_Click"/>
            </td>
            <td nowrap="nowrap">&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnPrint1" runat="server" Text="Print"/>
            </td>
            <td nowrap="nowrap">&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnReturn1" runat="server" Text="Return" onclick="btnReturn_Click"/>
            </td>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
        </tr> 
    </table>
    <br />
	<table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 20px"> 
                <asp:Repeater ID="gvItem" runat="server" OnItemDataBound="gvItem_ItemDataBound">
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
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap">
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
	                        <tr>
	                            <td>
	                                <table border=0 cellpadding=0 cellspacing =0>
	                                    <tr>
	                                        <td>
	                                            <asp:HyperLink runat="server" ID="hlItemText" Text='Texts'></asp:HyperLink>
	                                        </td>
	                                    </tr>
	                                    <tr>
	                                        <td>
	                                            <asp:HyperLink runat="server" ID="hlComponent" Text='Comps'></asp:HyperLink> 
	                                        </td>
	                                    </tr>
	                                    <tr>
	                                        <td>
	                                            <asp:HyperLink runat="server" ID="hlService" Text='Servs'></asp:HyperLink> 
	                                        </td>
	                                    </tr>
	                                </table>
	                            </td>     
	                            <td colspan="9" Width="100%" nowrap="nowrap">
	                                <asp:GridView BorderWidth="0" ShowHeader="true" AllowPaging="false" width="100%" ID="gvSchedule" runat="server" 
                                    AutoGenerateColumns="False" OnRowCreated="gvSchedule_RowCreated" OnRowDataBound="gvSchedule_RowDataBound" >
                                        <HeaderStyle  Height="10px" ForeColor="white"  BackColor="#a9a9a9"/>
                                        <AlternatingRowStyle CssClass=""/>
                                        <Columns>
                                            <asp:TemplateField HeaderText="schedule<BR>Sequence" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblScheduleSequence" runat="server" CssClass="" Text='<%# Eval("PurchaseOrderScheduleSequence") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="8%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Schedule Date" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblScheduleDate" runat="server" CssClass="" Text= '<%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("OrderItemScheduleDate")))) %>'></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="12%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Schedule<br>Quantity" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" align="right">
                                                                <asp:Label ID="lblScheduleQuantity" runat="server" CssClass="" Text='<%# Eval("DeliveryScheduleQuantity") %> '></asp:Label>
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table> 
                                                </ItemTemplate> 
                                                <ItemStyle Width="10%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblDeliveryDate" runat="server" CssClass="" Text='<%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("DeliveryDate")))) %>'></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="12%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delivery<br>Quantity" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" align="right">
                                                                <asp:Label ID="lblDeliveryQuantity" runat="server" CssClass="" Text='<%# Eval("DeliveredQuantity") %> '></asp:Label>
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table> 
                                                </ItemTemplate> 
                                                <ItemStyle Width="10%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Acknowledge Date" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblAcknowledgeDate" runat="server" CssClass="" Text= '<%# Eval("AcknowledgementDate") %>'></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="12%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Acknowledge Date" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                 <DatePicker:DatePicker ID="dtAcknowledgeDate" runat="server" />
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="12%"/>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
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
               <asp:Button ID="btnAccept" runat="server" Text="Accept" onclick="btnAcceptReject_Click"/>
            </td>
            <td nowrap="nowrap">&nbsp;</td>
             <td nowrap="nowrap">
               <asp:Button ID="btnReject" runat="server" Text="Reject" onclick="btnAcceptReject_Click"/>
            </td>
            <td nowrap="nowrap">&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnAcknowledge" runat="server" Text="Acknowledge" onclick="btnAcknowledge_Click"/>
            </td>
            <td nowrap="nowrap">&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnPrint2" runat="server" Text="Print"/>
            </td>
            <td nowrap="nowrap">&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnReturn" runat="server" Text="Return" onclick="btnReturn_Click"/>
            </td>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
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
        
        function PrintReport()
        {
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:768px;dialogWidth:1024px;dialogHide:true";    
            MyArgs = window.showModalDialog("../Reports/ReportControl.aspx?" + Math.random()*5 + "&ReportName=ORDER", MyArgs, WinSettings);
            
        }
    </script>	
</asp:Content>
