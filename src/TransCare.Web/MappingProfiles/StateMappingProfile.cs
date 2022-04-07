using AutoMapper;
using TransCare.Models;

namespace TransCare.Web.MappingProfiles
{
    public class StateMappingProfile : Profile
    {
        public StateMappingProfile()
        {
            CreateMap<State, StateResponse>();
        }
    }
}