<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageSimple.master" AutoEventWireup="true" CodeFile="ViewPurchaseContractDetail.aspx.cs" Inherits="PurchaseContract_ViewPurchaseContractDetail" Title="eProcurement System"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Purchase Contract Details</asp:Label></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
     <asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel>
    <table id="DetailsTable" width="100%" border="2" cellspacing="2" cellpadding="2" bordercolor="Gainsboro">
		<tr>
		    <td colspan=2 align="center" class="DetailsTableCaption">Purchase Contract Information</td>
		</tr>
		<tr>
		    <td width="50%">
		        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr >
                        <td class="DetailsTableCaption">Supplier</td> 
                    </tr> 
                     <tr>
                        <td><asp:Label runat="server" ID="lblSupplierId" CssClass="labelValue">Supplier Id</asp:Label></td> 
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
                        <td><asp:Label runat="server" ID="lblShipmentAddress" CssClass="labelValue"></asp:Label></td> 
                    </tr> 
                </table> 
		    </td>
		    <td width="50%" style="vertical-align:top">
		        <table id="tabl1" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="DetailsTableCaption" colspan="3">Information</td> 
                    </tr> 
                    <tr>
                        <td Width="40%"><asp:Label runat="server" ID="Label1">Contract Number</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td Width="60%"><asp:Label runat="server" ID="lblContractNumber" CssClass="labelValue">Contract Number</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label2">Contract Date</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblContractDate" CssClass="labelValue">Contract Date</asp:Label></td> 
                    </tr>
                     <tr>
                        <td><asp:Label runat="server" ID="Label4">Contract Category</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblContractCategory" CssClass="labelValue">Contract Category</asp:Label></td> 
                    </tr>
                     <tr>
                        <td><asp:Label runat="server" ID="Label5">Document Type</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblContractType" CssClass="labelValue">Contract Type</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label14">payment Term</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblpaymentTerm" CssClass="labelValue">payment Term</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label6">Purchasing Group</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblPurchasingGroup" CssClass="labelValue">Purchasing Group</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label10">Currency</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblCurrency" CssClass="labelValue">Currency</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label12">Exchange Rate</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblExchangeRate" CssClass="labelValue">Exchange Rate</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label8">Validity Period</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td nowrap>
                            <asp:Label runat="server" ID="lblValidityStart" CssClass="labelValue">Start</asp:Label>
                            -<asp:Label runat="server" ID="lblValidityEnd" CssClass="labelValue">End</asp:Label>
                        </td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label11">Contract Person</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblContractPerson" CssClass="labelValue">Contract Person</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label15">Telephone</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblTelephone" CssClass="labelValue">Telephone</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label17">Contract Value</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblContractValue" CssClass="labelValue">Contract Value</asp:Label></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label19">Internal Reference</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td><asp:Label runat="server" ID="lblInternalReference" CssClass="labelValue">Internal Reference</asp:Label></td> 
                    </tr>
                </table> 
		    </td>
		</tr> 
	</table> <br />
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
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
                 <asp:GridView Width="100%" ID="gvData" runat="server" AllowPaging="false" AutoGenerateColumns="False" 
                   AllowSorting="false" CellPadding="2" OnRowDataBound="gvData_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Item<br>Seq" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblContractItemSequence" runat="server" CssClass="" Text='<%# Eval("ContractItemSequence") %> '></asp:Label>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="5%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Material/Description " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%">
                                            <asp:Label ID="lblMaterial" runat="server" CssClass="" Text='<%# Eval("MaterialNumber") %> '></asp:Label>  
                                            &nbsp;-&nbsp;
                                            <asp:Label ID="lblDescription" runat="server" CssClass="" Text='<%# Eval("Description") %> '></asp:Label>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="30%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Plant " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblPlant" runat="server" CssClass="" Text=' <%# Eval("Plant") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="5%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" material<br>Group " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%">
                                            <asp:Label ID="lblMaterialGroup" runat="server" CssClass="" Text='<%# Eval("MaterialGroup") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Quantity " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                            <asp:Label ID="lblTargetQuantity" runat="server" CssClass="" Text='<%# Eval("TargetQuantity") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" UOM " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%">
                                            <asp:Label ID="lblUOM" runat="server" CssClass="" Text='<%# Eval("UnitOfMeasure") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Unit Price " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%"  align ="right">
                                            <asp:Label ID="lblUnitPrice" runat="server" CssClass="" Text='<%# Eval("UnitPrice") %>'></asp:Label>
                                        </tdP
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Net Amount " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align ="right" >
                                            <asp:Label ID="lblNetValue" runat="server" CssClass="" Text='<%# Eval("NetValue") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" RFQ No. " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="lblRFQNumber" runat="server" CssClass="" Text='<%# Eval("RFQNumber") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="10%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Requisition No. " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="lblRequisitionNumber" runat="server" CssClass="" Text='<%# Eval("RequisitionNumber") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="10%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Requisitioner " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="lblRequisitioner" runat="server" CssClass="" Text='<%# Eval("Requisitioner") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="10%"/>
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
               <asp:Button ID="btnReturn" runat="server" Text="Return" onclick="btnReturn_Click"/>
            </td>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
        </tr> 
    </table>
    <br />
</asp:Content>

