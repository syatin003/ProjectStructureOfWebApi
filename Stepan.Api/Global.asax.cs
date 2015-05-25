using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Stepan.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            HttpException lastErrorWrapper = Server.GetLastError() as HttpException;
            Exception lastError = lastErrorWrapper;
            if (lastErrorWrapper.InnerException != null)
                lastError = lastErrorWrapper.InnerException;
            string lastErrorTypeName = lastError.GetType().ToString();
            string lastErrorMessage = lastError.Message;
            string lastErrorStackTrace = lastError.StackTrace;
            String source = lastError.Source;
            DateTime dt = DateTime.Now;

            String code = lastError.HResult.ToString();
            String method_name = lastError.TargetSite.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("ExceptionLoggingToDataBase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ExceptionMsg", SqlDbType.VarChar, 100).Value = lastErrorMessage;
            cmd.Parameters.Add("@ExceptionType", SqlDbType.VarChar, 100).Value = lastErrorTypeName;
            cmd.Parameters.Add("@ExceptionURL", SqlDbType.VarChar, 500).Value = lastErrorStackTrace;
            cmd.Parameters.Add("@ExceptionSource", SqlDbType.VarChar, 500).Value = source;
            cmd.Parameters.AddWithValue("@Logdate", dt);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        // Sometimes Browser send request as OPTIONS request before any request, so this is used to overcome this drawback
        protected void Application_BeginRequest(object sender, EventArgs args)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                Response.StatusCode = 200;
                Response.Flush();
            }
        }
    }
}
