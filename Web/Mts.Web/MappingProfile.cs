using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto = Mts.Core.Dto;
using Entity = Mts.Core.Entity;
namespace Mts.Web
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            //DTO to Entity
            CreateMap<Dto.RegistrationRequest, Entity.RegistrationRequest>();
            CreateMap<Dto.User, Entity.User>();
            CreateMap<Dto.Business, Entity.Business>();
            CreateMap<Dto.Role, Entity.Role>();
            CreateMap<Dto.RoleApplicationFeature, Entity.RoleApplicationFeature>();
            CreateMap<Dto.Role, Entity.UserRole>();
            CreateMap<Dto.UserProfile, Entity.User>();
            CreateMap<Dto.Address, Entity.Address>();

            //Entity to DTO
            CreateMap<Entity.RegistrationRequest, Dto.RegistrationRequest>();
            CreateMap<Entity.User, Dto.User>();
            CreateMap<Entity.Business, Dto.Business>();
            CreateMap<Entity.Role, Dto.Role>();
            CreateMap<Entity.RoleApplicationFeature, Dto.RoleApplicationFeature>();
            CreateMap<Entity.User, Dto.UserProfile>();
            CreateMap<Entity.Address, Dto.Address>();
        }
    }
}
