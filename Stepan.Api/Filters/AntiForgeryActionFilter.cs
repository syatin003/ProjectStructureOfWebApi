using Stepan.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Filters;

namespace Stepan.Api.Filters
{
    public class AntiForgeryActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            string antiforgeryToken = "";
            string deviceId = "";

            IEnumerable<string> tokenHeaderAntiForgeryHashed;
            IEnumerable<string> tokenHeaderDeviceId;

            actionContext.Request.Headers.TryGetValues("AntiForgeryToken", out tokenHeaderAntiForgeryHashed);
            antiforgeryToken = tokenHeaderAntiForgeryHashed.First();
            //Check if request is come from mobile or website 
            if (HttpContext.Current.Request.Browser["IsMobileDevice"] == "true")
            {
                actionContext.Request.Headers.TryGetValues("DeviceId", out tokenHeaderDeviceId);
                deviceId = tokenHeaderDeviceId.First();
                string hashDeviceId = Hash.Hashing(deviceId);
                if (hashDeviceId != antiforgeryToken)
                {
                    throw new ArgumentException("This user is from different claims based user");
                }
            }
            else
            {
                string hostName = Dns.GetHostName();
                Console.WriteLine(hostName);
                string ip = Dns.GetHostByName(hostName).AddressList[0].ToString();
                string hashIp = Hash.Hashing(ip);
                if (hashIp != antiforgeryToken)
                {
                    throw new ArgumentException("This user is from different claims based user");
                }
            }
            base.OnActionExecuting(actionContext);
        }
    }
}