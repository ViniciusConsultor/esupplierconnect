<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControls_Header" %>
<%@ Register Src="../UserControls/HeaderTop.ascx" TagName="HeaderTop" TagPrefix="ucHeaderTop" %>

<ucHeaderTop:HeaderTop ID="HeaderTop" runat="server" />
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
                            <td nowrap>
                               0001 - CPP GLOBAL PRODUCTS P L 
                            </td>
                            <td nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td nowrap>
                               Role: 
                            </td>
                            <td nowrap>&nbsp;</td>
                            <td nowrap>
                               Administrator 
                            </td>
                            <td width="100%"></td>
                         </tr>
                     </table>    
                </td>
                <td class="TopMenu"> | </td>
                <td class="TopMenu"  style="width:10%"><a href="#" style="color:black">&nbsp;About&nbsp;Us&nbsp;</a></td>
                <td class="TopMenu"> | </td>
                <td class="TopMenu"  style="width:10%"><a href="mailto:raymondkhoo@fujitecsg.com" style="color:black">&nbsp;Contact&nbsp;Us&nbsp;</a></td>
                <td class="TopMenu"> | </td>
                <td class="TopMenu"  style="width:10%"><a href="#" style="color:black">&nbsp;logout&nbsp;</a></td>
             </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td>
        <table id="Table3" BORDER=0 style="background-color:#6666cc;vertical-align:middle;" cellpadding=0 cellspacing =0 width="100%">
             <tr>
                <td class="TopMenu" style="width:70%">
                    <table id="Table5" BORDER=0 cellpadding=0 cellspacing =0 width="100%">
                         <tr>
                            <td nowrap>
                               Address:
                            </td>
                            <td nowrap>&nbsp;</td>
                            <td nowrap>
                               Fujitec Singapore Corpn, Ltd. 204 Bedok South Avenue 1 Singapore 469333
                            </td>
                            <td width="100%"></td>
                            <td nowrap>
                               Sunday 31 Oct 2009 16:56
                            </td>
                         </tr>
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