using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Common
{
    public partial class Words : System.Web.UI.Page
    {
        string sql = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnWord_Click(object sender, EventArgs e)
        {
            if (mywords.Text != "")
            {
                if (AllData.judge2)
                {
                    sql = "insert [Book-User] values('" + AllData.rand + "','" + DataCom.datatable(0, "select 书名 from Book where ID='" + AllData.rand + "'") + "','" + Login.user.id + "','" + Login.user.Name + "','" + DateTime.Now.ToLocalTime().ToString() + "','" + mywords.Text + "','已借')";
                }
                else
                {
                    sql = "update UsersData set 留言='" + mywords.Text + "',时间='" + DateTime.Now.ToLocalTime().ToString() + "' where 用户名='" + Login.user.Name + "'";
                }
                DataCom.comdata(sql);
                Response.Write("<script>alert('留言成功了！');</script>");
            }
        }

        protected void history_Click(object sender, EventArgs e)
        {
            if (AllData.judge2)
            {
                sql = "select 书名,日期,留言,用户名 from [Book-User] where ID='"+AllData.rand+"'";
            }else
            {
                sql= "select 时间,留言,用户名 from UsersData where 用户名 = '" + Login.user.Name + "'";
            }
            GridView1.DataSource = DataCom.table(sql);
            GridView1.DataBind();
            GridView1.Visible = true;
        }

    }
}