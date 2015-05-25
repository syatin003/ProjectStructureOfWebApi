using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using context = System.Web.HttpContext;
namespace Stepan.Repository.Models
{
    public class ExceptionLogging
    {
        private static String exception_url;
        static SqlConnection con;

        private static void Connection()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(connectionstring);
            con.Open();
        }

        public static void SendExcepToDB(Exception exp) // Exception is saved to database
        {
            DateTime dt = DateTime.Now;
            Connection();
            exception_url = context.Current.Request.Url.ToString();
            SqlCommand comm = new SqlCommand("ExceptionLoggingToDataBase", con);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ExceptionMsg", exp.Message.ToString());
            comm.Parameters.AddWithValue("@ExceptionType", exp.GetType().Name.ToString());
            comm.Parameters.AddWithValue("@ExceptionURL", exception_url);
            comm.Parameters.AddWithValue("@ExceptionSource", exp.StackTrace.ToString());
            comm.Parameters.AddWithValue("@Logdate", dt);
            comm.ExecuteNonQuery();
            con.Close();
        }
    }
}