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
        <asp:GridView ID="tableDiscuss" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="MySQLDataSource">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Discuss ID" SortExpression="id" />
                <asp:BoundField DataField="serial_num" HeaderText="Serial Number" SortExpression="serial_num" />
                <asp:BoundField DataField="topic" HeaderText="Topic" SortExpression="topic" />
                <asp:BoundField DataField="attend_start" HeaderText="Attend Start Time" SortExpression="attend_start" />
                <asp:BoundField DataField="attend_end" HeaderText="Attend End Time" SortExpression="attend_end" />
                <asp:BoundField DataField="contents" HeaderText="Contents" SortExpression="contents" />
                <asp:TemplateField HeaderText="Options">
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkOpen" runat="server" Text='<%#"Open" %>' NavigateUrl='<%# "DiscussionHomePage?did=" + Eval("id") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="MySQLDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:hanPublicMySQLConnectionString %>" ProviderName="<%$ ConnectionStrings:hanPublicMySQLConnectionString.ProviderName %>" SelectCommand="SELECT dis.id, topic, serial_num, attend_start, attend_end, contents FROM fc_discuss dis, fc_course WHERE fc_course.id=@courseId AND fc_course.id=dis.course_id">
            <SelectParameters>
                <asp:QueryStringParameter Name="courseId" QueryStringField="cid" />
            </SelectParameters>
        </asp:SqlDataSource>
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
                            tableHtml += "&nbsp;|&nbsp;<a onclick=\"joinDiscuss(" + dlist[i].id + ")\">Attend</a>"
                        }
                        tableHtml += "</td>"
                        tableHtml += "</tr>"
                    }
                    $("#table-discuss").html(tableHtml)
                }
            })
        }
    </script>
    <%-- 报名讨论课 --%>
    <script>
        function joinDiscuss(did) {
            // 发送报名讨论课请求
        }
    </script>

</asp:Content>
