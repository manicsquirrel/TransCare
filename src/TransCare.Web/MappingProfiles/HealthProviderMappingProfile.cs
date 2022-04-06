using AutoMapper;
using TransCare.Models;
using TransCare.Web.Models.Responses;

namespace TransCare.Web.MappingProfiles
{
    public class HealthProviderMappingProfile : Profile
    {
        public HealthProviderMappingProfile()
        {
            CreateMap<HealthProvider, HealthProviderResponse>()
                .ForMember(d => d.StateCode, opt => opt.MapFrom(src => src.State.Code ?? ""))
                .ForMember(d => d.StateName, opt => opt.MapFrom(src => src.State.Name ?? ""));

            CreateMap<HealthProviderRequest, HealthProvider>()
                .ForMember(d => d.State, opt => opt.MapFrom(src => new State { Code = src.State, Name = "" }));
        }
    }
}