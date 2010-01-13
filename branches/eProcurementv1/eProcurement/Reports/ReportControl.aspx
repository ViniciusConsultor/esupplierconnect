<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageNoMenu.master" AutoEventWireup="true" CodeFile="ReportControl.aspx.cs" Inherits="Reports_ReportControl" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"/>
</asp:Content>

