using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using System.Text;

namespace Library.BLL
{
    public partial class Book : System.Web.UI.Page
    {
        static PagedDataSource pds = new PagedDataSource(); 
        static string[] list = new string[8] { "ID", "书名", "作者", "学科", "状态", "存货", "编码","借出"};
        static int i;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            pds.CurrentPageIndex = currentPage-1;
            i = pds.PageCount;
            pagetotle.Text = string.Format("当前第{0}页/总共{1}页", currentPage,i);
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
                if (pds.CurrentPageIndex == i-1)
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
            if (e.CommandName == "select")
            {
                string nameb = ((TextBox)e.Item.FindControl("name")).Text.Replace("'", "");
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                string sql = "select 用户名 from BookUser_1 where ID='" + id+"'";
                GridView1.DataSource=DataCom.table(sql);
                GridView1.DataBind();
                GridView1.Visible = true;
            }else
            {
                if (e.CommandName == "update")
                {
                    up(true, e);
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    string sql = "update Book set 书名='" + list[0] + "',作者='" + list[1] + "',学科='" + list[2] + "',存货='" + list[3] + "',编码='" + list[4] + "' where id='"+id+"'    update Book set 状态 = '不可借' where 存货<= 3 update Book set 状态 = '可借' where 存货> 3";
                    DataCom.comdata(sql);
                    bind(pds.CurrentPageIndex+1);
                }else
                {
                    up(false, e);                   
                }
            }
        }
        public void up(bool judge, RepeaterCommandEventArgs e) {
            Panel pl = (Panel)e.Item.FindControl("p");
            if (pl != null)
            {
                i = 0;
                foreach (Control control in pl.Controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).ReadOnly = judge;
                        list[i++] = (control as TextBox).Text;
                    }
                }
            }
        }
        protected void RptBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Panel pl = (Panel)e.Item.FindControl("p");
            if (pl != null)
            {
                foreach (Control control in pl.Controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).ReadOnly = true;                       
                    }
                }
            }            
        }
        protected void delete_Click(object sender, EventArgs e)
        {          
            string sql="";
            for (int i = 0; i <RptBooks.Items.Count; i++)
            {            
                RepeaterItem item = RptBooks.Items[i]; 
                if (((CheckBox)item.FindControl("moreselect")).Checked)
                {
                    string id = ((Label)item.FindControl("ID")).Text;
                    sql += "delete from Book where ID='" + id+ "' ";
                }
            }
            if (sql != "")
            {
                DataCom.comdata(sql);
                bind(pds.CurrentPageIndex+1);
            }
        }

        protected void addbook_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBooks.aspx");           
        }

        protected void LBfirst_Click(object sender, EventArgs e)
        {
            bind(1);
        }

        protected void LBlast_Click(object sender, EventArgs e)
        {
            bind(i);
        }

        protected void LBnup_Click(object sender, EventArgs e)
        {
            bind(pds.CurrentPageIndex);
        }

        protected void LBdown_Click(object sender, EventArgs e)
        {
           bind(pds.CurrentPageIndex+2);
        }

        protected void LBleave_Click(object sender, EventArgs e)
        {           
            if (pagecount.Text != "")
            {
                int j = Convert.ToInt16(pagecount.Text);
                if (j <=i&&j>0)
                {
                    bind(j);
                }
            }           
        }   
        protected void allre_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < RptBooks.Items.Count; i++)
            {
                RepeaterItem item = RptBooks.Items[i];
                if (((CheckBox)item.FindControl("moreselect")).Checked == true)
                {
                    ((CheckBox)item.FindControl("moreselect")).Checked = false;
                }
                else
                {
                    ((CheckBox)item.FindControl("moreselect")).Checked = true;
                }
            }
        }
    }
}