<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttachmentPanel.ascx.cs" Inherits="UserControls_AttachmentPanel" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td style="height: auto">
            <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblResult" runat="server" Text="" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvFileUpload" runat="server" PageSize="5" AllowPaging="True" AutoGenerateColumns="False"
                Width="100%" OnRowDataBound="gvFileUpload_RowDataBound" OnRowCommand="gvFileUpload_RowCommand"
                OnPreRender="gvFileUpload_PreRender" HeaderStyle-Height="10px">
                <Columns>
                    <asp:TemplateField HeaderText="S/N" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="30px"
                        ItemStyle-Width="30px" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <span>
                                <%# Container.DataItemIndex + 1 %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attachment Name" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td Width="100%">
                                        <asp:LinkButton ID="lbtnDocumentName" runat="server" Text='<%# Eval("FileName") %>'
                                            CommandName="Download" CommandArgument='<%# Eval("AttachmentId") %>' CausesValidation="False"></asp:LinkButton>
                                    </td>
                                   <td>&nbsp;</td>
                                </tr>
                            </table>  
                        </ItemTemplate> 
                        <ItemStyle Wrap="false" Width="30%"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attachment Description" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td Width="100%">
                                        <asp:Label ID="lblFileDesc" runat="server" CssClass="" Text='<%# Eval("FileDesc") %> '></asp:Label>  
                                    </td>
                                   <td>&nbsp;</td>
                                </tr>
                            </table>  
                        </ItemTemplate> 
                        <ItemStyle Wrap="false" Width="40%"/>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Size" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td Width="100%" nowrap align="right">
                                        <asp:Label ID="lblFileSize" runat="server" CssClass="" Text='<%# Eval("FileSize") %> '></asp:Label>  
                                    </td>
                                   <td>&nbsp;</td>
                                </tr>
                            </table>  
                        </ItemTemplate> 
                        <ItemStyle Wrap="false" Width="10%"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attached Date" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td Width="100%" nowrap="nowrap" align="center" >
                                        <asp:Label ID="lblAttachedDate" runat="server" CssClass="" Text=' <%# Eval("AttachDate") %> '></asp:Label>
                                    </td>
                                   <td>&nbsp;</td>
                                </tr>
                            </table>  
                        </ItemTemplate> 
                        <ItemStyle Wrap="false" Width="10%"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created By" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td Width="100%" nowrap>
                                        <asp:Label ID="lblCreatedBy" runat="server" CssClass="" Text='<%# Eval("CreateBy") %> '></asp:Label>  
                                    </td>
                                   <td>&nbsp;</td>
                                </tr>
                            </table>  
                        </ItemTemplate> 
                        <ItemStyle Wrap="false" Width="10%"/>
                    </asp:TemplateField>    
                    <asp:TemplateField HeaderText="Sel" HeaderStyle-Wrap="false"  HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td Width="100%" nowrap>
                                        <asp:CheckBox ID="chkDeleted" runat="server" />
                                         <asp:Label ID="lblDocumentSid" runat="server" Text='<%# Eval("AttachmentId") %>'
                                                Visible="false"></asp:Label>
                                          <asp:Label ID="lblProfileType" runat="server" Text='<%# Eval("ProfileType") %>'
                                                Visible="false"></asp:Label>
                                    </td>
                                   <td>&nbsp;</td>
                                </tr>
                            </table>  
                        </ItemTemplate> 
                        <ItemStyle Wrap="false" Width="0%"/>
                    </asp:TemplateField>    
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<table id="tblLabel" runat="server" width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="2" style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="right" style="padding-right: 10px; width: 5%">
            <asp:Label ID="lblFileRemark" runat="server" Text="Remark :" ForeColor="blue"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblUploadFileSize" runat="server" ForeColor="blue"></asp:Label><br />
            <asp:Label ID="lblTotalFileSize" runat="server" ForeColor="blue"></asp:Label>
        </td>
    </tr>
</table>
<table id="tblUpload" runat="server" width="100%" cellpadding="0" cellspacing="0"
    border="0">
    <tr>
        <td id="tdFirstColumn" runat="server" valign="middle" style="width: 13%" nowrap>
            <asp:Label ID="lblFileUpload" runat="server" Text="Attachment"></asp:Label>
            <span style="color: #ff0000">*</span>
        </td>
        <td>
            <asp:FileUpload ID="fuAttachment" runat="server" Width="400px" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAttachmentDescription" runat="server" TextMode="MultiLine" Width="500px"
                Height="60px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="right">
            <asp:Button ID="btnAddFile" runat="server" Text="Add Document" OnClick="btnAddFile_Click" />
            <asp:Button ID="btnDeleteFile" runat="server" OnClick="btnDeleteFile_Click" Text="Delete Document(s)"
                CausesValidation="False" />
        </td>
    </tr>
</table>
