using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library.Common;
namespace Library.Common
{
    public partial class Liberary : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {                      
            if (!Page.IsPostBack)
            {
                if (Login.user == null)
                {
                    Response.Redirect("Login.aspx");
                }
                string username = Login.user.Name;
                 Label1.Text = username;
                 string up = "update Book set 状态='不可借' where 存货<=3 update Book set 状态='可借' where 存货>3";
                 DataCom.comdata(up);                                                
            }
        }         
    }
}