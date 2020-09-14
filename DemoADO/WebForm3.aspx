<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="DemoADO.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Button ID="btnLoadData" runat="server" Text="Load Data" OnClick="btnLoadData_Click" />
            <asp:Button ID="btnClearData" runat="server" Text="Clear Data" OnClick="btnClearData_Click" />
        </p>
        <p>
            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        </p>
        <div style="margin-top: 0px">
        </div>
        
        <asp:GridView ID="gvProducts" runat="server">
        </asp:GridView>
        
    </form>
</body>
</html>
