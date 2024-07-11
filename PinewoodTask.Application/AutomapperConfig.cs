using AutoMapper;
using PinewoodTask.Core.Dto;
using PinewoodTask.Core.Entities;

namespace PinewoodTask.Application
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();

        }
    }

}
