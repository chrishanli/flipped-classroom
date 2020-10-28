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
            TableHeaderRow th = new TableHeaderRow();
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
                delButton.CssClass = "btn btn-danger";
                delButton.Style.Add("margin-right", "5px");
                delButton.Text = "Delete";
                controls.Controls.Add(delButton);
                Button editButton = new Button();
                editButton.CssClass = "btn btn-primary";
                editButton.Text = "Edit";
                controls.Controls.Add(editButton);
                tr.Cells.Add(controls);

                this.TableUsers.Rows.Add(tr);
            }
        }
    }
}