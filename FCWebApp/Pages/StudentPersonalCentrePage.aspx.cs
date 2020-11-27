using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWebApp.Pages
{
    public partial class StudentPersonalCentrePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUserId"] == null)
            {
                Response.Redirect("~/LoginPage.aspx");
            }
            this.txtAlias.Text = Session["CurrentUserAlias"].ToString();
            this.txtEmail.Text = Session["CurrentUserEmail"].ToString();
        }
    }
}