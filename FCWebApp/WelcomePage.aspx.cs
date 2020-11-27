using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWebApp
{
    public partial class WelcomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 检查是不是还没有激活
            if ((string)Session["CurrentUserStatus"] == "N")
            {
                Response.Write("<script>alert('You need to change your password to activate your account.');</script>");
            }
        }
    }
}