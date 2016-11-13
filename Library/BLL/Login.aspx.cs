using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
namespace Library.BLL
{
    public partial class Login : System.Web.UI.Page
    {
        public static Users adminner;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btlogin_Click(object sender, EventArgs e)
        {
            string sql = "select * from Adminner where 管理员='"+txtname.Text+"' and 密码='"+txtpwd.Text+"'";
            int count = DataCom.login(sql);
            if (count > 0)
            {
                adminner = new Users(txtname.Text);
                sql = "update Adminner set 记录 ='"+ DateTime.Now.ToString()+ "  ' where 管理员='"+txtname.Text+"'";
                Response.Write("<script>alert('登陆成功！');window.location.href='LibraryArranger.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('登陆失败！')</script>");

            }
        }
    }
}