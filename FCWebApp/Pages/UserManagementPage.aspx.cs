using FCBackend.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCWebApp.Pages
{
    public partial class UserManagementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RefreshListButton_Click(object sender, EventArgs e)
        {
            GridViewUsers.DataBind();
        }

        protected void AddUserButton_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string teacherId = this.InputNewTeacherID.Value;
            string name = this.InputNewName.Value;
            string pass = this.InputNewPassword.Value;
            string email = this.InputNewEmail.Value;

            // TODO - insert teacher
        }

        protected void BtnSubmitThisEdit()
        {

        }
    }
}