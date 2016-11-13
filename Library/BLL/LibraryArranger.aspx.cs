using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.BLL
{
    public partial class LibraryArranger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.adminner != null)
            {
                string username = Login.adminner.Name;
            }else
            {
                Response.Write("<script>alert('请先登陆！');window.location.href='Login.aspx'</script>");
            }
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        public static void exportfile(string FileType, string FileName, GridView Gridview1)
        {
        }

        protected void btregite_Click(object sender, EventArgs e)
        {

        }
    }
}