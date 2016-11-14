using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Data.DataCom;

namespace Library.Common
{
    public partial class Recode : System.Web.UI.Page
    {       
        public delegate void rechange(bool judge);
        rechange re;
        public static int random()
        {
            Random ran = new Random();
            return ran.Next(1000, 9999);
        }
        protected void Page_Load(object sender, EventArgs e)
        {        
            if (AllData.judge)
                {
                    re += re1;
                }
                else
                {
                    re += re2;
                }          
        }     
        protected void reBtn_Click(object sender, EventArgs e)
        {
            if (recode.Text!=null)
            {
                re(Convert.ToInt16(recode.Text) == AllData.rand);
            }else
            {
                Response.Write("<script>alert('注册失败!请输入验证码')</script>");
            }
        }

        protected void re2(bool judge)
        {
            if (judge)
            {
                DataCom.login(AllData.strDsc);
                Response.Write("<script>alert('注册成功！');location='Login.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('注册失败！验证码错误，请检查您的邮箱')</script>");
            }
        }
        public void re1(bool judge)
        {
            if (judge)
            {
                DataCom.comdata(AllData.strDsc);
                Response.Write("<script>alert('修改成功！');location='MyData.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！验证码错误，请检查您的邮箱')</script>");
            }
        }

        protected void retu_Click(object sender, EventArgs e)
        {
            if (AllData.judge)
            {
                Response.Redirect("MyData.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx"); 
            }
        }
    }
}