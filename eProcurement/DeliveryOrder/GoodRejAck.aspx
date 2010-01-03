<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="GoodRejAck.aspx.cs" Inherits="DeliveryOrder_GoodRejAck" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<%@ Register Src="~/UserControls/DualList.ascx" TagName="DualList" TagPrefix="DualList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<!--Page title-->
<asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
    <asp:TableHeaderRow>
        <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
            <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Goods Rejection Acknowledgment</asp:Label></asp:TableCell>
    </asp:TableHeaderRow>
</asp:Table>
<!--Message Panel-->
<asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
</asp:Panel>
<!--Search Criteria Panel-->
 <asp:Panel ID="plSearch" runat="server" Visible="true" Width="827px" Height="79px">
    <table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="top" >
               <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">
                     <tr>
                        <td align="left" style="width: 60px; height: 20px">
                            <asp:Label ID="lbl1" runat="server" Text="Order No" Width="113px"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 22%; height: 20px;">
                            <asp:TextBox ID="txtOrderNo" runat="server" Width="104px" OnTextChanged="txtOrderNo_TextChanged" AutoPostBack="True"></asp:TextBox></td>
                         <td align="left" style="width: 83px; height: 20px;">
                            <asp:Label ID="Label1" runat="server" Text="Document No" Width="91px"></asp:Label></td>
                         <td align="left" style="width: 6px; height: 20px;">
                            <asp:DropDownList ID="ddlDocumentNo" runat="server" AutoPostBack="false" Width ="155px" OnSelectedIndexChanged="ddlDocumentNo_SelectedIndexChanged">
                                <asp:ListItem value="0"></asp:ListItem>
                                <asp:ListItem value="1" Text="Text 1"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="left" nowrap style="height: 20px; width: 60px;">
                            <asp:Label ID="Label4" runat="server" Text="Item Sequence" Width="112px"></asp:Label></td> 
                        <td  align="left" style="width: 22%; height: 20px;">
                            <asp:DropDownList ID="ddlItemSequence" runat="server" AutoPostBack="false" Width ="100" OnSelectedIndexChanged="ddlItemSequence_SelectedIndexChanged">
                                <asp:ListItem value="0"></asp:ListItem>
                                <asp:ListItem value="1" Text="Text 1"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td align="left" style="width: 83px; height: 20px">
                            <asp:Label ID="Label3" runat="server" Text="Material No"></asp:Label></td>
                        <td align="left" style="width: 6px; height: 20px">
                            <asp:DropDownList ID="ddlMaterialNo" runat="server" AutoPostBack="false" Width ="155px" OnSelectedIndexChanged="ddlMaterialNo_SelectedIndexChanged">
                                <asp:ListItem value="0"></asp:ListItem>
                                <asp:ListItem value="1" Text="Text 1"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="left" nowrap style="height: 20px; width: 60px;">
                            &nbsp;</td> 
                        <td  align="left" style="width: 22%; height: 20px;">
                            &nbsp;</td>
                        <td align="left" style="width: 83px; height: 20px">
                        </td>
                        <td align="left" style="width: 6px; height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right; height: 20px;">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
                        </td>
                        <td colspan="1" style="height: 20px; text-align: right; width: 83px;">
                        </td>
                        <td colspan="1" style="width: 6px; height: 20px; text-align: right">
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
	        <td valign="top" colspan="10" style="height: 20px">
                <asp:GridView Width="100%" ID="gvItem" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="2" OnRowDataBound="gvItem_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S/N">
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
                            <ItemStyle Width = "5%" HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Order Number ">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label runat="server" ID="lblOrderNo" Text=' <%# Eval("OrderNumber") %> '></asp:Label>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="False" Width="15%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Material No">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblMaterialNumber" runat="server" CssClass="" Text='<%# Eval("MaterialNumber") %> '></asp:Label>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="False" Width="10%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Seq">
                        <ItemTemplate>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblItemSeq" runat="server" CssClass="" Text=' <%# Eval("ItemSequence") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                        </ItemTemplate>
                        <ItemStyle Wrap="False" Width="15%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Document No">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblDocumentNo" runat="server" CssClass="" Text=' <%# Eval("DocumentNumber") %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="False" Width="15%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM ">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                            <asp:Label ID="lblUOM" runat="server" CssClass="" Text='<%# Eval("UnitofMeasure") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ref No">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%">
                                            <asp:Label ID="lblRefNo" runat="server" CssClass="" Text='<%# Eval("ReferenceNumber") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reject Qty">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="lblRejectQuantity" runat="server" CssClass="" Text='<%# Eval("RejectQuantity") %>'></asp:Label>
                                        </tdP
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="15%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reject Date">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="lblRejectDate" runat="server" CssClass="" Text='<%#  GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("RejectDate")))) %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="15%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Acknowledge">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:CheckBox ID="chkAcknowledge" runat="server" CssClass="" ></asp:CheckBox>
                                             <asp:HiddenField ID="hdStatus" Visible="false" runat="server" Value=' <%# Eval("AcknowledgeStatus")%> '></asp:HiddenField>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="15%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
	        </td>
        </table>
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
        <td nowrap="nowrap"  align ="center" style="height: 20px">   
                <asp:Button ID="btnAcknowledge" runat="server" Text="Acknowledge" OnClick="btnAcknowledge_Click" Visible="False" />
                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" Visible="False" />
                </td>
                
              </tr> 
        </table>
</asp:Panel>
<script language="javascript" type="text/javascript">    
function CheckACKStatus(Val AckStatus)
{
    alert("Hi HI " & AckStatus)
    if (AckStatus == "Y")
   {return true;}
   else 
    {return false;}
}
</script>
</asp:Content>
