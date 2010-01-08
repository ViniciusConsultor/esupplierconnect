<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="ProcessQuotationDetail.aspx.cs" Inherits="Quotation_ProcessQuotationDetail" Title="eProcurement System" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<%@ Register Src="~/UserControls/AttachmentPanel.ascx" TagName="AttachmentPanel" TagPrefix="AttachmentPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Process Quotation Details</asp:Label></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
     <asp:Panel ID="plMessage" runat="server" Visible="true">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel>
    <table id="DetailsTable" width="100%" border="2" cellspacing="2" cellpadding="2" bordercolor="Gainsboro">
		<tr>
		    <td colspan=2 align="center" class="DetailsTableCaption">Purchase Order Information</td>
		</tr>
		<tr>
		    <td width="50%" style="height: 20px">
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
                        <td style="height: 20px"><asp:Label runat="server" ID="lblCountry" CssClass="labelValue">Country</asp:Label></td> 
                    </tr> 
                    <tr>
                        <td class="DetailsTableCaption" style="height: 20px; background-color: white"></td> 
                    </tr> 
                    <tr>
                        <td style="height: 20px"></td> 
                    </tr> 
                </table> 
		    </td>
		    <td width="50%" style="vertical-align:top; height: 20px;">
		        <table id="tabl1" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="DetailsTableCaption" colspan="2">Information</td> 
                        <td>
                            &nbsp;</td>
                    </tr> 
                    <tr>
                        <td Width="50%"><asp:Label runat="server" ID="Label1">Request Number</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td Width="50%"><asp:Label runat="server" ID="lblRequestNumber" CssClass="labelValue">Request Number</asp:Label></td> 
                    </tr>
                    <tr>
                        <td Width="40%" style="height: 20px"><asp:Label runat="server" ID="Label2">Request Expiry Date</asp:Label></td> 
                        <td style="height: 20px">&nbsp;</td>
                        <td style="height: 20px"><asp:Label runat="server" ID="lblRFQExpDate" CssClass="labelValue">Req Exp Date</asp:Label></td> 
                    </tr>
                    <tr>
                        <td></td> 
                        <td>&nbsp;</td>
                        <td></td> 
                    </tr>
                     <tr>
                        <td style="height: 20px"></td> 
                        <td style="height: 20px">&nbsp;</td>
                        <td style="height: 20px">
                            &nbsp;</td> 
                    </tr>
                     <tr>
                        <td style="height: 20px"><asp:Label runat="server" ID="Label5">Quotation Number</asp:Label></td> 
                        <td style="height: 20px">&nbsp;</td>
                        <td style="height: 20px">
                            <asp:TextBox ID="txtQuotationNo" runat="server" Width="110px"></asp:TextBox></td> 
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="Label14">Quotation Date</asp:Label></td> 
                        <td>&nbsp;</td>
                        <td style="height: 20px">
                            <DatePicker:DatePicker ID="dtpQuotationDate" runat="server" />
                        </td> 
                    </tr>
                    <tr>
                        <td style="height: 20px"><asp:Label runat="server" ID="Label4" nowrap>Quotation Expiry Date</asp:Label></td> 
                        <td style="height: 20px">&nbsp;</td>
                        <td style="height: 20px">
                            <DatePicker:DatePicker ID="dtpExpiryDate" runat="server" />
                        </td> 
                    </tr>
                </table> 
		    </td>
		</tr> 
	</table> 
	<table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td valign="top" style="height: 8px">
             <AttachmentPanel:AttachmentPanel ID="attPanel" runat="server" />                   
        </td>
    </tr>
    <tr>
        <td><hr /></td>
    </tr>
</table>
	<asp:Panel ID="plResult" runat="server" > 
    <!--Display Result Number-->
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <asp:Label ID="lblCount" runat="server" CssClass="labelMessage" ></asp:Label>
            </td>
            
        </tr> 
    </table>
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 20px">
                <asp:GridView Width="100%" ID="gvItem" runat="server" AutoGenerateColumns="False" CellPadding="2">
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                             <asp:Label ID="lblReqSeq" runat="server" CssClass="" Text='<%# Eval("RequestSequence") %> '></asp:Label>  
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate>
                            <ItemStyle Width = "5%" HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Material/Description">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%">
                                           <asp:Label ID="lblMaterialNumber" runat="server" CssClass="" Text='<%# Eval("MaterialDescription") %> '></asp:Label>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="False" Width="30%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                              <asp:TemplateField HeaderText="Plant">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="lblPlant" runat="server" CssClass="" Text='<%# Eval("Plant") %>'></asp:Label>
                                        </tdP
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                                  <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Required Qty">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap" align="right">
                                            <asp:Label ID="lblReqQty" runat="server" CssClass="" Text='<%# Eval("RequiredQuantity")%>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="False" Width="10%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="center">
                                            <asp:Label ID="lblReqUOM" runat="server" CssClass="" Text='<%# Eval("UnitMeasure")%>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supply Qty">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="10%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                           <asp:TextBox ID="txtSupQty" Width="65px" runat="server" CssClass=""></asp:TextBox>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:TextBox ID="txtSupUOM" Width="65px" runat="server" CssClass=""></asp:TextBox>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="False" Width="10%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit Price">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                        <asp:TextBox ID="txtUnitPrice" Width="65px" runat="server" CssClass=""></asp:TextBox>
                                            
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Net Price">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                             <asp:TextBox ID="txtNetPrice" Width="65px" runat="server" CssClass="" OnTextChanged="TextChangedEvent" AutoPostBack="true"></asp:TextBox>
                                        </tdP
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Net Amount">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                           <asp:Label ID="lblNetValue" runat="server" CssClass="" Text='<%# Eval("NetValue") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>                
                        
                    </Columns>
                </asp:GridView>
	        </td>
        </tr>
    </table>
    <br />
         
     <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
        <tr>
            <td nowrap="nowrap" style="height: 18px; width: 100%;">&nbsp;&nbsp;</td>
            <td nowrap="nowrap" style="height: 18px; width: 20px;">
                &nbsp;</td>
            <td nowrap="nowrap" style="height: 18px">&nbsp;</td>
             <td nowrap="nowrap" style="height: 18px">
                 &nbsp;</td>
            <td nowrap="nowrap" style="height: 18px">&nbsp;</td>
            <td nowrap="nowrap" style="height: 18px">
               <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"/>
            </td>
            <td nowrap="nowrap" style="height: 18px">&nbsp;</td>
            <td nowrap="nowrap" style="height: 18px">
               <asp:Button ID="btnReturn" runat="server" Text="Return" onclick="btnReturn_Click"/>
            </td>
            <td nowrap="nowrap" width="50%" style="height: 18px">&nbsp;&nbsp;</td>
        </tr> 
    </table>
</asp:Panel>
	<table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 20px"> 
                
                 </td> 
           </tr> 
      </table> 
    <br />
    <br />
	</asp:Content>
