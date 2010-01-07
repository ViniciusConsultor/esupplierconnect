<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchMaterial.aspx.cs" Inherits="Dialog_SearchMaterial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <base target="_self" />
    <title>Search material</title>
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
                                <asp:Label ID="lblMaterialNo" runat="server" Text="Material Number"></asp:Label>
                             </td>
                             <td nowrap>&nbsp;&nbsp;</td>
                            <td width= "100%">
                                <asp:TextBox ID="txtMaterialNo" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" nowrap>
                                <asp:Label ID="lblMaterialDesc" text="Material Description" runat="server"></asp:Label>
                             </td>
                             <td nowrap>&nbsp;&nbsp;</td>
                            <td width= "100%">
                                <asp:TextBox ID="txtMaterialDesc" runat="server" Width="300px"></asp:TextBox>
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
                    <asp:GridView ID="gvMaterial" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        OnPageIndexChanging="gvMaterial_PageIndexChanging" Width="100%">
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
                            <asp:BoundField HeaderText="Material Number" DataField="MaterialNumber">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Material Description" DataField="materialDescription">
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
