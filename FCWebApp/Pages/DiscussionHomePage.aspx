<%@ Page Title="Discuss Class Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DiscussionHomePage.aspx.cs" Inherits="FCWebApp.Pages.DiscussionHomePage" %>

<asp:Content ID="DiscussionHomePage" ContentPlaceHolderID="MainContent" runat="server">
    <%-- 引入 jQuery --%>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <div class="container">
        <h2>Discuss Home - <%= this.topic %></h2>
    </div>

    <%-- 我的报名 --%>
    <hr />
    <h3>My Sign-Ins</h3>
    <div class="row" style="margin: 20px 0 0 0">
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr>
                    <th>Sign-in Number</th>
                    <th>Group Id</th>
                    <th>Sign-in Time</th>
                    <th>Operation</th>
                </tr>
            </thead>
            <tbody id="table-signin">
            </tbody>
        </table>
    </div>

    <!-- 上传文件的模态框 -->
    <div class="modal fade" id="addFileModal" tabindex="-1" role="dialog" aria-labelledby="addFileModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Add File</h4>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <input type="file" id="upload-file" name="upload-file">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" id="btn-upload" class="btn" data-dismiss="modal">Upload</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>

    <script>
        $(document).ready()
    </script>
    <%-- 确认上传文件的脚本 --%>
    <script>
        $('#btn-upload').click(function () {
            var files = $('#upload-file').prop('files');
            var data = new FormData();
            data.append('upload-file', files[0]);
            $.ajax({
                url: 'DiscussHandler/uploadFile',
                type: 'POST',
                headers: { "attendId": <%= this.attendInfo == null ? 0 : this.attendInfo.id %>},
                data: data,
                cache: false,
                processData: false,
                contentType: false
            });
        })
    </script>

</asp:Content>
