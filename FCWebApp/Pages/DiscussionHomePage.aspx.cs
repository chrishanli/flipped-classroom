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
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["did"];
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
            attendInfo = DiscussDao.getDiscussAttendInfo(discussId, (long)Session["CurrentUserId"]);
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