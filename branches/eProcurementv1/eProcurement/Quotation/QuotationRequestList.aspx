<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="QuotationRequestList.aspx.cs" Inherits="Quotation_QuotationRequestList" Title="Quotation Request List" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>

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
 <asp:Panel ID="plSearch" runat="server" Visible="true">
    <table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="top" style="height: 8px">
               <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">

                    <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="lblTitleIspDateQuotation" runat="server" Text="Quotation Date"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                            <table id="tblDates" cellpadding="0" cellspacing="0">
                                <tr valign="middle">
                                    <td valign="middle">
                                        <asp:Label ID="lblFrom" Text="From" runat="server"></asp:Label>&nbsp;</td>
                                    <td align="center" style="width:150px">
                                         <DatePicker:DatePicker ID="dtQuoDtFrom" runat="server" />
                                    </td>
                                    <td align="right" valign="middle">
                                        <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>&nbsp;</td>
                                    <td align="center" style="width:150px">
                                        <DatePicker:DatePicker ID="dtQuoDtTo" runat="server" />
                                    </td>
                                </tr>
                           </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="lblTitleIspDateExpiry" runat="server" Text="Expiry Date"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                            <table id="Table1" cellpadding="0" cellspacing="0">
                                <tr valign="middle">
                                    <td valign="middle">
                                        <asp:Label ID="Label7" Text="From" runat="server"></asp:Label>&nbsp;</td>
                                    <td align="center" style="width:150px">
                                         <DatePicker:DatePicker ID="dtExpDtFrom" runat="server" />
                                    </td>
                                    <td align="right" valign="middle">
                                        <asp:Label ID="Label8" Text="To" runat="server"></asp:Label>&nbsp;</td>
                                    <td align="center" style="width:150px">
                                        <DatePicker:DatePicker ID="dtExpDtTo" runat="server" />
                                    </td>
                                </tr>
                           </table>
                        </td>
                    </tr>
                    <tr>
                       <td align="left" nowrap Width="130px">
                            <asp:Label ID="Label6" runat="server" Text="Quotation No"></asp:Label>
                           
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:TextBox runat="server" id="txtQuotationNo"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Enabled="false"  runat="server" Display="Dynamic" ControlToValidate="txtQuotationNo" ErrorMessage="Please enter Quotation Number."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="lbl1" runat="server" Text="Request No."></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:DropDownList ID="ddlRequestNo" runat="server" AppendDataBoundItems="true" AutoPostBack="false">
                                <asp:ListItem value="" Text="- All -"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <asp:Panel ID="pnlSupplier" runat="server" Visible="true">
                    <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="Label10" runat="server" Text="Supplier"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%;">
                            <asp:TextBox runat="server" id="txtSupplierId"></asp:TextBox>
                            <img style="cursor: hand; vertical-align:middle" id="imgSupplierSearch" height="20" src="../Images/Common/Search.gif" runat="server" />
                        </td>
                    </tr>
                    </asp:Panel>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
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
            <td nowrap="nowrap" style="height: 20px" >
                <asp:Label ID="lblCount" runat="server" CssClass="labelMessage" ></asp:Label>
            </td>
            <td width="100%" style="height: 20px"></td>
        </tr> 
    </table>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
	        <td valign="top" colspan="10" style="height: 20px">
                <asp:GridView Width="100%" ID="gvData" runat="server" OnPageIndexChanging ="gvData_PageIndexChanging" OnRowDataBound="gvData_RowDataBound" AllowPaging="True" AutoGenerateColumns="False" CellPadding="2">
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
                        <asp:TemplateField HeaderText="Request No">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right" nowrap>
                                            <asp:LinkButton runat="server" ID="hlReqNo" Text=' <%# Eval("RequestNumber") %> ' OnClick="hlReqNo_OnClick"></asp:LinkButton>  
                                            <asp:Label ID="lblReqNo" runat="server" CssClass="" Text='<%# Eval("RequestNumber") %>' Visible="false"></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="10%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quotation No">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblQuotationNumber" runat="server" CssClass="" Text='<%# Eval("QuotationNumber") %> '></asp:Label>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="False" Width="15%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quotation Date ">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblQuotationDate" runat="server" CssClass="" Text=' <%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("QuotationDate")))) %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="False" Width="15%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Supplier Id ">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblSupplierId" runat="server" CssClass="" Text='<%# Eval("SupplierId") %> '></asp:Label>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="False" Width="10%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Expiry Date">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                            <asp:Label ID="lblExpiryDate" runat="server" CssClass="" Text='<%# Eval("ExpiryDate") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
	        </td>
        </tr>
    </table>
</asp:Panel>

    <script language="javascript" type="text/javascript">    
        function OpenSupplierDialog(txtSupplierId)
        {
            var customerRefNo = document.getElementById(txtSupplierId).value;        
            
            var MyArgs;
            var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:600px;dialogWidth:720px;dialogHide:true";
            
            MyArgs = window.showModalDialog("../Dialog/SearchSupplier.aspx", MyArgs, WinSettings);
                        
            if(MyArgs != null)
            {
                document.getElementById(txtSupplierId).value = MyArgs[0].toString();
            }
        }
    </script>

</asp:Content>


