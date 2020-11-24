using FCWebApp.Backend.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWebApp.Pages
{
    public partial class CourseHomePage : System.Web.UI.Page
    {

        public Int64 courseId;
        public String name;
        protected void Page_Load(object sender, EventArgs e)
        {
            courseId = Int64.Parse(Request["cid"]);
            // 获取课程的姓名
            name = CourseDao.getCourseName(courseId);
        }
    }
}