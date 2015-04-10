using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace myWebService
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。
    // [System.Web.Script.Services.ScriptService]

        
    public class Service1 : System.Web.Services.WebService
    {


        [WebMethod]

        //public IList<WxlhyList> ToDoList()
        //{
        //    string conn000 = ConfigurationManager.AppSettings["ConStr"];
        //    return GetListAll(conn000,"slect * from ToDoTabel");
        //}
       //获取待办事项
        public List<WxlhyList> ToDoList(string iscom)
        {
            
            string sqlstr;
            if(iscom != "")
            sqlstr = "select * from ToDoTable where IsComplete =" + "'"+ iscom + "'";
            else
            sqlstr = "select * from ToDoTable";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlstr, conn))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    List<WxlhyList> list = new List<WxlhyList>();

                    while (sdr.Read())
                    {

                        WxlhyList testlist = new WxlhyList();

                        testlist.ID = (Guid)sdr["ID"];

                        testlist.Label = sdr["Label"].ToString();

                        testlist.IsComplete = (bool)sdr["IsComplete"];

                        list.Add(testlist);

                    }
                    conn.Close();
                    cmd.Dispose();
                    return list;
                    
                }
            }
        }
        
       // 修改

        [WebMethod]

        public int updatetodolist(string _id,string _label,string _iscomplete)
        {

            
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);

            conn.Open();
            string strSql;
            if (_label=="")
            strSql = "update TodoTable set IsComplete=" + "'" + _iscomplete + "'" + "where ID=" + "'" + _id + "'";
            else
            strSql = "update TodoTable set Label=" + "'" + _label + "'" + "where ID=" + "'" + _id + "'";

            SqlCommand cmd = new SqlCommand(strSql, conn);

            //SqlParameter para_ID = new SqlParameter("@_label", _id);

            //cmd.Parameters.Add(para_ID);

            //SqlParameter para_iscomplete = new SqlParameter("@_iscomplete", _iscomplete);

            //cmd.Parameters.Add(para_iscomplete);

            int result = cmd.ExecuteNonQuery();

            conn.Close();

            cmd.Dispose();

            return result;

        }

        //添加代办事项

        [WebMethod]

        public int addtodo(string _id, string _label, string _iscomplete)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);

            conn.Open();

            string strSql = "insert into TodoTable  values("+  "'" + _id + "'," +  "'" + _label + "',"+  "'" + _iscomplete + "')";

            SqlCommand cmd = new SqlCommand(strSql, conn);


            int result = cmd.ExecuteNonQuery();

            conn.Close();

            cmd.Dispose();

            return result;

        }


        //添加代办事项

        [WebMethod]

        public int deletetodo(string _id)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);

            conn.Open();

            string strSql = "delete from TodoTable  where ID=" + "'" + _id + "'";

            SqlCommand cmd = new SqlCommand(strSql, conn);


            int result = cmd.ExecuteNonQuery();

            conn.Close();

            cmd.Dispose();

            return result;

        }
  }
 
}