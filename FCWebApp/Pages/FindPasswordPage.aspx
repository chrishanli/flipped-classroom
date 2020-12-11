<%@ Page Title="Student Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindPasswordPage.aspx.cs" Inherits="FCWebApp.Pages.FindPasswordPage" %>

<asp:Content ID="FindPasswordPage" ContentPlaceHolderID="MainContent" runat="server">
    <%-- 引入 jQuery --%>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <div class="container">
        <h2>找回密码 </h2>
    </div>

    <%-- 找回密码页面 --%>
    <hr />
    <div class="row" style="margin: 20px 0 0 0">
        <div class="form-group">
            <label for="exampleInputEmail1">学号 / 工号</label>
            <input runat="server" type="text" class="form-control" id="txtUsername" placeholder="输入学工号">
        </div>
        <asp:Button runat="server" OnClick="btnSubmit_Click" ID="btnSubmit" CssClass="btn btn-default" Text="发送找回邮件" />
    </div>

</asp:Content>
