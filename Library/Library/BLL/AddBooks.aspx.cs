using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
namespace Library.BLL
{
    public partial class AddBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void add_Click(object sender, EventArgs e)
        {
            string sql = "insert Book(书名,作者,学科,存货,编码,借出) values('" + Textname.Text + "','" + Textauth.Text + "','" + Texttype.Text + "','" + Textnownum.Text + "','" + Textcode.Text + "','0')    update Book set 状态 = '不可借' where 存货<= 3 update Book set 状态 = '可借' where 存货> 3";
            DataCom.comdata(sql);
        }
    }
}