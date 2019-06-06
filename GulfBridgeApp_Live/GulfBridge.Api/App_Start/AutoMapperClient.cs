using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GulfBridge.Entity.Entity;

namespace GulfBridge.Api.App_Start
{
    public class AutoMapperClient
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<ApplicantDetail, GulfBridge.DAL.dbContext.ApplicantDetail>().ReverseMap();
                config.CreateMap<CommonType, GulfBridge.DAL.dbContext.Mst_ApplicationType>().ReverseMap();
                config.CreateMap<CommonType, GulfBridge.DAL.dbContext.Mst_Countries>().ReverseMap();
                config.CreateMap<EmployerDetails, GulfBridge.DAL.dbContext.EmployerDetail>().ReverseMap();
                config.CreateMap<AspNetUser, GulfBridge.DAL.dbContext.AspNetUser>().ReverseMap();

            });

            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<ApplicantDetail, GulfBridge.DAL.dbContext.ApplicantDetail>().ReverseMap();
            //    cfg.CreateMap<IEnumerable<CommonType>, IEnumerable<GulfBridge.DAL.dbContext.Mst_ApplicationType>>().ReverseMap();
            //    cfg.CreateMap<IEnumerable<GulfBridge.DAL.dbContext.Mst_ApplicationType>, IEnumerable<CommonType>>().ReverseMap();
            //    cfg.CreateMap<IEnumerable<CommonType>, IEnumerable<GulfBridge.DAL.dbContext.Mst_Countries>>().ReverseMap();
            //    cfg.CreateMap<IEnumerable<GulfBridge.DAL.dbContext.Mst_Countries>, IEnumerable<CommonType>>().ReverseMap();
            //});
        }


    }
}