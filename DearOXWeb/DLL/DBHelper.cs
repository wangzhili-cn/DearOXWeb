using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DLL
{
    public class DBHelper
    {
        //数据库连接字符串
        private static string connstring = "server=.;database=DB_DearOX;uid=sa;pwd=sqlserver963025";
        //数据库命令对象
        private static SqlConnection conn = new SqlConnection(connstring);
        private static SqlCommand comm = null;
        //创建数据库适配器
        private static SqlDataAdapter da = null;
        //查询方法
        public static DataTable GetDTBySQL(string sql)
        { 
        //如果查找的是DataTable则不用一直打开关闭，应为他是连续的
            da = new SqlDataAdapter(sql,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //增删改的方法
        public static int ExecuteNonQuery(string sql)
        {
            comm = new SqlCommand(sql,conn);
            conn.Open();
            int num = comm.ExecuteNonQuery();
            comm.Dispose();
            conn.Close();
            return num;
        }
    }
}
