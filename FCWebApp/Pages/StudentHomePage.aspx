<%@ Page Title="Student Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="FCWebApp.Pages.StudentHomePage" %>

<asp:Content ID="StudentHomePage" ContentPlaceHolderID="MainContent" runat="server">
    <%-- 引入 jQuery --%>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <div class="container">
        <h2>Welcome, <%= Session["CurrentUserAlias"] %></h2>
    </div>

    <hr />
    <h3>Courses</h3>
    <%-- 我的课程列表 --%>
    <div class="row" style="margin: 20px 0 0 0">
        <asp:GridView ID="tableCourses" runat="server" CssClass="table table-striped table-bordered table-hover" DataSourceID="SqlDataSourceMySQL" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="course_id" HeaderText="Course ID" SortExpression="course_id" />
                <asp:BoundField DataField="name" HeaderText="Course Name" SortExpression="name" />
                <asp:BoundField DataField="class_num" HeaderText="Class Number" SortExpression="class_num" />
                <asp:BoundField DataField="description" HeaderText="Course Description" SortExpression="description" />
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                <asp:TemplateField HeaderText="Options">
                    <ItemTemplate>
                        <asp:HyperLink ID="Link" runat="server" Text='<%#"Enter Home" %>' NavigateUrl='<%# "CourseHomePage?cid=" + Eval("course_id") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <h4>Your course list is empty. Please select a course first!</h4>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceMySQL" runat="server" ConnectionString="<%$ ConnectionStrings:hanPublicMySQLConnectionString %>" ProviderName="<%$ ConnectionStrings:hanPublicMySQLConnectionString.ProviderName %>" SelectCommand="SELECT fc_select.course_id, fc_select.class_num, fc_course.name, fc_course.description, fc_course.status FROM fc_select INNER JOIN fc_course ON fc_select.course_id = fc_course.id WHERE (fc_select.stu_id = 1)">
            <SelectParameters>
                <asp:SessionParameter Name="stuId" SessionField="CurrentUserId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <%--<table class="table table-striped table-bordered table-hover">
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
        </table>--%>
    </div>
    <%--我觉得还是先不用 ajax 了，何必呢 ado.NET 不香嘛<script>
        window.onload = function () {
            // 文档加载完毕后，去获取数据
            $.ajax({
                type: "get",
                contentType: "application/json",
                url: "Services/StudentHandler.ashx?method=" + "fetchCourses",
                headers: {
                    "id": <%= Session["CurrentUserId"] %>
                },
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
    </script>--%>

</asp:Content>
