using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Common
{
    public partial class MyBooks : System.Web.UI.Page
    {
        string[] list = new string[5] { "书名", "日期", "状态", "作者","学科" };
        string name= Login.user.Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                searchlist.DataSource = list;
                searchlist.DataBind();
                GridView1.AllowPaging = true;
                GridView1.PageSize = 10;
                bind();
            }
        }
        public void bind()
        {
            DataSet myds = DataCom.dataSet("select 用户名,书名,日期,状态,作者,学科 from BookUser_1 where " + searchlist.SelectedValue + " like '%" + searchname.Text + "%' and 用户名='"+ Login.user.Name+"' order by 日期");
            GridView1.DataSource = myds;
            GridView1.DataBind();
            this.CurrentPage.Items.Clear();
            for (int i = 1; i <= this.GridView1.PageCount; i++)
            {
                this.CurrentPage.Items.Add(i.ToString());
            }
            if (GridView1.PageCount == 0)
            {
                this.CurrentPage.Items.Add("空");
            }
            this.CurrentPage.SelectedIndex = this.GridView1.PageIndex;
        }
        protected void search_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void lnkbtnFrist_Click(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = 0;
            bind();
        }

        protected void lnkbtnPre_Click(object sender, EventArgs e)
        {
            if (this.GridView1.PageIndex > 0)
            {
                this.GridView1.PageIndex = this.GridView1.PageIndex - 1;
                bind();
            }
        }

        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            if (this.GridView1.PageIndex < this.GridView1.PageCount)
            {
                this.GridView1.PageIndex = this.GridView1.PageIndex + 1;
                bind();
            }
        }

        protected void lnkbtnLast_Click(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = this.GridView1.PageCount;
            bind();
        }
        protected void CurrentPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = this.CurrentPage.SelectedIndex;
            bind();
        }
    }
}