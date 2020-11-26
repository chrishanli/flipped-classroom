using FCBackend.Dao;
using FCWebApp.Backend.Dao;
using FCWebApp.Backend.Model.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWebApp.Pages
{
    public partial class DiscussionHomePage : System.Web.UI.Page
    {
        public Int64 discussId;
        public Int64 attendId;
        public String topic;
        protected void Page_Load(object sender, EventArgs e)
        {
            discussId = Int64.Parse(Request["did"]);
            // 获取讨论课所属课程
            Int64 courseId = DiscussDao.getCourseIdByDiscussId(discussId);
            // 获取学生的报名情况
            DiscussSigninVo dsvo = PersonDao.getSignedInRecord((long)Session["CurrentUserId"], discussId);
            if (dsvo != null)
            {
                attendId = dsvo.id;
            }
        }
    }
}