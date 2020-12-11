using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace FCWebApp
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected bool isSignedIn()
        {
            object alias = Session["CurrentUserAlias"];
            return alias != null;
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/LoginPage.aspx");
        }
    }
}