using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.BLL
{
    public partial class Students : System.Web.UI.Page
    {
        string sql = "";
        string[] list = new string[2] { "学号", "姓名" };
        protected void Page_Load(object sender, EventArgs e)
        {         
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                searchlist.DataSource = list;
                searchlist.DataBind();
                GridView1.AllowPaging = true;
                GridView1.PageSize = 5;
                bind();
            }
        }
        public void bind()
        {
            DataSet myds = DataCom.dataSet("select * from Students where " + searchlist.SelectedValue + " like '%" + searchname.Text + "%'");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "学号" };
            GridView1.DataBind();
            this.CurrentPage.Items.Clear();
            lnkbtnFrist.Enabled = true;
            lnkbtnLast.Enabled = true;
            lnkbtnNext.Enabled = true;
            lnkbtnPre.Enabled = true;
            if (GridView1.PageIndex == 0)
            {
                lnkbtnFrist.Enabled = false;
                lnkbtnPre.Enabled = false;
            }
            else
            {
                if (GridView1.PageIndex == GridView1.PageCount - 1)
                {
                    lnkbtnLast.Enabled = false;
                    lnkbtnNext.Enabled = false;
                }
            }
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

        protected void delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
                if (((CheckBox)row.Cells[0].FindControl("alldata")).Checked)
                {
                    sql += "delete from Students where 学号='" + GridView1.DataKeys[i].Value + "' ";
                }
            }
            if (sql != "")
            {
                DataCom.comdata(sql);
                bind();
            }
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            div.Visible = true;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (DataCom.login("select * from Students where 学号='" + txtnum.Text + "'") == 0)
            {
                string sql = "insert into Students values('" + txtname.Text + "','" + txtnum.Text + "','0000','0','0')";
                DataCom.comdata(sql);
                bind();
            }
            else
            {
                Response.Write("添加失败！学号重复");
            }
        }

        protected void Btnclose_Click(object sender, EventArgs e)
        {
            div.Visible = false;
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.GridView1.PageIndex + 1, this.GridView1.PageCount);
            //用索引来取得编号
            if (e.Row.RowIndex != -1)
            {
                int id = GridView1.PageIndex * GridView1.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = id.ToString();
            }
        }

        protected void CurrentPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = this.CurrentPage.SelectedIndex;
            bind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
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
        protected void allre_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
                if (((CheckBox)row.FindControl("alldata")).Checked == true)
                {
                    ((CheckBox)row.FindControl("alldata")).Checked = false;
                }
                else
                {
                    ((CheckBox)row.FindControl("alldata")).Checked = true;
                }
            }
        }
    }
}