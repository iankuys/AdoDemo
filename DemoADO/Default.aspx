<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoADO._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ADO.NET Tutorial Exercises</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Pick one of the links below</h2>

            <p>
                <ul>
                    <li><a href="WebForm1.aspx">ADO.NET(Introduction)</a></li>
                    <li><a href="WebForm2.aspx">Stored PROC with ADO.NET(Parameterized)</a></li>
                    <li><a href="WebForm3.aspx">Cache in ADO.NET</a></li>
                    <li><a href="WebForm4.aspx">Getting started with SqlDataReader</a></li>
                    <li><a href="WebForm5.aspx">Display a view with a new column</a></li>
                    <li><a href="SqlCommandBuilderTutorial.aspx">SqlCommandBuilder</a></li>
                    <li><a href="DisconnectedDataAccess.aspx">Disconnected Data Access</a></li>
                </ul>
            </p>
        </div>

    </div>

</asp:Content>
