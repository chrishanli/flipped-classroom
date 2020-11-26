<%@ Page Title="Student Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseHomePage.aspx.cs" Inherits="FCWebApp.Pages.CourseHomePage" %>

<asp:Content ID="CourseHomePage" ContentPlaceHolderID="MainContent" runat="server">
    <%-- 引入 jQuery --%>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <div class="container">
        <h2><%= this.name %> - Home</h2>
    </div>

    <%-- 讨论课列表 --%>
    <hr />
    <h3>All Discuss Classes</h3>
    <div class="row" style="margin: 20px 0 0 0">
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr>
                    <th>Serial Number</th>
                    <th>Topic</th>
                    <th>Contents</th>
                    <th>Sign In Start Time</th>
                    <th>Sign In End Time</th>
                    <th>Sign In Status</th>
                    <th>Operation</th>
                </tr>
            </thead>
            <tbody id="table-discuss">
            </tbody>
        </table>
    </div>

    <script>
        window.onload = function () {
            // 文档加载完毕后，去获取讨论课数据
            $.ajax({
                type: "get",
                contentType: "application/json",
                url: "Services/CourseHandler.ashx?method=" + "fetchDiscuss" + "&cid=" + 1,
                success: function (res) {
                    if (res.errCode != 200) {
                        alert(res.data)
                    }
                    // 获取到数据
                    dlist = res.data
                    tableHtml = ""
                    for (i = 0; i < dlist.length; i++) {
                        status = ""
                        switch (dlist[i].signinStatus) {
                            case "not":
                                status = "Not Started";
                                break;
                            case "ing":
                                status = "In Progress";
                                break;
                            case "exp":
                                status = "Expired";
                                break;
                        }

                        tableHtml += "<tr>"
                        tableHtml += "<td>" + dlist[i].sn + "</td>"
                        tableHtml += "<td>" + dlist[i].topic + "</td>"
                        tableHtml += "<td>" + dlist[i].contents + "</td>"
                        tableHtml += "<td>" + dlist[i].signinStartTime + "</td>"
                        tableHtml += "<td>" + dlist[i].signinEndTime + "</td>"
                        tableHtml += "<td>" + status + "</td>"
                        tableHtml += "<td>"
                        tableHtml += "<a href=DiscussionHomePage?did=" + dlist[i].id + ">Open</a>"
                        if (dlist[i].signinStatus === "ing") {
                            tableHtml += "&nbsp;|&nbsp;<a href=DiscussionHomePage?sid=<%=4%>&did=" + dlist[i].id + ">Attend</a>"
                        }
                        tableHtml += "</td>"
                        tableHtml += "</tr>"
                    }
                    $("#table-discuss").html(tableHtml)
                }
            })
        }
    </script>

</asp:Content>
