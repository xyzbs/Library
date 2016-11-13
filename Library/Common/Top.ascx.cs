using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using Data;
namespace Library.Common
{
    public partial class Top : System.Web.UI.UserControl
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.user == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                Image1.ImageUrl = DataCom.datatable(9, "select * from UsersData where 用户名='" + Login.user.Name + "'");
            }
        }
        protected void btndata_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyData.aspx");
        }

        protected void btnhis_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyBooks.aspx");
        }

        protected void btnbook_Click(object sender, EventArgs e)
        {
            Response.Redirect("Book.aspx");
        }

        protected void btnword_Click(object sender, EventArgs e)
        {
            Response.Redirect("Words.aspx");
        }

        protected void btnmoney_Click(object sender, EventArgs e)
        {
            Response.Redirect("Money.aspx");
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            Boolean fileOk = false;
            //指定文件路径，pic是项目下的一个文件夹；～表示当前网页所在的文件夹
            String path = Server.MapPath("~/pic/");//物理文件路径
            //文件上传控件中如果已经包含文件
            if (FileUpload1.HasFile)
            {
                //得到文件的后缀
                String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();

                //允许文件的后缀
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };

                //看包含的文件是否是被允许的文件的后缀
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOk = true;                        
                    }
                }
            }
            if (fileOk)
            {
                try
                {
                    //文件另存在服务器的指定目录下     
                    string name = FileUpload1.FileName;//获取上传的文件名
                    path = "~/pic/" + name;
                    DataCom.comdata("update UsersData set 路径='" + path + "' where 用户名='" + Login.user.Name + "'");
                    Image1.ImageUrl = path;
                    FileUpload1.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path));
                    Response.Write("<script>alert('文件上传成功！');</script>");
                }
                catch
                {
                    Response.Write("<script>alert('文件上传失败！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('只能上传gif,png,jpeg,jpg,bmp图象文件！');</script>");
            }
        }
        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = true;
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            Login.user = null;
            Response.Redirect("Login.aspx");
        }
    }
}