<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="QuotationRequestCreate.aspx.cs" Inherits="Quotation_QuotationRequestCreate" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<%@ Register Src="~/UserControls/DualList.ascx" TagName="DualList" TagPrefix="DualList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<!--Page title-->
<asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
    <asp:TableHeaderRow>
        <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
            <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Create Quotation Request</asp:Label></asp:TableCell>
    </asp:TableHeaderRow>
</asp:Table>
<!--Message Panel-->
<asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
</asp:Panel>
<!--Search Criteria Panel-->
 <asp:Panel ID="plSearch" runat="server" Visible="true">
    <table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="top" style="height: 8px">
               <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">
                    <tr>
                       <td align="left" nowrap Width="130">
                            <asp:Label ID="Label4" runat="server" Text="Requisition No."></asp:Label>
                            <span class="redtxt">*</span> 
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:TextBox runat="server" id="txtRequisitionNo"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" nowrap Width="130">
                            <asp:Label ID="Label3" runat="server" Text="Material No."></asp:Label>
                            <span class="redtxt">*</span> 
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:DropDownList ID="ddlMaterialNo" runat="server" AutoPostBack="false">
                                <asp:ListItem value="0" Text=""></asp:ListItem>
                                <asp:ListItem value="1" Text="Text 1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                       <td align="left" nowrap Width="130">
                            <asp:Label ID="Label6" runat="server" Text="Material Desc"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:TextBox runat="server" id="txtMaterialDesc"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:Button ID="btnSearch" runat="server" Text="Search"/>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" nowrap Width="130">
                            <asp:Label ID="Label5" runat="server" Text="Requisition"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 200%">
                             <DualList:DualList ID="DualList1" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:Button ID="btnAssign" runat="server" Text="Assign"/>
                        </td>
                    </tr>
                </table>
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
            <td nowrap="nowrap" >
                <asp:Label ID="lblCount" runat="server" CssClass="labelMessage" ></asp:Label>
            </td>
            <td width="100%"></td>
        </tr> 
    </table>
   <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 17px; width: 687px;">
                <asp:Repeater ID="gvItem" runat="server">
                    <HeaderTemplate>
                        <table width="100%">
                            <tr class="gridHeader" style="height:25px">
	                            <td style="vertical-align:middle; text-align:center;" width="5%">Itm<BR>Seq</td>
	                            <td style="vertical-align:middle; text-align:center;" width="20%">Material/<BR>Description</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Req Qty/<BR>Unit Measure</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Est.<BR>Price</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Unit<BR>Price</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Order<BR>Date</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Plant</td>
	                            <td style="vertical-align:middle; text-align:center;" width="8%">Curr.ID</td>
	                            <td style="vertical-align:middle; text-align:center;" width="15%">Total<BR>Value</td>
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
                                              <a href="">Texts</a>
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
                                            <td Width="100%" align="right">
                                                <asp:Label ID="Label6" runat="server" CssClass="" Text='<%# Eval("NetPrice") %>'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </td>
                               </tr>
	                        <tr>
	                            <td>
	                            
	                            </td>     
	                            <td colspan="9" Width="100%" nowrap="nowrap">
	                                <asp:GridView BorderWidth="0" ShowHeader="true" AllowPaging="false" width="100%" ID="gvSchedule" runat="server" 
                                    AutoGenerateColumns="False">
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
                                                                <asp:Label ID="lblScheduleDate" runat="server" CssClass="" Text='27/09/2009 '></asp:Label> 
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
                                                                <asp:Label ID="lblScheduleQuantity" runat="server" CssClass="" Text='300'></asp:Label>
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
                                                                <asp:Label ID="lblDeliveryDate" runat="server" CssClass="" Text='27/09/2009 '></asp:Label> 
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
                                                                <asp:Label ID="lblDeliveryQuantity" runat="server" CssClass="" Text='100'></asp:Label>
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table> 
                                                </ItemTemplate> 
                                                <ItemStyle Width="10%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ack Date 1" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblAcknowledgeDate1" runat="server" CssClass="" Text='27/09/2009 '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="12%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ack Date 2" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblAcknowledgeDate2" runat="server" CssClass="" Text=' '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="12%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Promise Date 1" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblPromiseDate1" runat="server" CssClass="" Text='27/09/2009'></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="12%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Promise Date 2" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblPromiseDate2" runat="server" CssClass="" Text=' '></asp:Label> 
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
