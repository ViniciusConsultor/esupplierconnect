<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="MaterialShortageList.aspx.cs" Inherits="PurchaseOrder_MaterialShortageList" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<%@ Register Src="~/UserControls/DualList.ascx" TagName="DualList" TagPrefix="DualList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<!--Page title-->
<asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
    <asp:TableHeaderRow>
        <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
            <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Quotation Request List</asp:Label></asp:TableCell>
    </asp:TableHeaderRow>
</asp:Table>
<!--Message Panel-->
<asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
</asp:Panel>
<!--Search Criteria Panel-->
<br />
 <asp:Panel ID="plSearch" runat="server" Visible="true">
    <table id="GreyTable" cellspacing="0" cellpadding="0" width="820" border="0">
        <tr>
            <td align="left" nowrap Width="130px">
                    <asp:Label ID="lblMAterialNo" runat="server" Text="Material Number"></asp:Label>
            </td> 
            <td  align="left" style="width: 100%;">
                <asp:TextBox runat="server" id="txtSupplier"></asp:TextBox>
                <img style="cursor: hand; vertical-align:middle" id="img1" height="20" src="../Images/Common/Search.gif" runat="server" />
                <asp:Button ID="btnFilter" runat="server" Text="Filter"/>
                <asp:Button ID="btnShowAll" runat="server" Text="Show All"/>
            </td>
        </tr>
    </table>
</asp:Panel> 
    <br />
    <!--Search Result Panel-->
<asp:Panel ID="plResult" runat="server" > 
    <!--Display Result Number-->
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" style="height: 20px" >
                <asp:Label ID="lblCount" runat="server" CssClass="labelMessage" ></asp:Label>
            </td>
            <td width="100%" style="height: 20px"></td>
        </tr> 
    </table>
  <table cellspacing="0" cellpadding="0" width="820" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 17px">
                <asp:Repeater ID="gvItem" runat="server" OnItemDataBound="gvItem_ItemDataBound">
                    <HeaderTemplate>
                        <table width="100%">
                         
                            <tr class="gridHeader"  style="height:25px">
	                            <td rowspan =2 style="vertical-align:middle; text-align:center;" width="5%">SN</td>
	                            <td rowspan =2 style="vertical-align:middle; text-align:center;" width="20%">Material No</td>
	                            <td rowspan =2 style="vertical-align:middle; text-align:center;" width="20%">Material Description</td>
	                            <td rowspan =2 style="vertical-align:middle; text-align:center;" width="10%">Shortage/<BR>Quantity</td>
	                            <td rowspan =2 style="vertical-align:middle; text-align:center;" width="8%">Unit of Masurement</td>
	                            <td colspan =3 style="vertical-align:middle; text-align:center;" width="8%">Material Stock</td>
	                        </tr>
	                       <tr class="gridHeader"  style="height:25px">
	                           <td style="vertical-align:middle; text-align:center;" width="8%">Plant</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Unit of Stock</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Inspection Stock</td>
	                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr class="odd" style="height:25px; font-weight:normal;">
	                            <td>
	                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap">
                                                <asp:Label ID="lblSN" runat="server" CssClass="" Text='<%#DataBinder.Eval(Container, "ItemIndex", "")%>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table>  
	                            </td>
	                            <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td Width="100%" nowrap="nowrap">
                                                <asp:Label ID="lblMaterialNumber" runat="server" CssClass="" Text='<%# Eval("MaterialNumber") %> '></asp:Label> 
                                            </td>
                                        </tr>
                                    </table>  
                               </td> 
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>                                            
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblMaterialDescription" runat="server" CssClass="" Text='<%# Eval("MaterialDescription") %>'></asp:Label>
                                            </td>                                           
                                        </tr>                                        
                                    </table> 
                                </td>
                                 <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblShortageQty" runat="server" CssClass="" Text='<%# Eval("shortageQuantity") %>'></asp:Label>
                                            </td>                                           
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>                                            
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblUOM" runat="server" CssClass="" Text='<%# Eval("UnitOfMeasure") %>'></asp:Label>
                                            </td>                                           
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>                                            
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblPlant" runat="server" CssClass="" Text='<%# Eval("Plant") %>'></asp:Label>
                                            </td>                                           
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>                                            
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblUnrestrictedStock" runat="server" CssClass="" Text='<%# Eval("UnrestrictedStock") %>'></asp:Label>
                                            </td>                                           
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>                                            
                                            <td Width="100%" align="right">
                                                <asp:Label ID="lblInspectionStock" runat="server" CssClass="" Text='<%# Eval("InspectionStock") %>'></asp:Label>
                                            </td>                                           
                                        </tr>
                                    </table> 
                                </td>
                               </tr>
	                        <tr>
	                            <td>
	                            
	                            </td>     
	                            <td colspan="9" Width="100%" nowrap="nowrap">
	                                <asp:GridView BorderWidth="0" ShowHeader="true" AllowPaging="false" width="100%" ID="gvMaterialDtl" runat="server" 
                                    AutoGenerateColumns="False">
                                        <HeaderStyle  Height="10px" ForeColor="white"  BackColor="#a9a9a9"/>
                                        <AlternatingRowStyle CssClass=""/>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Order<BR>No" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblOrderNo" runat="server" CssClass="" Text='<%# Eval("OrderNumber") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="8%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Item<BR>Sequence" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
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
                                                <ItemStyle Wrap="false" Width="8%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Seedule<BR>Sequence" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblScheduleSequence" runat="server" CssClass="" Text='<%# Eval("ScheduleSequence") %> '></asp:Label> 
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
                                                                <asp:Label ID="lblScheduleDate" runat="server" CssClass="" Text='<%# Eval("ScheduleDate") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="12%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Expedite<br>Quantity" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" align="right">
                                                                <asp:Label ID="lblExpediteQuantity" runat="server" CssClass="" Text='<%# Eval("ExpediteQuantity") %> '></asp:Label>
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table> 
                                                </ItemTemplate> 
                                                <ItemStyle Width="10%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Expedite Date" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblExpediteDate" runat="server" CssClass="" Text='<%# Eval("ExpeditDate") %> '></asp:Label> 
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
</asp:Panel>
</asp:Content>


