using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.BLL
{
    public partial class AddBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string sql = "update Book set 书名='" + list[0] + "',作者='" + list[1] + "',学科='" + list[2] + "',存货='" + list[3] + "',编码='" + list[4] + "',总数='" + list[5] + "' where id='" + id + "'    update Book set 状态 = '不可借' where 存货<= 3 update Book set 状态 = '可借' where 存货> 3";
            //string sql = "insert into Book values('" + i + "','" + i + "','" + i + "',' 0 ','" + i + "','" + i + "','" + i + "','" + i + "')";
        }

        protected void add_Click(object sender, EventArgs e)
        {
            string sql = "insert Book values(书名='" + Textname.Text + "',作者='" + Textauth.Text + "',学科='" + Texttype.Text + "',存货='" + Textnownum.Text + "',编码='" + Textcode.Text + "',总数='" + Textnownum.Text + "')    update Book set 状态 = '不可借' where 存货<= 3 update Book set 状态 = '可借' where 存货> 3";
        }
    }
}