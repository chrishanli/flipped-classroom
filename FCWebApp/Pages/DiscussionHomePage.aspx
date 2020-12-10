<%@ Page Title="Discuss Class Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DiscussionHomePage.aspx.cs" Inherits="FCWebApp.Pages.DiscussionHomePage" %>

<asp:Content ID="DiscussionHomePage" ContentPlaceHolderID="MainContent" runat="server">
    <%-- 引入 jQuery, jQuery Validation --%>
    <script src="http://static.runoob.com/assets/jquery-validation-1.14.0/lib/jquery.js"></script>
    <script src="http://static.runoob.com/assets/jquery-validation-1.14.0/dist/jquery.validate.min.js"></script>
    <div class="container">
        <h2>讨论课主页 - <%= this.topic %></h2>
    </div>
    <!-- 提问列表 -->
    <hr />
    <h3>讨论课提问</h3>
    <div class="row" style="margin: 20px 0 0 0">
        <asp:SqlDataSource ID="SqlDataSourceQuestion" runat="server" ConnectionString="<%$ ConnectionStrings:hanPublicMySQLConnectionString %>" ProviderName="<%$ ConnectionStrings:hanPublicMySQLConnectionString.ProviderName %>" SelectCommand="SELECT q.id, q.attend_id, q.question_time, q.topic FROM fc_discuss_question q INNER JOIN fc_discuss_attend a ON q.attend_id = a.id WHERE (a.discuss_id = 1)">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSourceQuestion">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="问题编号" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="attend_id" HeaderText="attend_id" SortExpression="attend_id" Visible="False" />
                <asp:BoundField DataField="question_time" HeaderText="提问时间" SortExpression="question_time" />
                <asp:BoundField DataField="topic" HeaderText="提问主题" SortExpression="topic" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkOpen" runat="server" Text='<%#"查看详情" %>' NavigateUrl='<%# "/Pages/QuestionPage.aspx?qid=" + Eval("id") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <h4>此讨论课还未有任何人发表过任何提问。</h4>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div class="row" style="margin: 20px 0 0 0">
        <button class="btn btn-primary" type="button" data-toggle="modal" data-target="#questionModal">提问</button>
    </div>
    <!-- 提交提问的模态框 -->
    <div class="modal fade" id="questionModal" tabindex="-1" role="dialog" aria-labelledby="questionModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <%-- 标题 --%>
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="questionModalLabel">讨论课提问</h4>
                </div>
                <%-- 提问区域 --%>

                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="control-label">提问主题</label>
                        <input ClientIDMode="Static" type="text" class="form-control" id="questionTopic" name="questionTopic" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="control-label">提问内容</label>
                        <textarea ClientIDMode="Static" class="form-control" id="questionContents" name="questionContents" runat="server"></textarea>
                    </div>
                </div>

                <%-- 提交提问按钮 --%>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button runat="server" ID="btnSubmitQuestion" CssClass="btn btn-default" Text="提交提问"
                        OnClick="btnSubmitQuestion_Click"/>
                    <%--<button type="button" id="btnSubmitQuestion" class="btn btn-default">提交提问</button>--%>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
    <script>
        $().ready(function () {
            // 在键盘按下并释放及提交后验证提交表单
            $("#bigForm").validate({
                rules: {
                    <%= questionTopic.UniqueID %>: {
                        required: true,
                        minlength: 2,
                        maxlength: 20
                    },
                    <%= questionContents.UniqueID %>: {
                        required: true,
                        minlength: 2,
                        maxlength: 512
                    },
                },
                messages: {
                    <%= questionTopic.UniqueID %>: {
                        required: "请键入提问主题",
                        minlength: "提问主题最短为两个字符",
                        maxlength: "提问主题不能超过 20 个字符"
                    },
                    <%= questionContents.UniqueID %>: {
                        required: "请键入提问内容",
                        minlength: "提问具体内容最短为两个字符",
                        maxlength: "提问内容不能超过 512 个字符"
                    },
                },
                highlight: function (element) {
                    $(element).closest('.form-group').addClass('has-error');
                },
                success: function (label) {
                    label.closest('.form-group').removeClass('has-error');
                    label.remove();
                },
                errorPlacement: function (error, element) {
                    element.parent('div').append(error);
                }, 
            })
        });
    </script>

    <% if (this.attendInfo != null)
        { %>
    <%-- 上传材料部分: 只限已报名该讨论课的客户使用 --%>
    <hr />
    <h3>上传展示材料</h3>
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
            <EmptyDataTemplate>
                <h4>你还未有上传任何资料。</h4>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div class="row" style="margin: 20px 0 0 0">
        <button class="btn btn-primary" type="button" data-toggle="modal" data-target="#addFileModal">上传档案</button>
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
    <h3>上传讨论课报告</h3>
    <asp:SqlDataSource ID="SqlDataSourceReportFile" runat="server" ConnectionString="<%$ ConnectionStrings:hanPublicMySQLConnectionString %>" ProviderName="<%$ ConnectionStrings:hanPublicMySQLConnectionString.ProviderName %>" SelectCommand="SELECT id, upload_time, file_name, file_url FROM `fc_discuss_material` WHERE attend_id=@attendId AND type=1">
        <SelectParameters>
            <asp:Parameter Name="attendId" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridViewReportFile" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSourceReportFile">
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
        <EmptyDataTemplate>
            <h4>你还未有上传任何该讨论课的汇报。</h4>
        </EmptyDataTemplate>
    </asp:GridView>
    <% if (this.isReportAssigned)
        { %>
    <h4>Good! You have alrady assigned your report.</h4>

    <% }
    else
    { %>
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
                        <input id="reportFileUpload" type="file" />
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
    <%-- 确认上传文件的脚本 --%>
    <script>
        // 上传讨论课档案脚本
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
        // 讨论课提问脚本
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
