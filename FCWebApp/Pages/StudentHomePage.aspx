<%@ Page Title="Student Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="FCWebApp.Pages.StudentHomePage" %>

<asp:Content ID="StudentHomePage" ContentPlaceHolderID="MainContent" runat="server">
    <%-- 引入 jQuery --%>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <div class="container">
        <h2>Student Home</h2>
    </div>

    <%-- 我的课程 --%>
    <div class="row" style="margin: 20px 0 0 0">
        <table class="table table-striped table-bordered table-hover" id="table-stu-course">
            <thead>
                <tr>
                    <th>Course ID</th>
                    <th>Course Name</th>
                    <th>Function</th>
                </tr>
            </thead>
            <tbody>
                <tr id="row"></tr>
            </tbody>
        </table>
    </div>

</asp:Content>
