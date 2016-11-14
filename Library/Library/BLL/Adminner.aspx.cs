using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using System.Data;
using System.IO;
using System.Text;

namespace Library.BLL
{
    public partial class Adminner : System.Web.UI.Page
    {
        string[] list = new string[] { "管理员", "ID", "记录" };
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
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        public void bind()
        {
            DataSet myds = DataCom.dataSet("select 管理员,ID,记录 from Adminner where " + searchlist.SelectedValue + " like '%" + searchname.Text + "%'");
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
        protected void BtnExcell_Click(object sender, EventArgs e)
        {
            Export("application/ms-excel", "Usersnformation.xls");
        }
        /// <summary>
        /// 定义导出Excel的函数
        /// </summary>
        /// <param name="FileType"></param>
        /// <param name="FileName"></param>
        /// <param name="Gridview"></param>
        private void Export(string FileType, string FileName)
        {
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
            Response.ContentType = FileType;
            this.EnableViewState = false;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            GridView1.AllowPaging = false;
            bind();
            this.GridView1.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
            GridView1.AllowPaging = true;
            bind();
        }
        /// <summary>
        /// 此方法必重写，否则会出错
        /// </summary>
        /// <param name="control"></param>
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void BtnWord_Click(object sender, EventArgs e)
        {
            Export("application/ms-word", "Usersnformation.doc");
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            div.Visible = true;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string sql = "select * from UsersData where 用户名='" + txtname.Text + "'and 密码='" + txtpwd.Text + "'";
            if (DataCom.login(sql) == 1)
            {
                sql = "insert Adminner(管理员,密码) values(' " + txtname.Text + "' ,'" + txtpwd.Text + "')";
                DataCom.comdata(sql);
            }
        }

        protected void Btnclose_Click(object sender, EventArgs e)
        {
            div.Visible = false;
        }
    }
}