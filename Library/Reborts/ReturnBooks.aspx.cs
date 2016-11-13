using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
namespace Library.Reborts
{
    public partial class ReturnBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void BtnScan_Click(object sender, EventArgs e)
        {
            string sel = "select * from [Book-User] where 状态='已借' and ID='" + textID.Text + "' and 用户名='" + textName.Text + "'";
            if (DataCom.login(sel) == 1)
            {
                string sql = "Update [Book-User] set 状态='已还' where ID='" + textID.Text + "' and 用户名='" + textName.Text + "'";
                DataCom.comdata(sql);
                Response.Write("<script>alert('还书成功')</script>");
            }
            else
            {
                 Response.Write("<script>alert('该用户未借！')</script>");
            }        
        }
    }
}