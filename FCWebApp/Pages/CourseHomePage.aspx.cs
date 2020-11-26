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
            string id = Request["cid"];
            if (id == null)
            {
                Response.Write("<script language='javascript'>");
                Response.Write("alert('The course id was not specified.');");
                Response.Write("</script>");
                Response.Redirect("StudentHomePage.aspx");
                return;
            }
            courseId = Int64.Parse(id);
            // 获取课程的姓名
            name = CourseDao.getCourseName(courseId);
        }
    }
}