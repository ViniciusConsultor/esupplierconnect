<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Encrypt.aspx.cs" Inherits="UISample_Encrypt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
     Plaintext:<asp:TextBox runat="server" ID="txtPlain"></asp:TextBox>  
     Cipher<asp:TextBox runat="server" ID="txtCipher"></asp:TextBox>  
     <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" OnClick="btnEncrypt_Click"/>
      <asp:Button ID="btnDecrypt" runat="server" Text="Decrypt" OnClick="btnDecrypt_Click"/>
    </form>
</body>
</html>
