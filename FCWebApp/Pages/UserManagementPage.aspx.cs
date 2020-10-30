using FCBackend.Actors;
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

            if (Administrator.CreateTeacher(teacherId, pass, name, email))
            {
                Response.Write("<div class=\"alert alert-success alert-dismissable\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                    "Insert succeessfully." +
                    "</div>");
            }
            else
            {
                // wrong
                Response.Write("<div class=\"alert alert-danger alert-dismissable\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                    "Error occurred." +
                    "</div>");
            }
        }

        protected void BtnSubmitThisEdit()
        {

        }
    }
}