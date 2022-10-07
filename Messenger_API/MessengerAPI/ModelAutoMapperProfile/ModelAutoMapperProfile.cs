using AutoMapper;
using FluentResults;
using MessengerAPI.Models;
using MessengerInfrastructure.Entity;
using MessengerService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerService.ModelAutoMapperProfile
{
    public class ModelAutoMapperProfile : Profile
    {
        public ModelAutoMapperProfile()
        {
            CreateMap<Result<MessageDTO>, Result<MessageResponseModel>>().ReverseMap();
            CreateMap<MessageDTO, MessageModel>().ReverseMap();
        }
    }
}
