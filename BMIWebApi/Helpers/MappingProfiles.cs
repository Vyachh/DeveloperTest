using AutoMapper;
using BMIWebApi.Dto;
using BMIWebApi.Models;


namespace BMIWebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PacientDto, Pacient>();
            CreateMap<User, Pacient>();
        }
    }
}
