using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Common
{
    public partial class BookWords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.user == null)
            {
                Response.Redirect("Login.aspx");
            }
            GridView1.DataSource = DataCom.table("select 日期,留言,用户名,书名 from [Book-User] where ID='" +AllData.rand  + "'");
            GridView1.DataBind();
        }
    }
}