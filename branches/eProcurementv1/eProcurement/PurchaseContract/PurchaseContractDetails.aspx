<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageSimple.master" AutoEventWireup="true" CodeFile="PurchaseContractDetails.aspx.cs" Inherits="PurchaseContract_PurchaseContractDetails" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
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
    <table id="DetailsTable" width="100%" border="2" cellspacing="2" cellpadding="2" bordercolor="gainsboro">
        <tr>
            <td colspan=2 align="center" class="DetailsTableCaption">Purchase Contract Information</td>
        </tr>
        <tr>
            <td style="width: 100%; height: 20px;" valign="top">
                <table id="tbl1" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label1" runat="server" Text="Contract Number"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblContractNumber" runat="server" Text="Contract Number" CssClass="labelValue"></asp:Label>
                        </td>
                       <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label2" runat="server" Text="Contract Type"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblContractType" runat="server" Text="Contract Type" CssClass="labelValue"></asp:Label>
                        </td>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label3" runat="server" Text="Valid Start"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblValidStart" runat="server" Text="Valid Start" CssClass="labelValue"></asp:Label>
                        </td>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label4" runat="server" Text="Valid End"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblValidEnd" runat="server" Text="Valid End" CssClass="labelValue"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label5" runat="server" Text="Contract Date"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblContractDate" runat="server" Text="Contract Date" CssClass="labelValue"></asp:Label>
                        </td>
                       <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label7" runat="server" Text="Supplier ID"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblSupplierId" runat="server" Text="Supplier ID" CssClass="labelValue"></asp:Label>
                        </td>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label9" runat="server" Text="Contact Person"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblContactPerson" runat="server" Text="Contact Person" CssClass="labelValue"></asp:Label>
                        </td>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label11" runat="server" Text="Telephone"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblTelephone" runat="server" Text="Telephone" CssClass="labelValue"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label13" runat="server" Text="Contract Category"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblContractCat" runat="server" Text="Contract Category" CssClass="labelValue"></asp:Label>
                        </td>
                       <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label15" runat="server" Text="Purchase Group"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblPurchaseGrp" runat="server" Text="Purchase Group" CssClass="labelValue"></asp:Label>
                        </td>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label17" runat="server" Text="Internal Ref"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblInternalRef" runat="server" Text="Internal Ref" CssClass="labelValue"></asp:Label>
                        </td>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label19" runat="server" Text="Contract Value"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblContractValue" runat="server" Text="Contract Value" CssClass="labelValue"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label21" runat="server" Text="Payment Term"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblPayment" runat="server" Text="Payment Term" CssClass="labelValue"></asp:Label>
                        </td>
                       <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label23" runat="server" Text="Currency ID"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblCurrencyId" runat="server" Text="Currency ID" CssClass="labelValue"></asp:Label>
                        </td>
                        <td style="width: 12%;" class="DetailsTableCaption">
                            <asp:Label ID="Label25" runat="server" Text="Exchange Rate"></asp:Label>
                        </td>         
                        <td style="width: 12%;">   
                        <asp:Label ID="lblExchangeRate" runat="server" Text="Exchange Rate" CssClass="labelValue"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>

        </tr>
    </table>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="top" colspan="10" style="height: 20px;">
                <asp:Repeater ID="gvItem" runat="server" OnItemDataBound="gvItem_ItemDataBound">
               <HeaderTemplate>
                   <table width="100%">
                       <tr class="gridHeader" style="height:25px">
                                <td style="vertical-align:middle; text-align:center;" width="10%">Contract Sequence</td>
	                            <td style="vertical-align:middle; text-align:center;" width="60%">Contract Description</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">RFQ Number</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Requisition Number</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Requisitioner</td>
                       </tr>
               </HeaderTemplate> 
               <ItemTemplate>
               <tr class="odd" style="height:25px; font-weight:normal;">
                                 <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" align="left">
                                                <asp:Label ID="lblContractSeq" runat="server" CssClass="" Text='<%# Eval("ContractItemSequence") %>'></asp:Label>
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
                                                <asp:Label ID="lblContractDesc" runat="server" CssClass="" Text='<%# Eval("Description") %>'></asp:Label>
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
                                                <asp:Label ID="lblRFQ" runat="server" CssClass="" Text='<%# Eval("RFQNumber") %>'></asp:Label>
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
                                                <asp:Label ID="lblRequisitionNo" runat="server" CssClass="" Text='<%# Eval("RequisitionNumber") %>'></asp:Label>
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
                                                <asp:Label ID="lblRequisitioner" runat="server" CssClass="" Text='Martin'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </td>            
               </tr>   
               <tr>
               <td colspan="9" Width="100%" nowrap="nowrap">
                   <asp:GridView BorderWidth="0" ShowHeader="true" AllowPaging="false" width="100%" ID="gvContract" runat="server" 
                    AutoGenerateColumns="False">
                    <HeaderStyle CssClass="subGridHeader"/>
                    <AlternatingRowStyle CssClass=""/>
                    <Columns>
                            <asp:TemplateField HeaderText="Material Number" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblMaterialNo" runat="server" CssClass="" Text='<%# Eval("MaterialNumber") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="8%"/>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Material Group" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblMaterialGrp" runat="server" CssClass="" Text='<%# Eval("MaterialGroup") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="8%"/>
                                 </asp:TemplateField>
                              <asp:TemplateField HeaderText="Plant" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblPlant" runat="server" CssClass="" Text='<%# Eval("Plant") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="8%"/>
                                            </asp:TemplateField>             
                             <asp:TemplateField HeaderText="Unit Price" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblUnitPrice" runat="server" CssClass="" Text='<%# Eval("UnitPrice") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="8%"/>
                                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Contract Quantity" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblContractQty" runat="server" CssClass="" Text='<%# Eval("TargetQuantity") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="8%"/>
                                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Unit of Measure" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblUOM" runat="server" CssClass="" Text='<%# Eval("UnitofMeasure") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="8%"/>
                                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Net Price" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblNetPrice" runat="server" CssClass="" Text='<%# Eval("UnitPrice") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="8%"/>
                                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Net Value" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblNetValue" runat="server" CssClass="" Text='<%# Eval("NetValue") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="8%"/>
                                            </asp:TemplateField>
                                             
                    </Columns>
                    
                   </asp:GridView>
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
    <br />
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" width="50%" style="height: 21px">&nbsp;&nbsp;</td>
            <td nowrap="nowrap" style="height: 21px">
               <asp:Button ID="btnReturn" runat="server" Text="Return" />
            </td>
            <td nowrap="nowrap" style="height: 21px">&nbsp;&nbsp;</td>
            
            <td nowrap="nowrap" width="50%" style="height: 21px">&nbsp;&nbsp;</td>
        </tr> 
    </table>
    <br />
</asp:Content>

