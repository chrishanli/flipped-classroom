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
    public partial class QuestionPage : System.Web.UI.Page
    {
        public QuestionVo qvo = null;
        public string topic = null;
        public long ggg = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["CurrentUserId"] == null)
            //{
            //    Response.Redirect("~/LoginPage.aspx");
            //}
            // 记录问题 id
            string qid = Request["qid"];
            if (qid == null)
            {
                Response.Write("<script language='javascript'>");
                Response.Write("alert('问题 id 并未指明');");
                Response.Write("</script>");
                Response.Redirect("StudentHomePage.aspx");
                return;
            }
            long stuId = (long)Session["CurrentUserId"];
            // 获取问题详细资料
            qvo = DiscussDao.getQuestion(long.Parse(qid));

        }
    }
}