using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using GulfBridge.DAL.dbContext;
using Microsoft.Owin.Security;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Routing;
using System.Diagnostics;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.IO;

namespace GulfBridge.Api.App_Start
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AutherizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });


            using (var db = new Gulf_Bridge_db1Entities())
            {
                if (db != null)
                {
                    //string password= ExternalPlugin.EncodePasswordToBase64(context.Password);
                    var user = db.AspNetUsers.Where(c => c.Email == context.UserName &&
                        c.PasswordHash == context.Password && c.IsActive == true).FirstOrDefault();

                    if (user != null)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));

                        var prop = new AuthenticationProperties(new Dictionary<string, string>
                        {
                            {
                                "Id",user.Id
                            },
                            {
                                "Email",!string.IsNullOrEmpty(user.Email)?user.Email:""
                            },
                            {
                                "PhoneNumber",!string.IsNullOrEmpty(user.PhoneNumber)?user.PhoneNumber:""
                            },
                            {
                                "UserName",!string.IsNullOrEmpty(user.UserName)?user.UserName:""
                            },
                            {
                                "UserType",user.UserType!=0?user.UserType.ToString():""
                            },
                            {
                                "IsFirstLogin",user.IsFirstLogin!=null?user.IsFirstLogin.ToString():""
                            },
                        });
                        var ticket = new AuthenticationTicket(identity, prop);
                        context.Validated(ticket);
                    }
                    else
                    {
                        context.SetError("invalid_grant", "Provided username and password is incorrect");
                        context.Rejected();
                    }
                }
                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    context.Rejected();
                }
                return;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            context.AdditionalResponseParameters.Add("userID", context.Identity.GetUserId());

            return Task.FromResult<object>(null);
        }
    }

    public class GulfActionLogFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
     
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            StaticLogger.Logger.Log(string.Format("User {0} Invoked Action Method {1} at {2}", HttpContext.Current.User.Identity.Name, actionContext.ActionDescriptor.ActionName, DateTime.Now));
        }
    }

    public interface ILoggerFacade
    {
        void Log(string logInfo);

    }

    public class SimpleLogger : ILoggerFacade
    {

        public void Log(string logInfo)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(GetPath("GBLog.txt"), true))
                {
                    outputFile.WriteLine(logInfo);
                    outputFile.WriteLine("--------------------------------------------------------------------------");

                }
            }
            catch
            {

            }
        }

        public static string GetPath(string localPath)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory + @"\Log\";
            if (!Directory.Exists(currentDir))
                Directory.CreateDirectory(currentDir);
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, DateTime.Today.ToString("dd'.'MM'.'yyyy") + "_" + localPath)));
            return directory.ToString();
        }

    }

    public class StaticLogger
    {

        static readonly ILoggerFacade _logger = new SimpleLogger();
        StaticLogger()
        {
        }
        public static ILoggerFacade Logger
        {
            get { return _logger; }
        }
    }


}