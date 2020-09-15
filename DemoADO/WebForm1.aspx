<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DemoADO.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Namespaces to keep in mind
        </div>
        <div>
            <ul>
                <li>System.Data.SqlClient</li>
                <li>System.Data.OracleClient</li>
            </ul>
        </div>
        <div>Step 1:</div>
        <div>Connect to database using SqlConnection object, <b>SqlConnection db = new SqlConnection(“ConnectionString”);</b></div>
        <div>How connection string works,<b>eg: “data source =.; database/initial catalogue = server naem; integrated security = any security”;</b></div>
        <br>

        <div>Step 2:</div> 
        <div><b>SqlCommand cmd = new SqlCommand(“sql query command;”, SqlConnection object);</b></div>
        <br>

        <div>Step 3:</div> 
        <div>Open connection, open SqlConnection object,</div>
        <div><b>con.Open();</b></div>
        <br>

        <div>Step 4:</div> 
        <div>Display data by either using Webforms DataSource and DataBind().</div>
        <br>

        <div>Step 5:</div> 
        <div>Make sure to close the connection, either using the using() statemnt, or manually by <b>con.Close()</b></div>
        <br>

        <div>
            <asp:Label ID="LabelMessage" runat="server" Text="Label"></asp:Label>

            <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"></FooterStyle>

                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510"></PagerStyle>

                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510"></RowStyle>

                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#FFF1D4"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#B95C30"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#F1E5CE"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#93451F"></SortedDescendingHeaderStyle>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
