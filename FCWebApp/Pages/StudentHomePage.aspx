<%@ Page Title="Student Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="FCWebApp.Pages.StudentHomePage" %>

<asp:Content ID="StudentHomePage" ContentPlaceHolderID="MainContent" runat="server">
    <%-- 引入 jQuery --%>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <div class="container">
        <h2>Welcome, <%= this.name %></h2>
    </div>

    <hr />
    <h3>Courses</h3>
    <%-- 我的课程列表 --%>
    <div class="row" style="margin: 20px 0 0 0">
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr>
                    <th>Course ID</th>
                    <th>Course Name</th>
                    <th>Description</th>
                    <th>Status</th>
                    <th>Class Number</th>
                    <th>Operation</th>
                </tr>
            </thead>
            <tbody id="table-courses">
            </tbody>
        </table>
    </div>
    <script>
        window.onload = function () {
            // 文档加载完毕后，去获取数据
            $.ajax({
                type: "get",
                contentType: "application/json",
                url: "Services/StudentHandler.ashx?method=" + "fetchCourses",
                success: function (res) {
                    if (res.errCode != 200) {
                        alert(res.data)
                    }
                    // 获取到数据
                    clist = res.data
                    tableHtml = ""
                    for (i = 0; i < clist.length; i++) {
                        tableHtml += "<tr>"
                        tableHtml += "<td>" + clist[i].id + "</td>"
                        tableHtml += "<td>" + clist[i].name + "</td>"
                        tableHtml += "<td>" + clist[i].description + "</td>"
                        tableHtml += "<td>" + clist[i].status + "</td>"
                        tableHtml += "<td>" + clist[i].classNum + "</td>"
                        tableHtml += "<td><a href=CourseHomePage?cid=" + clist[i].id + ">Home Page</td>"
                        tableHtml += "</tr>"
                    }
                    $("#table-courses").html(tableHtml)
                }
            })
        }
    </script>

</asp:Content>
