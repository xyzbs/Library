using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using System.Text;
using System.Data;

namespace Library.Common
{
    public partial class MyData : System.Web.UI.Page
    {
        string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.user == null)
            {
                Response.Redirect("Login.aspx");
            }
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                bind();
            }          
        }
        public void bind()
        {
 
            DataSet myds = DataCom.dataSet("select * from UsersData where 用户名='"+Login.user.Name+"'");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "ID" };
            GridView1.DataBind();
        }
        protected void update_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                StringBuilder query = new StringBuilder();
                GridViewRow row = GridView1.Rows[i];
                name = ((TextBox)row.Cells[0].FindControl("txtname")).Text.Replace("'", "");
                string mobile = ((TextBox)row.Cells[0].FindControl("txtmobile")).Text.Replace("'", "");           
                query.Append("update UsersData set 用户名='" + name + "',手机号='" + mobile + "' where ID=" + GridView1.DataKeys[i].Value + "");
                DataCom.comdata(query.ToString());
            }
            bind();
        }
        protected void rebtn_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.Rows[0];
            name = ((TextBox)row.Cells[0].FindControl("txtname")).Text.Replace("'", "");          
            reform.Visible = true;
        }

        protected void sendemail_Click(object sender, EventArgs e)
        {
            name = Login.user.Name;
            string messageto, subject, body = "", str;
            int n = Recode.random();
            if (email.Text == "")
            {
                messageto = DataCom.datatable(4, "select * from UsersData where 用户名='" +name + "'");
                subject = "海大图书馆修改密码";
                body = "您的新密码是" + txtpwd1.Text;
                str = "update UsersData set 密码='" + txtpwd1.Text + "' where 用户名='";
            }
            else
            {
                messageto = email.Text;
                subject = "海大图书馆修改邮箱";
                if (txtpwd1 == null)
                {
                    str = "update UsersData set 邮箱 = '" + email.Text + "' where 用户名 = '";
                }
                str = "update UsersData set 邮箱 = '" + email.Text + "',密码 = '" + txtpwd1.Text + "' where 用户名 ='";
            }
            DataCom.getsend().Sendemails("z1b3s6@163.com", messageto, subject, "请确保是本人在操作，如不是请不要理会.您的修改码是：" + n + body);
            AllData alldata = new AllData(str+Login.user.Name+"'", true, n);
            Response.Write("<script>alert('请输入邮箱验证码！');window.location.href='Recode.aspx'</script>");
        }
    }
}