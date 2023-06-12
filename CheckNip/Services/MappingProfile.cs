using AutoMapper;
using CheckNip.DB.Models;
using CheckNip.Models;

namespace CheckNip.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Subject, SubjectDb>();
            CreateMap<Person, RepresentativesDb>();
            CreateMap<Person, PartnersDb>();           
            CreateMap<BankAccountDb, string>().ConvertUsing(source => source.Value);
            CreateMap<string, BankAccountDb>().ForMember(z => z.Value, z => z.MapFrom(d => d));
        }
    }
}
