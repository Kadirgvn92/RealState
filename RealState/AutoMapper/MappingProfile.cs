using AutoMapper;
using RealState.DTOs.CustomerDTOs;
using RealState.Entity;

namespace RealState.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerAddDTO, Customer>();
    }
}
