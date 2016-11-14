using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
namespace Library.Reborts
{
    public partial class BorrowBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void BtnScan_Click(object sender, EventArgs e)
        {
            string sel = "select * from [Book-User] where 状态='已借' and ID='" + textID.Text + "' and 用户名='" + textName.Text + "'";
            if (DataCom.login(sel) == 0)
            {
                string sql = "Update [Book-User] set 状态='已借' where ID='" + textID.Text + "' and 用户名='" + textName.Text + "'";
                if (DataCom.comdata(sql) == 1)
                {
                    sql = "update Book set 借出-=1 where ID="+textID.Text;
                    Response.Write("<script>alert('借书成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('对不起，预约后才能借书')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('用户已借，请不要重复扫描！')</script>");
            }
        }
    }
}