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
                   AllowSorting="false" CellPadding="2"  OnRowDataBound="gvData_RowDataBound">
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
                                            <asp:Label ID="lblOrderNo" runat="server" CssClass="" Text='<%# Eval("OrderNumber") %> '></asp:Label>  
                                 
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
                                            <asp:Label ID="lblMaterialNumber" runat="server" CssClass="" Text='<%# Eval("MaterialNumber")  %> '></asp:Label>
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
                                            <asp:Label ID="lblDeliveryNumber" runat="server" CssClass="" Text='<%# Eval("DeliveryNumber") %>'></asp:Label>
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
                                                                                        
                                            <asp:Label ID="lblDeliveryDate" runat="server" CssClass="" Text=' <%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("DeliveryDate")))) %> '></asp:Label>
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
                                            <asp:Label ID="lblDeliveryQuantity" runat="server" CssClass="" Text='<%# Eval("DeliveryQuantity") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Print" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%">
                                            <asp:Button ID="btnPrint" runat="server" Text="Print"/>
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
        
        function PrintReport(refNo)
        {
            var MyArgs;
            //var WinSettings = "center:yes;resizable:no;status:no;dialogHeight:768px;dialogWidth:1024px;dialogHide:true";    
            //MyArgs = window.showModalDialog("../Reports/ReportControl.aspx?" + Math.random()*5 + "&ReportName=DELIVERY&Delivery=" + refNo, MyArgs, WinSettings);
            
            var WinSettings = "toolbar=0,location=0,status=1,menubar=0,scrollbars=1,resizable=1,width=1024px,height=700px,top=0,left=0";    
            window.open("../Reports/ReportControl.aspx?" + Math.random()*5 + "&ReportName=DELIVERY&Delivery=" + refNo,"epReport",WinSettings);
            
        }
    </script>
</asp:Content>


