<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="QuotationRequestCreate.aspx.cs" Inherits="Quotation_QuotationRequestCreate" Title="eProcurement System" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<%@ Register Src="~/UserControls/AttachmentPanel.ascx" TagName="AttachmentPanel" TagPrefix="AttachmentPanel" %>
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
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>&nbsp;
</asp:Panel>
<!--Search Criteria Panel-->
<asp:Panel ID="plSearch" runat="server" Visible="true">
    <table id="GreyTable" cellspacing="0" cellpadding="0" border="0" style="width: 175%; height: 279px">
        <tr>
            <td valign="top" style="height: 8px">
               <table id="tblSearch" cellspacing="0" cellpadding="1" width="820" border="0">
                    <tr>
                       <td align="left"  style="width : 130px; height: 20px;" nowrap>
                            <asp:Label ID="Label4" runat="server" Text="Requisition No." Width="114px"></asp:Label>
                         
                        </td> 
                        <td  align="left" colspan="3" style="width: 100%; height: 20px;" >
                            <asp:TextBox runat="server" id="txtRequisitionNo" AutoPostBack="True" OnTextChanged="txtRequisitionNo_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  style="width : 130px" nowrap>
                            <asp:Label ID="Label3" runat="server" Text="Material No."></asp:Label>
                       
                        </td> 
                        <td  align="left" colspan="3" style="width: 100%">
                            <asp:DropDownList ID="ddlMaterialNo" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlMaterialNo_SelectedIndexChanged" Width="600px">                             
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display:none">
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
                        <td align="left"  colspan ="4" style="width:100%">
                             <hr />
                        </td>
                    </tr>     
                    <tr>
                        <td align="left" style="width : 130px">
                            <asp:Label ID="Label5" runat="server" Text="Requisition"></asp:Label>
                        </td>
                        <td align="left"  colspan ="3" style="width:500px">
                             <asp:ListBox ID="lstRequisition" runat="server" Width="300px"></asp:ListBox>
                        </td>
                    </tr>     
                    <tr>
                        <td align="left" style="width : 130px">
                           <asp:Label ID="Label8" runat="server" Text="Supplier"></asp:Label>
                        </td>
                        <td align="left"  colspan ="3" style="width:500px">
                             <asp:ListBox ID="lstSupplier" runat="server" Width="500px" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                    </tr>   
                    <tr>
                        <td align="left" style="width : 130px">
                         <asp:Label ID="lblExpiryDate" Text="Expiry Date" runat="server"></asp:Label>
                        </td>
                        <td align="left"  colspan ="3" style="width:500px">
                             <DatePicker:DatePicker ID="dtpExpiry" runat="server" />
                        </td>
                    </tr>                    
                    <tr>
                        <td colspan="4" style="text-align: right">                            
                            <asp:Button ID="btnAssign" OnClick  ="btnAssign_Click"  runat="server" Text="Assign" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel> 
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
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 20px">
                <asp:GridView Width="100%" ID="gvItem" runat="server" AllowPaging="false" AutoGenerateColumns="False" 
                   AllowSorting="false" CellPadding="2">
                    <Columns>
                        <asp:TemplateField HeaderText="Itm<BR>Seq" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                             <asp:Label ID="lblItemSequence" runat="server" CssClass="" Text='<%# Eval("RequestSequence") %> '></asp:Label> 
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate>
                            <ItemStyle Width = "5%" HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Request NO" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblRequestNumber" runat="server" CssClass="" Text='<%# Eval("RequestNumber") %> '></asp:Label> 
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="10%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Material/<BR>Description" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
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
                            <ItemStyle Wrap="false" Width="30%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Req Qty" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap" align="right">
                                            <asp:Label ID="lblOrderQuantity" runat="server" CssClass="" Text='<%# Eval("RequiredQuantity")%>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="10%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="center">
                                            <asp:Label ID="Label2" runat="server" CssClass="" Text='<%# Eval("UnitMeasure")%>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Est." HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                            <asp:Label ID="lblPricePer" runat="server" CssClass="" Text='<%# Eval("PriceUnit") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit<BR>Price" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                            <asp:Label ID="lblNetPrice" runat="server" CssClass="" Text='<%# Eval("NetPrice") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Plant" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="Label1" runat="server" CssClass="" Text='<%# Eval("Plant") %>'></asp:Label>
                                        </tdP
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="8%"/>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
	        </td>
        </tr>
    </table>
    <br />
   <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td valign="top" style="height: 8px">
             <AttachmentPanel:AttachmentPanel ID="attPanel" runat="server" />                   
        </td>
    </tr>
    <tr>
        <td><hr /></td>
    </tr>
</table>

    <table cellspacing="0" cellpadding="0" width="100%" border="0">   
       <tr>   
             <td nowrap="nowrap" align= "left"  style="width : 100%">
               <asp:Button ID="btnReturn" runat="server" Text="Return" onclick="btnReturn_Click" Visible ="false"/>

               <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"/>
            </td>                        
        </tr> 
      </table>      
</asp:Panel>
<script language="javascript" type="text/javascript">    
function check_validate()
{
  //alert("Please Select Requisition");
    if(lstRequisition.SelectedIndex == -1) 
    {
        alert("Please Select Requisition");
        return false;
    }
    return true;
}

</script>	
</asp:Content>
