<%@ Page Title="User Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManagementPage.aspx.cs" Inherits="FCWebApp.Pages.UserManagementPage" %>

<asp:Content ID="ContentUserManPage" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>User Management</h2>

        <div class="row" style="margin-top: 20px">
            <div class="col-xs-1 col-sm-1" style="margin-right: 10px">
                <asp:LinkButton ID="RefreshListButton" runat="server" OnClick="RefreshListButton_Click" CssClass="btn btn-primary">
                    Refresh List
                </asp:LinkButton>
            </div>
            <div class="col-xs-1 col-sm-1">
                <%--<asp:LinkButton ID="AddUserButton" runat="server" OnClick="AddUserButton_Click" CssClass="btn btn-warning">
                    Add Teacher
                </asp:LinkButton>--%>
                <button type="button" class="btn btn-default" data-toggle="modal" data-target="#addUserModal">
                    Add User
                </button>
            </div>
        </div>
        <div class="row" style="margin: 20px 0 0 0">
            <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="HanLiPublicMySQL" CssClass="table table-striped table-bordered table-hover">
                <Columns>
                    <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type" />
                    <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false"/>
                    <asp:BoundField DataField="username" HeaderText="Student/Teacher ID" SortExpression="username" />
                    <asp:BoundField DataField="alias" HeaderText="Name" SortExpression="alias" />
                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                    <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                    <asp:CommandField HeaderText="Operation" ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="HanLiPublicMySQL" runat="server" ConnectionString="<%$ ConnectionStrings:hanPublicMySQLConnectionString %>" ProviderName="<%$ ConnectionStrings:hanPublicMySQLConnectionString.ProviderName %>" SelectCommand="SELECT type, id, username, alias, email, status FROM fc_user" DeleteCommand="DELETE FROM fc_user WHERE id=@id" UpdateCommand="UPDATE fc_user SET username = @username, alias = @alias, email =@email, status =@status WHERE id=@id"></asp:SqlDataSource>
        </div>
    </div>

    <!-- 新建用户的模态框 -->
    <div class="modal fade" id="addUserModal" tabindex="-1" role="dialog" aria-labelledby="addUserModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Add New Teacher User</h4>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="form-group">
                            <label for="InputNewTeacherID">Teacher ID</label>
                            <input type="text" runat="server" class="form-control" id="InputNewTeacherID" placeholder="Teacher ID">
                        </div>
                        <div class="form-group">
                            <label for="InputNewName">Full Name</label>
                            <input type="text" runat="server" class="form-control" id="InputNewName" placeholder="Name">
                        </div>
                        <div class="form-group">
                            <label for="InputNewPassword">Password</label>
                            <input type="password" runat="server" class="form-control" id="InputNewPassword" placeholder="Password">
                        </div>
                        <div class="form-group">
                            <label for="InputNewEmail">Email</label>
                            <input type="text" runat="server" class="form-control" id="InputNewEmail" placeholder="Email">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:LinkButton ID="LinkButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" CssClass="btn btn-primary">
                        Submit
                    </asp:LinkButton>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>

    <!-- 更改用户的模态框 -->
    <div class="modal fade" id="editUserModal" tabindex="-1" role="dialog" aria-labelledby="editUserModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Edit User</h4>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="form-group">
                            <label for="InputTeacherStuID">Teacher / Student ID</label>
                            <input type="text" runat="server" class="form-control" id="TxtTeacherStuId" placeholder="Teacher ID">
                        </div>
                        <div class="form-group">
                            <label for="InputName">Full Name</label>
                            <input type="text" runat="server" class="form-control" id="TxtName" placeholder="Name">
                        </div>
                        <div class="form-group">
                            <label for="InputEmail">Email</label>
                            <input type="text" runat="server" class="form-control" id="TxtEmail" placeholder="Email">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:LinkButton ID="BtnSubmitEdit" runat="server" CssClass="btn btn-primary">
                        Submit
                    </asp:LinkButton>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
</asp:Content>
