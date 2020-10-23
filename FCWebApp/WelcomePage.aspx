<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="FCWebApp.WelcomePage" %>

<asp:Content ID="ContentWelcomePage" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome ;)</h1>
        <p class="lead">Welcome to Flipped Classroom Management Backend. For more details of this platform, please press Learn More.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h2>User Management</h2>
            <p>
                To update, add or delete the platform users.
            </p>
            <p>
                <a runat="server" class="btn btn-default" href="~/Pages/UserManagementPage">Manage &raquo;</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2>Platform Settings</h2>
            <p>
                To change settings or adjust system functions.
            </p>
            <p>
                <a runat="server" class="btn btn-default" href="~/Pages/PlatformSettingsPage">Settings &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>