using GulfBridge.Api.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using GulfBridge.DAL.DAL;
using GulfBridge.DAL.IDAL;
using AutoMapper;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Web.Http.Cors;

namespace GulfBridge.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);


            // Web API configuration and services
            var container = new UnityContainer();

            container.RegisterType<IAccountDAL, AccountDAL>();
            container.RegisterType<IUserDAL, UserDAL>();
            container.RegisterType<IEmployerDAL, EmployerDAL>();
            container.RegisterType<IAdminDAL, AdminDAL>();
            container.RegisterType<ICommonDAL, CommonDAL>();
            container.RegisterType<IMapper, Mapper>();
            container.RegisterType<IMinistryDAL, MinistryDAL>();
            container.RegisterType<IGulfBridgeDAL, GulfBridgeDAL>();
            container.RegisterType<IApplicantDAL, ApplicantDAL>();
            config.DependencyResolver = new UnityResolver(container);

            //AutoMapperClient.Initialize();

            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //        config.Formatters.JsonFormatter.SupportedMediaTypes
            //.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            // Web API routes
            config.MapHttpAttributeRoutes();


            log4net.Config.XmlConfigurator.Configure();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
