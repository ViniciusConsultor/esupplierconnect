<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="ExpeditingAckConfirm.aspx.cs" Inherits="Expediting_ExpeditingAckConfirm" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Purchase Expediting Acknowledgement Confirm</asp:Label></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
     <asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel>
    <asp:Panel CssClass="GreyTable" ID="plResult" runat="server" > 
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" >
                <asp:Label ID="lblCount" runat="server" CssClass="labelMessage" ></asp:Label>
            </td>
            <td width="100%"></td>
        </tr> 
    </table>
    <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="top" style="height: 8px">
               <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">
                     <tr>
                        <td align="left" >
                            <asp:Label ID="Label1" runat="server" Width="130px" Text="Material Number"></asp:Label>
                        </td> 
                        <td  align="left">
                            <asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
                        </td>
                        <td><img style="cursor: hand; vertical-align:middle" id="imgMaterialSearch" height="20" src="../Images/Common/Search.gif" runat="server" /></td>
                        <td>&nbsp;</td> 
                        <td style="text-align: left" style="width: 100%;">
                            <asp:Button ID="btnFilter" runat="server" Text="Filter"/>
                            <asp:Button ID="Button2" runat="server" Text="ShowAll"/>
                        </td>
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
	                            <td rowspan="2" style="vertical-align:middle; text-align:center;" width="5%">SN</td>
	                            <td rowspan="2" style="vertical-align:middle; text-align:center;" width="10%">Material Number</td>
	                            <td rowspan="2" style="vertical-align:middle; text-align:center;" width="20%">Material Description</td>
	                            <td rowspan="2" style="vertical-align:middle; text-align:center;" width="10%">Shortage<BR>Quantity</td>
	                            <td rowspan="2" style="vertical-align:middle; text-align:center;" width="10%">Unit of<BR>Measure</td>
	                            <td colspan="3" style="vertical-align:middle; text-align:center;" width="40%">Material Stock</td>
	                        </tr>
	                        <tr class="gridHeader" style="height:25px">
	                            <td style="vertical-align:middle; text-align:center;" width="25%">Plant</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Unrestricted Stock</td>
	                            <td style="vertical-align:middle; text-align:center;" width="10%">Inspection Stock</td>
	                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr class="odd" style="height:25px; font-weight:normal;">
	                            <td>
	                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap">
                                                <asp:Label ID="Label6" runat="server" CssClass="" Text='<%# Eval("Text1") %> '></asp:Label>
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
                                                <asp:Label ID="Label2" runat="server" CssClass="" Text='<%# Eval("Text2") %> '></asp:Label> 
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
                                                <asp:Label ID="Label3" runat="server" CssClass="" Text='<%# Eval("Text3") %> '></asp:Label> 
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
                                                <asp:Label ID="Label5" runat="server" CssClass="" Text='1000'></asp:Label>
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
                                                <asp:Label ID="Label13" runat="server" CssClass="" Text='PCS'></asp:Label> 
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
                                                <asp:Label ID="Label15" runat="server" CssClass="" Text='Plant 1'></asp:Label> 
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
                                                <asp:Label ID="Label16" runat="server" CssClass="" Text='1000'></asp:Label>
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
                                                <asp:Label ID="Label17" runat="server" CssClass="" Text='1000'></asp:Label>
                                            </td>
                                           <td>&nbsp;</td>
                                        </tr>
                                    </table> 
                                </td>
                            </tr>     
                            <tr class="odd" style="height:25px; font-weight:normal;">
	                            <td>

	                            </td>
	                            <td>
	                                 
	                            </td>
	                            <td>
	                                

	                            </td>
	                            <td>
                                   
                                </td>
	                            <td>
	                               
	                            </td>
	                            <td>
	                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td Width="100%" nowrap="nowrap">
                                                <asp:Label ID="Label12" runat="server" CssClass="" Text='Plant 2'></asp:Label> 
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
                                                <asp:Label ID="Label14" runat="server" CssClass="" Text='2000'></asp:Label>
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
                                                <asp:Label ID="Label18" runat="server" CssClass="" Text='2000'></asp:Label>
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
                                            <asp:TemplateField HeaderText="Order<br>Number" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblOrderNumber" runat="server" CssClass="" Text='<%# Eval("OrderNumber") %> '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="10%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Item<br>Sequence" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
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
                                             <asp:TemplateField HeaderText="Schedule<br>Sequence" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
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
                                            <asp:TemplateField HeaderText="Unit<br>Measure" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblItemSequence" runat="server" CssClass="" Text='PCS '></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="10%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Expedite<br>Quantity" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" align="right">
                                                                 <asp:Label ID="lblItemSequence" runat="server" CssClass="" Text='50'></asp:Label> 
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
                                                                <asp:Label ID="lblPromiseDate" runat="server" CssClass="" Text='29/10/2009'></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="10%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Promise Date1" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblPromiseDate" runat="server" CssClass="" Text='01/11/2009'></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="10%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Promise Date2" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:Label ID="lblPromiseDate" runat="server" CssClass="" Text='30/10/2009'></asp:Label> 
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="10%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Confirm" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:RadioButton runat="server" ID="rad1" Text="Accept" />
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td Width="100%" nowrap="nowrap">
                                                                <asp:RadioButton runat="server" ID="RadioButton1" Text="Reject" />
                                                            </td>
                                                           <td>&nbsp;</td>
                                                        </tr>
                                                    </table>  
                                                </ItemTemplate> 
                                                <ItemStyle Wrap="false" Width="10%"/>
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
    <br />
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnReturn" runat="server" Text="Exit" />
            </td>
            <td nowrap="nowrap">&nbsp;&nbsp;</td>
            <td nowrap="nowrap">
               <asp:Button ID="btnSubmit" runat="server" Text="Submit"/>
            </td>
            <td nowrap="nowrap" width="50%">&nbsp;&nbsp;</td>
        </tr> 
    </table>
</asp:Content>

