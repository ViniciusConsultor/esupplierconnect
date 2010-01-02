<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="PurchaseContractList.aspx.cs" Inherits="PurchaseContract_PurchaseContractList" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<%@ Register Src="~/UserControls/DualList.ascx" TagName="DualList" TagPrefix="DualList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<!--Page Title-->
    <asp:Table ID="tblNavigation" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ID="lblSubPath" runat="server" Text="Label" ForeColor="White">title
                </asp:Label>
                </asp:TableCell>
         </asp:TableHeaderRow>        
    </asp:Table>   
<!--Message Panel--> 
    <asp:Panel ID="plMessage" runat="server" Visible="False">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </asp:Panel>                
             
<!--Search Panel-->
    <asp:Panel ID="plSearch" runat="server" Visible="true">
        <table id="GreyTable" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td style="height: 8px" valign="top">
                    <table id="tblSearch" cellpadding="1" cellspacing="0" border="0" width="100%">
                    <!--FIrst Row-->
                        <tr>
                            <td align="left">
                            <asp:Label runat="server" Text="Contract Date" Width="130px" ID="lblTitlelspDate"></asp:Label>
                            </td>
                            <td align="left" style="width: 100%;" colspan="4">
                                <table id="tblDates" cellpadding="0" cellspacing="0">
                                    <tr valign="middle">
                                        <td valign="middle">
                                         <asp:Label ID="lblFrom" runat="server" Text="From"></asp:Label>&nbsp;
                                         </td> 
                                       
                                        <td align="center" style="width: 200px;">
                                        <DatePicker:DatePicker ID="dtpContractFrom" runat="server" />
                                        </td>
                                        
                                        <td valign="middle">
                                         <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label>&nbsp;
                                         </td> 
                                       
                                        <td align="center" style="width: 200px;">
                                        <DatePicker:DatePicker ID="dtpContractTo" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        
                        <!-- Second Row-->
                        <tr>
                            <td align="left">
                            <asp:Label runat="server" Text="Valid Date" Width="130px" ID="lblTitleexpDate"></asp:Label>
                            </td>
                            <td align="left" style="width: 100%;" colspan="4">
                                <table id="tblExpDates" cellpadding="0" cellspacing="0">
                                    <tr valign="middle">
                                        <td valign="middle">
                                         <asp:Label ID="lblExpFrom" runat="server" Text="From"></asp:Label>&nbsp;
                                         </td> 
                                       
                                        <td align="center" style="width: 200px;">
                                        <DatePicker:DatePicker ID="dtpValFrom" runat="server" />
                                        </td>
                                        
                                        <td valign="middle">
                                         <asp:Label ID="lblExpTo" runat="server" Text="To"></asp:Label>&nbsp;
                                         </td> 
                                       
                                        <td align="center" style="width: 200px;">
                                        <DatePicker:DatePicker ID="dtpValTo" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                     <asp:Panel runat="server" ID="plshSupplier" Visible="false">
                       <tr>
                            <td>
                                <asp:Label ID="lblSupplier" runat="server" Text="Supplier" Width="130px"></asp:Label>
                                </td>
                            <td align="left" colspan="4" style="width: 100%;">
                                <asp:TextBox ID="txtSupplierId" runat="server"></asp:TextBox>
                                <img style="cursor: hand; vertical-align:middle" id="imgSupplierSearch" height="20" src="../Images/Common/Search.gif" runat="server" />
                                </td>
                        </tr>
                      </asp:Panel> 
                        <tr>
                            <td>
                                <asp:Label ID="lblTitleContractNum" runat="server" Text="Contract Number" Width="130px"></asp:Label>
                                </td>
                            <td align="left" colspan="4" style="width: 100%;">
                                <asp:TextBox ID="txtConNum" runat="server"></asp:TextBox>
                                <img style="cursor: hand; vertical-align:middle" id="img1" height="20" src="../Images/Common/Search.gif" runat="server" />
                                </td>
                        </tr>
                        <tr>
                            <td colspan="9" style="text-align: right">
                                <asp:Button ID="btnSearch" runat="server" Text="Search"/>
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
                    <asp:GridView ID="gvData" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False" CellPadding="2">
                        <Columns>
                            <asp:TemplateField HeaderText="Contract Number" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td style="width: 100%;"nowrap="nowrap">
                                                <asp:LinkButton runat="server" ID="lbhlContractNo" Text=' <%# Eval("ContractNumber") %> '></asp:LinkButton>
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
                                            <asp:Label ID="lblCurrency" runat="server" CssClass="" Text='<%# Eval("CurrencyCode") %>'></asp:Label>
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
                                                <asp:Label ID="lblExpiryDate" runat="server" CssClass="" Text=' <%# GetShortDate(GetDateTimeFormStoredValue(Convert.ToInt64( Eval("ExpiryDate")))) %> '></asp:Label>
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


        

</asp:Content>

