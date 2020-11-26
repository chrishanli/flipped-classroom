using FCBackend.Dao;
using FCWebApp.Backend.Model.Po;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String id = this.idInput.Text;
            String pw = this.passwordInput.Text;
            // 验证用户名及密码
            PersonPo po = PersonDao.getUser(id, pw);
            if (po == null)
            {
                this.lblWrongPw.Text = "Wrong Password or Username.";
            }
            else
            {
                Session["CurrentUserId"] = po.id;
                Response.Redirect("WelcomePage.aspx");
            }
        }
    }
}