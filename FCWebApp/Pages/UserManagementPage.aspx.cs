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
            refreshUserTable();
        }

        protected void RefreshListButton_Click(object sender, EventArgs e)
        {
            refreshUserTable();
        }

        protected void AddUserButton_Click(object sender, EventArgs e)
        {

        }


        void refreshUserTable()
        {
            this.TableUsers.Rows.Clear();
            PersonDao.FetchAllPerson();

            TableHeaderRow th = new TableHeaderRow();
            TableHeaderCell thro = new TableHeaderCell();
            thro.Text = "Role";
            th.Cells.Add(thro);
            TableHeaderCell thun = new TableHeaderCell();
            thun.Text = "Student Id / Teacher Id";
            th.Cells.Add(thun);
            TableHeaderCell thal = new TableHeaderCell();
            thal.Text = "Alias";
            th.Cells.Add(thal);
            TableHeaderCell them = new TableHeaderCell();
            them.Text = "Email";
            th.Cells.Add(them);
            TableHeaderCell thop = new TableHeaderCell();
            thop.Text = "Operations";
            th.Cells.Add(thop);
            this.TableUsers.Rows.Add(th);

            foreach (Person p in PersonDao.PersonList)
            {
                TableRow tr = new TableRow();
                TableCell role = new TableCell();
                role.Text = p is Teacher ? "Teacher" : "Student";
                tr.Cells.Add(role);

                TableCell username = new TableCell();
                username.Text = p.Username;
                tr.Cells.Add(username);

                TableCell alias = new TableCell();
                alias.Text = p.Alias;
                tr.Cells.Add(alias);

                TableCell email = new TableCell();
                email.Text = p.Email;
                tr.Cells.Add(email);

                TableCell controls = new TableCell();
                Button delButton = new Button();
                delButton.Click += new EventHandler((obj, args) =>
                {
                    if (Person.DeletePersonById(p.Id))
                    {
                        Response.Write("<div class=\"alert alert-success alert-dismissable\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "Delete succeessfully." +
                            "</div>");
                        refreshUserTable();
                    } else
                    {
                        // wrong
                        Response.Write("<div class=\"alert alert-danger alert-dismissable\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "Error occurred." +
                            "</div>");
                    }
                });
                delButton.CssClass = "btn btn-danger";
                delButton.Style.Add("margin-right", "5px");
                delButton.Text = "Delete";
                controls.Controls.Add(delButton);

                Button editButton = new Button();
                editButton.CssClass = "btn btn-primary";
                editButton.Text = "Edit";
                editButton.Attributes.Add("data-toggle", "modal");
                editButton.Attributes.Add("data-target", "#editUserModal");
                editButton.Click += new EventHandler((obj, args) =>
                {
                    TxtTeacherStuId.Value = p.Username;
                    TxtEmail.Value = p.Email;
                    TxtName.Value = p.Alias;
                    BtnSubmitEdit.Click += new EventHandler((o, e) =>
                    {
                        if (Person.ChangeInfoById(p.Id, TxtTeacherStuId.Value, TxtEmail.Value, TxtName.Value))
                        {
                            Response.Write("<div class=\"alert alert-success alert-dismissable\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "Edit succeessfully." +
                            "</div>");
                            refreshUserTable();
                        } else
                        {
                            // wrong
                            Response.Write("<div class=\"alert alert-danger alert-dismissable\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                                "Error occurred." +
                                "</div>");
                        }
                    });
                });
                controls.Controls.Add(editButton);
                tr.Cells.Add(controls);

                this.TableUsers.Rows.Add(tr);
            }
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
                refreshUserTable();
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