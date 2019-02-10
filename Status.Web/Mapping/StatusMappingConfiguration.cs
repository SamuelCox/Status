using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Status.DomainModel.Models;
using Update = Status.Data.Entities.Update;

namespace Status.Web.Mapping
{
    public static class StatusMappingConfiguration
    {
        public static MapperConfiguration GetConfig()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Update, DomainModel.Models.Update>().
                        ForMember(x => x.Creator, o => o.MapFrom(x => x.AspNetUser))
                        .ReverseMap()
                        .ForMember(x => x.UserId, o => o.MapFrom(x => x.Creator.Id))
                        .ForMember(x => x.AspNetUser, o => o.Ignore());
                    cfg.CreateMap<IdentityUser, User>().ReverseMap();
                    cfg.CreateMap<Data.Entities.Blog, DomainModel.Models.Blog>()
                        .ForMember(x => x.Creator, o => o.MapFrom(x => x.AspNetUser))
                        .ReverseMap()
                        .ForMember(x => x.UserId, o => o.MapFrom(x => x.Creator.Id))
                        .ForMember(x => x.AspNetUser, o => o.Ignore());
                });
            return config;
        }
    }
}
