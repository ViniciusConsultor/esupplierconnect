<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="EnqDeliveryOrders.aspx.cs" Inherits="DeliveryOrder_EnquireDeliveryOrders" %>

<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">Enquire Delivery Order</asp:Label></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
     <asp:Panel ID="plMessage" runat="server" Visible="false">
        <asp:Label runat="server" ID="lblMessage" CssClass="" Visible="True"></asp:Label>
    </asp:Panel>
    <asp:Panel CssClass="GreyTable" ID="plSearch" runat="server" Visible="true">
        <table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top" style="height: 8px">
                   <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">
                   
                   <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="lbl1" runat="server" Text="Order No"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:DropDownList ID="ddlOrderNo" runat="server" AutoPostBack="false" Width ="100">
                                <asp:ListItem value="0" Text=""></asp:ListItem>
                                <asp:ListItem value="1" Text="Text 1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="Label5" runat="server" Text="Material No"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:DropDownList ID="ddlMaterialNo" runat="server" AutoPostBack="false" Width ="100">
                                <asp:ListItem value="0" Text=""></asp:ListItem>
                                <asp:ListItem value="1" Text="Text 1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                                        <tr>
                        <td align="left" nowrap Width="130px">
                            <asp:Label ID="Label6" runat="server" Text="Delivery No"></asp:Label>
                        </td> 
                        <td  align="left" style="width: 100%">
                            <asp:DropDownList ID="ddlDeliveryNo" runat="server" AutoPostBack="false" Width ="100">
                                <asp:ListItem value="0" Text=""></asp:ListItem>
                                <asp:ListItem value="1" Text="Text 1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                         
                        <tr>
                            <td align="left" >
                                <asp:Label ID="lblDeliveryOrderDate" runat="server" Text="DO Date" Width="130px"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <table id="tblDates" cellpadding="0" cellspacing="0">
                                    <tr valign="middle">
                                        <td valign="middle">
                                            <asp:Label ID="lblFrom" Text="From" runat="server"></asp:Label>&nbsp;</td>
                                        <td align="center" style="width:200px">
                                             <DatePicker:DatePicker ID="dtpFrom" runat="server" />
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>&nbsp;</td>
                                        <td align="center" style="width:200px">
                                            <DatePicker:DatePicker ID="dtpTo" runat="server" />
                                        </td>
                                    </tr>
                               </table>
                            </td>
                        </tr>
                        <asp:Panel runat="server" ID="plshSupplier" Visible="false">
                        <tr>
                            <td align="left" >
                                <asp:Label ID="Label1" runat="server" Width="130px" Text="Supplier"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%;" colspan=4>
                                <asp:TextBox runat="server" id="txtSupplierId" Width="200px"></asp:TextBox>
                                <asp:Image runat="server" ID="imgSupplierSearch" ImageUrl="~/Images/Common/Search.gif" height="20"/>
                            </td>
                        </tr>
                        </asp:Panel> 
                        <asp:Panel runat="server" ID="plshBuyer" Visible="false">
                        <tr>
                            <td align="left" >
                                <asp:Label ID="Label2" runat="server" Width="130px" Text="Buyer"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <asp:TextBox runat="server" id="txtBuyer"  Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        </asp:Panel> 
                        <asp:Panel runat="server" ID="plshStatus" Visible="false">
                        <tr>
                            <td align="left" >
                                <asp:Label ID="Label4" runat="server" Width="130px" Text="Status"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        </asp:Panel> 
                        <tr>
                            <td colspan="9" style="text-align: right">
                                <asp:Button ID="btnSearch" runat="server" Text="Search"  OnClick="btnSearch_Click"/>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel> 
    <br />
    <asp:Panel CssClass="GreyTable" ID="plResult" runat="server" > 
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
                 <asp:GridView Width="100%" ID="gvData" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                   AllowSorting="false" CellPadding="2">
                    <Columns>
                        <asp:TemplateField HeaderText="S/N" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
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
                            <ItemStyle Width = "5%" HorizontalAlign="left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Order Number " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:LinkButton runat="server" ID="lbhlOrderNo" Text=' <%# Eval("OrderNumber") %> '></asp:LinkButton>  
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="15%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Item Sequence " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
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
                            <ItemStyle Wrap="false" Width="10%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Material Number " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" nowrap="nowrap">
                                            <asp:Label ID="lblOrderDate" runat="server" CssClass="" Text=' <%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("OrderDate")))) %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table>  
                            </ItemTemplate> 
                            <ItemStyle Wrap="false" Width="15%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Delivery Number " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                            <asp:Label ID="lblAmount" runat="server" CssClass="" Text='<%# Eval("OrderAmount") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="10%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Delivery Date " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                            <asp:Label ID="lblGSTAmount" runat="server" CssClass="" Text='<%# Eval("GstAmount") %>'></asp:Label>
                                            
                                            <asp:Label ID="lblOrderDate" runat="server" CssClass="" Text=' <%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("OrderDate")))) %> '></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Delivery Quantity " HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%">
                                            <asp:Label ID="lblCurrency" runat="server" CssClass="" Text='<%# Eval("CurrencyCode") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/>
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


