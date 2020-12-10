using FCBackend.Dao;
using FCWebApp.Backend.Dao;
using FCWebApp.Backend.Model.Po;
using FCWebApp.Backend.Model.Vo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWebApp.Pages
{
    public partial class DiscussionHomePage : System.Web.UI.Page
    {
        public Int64 discussId;
        public DiscussAttendPo attendInfo;
        public String topic;
        public bool isReportAssigned = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["did"];
            long stuId = (long) Session["CurrentUserId"];
            if (id == null)
            {
                Response.Write("<script language='javascript'>");
                Response.Write("alert('The discussion id was not specified.');");
                Response.Write("</script>");
                Response.Redirect("StudentHomePage.aspx");
                return;
            }
            discussId = Int64.Parse(id);
            // 获取讨论课的主题
            topic = DiscussDao.getDiscussTopic(discussId);
            // 获取报名资料 （如有）
            attendInfo = DiscussDao.getDiscussAttendInfo(discussId, stuId);
            if (attendInfo != null)
            {
                long attendId = attendInfo.id;
                // 获取讨论课报名 id
                this.SqlDataSourceMySQL.SelectParameters["attendId"].DefaultValue = attendId.ToString();
                // 获取是否提交了讨论课报告
                this.isReportAssigned = DiscussDao.isReportAssigned(attendId);
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            // 点击了 报名讨论课 按钮
            bool isJoined = DiscussDao.attend(discussId, (long)Session["CurrentUserId"]);
            if (isJoined)
            {
                // 报名成功
                Response.Write(String.Format("<script>alert('报名成功。');location.href='/Pages/DiscussionHomePage.aspx?did={0}';</script>", this.discussId));
            }
        }

        protected void btnSignOutDiscuss_Click(object sender, EventArgs e)
        {
            // 点击了 取消报名讨论课 按钮
            bool isJoined = DiscussDao.cancelDiscuss(discussId, (long)Session["CurrentUserId"]);
            if (isJoined)
            {
                // 取消报名成功
                Response.Write(String.Format("<script>alert('取消报名成功。');location.href='/Pages/DiscussionHomePage.aspx?did={0}';</script>", this.discussId));
            }
        }

        /*
         * ASP 的上传文件方法 不用了 现在用 ajax
         * 
        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            // 搜索文件是否上传了
            HttpFileCollection files = Request.Files;
            string filePath = Server.MapPath("~/UploadFiles/");
            // 接受文件
            if (files.Count != 0)
            {
                string fileName = files[0].FileName;
                files[0].SaveAs(Path.Combine(filePath, fileName));
                // 上传成功，弹出一个框
                Response.Write("alert('success')");
            }
            else
            {
                
            }
        }
        */
    }
}