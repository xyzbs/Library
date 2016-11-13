using Data;
using Library.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Library
{
    public partial class Login : System.Web.UI.Page
    {
        public static Users user;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btlogin_Click(object sender, EventArgs e)
        {
            string username = txtname.Text;
            string password = txtpwd.Text;
            string sql = "select * from UsersData where 用户名='" + username + "'and 密码='" + password + "'";
            int count = DataCom.login(sql);
            if (count > 0)
            {
                user = new Users(Convert.ToInt16(DataCom.datatable(0, "select * from UsersData where 用户名='" + username+"'")),username);
                Response.Write("<script>alert('登陆成功！');window.location.href='Liberary.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('登陆失败！')</script>");

            }
        }
        //注册页面

        protected void btregite_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
            Response.End();
        }
        //发送邮件
        protected void rtpassword_Click(object sender, EventArgs e)
        {
            string str = "select * from Users where name='" + txtname.Text + "'";
            Send send = new Send();
            if (DataCom.email(str, txtname.Text,2, "海大图书馆找回密码", "<br/>您丢失的密码："))
            {
                Response.Write("<script>alert('恭喜，找回成功！请注意查收')</script>");
            }else{
                Response.Write("<script>alert('发送失败！ 请检查您的用户名')</script>");
            }
        }
    }
}