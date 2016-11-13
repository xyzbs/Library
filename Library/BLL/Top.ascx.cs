using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.BLL
{
    public partial class Top : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.adminner == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void Btnusers_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersData.aspx");
        }

        protected void Btnbooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("Book.aspx");
        }

        protected void Btnstudents_Click(object sender, EventArgs e)
        {
            Response.Redirect("Students.aspx");
        }

        protected void Btnadminner_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminner.aspx");
        }

        protected void end_Click(object sender, EventArgs e)
        {
            Login.adminner = null;
            Response.Redirect("Login.aspx");
        }
    }
}