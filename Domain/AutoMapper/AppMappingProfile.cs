using AutoMapper;
using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.AutoMapper;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<Sample, SampleDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
            .ForMember(dest => dest.NodeId, opt => opt.MapFrom(src => src.NodeId))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.User.FullName));
    }
}