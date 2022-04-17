using AutoMapper;
using TransCare.Models;
using TransCare.Web.Models.Requests;
using TransCare.Web.Models.Responses;

namespace TransCare.Web.MappingProfiles
{
    public class HealthProviderMappingProfile : Profile
    {
        public HealthProviderMappingProfile()
        {
            CreateMap<HealthProvider, HealthProviderResponse>()
                .ForMember(dest => dest.StateCode, opt => opt.MapFrom(src => src.State.Code ?? ""))
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State.Name ?? ""));

            CreateMap<HealthProviderRequest, HealthProvider>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => new State { Code = src.State, Name = "" }))
                .ForMember(dest => dest.StateCode, opts => opts.MapFrom(src => src.State));
        }
    }
}