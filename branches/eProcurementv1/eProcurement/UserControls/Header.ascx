<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControls_Header" %>
<%@ Register Src="../UserControls/HeaderTop.ascx" TagName="HeaderTop" TagPrefix="ucHeaderTop" %>

<TABLE border="0" width="990" cellpadding="0" cellspacing="0" ID="TABLE7">
    <tr>
        <td>
           <table id="Table6" BORDER=0 style="vertical-align:middle;" cellpadding=0 cellspacing =0 width="200px">
                 <tr>
                    <td nowrap Id="tdTime"></td>
                 </tr>
            </table> 
        </td>
        <td width=100%>&nbsp;</td>
        <td align="right">
             <table id="Table8" BORDER=0 style="vertical-align:middle;" cellpadding=0 cellspacing =0 width="200px">
                 <tr>
                    <td nowrap><asp:HyperLink ID="HyperLink1" runat ="server" NavigateUrl ="" >&nbsp;About&nbsp;Us&nbsp;</asp:HyperLink></td>
                    <td nowrap> | </td>
                    <td nowrap><asp:HyperLink ID="HyperLink3" runat ="server" NavigateUrl ="mailto:raymondkhoo@fujitecsg.com" >&nbsp;Contact&nbsp;Us&nbsp;</asp:HyperLink></td>
                    <td nowrap> | </td>
                    <td nowrap><asp:HyperLink  ID="HyperLink2" runat ="server" NavigateUrl ="~/Common/Logout.aspx">&nbsp;logout&nbsp;</asp:HyperLink></td>
                 </tr>
            </table>
        </td>
    </tr>
</TABLE> 
<TABLE border="0" width="990" cellpadding="0" cellspacing="0" ID="TblTop">
    <tr>
        <td>
            <ucHeaderTop:HeaderTop ID="HeaderTop" runat="server" />        
        </td>
    </tr>
</TABLE> 
<table id="Table1" width="990" border="1" cellspacing="0" cellpadding="0">
  <tr>
    <td>
        <table id="Table2" BORDER=0 style="background-color:#6666cc;vertical-align:middle;" cellpadding=0 cellspacing =0 width="100%">
             <tr>
                <td class="TopMenu" style="width:70%">
                    <table id="Table4" BORDER=0 cellpadding=0 cellspacing =0 width="100%">
                         <tr>
                                <td nowrap>
                                   Login User:
                                </td>
                                <td nowrap>&nbsp;</td>
                                <td nowrap align="left" width="100%">
                                   <asp:Label runat="server" id="lblLoginUser" CssClass="labelValue"></asp:Label> 
                                </td>
                         </tr>
                         <asp:Panel runat ="server" ID="plSupplier" Visible="false">
                          <tr>
                                <td nowrap>
                                   Supplier:
                                </td>
                                <td nowrap>&nbsp;</td>
                                <td align="left" width="100%">
                                   <asp:Label runat="server" id="lblSupplier" CssClass="labelValue"></asp:Label> 
                                </td>
                         </tr>  
                         </asp:Panel> 
                     </table>    
                </td>
             </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td style="height:3px"><asp:Image ID="Image17" runat="server" ImageUrl ="~/Images/common/HeaderLine.gif" width="990" height="3" alt="" /></td>
  </tr>
</table>
