using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Reborts
{
    public partial class Top : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BorrowBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("BorrowBooks.aspx");
        }

        protected void ReturnBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReturnBooks.aspx");
        }
    }
}