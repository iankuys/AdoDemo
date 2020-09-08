<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="DemoADO.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<table style="border: 1px solid black; font-family:Arial">
    <tr>
        <td>
            Employee Name
        </td>
        <td>
            <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
        </td>
    </tr>        
    <tr>
        <td>
            Gender
        </td>
        <td>
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr> 
    <tr>
        <td class="auto-style1">
            City
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
        </td>
    </tr>   
        <td>
            DepartmentId
        </td>
        <td>
            <asp:TextBox ID="TextDepartment" runat="server"></asp:TextBox>
        </td>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                onclick="btnSubmit_Click" />
        </td>
    </tr>          
    <tr>
        <td colspan="2">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </td>
    </tr>  
</table>
    </form>
</body>
</html>
