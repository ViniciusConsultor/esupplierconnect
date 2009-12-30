<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="EnquiryPurchaseContractList.aspx.cs" Inherits="PurchaseContract_EnquiryPurchaseContractList" Title="eProcurement System" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<!--Page Title-->
    <asp:Table ID="tblNavigation" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ID="lblSubPath" runat="server" Text="Label" ForeColor="White">Purchase Contract List</asp:Label>
                </asp:TableCell>
         </asp:TableHeaderRow>        
    </asp:Table>   
<!--Message Panel--> 
    <asp:Panel ID="plMessage" runat="server" Visible="False">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
     </asp:Panel>                      
<!--Search Panel-->
    <asp:Panel CssClass="GreyTable" ID="plSearch" runat="server" Visible="true">
        <table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top" style="height: 8px">
                   <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">
                         <tr>
                            <td align="left" >
                                <asp:Label ID="Label3" runat="server" Width="130px" Text="Contract Number"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <asp:TextBox runat="server" id="txtContractNumber" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" nowrap>
                                <asp:Label ID="lblTitleContractDate" runat="server" Text="Contract Date"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <table id="tblDates" cellpadding="0" cellspacing="0">
                                    <tr valign="middle">
                                        <td valign="middle">
                                            <asp:Label ID="lblFrom" Text="From" runat="server"></asp:Label>&nbsp;</td>
                                        <td align="center" style="width:200px">
                                             <DatePicker:DatePicker ID="dtpContractFrom" runat="server" />
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>&nbsp;</td>
                                        <td align="center" style="width:200px">
                                            <DatePicker:DatePicker ID="dtpContractTo" runat="server" />
                                        </td>
                                    </tr>
                               </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" nowrap>
                                <asp:Label ID="Label2" runat="server" Text="Expiry Date"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <table id="Table1" cellpadding="0" cellspacing="0">
                                    <tr valign="middle">
                                        <td valign="middle">
                                            <asp:Label ID="Label6" Text="From" runat="server"></asp:Label>&nbsp;</td>
                                        <td align="center" style="width:200px">
                                             <DatePicker:DatePicker ID="dtpExpiryFrom" runat="server" />
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:Label ID="Label7" Text="To" runat="server"></asp:Label>&nbsp;</td>
                                        <td align="center" style="width:200px">
                                            <DatePicker:DatePicker ID="dtpExpiryTo" runat="server" />
                                        </td>
                                    </tr>
                               </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" >
                                <asp:Label ID="Label1" runat="server" Width="130px" Text="Supplier"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%;" colspan=4>
                                <asp:TextBox runat="server" id="txtSupplierId" Width="200px"></asp:TextBox>
                                <asp:Image runat="server" ID="imgSupplierSearch" ImageUrl="~/Images/Common/Search.gif" height="20"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" >
                                <asp:Label ID="Label4" runat="server" Width="130px" Text="Status"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="false" Width="205px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9" style="text-align: right">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel> 
    <br />
    <asp:Panel ID="plResult" runat="server" CssClass="GreyTable">
        <table cellpadding="0" cellspacing="0" width="100%" border="0">
            <tr>
                <td nowrap = "nowrap">
                    <asp:Label ID="lblCount" runat="server" CssClass="labelMessage"></asp:Label>
                    </td>
                <td style="width: 100%;">
                </td>

            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td valign="top" colspan="10" style="height: 19px;">
                    <asp:GridView ID="gvData" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False" CellPadding="2"
                     OnPageIndexChanging ="gvData_PageIndexChanging" OnRowDataBound="gvData_RowDataBound">
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
                            <asp:TemplateField HeaderText="Contract Number" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td style="width: 100%;"nowrap="nowrap">
                                                <asp:LinkButton runat="server" ID="lbhlContractNo" Text=' <%# Eval("ContractNumber") %> '  OnClick="hlContractNo_OnClick"></asp:LinkButton>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract Date" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="width: 100%;" nowrap="nowrap">
                                                <asp:Label ID="lblContractDate" runat="server" CssClass="" Text=' <%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("ContractDate")))) %> '></asp:Label>
                                                </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="lblCategory" runat="server" CssClass="" Text='<%# Eval("ContractCategory") %>'></asp:Label>
                                        </tdP
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="15%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Payment Terms" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                             <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" >
                                            <asp:Label ID="lblPaymentTerms" runat="server" CssClass="" Text='<%# Eval("PaymentTerms") %>'></asp:Label>
                                        </tdP
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="15%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Currency ID" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%">
                                            <asp:Label ID="lblCurrency" runat="server" CssClass="" Text='<%# Eval("Currency") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="5%"/> 
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contract Value" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td Width="100%" align="right">
                                            <asp:Label ID="lblValue" runat="server" CssClass="" Text='<%# Eval("ContractValue") %>'></asp:Label>
                                        </td>
                                       <td>&nbsp;</td>
                                    </tr>
                                </table> 
                            </ItemTemplate> 
                            <ItemStyle Width="10%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Expiry Date" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                           <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="width: 100%;" nowrap="nowrap">
                                                <asp:Label ID="lblExpiryDate" runat="server" CssClass="" Text=' <%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("ValidityEnd")))) %> '></asp:Label>
                                                </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                    <ItemStyle Wrap="false" />                        
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplier" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
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
                            <ItemStyle Wrap="false" Width="10%"/>
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



