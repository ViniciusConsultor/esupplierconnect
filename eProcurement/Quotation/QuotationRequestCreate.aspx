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
    <table id="GreyTable" cellspacing="0" cellpadding="0" border="0" style="width: 175%; height: 279px">
        <tr>
            <td valign="top" style="height: 8px">
               <table id="tblSearch" cellspacing="0" cellpadding="1" width="820" border="0">
                    <tr>
                       <td align="left"  style="width : 130px; height: 20px;">
                            <asp:Label ID="Label4" runat="server" Text="Requisition No." Width="114px"></asp:Label>
                            <span class="redtxt">*</span> 
                        </td> 
                        <td  align="left" colspan="3" style="width: 100%; height: 20px;">
                            <asp:TextBox runat="server" id="txtRequisitionNo" AutoPostBack="True" OnTextChanged="txtRequisitionNo_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  style="width : 130px">
                            <asp:Label ID="Label3" runat="server" Text="Material No."></asp:Label>
                            <span class="redtxt">*</span> 
                        </td> 
                        <td  align="left" colspan="3" style="width: 100%">
                            <asp:DropDownList ID="ddlMaterialNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMaterialNo_SelectedIndexChanged">                             
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                       <td align="left" style="width : 130px">
                            <asp:Label ID="Label6" runat="server" Text="Material Desc"></asp:Label>
                        </td> 
                        <td  align="left" colspan="3" style="width: 100%">
                            <asp:TextBox runat="server" id="txtMaterialDesc" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: right">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" style="width : 130px">
                            <asp:Label ID="Label5" runat="server" Text="Requisition"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 120px">
                            &nbsp;<asp:ListBox ID="lstRequisition" runat="server" Width="227px"></asp:ListBox></td>
                        <td align="left" style="width : 130px">
                            <asp:Label ID="Label8" runat="server" Text="Supplier"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 120px">
                            &nbsp;<asp:ListBox ID="lstSupplier" runat="server" Width="211px" SelectionMode="Multiple"></asp:ListBox></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: right">
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
            <td>
                <asp:Label ID="lblCount" runat="server" CssClass="labelMessage" ></asp:Label>
            </td>
            
        </tr> 
    </table>
   <table cellspacing="0" cellpadding="0" width="820px" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 17px;" width="100%">
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
                                            <td >
                                                <asp:Label ID="lblItemSequence" runat="server" CssClass="" Text='<%# Eval("PurchaseItemSequenceNumber") %> '></asp:Label> 
                                            </td>                                           
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
                                                <asp:Label ID="lblOrderQuantity" runat="server" CssClass="" Text='<%# Eval("OrderQuantity") %>'></asp:Label>
                                            </td>
                                        </tr>                                        
                                    </table> 
                                </td>
                                 <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td style="width : 100%"align="right">
                                                <asp:Label ID="lblPricePer" runat="server" CssClass="" Text='<%# Eval("PricePerUnit") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td style="width : 100%" align="right">
                                                <asp:Label ID="lblNetPrice" runat="server" CssClass="" Text='<%# Eval("NetPrice") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td style="width : 100%" align="right">
                                                <asp:Label ID="Label6" runat="server" CssClass="" Text='<%# Eval("NetPrice") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td style="width : 100%" align="right">
                                                <asp:Label ID="Label1" runat="server" CssClass="" Text='<%# Eval("PLANT") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td style="width : 100%" align="right">
                                                <asp:Label ID="Label2" runat="server" CssClass="" Text='<%# Eval("CURRID") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table> 
                                </td>
                                <td>
                                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                        <tr>
                                            <td style="width : 100%" align="right">
                                                <asp:Label ID="Label7" runat="server" CssClass="" Text='<%# Eval("TotalValue") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table> 
                                </td>
                               </tr>
                    </ItemTemplate>            
                 </asp:Repeater>
            </td> 
       </tr> 
       <tr>   
             <td>         
               <asp:Button ID="btnReturn" runat="server" Text="Return" onclick="btnReturn_Click"/>
               <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"/>
            </td>                        
        </tr> 
      </table>      
</asp:Panel>
</asp:Content>
