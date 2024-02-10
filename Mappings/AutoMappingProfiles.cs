using Agua_e_Aventura.Models.Domain;
using Agua_e_Aventura.Models.DTOS;
using AutoMapper;

namespace Agua_e_Aventura.Mappings
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            //Mapas de Praia

            CreateMap<UpdateRequestPraiaDTO, Praia>().ReverseMap();
            CreateMap<PraiaDTO, Praia>().ReverseMap();
            CreateMap<UpdateRequestPraiaDTO, Praia>().ReverseMap();
            CreateMap<DeletePraiaDTO, Praia>().ReverseMap();
            
        }


    }
}
