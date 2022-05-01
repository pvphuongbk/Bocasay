using AutoMapper;
using Bocasay.Data.Dto.User;
using Bocasay.Data.SqlServer.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Service.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, UserDto>().ReverseMap();
            CreateMap<UpdateUserDto, UserDto>().ReverseMap();
        }
    }
}
