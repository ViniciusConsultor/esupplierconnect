<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DualList.ascx.cs" Inherits="UserControls_DualList" %>
<table cellpadding="0" cellspacing="0" border="0"  >
<tr runat="server" id="trLabels">
    <td class="tdContent" valign="middle" style="padding-left:0px"><asp:Label runat="server" ID="lblTextLeft" Text="Left Text"></asp:Label></td>
    <td class="tdContent"></td>
    <td class="tdContent" valign="middle" style="padding-left:0px"><asp:Label runat="server" ID="lblTextRight" Text="Right Text"></asp:Label></td>
</tr>
<tr>
    <td class="tdContent" style="width:300px; padding-left:0px"><asp:ListBox runat="server" CssClass="LabControl" ID="lbLeft"  Width="100%" SelectionMode="Multiple" Rows="7" ></asp:ListBox></td>
    <td class="tdContent" valign="middle" align="center"  >
        <table cellpadding="0" cellspacing="0" border="0" style="width:50px" >
            <tr><td class="tdContent"><input class="formbutton" type="button"  runat="server" style="width:50px" id="btnToRight" value=">" /></td></tr>
            <tr><td class="tdContent"><input class="formbutton" type="button"  runat="server" style="width:50px" id="btnToRightAll" value=">>" /></td></tr>
            <tr><td class="tdContent"><input class="formbutton" type="button"  runat="server" style="width:50px" id="btnToLeft" value="<" /></td></tr>
            <tr><td class="tdContent"><input class="formbutton" type="button"  runat="server" style="width:50px" id="btnToLeftAll" value="<<" /></td></tr>
        </table>
    </td>
    <td class="tdContent" style="width:300px; padding-left:0px"><asp:ListBox runat="server" CssClass="LabControl" ID="lbRight" Width="100%" SelectionMode="Multiple" Rows="6" EnableViewState="true" ></asp:ListBox></td>
</tr>
</table>
<asp:HiddenField runat="server" ID="hidSelected" />