<%@ Page Title="Discuss Class Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DiscussionHomePage.aspx.cs" Inherits="FCWebApp.Pages.DiscussionHomePage" %>

<asp:Content ID="DiscussionHomePage" ContentPlaceHolderID="MainContent" runat="server">
    <%-- 引入 jQuery --%>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <div class="container">
        <h2>Discuss Home - <%= this.topic %></h2>
    </div>
    <% if (this.attendInfo != null)
        { %>
    <%-- 上传材料部分: 只限已报名该讨论课的客户使用 --%>
    <hr />
    <h3>Uploaded Files</h3>
    <div class="row" style="margin: 20px 0 0 0">
        <asp:SqlDataSource ID="SqlDataSourceMySQL" runat="server" ConnectionString="<%$ ConnectionStrings:hanPublicMySQLConnectionString %>" ProviderName="<%$ ConnectionStrings:hanPublicMySQLConnectionString.ProviderName %>" SelectCommand="SELECT m.id, m.attend_id, upload_time, file_name, file_url FROM `fc_discuss_material` m, `fc_discuss_attend` a WHERE m.attend_id=a.id AND a.id=@attendId AND a.stu_id=@stuId AND m.type=0;">
            <SelectParameters>
                <asp:SessionParameter Name="stuId" SessionField="CurrentUserId" />
                <asp:Parameter Name="attendId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="tableUploadedFiles" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSourceMySQL">
            <Columns>
                <asp:BoundField DataField="file_name" HeaderText="File Name" SortExpression="file_name" />
                <asp:BoundField DataField="upload_time" HeaderText="Uploaded Time" SortExpression="upload_time" />
                <asp:BoundField DataField="file_url" HeaderText="file_url" SortExpression="file_url" Visible="False" />
                <asp:TemplateField HeaderText="Options">
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkOpen" runat="server" Text='<%#"Download" %>' NavigateUrl='<%# "/UploadFiles/" + Eval("file_url") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="row" style="margin: 20px 0 0 0">
        <button class="btn btn-primary" type="button" data-toggle="modal" data-target="#addFileModal">Upload File</button>
    </div>

    <!-- 上传材料文件的模态框 -->
    <div class="modal fade" id="addFileModal" tabindex="-1" role="dialog" aria-labelledby="addFileModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <%-- 标题 --%>
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Add File</h4>
                </div>
                <%-- 上传文件控件 --%>
                <div class="modal-body">
                    <div class="container">
                        <input id="fileUpload" type="file"/>
                    </div>
                </div>
                <%-- 上传按钮 --%>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" id="btnFileUpload" class="btn btn-default">Upload</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>

    <%-- 上传讨论课报告部分 --%>
    <hr />
    <h3>Upload Report File</h3>
    <% if (this.isReportAssigned)
        { %>
    <h4>Good! You have alrady assigned your report.</h4>
    <% } else { %>
    <%-- 上传讨论课报告: 只限还没有传报告的客户使用 --%>
    <div class="row" style="margin: 20px 0 0 0">
        <button class="btn btn-primary" type="button" data-toggle="modal" data-target="#addReportFileModal">Upload Report File</button>
    </div>

    <!-- 上传讨论课报告文件的模态框 -->
    <div class="modal fade" id="addReportFileModal" tabindex="-1" role="dialog" aria-labelledby="addReportFileModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <%-- 标题 --%>
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="addReportFileModalLabel">Add Report File</h4>
                </div>
                <%-- 上传文件控件 --%>
                <div class="modal-body">
                    <div class="container">
                        <input id="reportFileUpload" type="file"/>
                    </div>
                </div>
                <%-- 上传按钮 --%>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" id="btnReportFileUpload" class="btn btn-default">Upload</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
    <hr />
    <% } %>

    <%-- 已报名讨论课，允许取消报名讨论课 --%>
    <div class="row" style="margin: 20px 0 0 0">
        <button class="btn btn-danger" type="button" data-toggle="modal" data-target="#confirmSignOutModal">Sign Out this Discussion</button>
    </div>
    <!-- 取消报名的确认的模态框 -->
    <div class="modal fade" id="confirmSignOutModal" tabindex="-1" role="dialog" aria-labelledby="confirmSignOutModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <%-- 标题 --%>
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="confirmSignOutModalTitle">Confirm</h4>
                </div>
                <%-- 中间内容 --%>
                <div class="modal-body">
                    <p>Please make sure that you're going to sign out this discussion class.</p>
                </div>
                <%-- 确认/取消按钮 --%>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button runat="server" OnClick="btnSignOutDiscuss_Click" CssClass="btn btn-danger" ID="btnSignOutDiscuss" Text="Confirm" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
    <% } else { %>
    <%-- 没有报名讨论课的，显示未报名讨论课，并给出报名按钮 --%>
    <h3>Discussion Class - Sign In</h3>
    <h5>You have not signed in this discussion class yet!</h5>
    <div class="row" style="margin: 20px 0 0 0">
        <asp:Button OnClick="btnSignIn_Click" runat="server" ID="btnSignIn" CssClass="btn btn-primary" Text="Sign In" />
    </div>

    <% } %>
    <%-- 加载页面时，获取已经上传至该讨论课的资料 --%>
    <script>
        $(document).ready(function () {
            $.ajax({
                url: 'Services/DiscussHandler.ashx?method=getUploadedFiles&aid=<%= this.attendInfo == null ? 0 : this.attendInfo.id %>',
                type: 'GET',
                headers: {
                    "id": <%= Session["CurrentUserId"] == null ? 0 : Session["CurrentUserId"] %>
                },
                success: function (result) {
                    console.log(result);
                },
                error: function (err) {
                    alert(err.statusText)
                }
            });
        })
    </script>
    <%-- 确认上传文件的脚本 --%>
    <script>
        $('#btnReportFileUpload').click(function () {
            var files = reportFileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }

            console.log(data);
            $.ajax({
                url: 'Services/DiscussHandler.ashx?method=uploadReportFile',
                type: 'POST',
                headers: {
                    "id": <%= Session["CurrentUserId"] == null ? 0 : Session["CurrentUserId"] %>,
                    "aid": <%= this.attendInfo == null ? 0 : this.attendInfo.id %>
                },
                data: data,
                contentType: false,
                processData: false,  
                success: function (result) {
                    alert(result);
                    location.reload();
                },
                error: function (err) {
                    alert(err.statusText)
                }  
            });
        })
        $('#btnFileUpload').click(function () {
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }

            console.log(data);
            $.ajax({
                url: 'Services/DiscussHandler.ashx?method=uploadFile',
                type: 'POST',
                headers: {
                    "id": <%= Session["CurrentUserId"] == null ? 0 : Session["CurrentUserId"] %>,
                    "aid": <%= this.attendInfo == null ? 0 : this.attendInfo.id %>
                },
                data: data,
                contentType: false,
                processData: false,
                success: function (result) {
                    alert(result);
                    location.reload();
                },
                error: function (err) {
                    alert(err.statusText)
                }
            });
        })
    </script>

</asp:Content>
