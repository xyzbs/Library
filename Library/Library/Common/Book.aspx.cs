using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Library.Common
{
    public partial class Book : System.Web.UI.Page
    {
        static PagedDataSource pds = new PagedDataSource();
        string id2 = "231", name = "";
        static string[] list = new string[8] { "ID", "书名", "作者", "学科", "状态", "存货", "编码", "借出" };
        int i;              
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.user == null)
            {
                Response.Redirect("Login.aspx");
            }
            name = Login.user.Name;
            if (!IsPostBack)
            {
                searchlist.DataSource = list;
                searchlist.DataBind();
                pds.AllowPaging = true;
                pds.PageSize = 5;
                bind(1);
            }                         
        }
        public void bind(int currentPage)
        {
            string comsql = "select * from Book where "+searchlist.SelectedValue+" like '%" + searchname.Text + "%'";
            pds.DataSource = DataCom.table(comsql).DefaultView;
            pds.CurrentPageIndex = currentPage - 1;
            i = pds.PageCount;
            pagetotle.Text = string.Format("当前第{0}页/总共{1}页", currentPage, i);
            RptBooks.DataSource = pds;
            RptBooks.DataBind();
            LBdown.Enabled = true;
            LBlast.Enabled = true;
            LBfirst.Enabled = true;
            LBnup.Enabled = true;
            if (pds.CurrentPageIndex == 0)
            {
                LBfirst.Enabled = false;
                LBnup.Enabled = false;
            }
            else
            {
                if (pds.CurrentPageIndex == i - 1)
                {
                    LBdown.Enabled = false;
                    LBlast.Enabled = false;
                }
            }
        } 
        protected void search_Click(object sender, EventArgs e)
        {
            bind(1);
        }
        protected void RptBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
             int id = Convert.ToInt32(e.CommandArgument.ToString());
             AllData.rand = id;
            if (e.CommandName == "update")
            {
                id2 = DataCom.datatable(0, "select * from UsersData where 用户名='" + name + "'");
                string nameb=((Label)e.Item.FindControl("name")).Text.Replace("'", "");                                
                string sql = "update Book set 存货-=1 where ID='" + id + "'  insert into [Book-User] values('"+id+"','"+nameb+"','"+id2+"','"+name+"','"+ DateTime.Now.ToString()+"',' ', '已预约')";
                DataCom.comdata(sql);
                bind(pds.CurrentPageIndex+1);
            }else
            {
                if (e.CommandName == "word")
                {
                    AllData.judge2 = true;
                    Response.Redirect("Words.aspx");
                }
                else
                {
                    Response.Redirect("BookWords.aspx");
                }
            }
        }

        protected void RptBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lab = (Label) e.Item.FindControl("state");
            if (lab != null)
            {
                Label ubstate = (Label)e.Item.FindControl("ubstate");
                Label labid = (Label)e.Item.FindControl("ID");
                ubstate.Text = DataCom.datatable(6, "select * from [Book-User] where 用户名='"+name+"' and ID='"+labid.Text+"'"); 
                string state = (string)lab.Text;
                if (state == "不可借   "||ubstate.Text!="")
                {
                    LinkButton btn = (LinkButton)e.Item.FindControl("linkborrow");
                    btn.Visible = false;
                }
                if(ubstate.Text == "已借        ")
                {
                    LinkButton btn = (LinkButton)e.Item.FindControl("word");
                    btn.Visible = true;
                }                
            }
        }

        protected void LBfirst_Click(object sender, EventArgs e)
        {
            bind(1);
        }

        protected void LBlast_Click(object sender, EventArgs e)
        {
            bind(pds.PageCount);
        }

        protected void LBnup_Click(object sender, EventArgs e)
        {
            bind(pds.CurrentPageIndex);
        }

        protected void LBdown_Click(object sender, EventArgs e)
        {
            bind(pds.CurrentPageIndex + 2);
        }

        protected void LBleave_Click(object sender, EventArgs e)
        {
            if (pagecount.Text != "")
            {
                int j = Convert.ToInt16(pagecount.Text);
                if (j <= i && j > 0)
                {
                    bind(j);
                }
            }
        }
    }
}