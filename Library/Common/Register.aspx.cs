using Data;
using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btregite_Click(object sender, EventArgs e)
        {
            
                string sql = "select * from UsersData where 用户名='" + txtname + "'";
                if (DataCom.login(sql)==0)
                {
                    string str = "insert into Usersdata (用户名,密码,手机号,邮箱,学号,余额) values('" + txtname.Text + "', '" + txtpwd1.Text + "', '" 
                 + txtmobile.Text + "', '" + txtemail.Text + "', '" + txtstunum.Text + "','0')";
                    AllData  alldata = new AllData(str, false, Recode.random());
                    DataCom.getsend().Sendemails("z1b3s6@163.com", txtemail.Text, "海大图书馆注册", "请确保是本人在操作，如不是请不要理会.您的注册码是：" + AllData.rand);
                    Response.Write("<script>alert('请输入邮箱验证码！');window.location.href='Recode.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('注册失败！用户名重复')</script>");
                }               
            
        }
    }
}
