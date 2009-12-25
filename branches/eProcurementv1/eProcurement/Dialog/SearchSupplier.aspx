<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchSupplier.aspx.cs" Inherits="Dialog_SearchSupplier" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <base target="_self" />
    <title>Search Supplier</title>
</head>
<body>
    <form id="form1" runat="server">
        <table cellspacing="0" width="700px" border=0>
            <tr><td>&nbsp;</td></tr>
            <tr style="height: 10px">
                <td style="width: 10px" nowrap>&nbsp;&nbsp;&nbsp;</td>
                <td width= "100%">
                     <table cellspacing="0" width= "100%" border=0>
                        <tr>
                            <td valign="middle" nowrap>
                                <asp:Label ID="lblSupplierId" runat="server" Text="Supplier id"></asp:Label>
                             </td>
                             <td nowrap>&nbsp;&nbsp;</td>
                            <td width= "100%">
                                <asp:TextBox ID="txtSupplierId" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" nowrap>
                                <asp:Label ID="lblSupplierName" text="Supplier Name" runat="server"></asp:Label>
                             </td>
                             <td nowrap>&nbsp;&nbsp;</td>
                            <td width= "100%">
                                <asp:TextBox ID="txtSupplierName" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                     </table> 
                </td>
                <td style="width: 10px" nowrap>&nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <table cellspacing="0" width= "100%" border=0>
                        <tr>
                            <td valign="middle" nowarp width= "100%">
                                
                             </td>
                            <td>
                                <asp:Button ID="btnSearch" Text="Search" OnClick="btnSearch_Click"
                                    runat="server" Width="56px"></asp:Button>
                            </td>
                        </tr>
                     </table> 
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td id="tdSearchResult" runat="server" class="form_sub_header" align="left" visible="true">
                    Search Result:
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lblResult" runat="server" Font-Bold="True" Font-Size="11px" Font-Names="Verdana"
                                    ForeColor="black" Text=""></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:GridView ID="gvSupplier" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        OnPageIndexChanging="gvSupplier_PageIndexChanging" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:RadioButton ID="selectRadioButton" GroupName="itemCheck" AutoPostBack="true"
                                        runat="server" OnCheckedChanged="selectRadioButton_CheckedChanged" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" Wrap="True">
                                </ItemStyle>
                                <HeaderStyle Font-Size="8pt" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S/N" HeaderStyle-Wrap="false">
                                <ItemTemplate>
                                     <asp:Label ID="lblSN" runat="server" CssClass="" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width = "0%" HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Supplier Id" DataField="SupplierId">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Supplier Name" DataField="SupplierName">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="20" align="center">
                    <br />
                    <Input class="formbutton" type=button name="rtnbtn" value="Close" onclick="javascript:window.close();">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
