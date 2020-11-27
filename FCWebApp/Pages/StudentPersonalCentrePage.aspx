<%@ Page Title="Student Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentPersonalCentrePage.aspx.cs" Inherits="FCWebApp.Pages.StudentPersonalCentrePage" %>

<asp:Content ID="StudentPersonalCentrePage" ContentPlaceHolderID="MainContent" runat="server">
    <%-- 引入 jQuery --%>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <div class="container">
        <h2>Personal Centre</h2>
    </div>

     <%-- 个人信息页 --%>
    <div class="row" style="margin: 20px 0 0 0">
        <%-- 导航栏 --%>
        <div class="col-md-3">
            <div class="list-group">
                <a href="#" class="list-group-item active">Personal Info
                </a>
                <a href="#" class="list-group-item">Change Password
                </a>
                <a href="#" class="list-group-item">Log Out
                </a>
            </div>
        </div>
        <%-- 个人信息页 --%>
        <div class="col-md-9">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Personal Info
                    </h3>
                </div>
                <div class="panel-body">
                    <%-- 显示个人信息表格 --%>
                    <dl class="dl-horizontal" style="margin-bottom: 10px">
                        <dt>Student ID</dt>
                        <dd><%= this.Session["CurrentUsername"] %></dd>
                    </dl>
                    <dl class="dl-horizontal" style="margin-bottom: 10px">
                        <dt>Real Name</dt>
                        <dd><%= this.Session["CurrentUserAlias"] %></dd>
                    </dl>
                    <dl class="dl-horizontal" style="margin-bottom: 10px">
                        <dt>Email</dt>
                        <dd><%= this.Session["CurrentUserEmail"] %></dd>
                    </dl>
                </div>
                <div class="panel-footer">
                    <button type="button" class="btn btn-default" data-toggle="modal" data-target="#modal-change-info">Edit Personal Info</button>
                </div>
            </div>
        </div>
    </div>

    <%-- 修改失败弹框 --%>
    <div class="alert alert-warning alert-dismissible alert-change-notok fade" role="alert">
        <strong>Oh!</strong>
        Something went wrong.
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
    </div>
    <%-- 修改成功弹框 --%>
    <div class="alert alert-success alert-dismissible alert-change-ok fade" role="alert">
        <strong>Success.</strong>
        Success.
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
    </div>

    <%-- 修改个人信息弹框 --%>
    <div class="modal fade" id="modal-change-info" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <%-- 标题栏 --%>
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Change Info</h4>
                </div>
                <%-- 表单栏 --%>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <%-- 真实姓名 --%>
                        <div class="form-group">
                            <label for="txtAlias" class="col-sm-2 control-label">True Name</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtAlias" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <%-- 邮箱 --%>
                        <div class="form-group">
                            <label for="txtEmail" class="col-sm-2 control-label">Email</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <%-- 提交个人信息修改 --%>
                    <button type="button" class="btn btn-primary" data-dismiss="modal" id="btn-submit">Save Changes</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
    </div>
    <%-- 提交个人信息修改给服务器 --%>
    <script>
        $('#btn-submit').click(function () {
            var id = <%= this.Session["CurrentUserId"] == null ? -1 : this.Session["CurrentUserId"] %>;
                var h = {
                    "id": id,
                    "newAlias": $("#<%=txtAlias.ClientID%>").val(),
                    "newEmail": $("#<%=txtEmail.ClientID%>").val(),
                };
                console.log(h);

                $.ajax({
                    url: 'Services/StudentHandler.ashx?method=changeInfo',
                    type: 'POST',
                    headers: h,
                    success: function (res) {
                        // 修改成功
                        if (res.errCode != 200) {
                            $('#alert-change-notok').alert()
                        }
                        else {
                            $('#alert-change-ok').alert()
                        }
                    }
                });
            })
    </script>
    <%-- 修改密码弹框 --%>
    <div class="modal fade" id="modal-change-pw" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                Change Pw
            </div>
        </div>
    </div>

    

</asp:Content>
