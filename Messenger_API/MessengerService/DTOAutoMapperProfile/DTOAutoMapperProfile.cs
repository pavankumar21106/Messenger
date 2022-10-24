using AutoMapper;
using FluentResults;
using MessengerInfrastructure.Entity;
using MessengerService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerService.DTOAutoMapperProfile
{
    public class DTOAutoMapperProfile : Profile
    {
        public DTOAutoMapperProfile()
        {
            CreateMap<Result<MessageEntity>, Result<MessageDTO>>().ReverseMap();
            CreateMap<MessageEntity, MessageDTO>().ReverseMap();
            CreateMap<UserDTO, UserEntity>();

        }
    }
}
