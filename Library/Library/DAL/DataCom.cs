using Library.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
namespace Data
{
    public class DataCom : System.Web.UI.Page
    {
        public delegate int comEvent(string str);
        comEvent comreg = login;
        comEvent comrec =comdata;
        private static string strcon = "server=DESKTOP-DFOPNE4;Integrated Security=SSPI;database=Library;";
        private static SqlConnection con = new SqlConnection(strcon);
        private static SqlCommand com;
        private static DataTable dt;
        private static DataCom data = new DataCom();       
        public int open(string str)
        {
            int i = 0;
            try
            {
                con.Open();//打开数据库
                com = new SqlCommand(str, con);//执行命令
                i=com.ExecuteNonQuery();//受影响的行数               
            }
            //捕捉异常
            catch (HttpException ex)
            {
                Response.Write("<script>alert('操作失败！')</script>");
                ex.Message.ToString();
            }
            catch (Exception ex)
            {
                 Response.Write("<script>alert('操作失败！')</script>");
                ex.Message.ToString();
            }
            finally
            {
                con.Close();//关闭数据库
            }
            return i;
        }
        public static int comdata(string com)
        {                     
            return data.open(com);
        }
        public static DataSet dataSet(string sqlStr)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = new SqlCommand(sqlStr,con);
                com.CommandType = CommandType.Text;
                com.CommandText = sqlStr;
                da.SelectCommand = com;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        ///登录
        public static int login(string str)
        {
            return table(str).Rows.Count;
        }
        ///数据库表格
        public static DataTable table(string str)
        {
            dt = new DataTable();
            con.Open();//打开
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(dt);//进行填充          
            con.Close();
            return dt;
        }
        ///读取数据库数据  
        public static string datatable(int a,string str)
        {
            return table(str).Rows.Count==0?"": table(str).Rows[0][a].ToString();
        }
        public static Send getsend()
        {
           Send send = new Send();
            return send;
        }
        ///发邮件
        public static bool email(string str,string name,int pwd,string subject,string content)
        {
            return getsend().Sendemails("z1b3s6@163.com",datatable(5, str), subject, "尊敬的用户：" + name + content + datatable(pwd, str));
        }
    }
}