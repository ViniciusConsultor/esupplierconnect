<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageWithMenu.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="UserManagement_User" Title="User Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:Table ID="tblNavigation" CellSpacing="0" CellPadding="0" runat="server" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass="navigation" VerticalAlign="Middle">
                <asp:Label ForeColor="White" ID="lblSubPath" runat="server">User Profile</asp:Label></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table> 
    <asp:Panel ID="plMessage" runat="server" Visible="false"></asp:Panel> 
    <asp:Panel CssClass="GreyTable" ID="plSearch" runat="server" Visible="true" width="100%">
    <table id="GreyTable" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr><td valign="top" style="height: 8px">
            <table id="tblSearch" cellspacing="0" cellpadding="1" width="100%" border="0">
                <tr>
                    <td align="left" ><asp:Label ID="Label4" runat="server" Width="130px" Text="User ID"></asp:Label></td>
                    <td align="left" style="width: 70%" >
                        <asp:Label runat="server" id="lblUserID" /><asp:Label runat="server" id="lblPSWD" Visible="false" />
                        <asp:TextBox runat="server" id="txtUserID" Visible="false" MaxLength="10" />
                        <asp:RequiredFieldValidator ID="rfvUserID" runat="server" Display="Dynamic" ControlToValidate="txtUserID" ErrorMessage="Please enter user id."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" ><asp:Label ID="Label3" runat="server" Width="130px" Text="User Name"></asp:Label> </td>
                    <td align="left" style="width: 70%"><asp:TextBox runat="server" id="txtUserName" MaxLength="40" ></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtUserName" ErrorMessage="Please enter user name."></asp:RequiredFieldValidator>
                    </td>
                </tr>                
                <tr>
                    <td align="left" ><asp:Label ID="Label2" runat="server" Width="130px" Text="Email"></asp:Label> </td>
                    <td  align="left" style="width: 70%" ><asp:TextBox runat="server" id="txtEmail" MaxLength="70"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="Please enter email."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="Invalid email." Enabled="false" ValidationExpression='@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"' />
                    </td>
                </tr>                
                <tr>
                    <td align="left" ><asp:Label ID="lbl1" runat="server" Width="130px" Text="Role"></asp:Label> </td>
                    <td  align="left" style="width: 100%" colspan="4">
                        <asp:Label ID="lblRole" runat="server" Font-Bold="false" Visible="false" />
                        <asp:DropDownList ID="ddlRole" runat="server" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" Visible="false"></asp:DropDownList>                        
                    </td>
                </tr>
                <tr>
                    <td align="left" ><asp:Label ID="lblproftype" runat="server" Width="130px" Text="Profile Type"></asp:Label> </td>
                    <td  align="left" style="width: 100%" colspan="4">
                        <asp:Label ID="lblType" runat="server" Font-Bold="false" Visible="false" />
                        <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>                        
                    </td>
                </tr>
                <asp:Panel ID="pnlAdmin" runat="server" Visible="false" >
                <asp:Panel ID="pnlBuyer" runat="server" Visible="false" >
                <tr>
                    <td align="left" ><asp:Label ID="Label6" runat="server" Width="130px" Text="Purchasing Group"></asp:Label> </td>
                    <td  align="left" style="width: 100%" colspan="4">
                        <asp:CheckBoxList ID="chklstPG" runat="server" />
                        <%--<asp:XmlDataSource ID="dsXML" runat="server" DataFile="~/App_Data/PurchaseGroups.xml"></asp:XmlDataSource>--%>
                    </td>
                </tr>
                </asp:Panel>
                <asp:Panel ID="pnlSupplier" runat="server" Visible="false" >
                <tr>
                    <td align="left" ><asp:Label ID="Label5" runat="server" Width="130px" Text="Supplier ID"></asp:Label> </td>
                    <td  align="left" style="width: 100%" colspan="4">
                        <asp:Label ID="lblSupplierID" runat="server" Font-Bold="false" Visible="false" />
                        <asp:DropDownList ID="ddlSupplierID" runat="server" AppendDataBoundItems="true" AutoPostBack="false" Visible="false">
                            <asp:ListItem Selected="true" Text="[None]" Value="" />
                        </asp:DropDownList>                        
                    </td>
                </tr>   
                </asp:Panel>
                <tr>
                    <td align="left" ><asp:Label ID="Label1" runat="server" Width="130px" Text="Account Active?"></asp:Label> </td>
                    <td  align="left" style="width: 70%" >
                        <asp:RadioButton ID="rdoStatusYes" Text="Yes" runat="server" Checked="true" GroupName="Status" /> 
                        <asp:RadioButton ID="rdoStatusNo" Text="No" runat="server" GroupName="Status" /> 
                    </td>
                </tr>
                </asp:Panel>   
                <tr><td colspan="9">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Visible="false" />
                    <asp:Button ID="btncancel" runat="server" Text="Back" CausesValidation="false" OnClientClick="javascript:history.go(-1);" />                    
                    <asp:Label ID="lblError" runat="server" CssClass="labelErrorMessage" />
                    <asp:Label ID="lblMessage"  runat="server" CssClass=""></asp:Label>
                </td>
                </tr>
            </table>
        </td></tr>
    </table>
    </asp:Panel> 
</asp:Content>
