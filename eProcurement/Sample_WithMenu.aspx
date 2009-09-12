<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="Sample_WithMenu.aspx.cs" Inherits="Sample_WithMenu" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagName="DatePicker" TagPrefix="DatePicker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
 <asp:Panel CssClass="GreyTable" ID="plSearch" runat="server" Visible="true">
        <table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="top" style="height: 8px">
                   <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">
                         <tr>
                            <td align="left" >
                                <asp:Label ID="Label3" runat="server" Width="130px" Text="Title1"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <asp:Label ID="lblOrgTypeName" runat="server" CssClass="labelValue" >fsdfsfd</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" >
                                <asp:Label ID="Label4" runat="server" Width="130px" Text="Title2"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <asp:TextBox runat="server" id="textbox1"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td align="left" >
                                <asp:Label ID="lbl1" runat="server" Width="130px" Text="Title3"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <asp:DropDownList ID="ddlIspType" runat="server" AutoPostBack="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" >
                                <asp:Label ID="lblTitleIspDate" runat="server" Text="Title4" Width="130px"></asp:Label>
                            </td> 
                            <td  align="left" style="width: 100%" colspan=4>
                                <table id="tblDates" cellpadding="0" cellspacing="0">
                                    <tr valign="middle">
                                        <td valign="middle">
                                            <asp:Label ID="lblFrom" Text="From" runat="server"></asp:Label>&nbsp;</td>
                                        <td align="center" style="width:200px">
                                             <DatePicker:DatePicker ID="dpIspDateStart" runat="server" />
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:Label ID="lblTo" Text="To" runat="server"></asp:Label>&nbsp;</td>
                                        <td align="center" style="width:200px">
                                            <DatePicker:DatePicker ID="dpIspDateEnd" runat="server" />
                                        </td>
                                    </tr>
                               </table>
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
    <br /><br />
 <asp:GridView Width="100%" ID="gvUserDetails" runat="server" AllowPaging="false" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="S/N">
                <ItemTemplate>
                    <span><%# Container.DataItemIndex + 1 %></span>
                </ItemTemplate>
                <ItemStyle Width = "10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Id">
                <ItemTemplate>
                    <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("Id") %>' CssClass="" ></asp:Label>
                </ItemTemplate> 
                <ItemStyle Width="30%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Name">
                <ItemTemplate>
                    <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("Name") %>' CssClass="" ></asp:Label>
                </ItemTemplate> 
                <ItemStyle Width="60%" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

