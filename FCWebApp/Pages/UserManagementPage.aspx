<%@ Page Title="User Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManagementPage.aspx.cs" Inherits="FCWebApp.Pages.UserManagementPage" %>

<asp:Content ID="ContentUserManPage" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>User Management</h2>

        <div class="row" style="margin-top: 20px">
            <div class="col-xs-3 col-sm-2">
                <asp:LinkButton ID="RefreshListButton" runat="server" OnClick="RefreshListButton_Click" CssClass="btn btn-default">
                    Refresh List
                </asp:LinkButton>
            </div>
            <div class="col-xs-3 col-sm-2">
                <asp:LinkButton ID="AddUserButton" runat="server" OnClick="AddUserButton_Click" CssClass="btn btn-default">
                    Add User
                </asp:LinkButton>
            </div>
        </div>

        <div class="row" style="margin: 20px 0 0 0">
            <asp:Table ID="TableUsers" runat="server" CssClass="table table-striped table-bordered table-hover">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Student ID / Teacher ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Operations</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>
