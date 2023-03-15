using AutoMapper;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Models.Dto;

namespace ConsumoAlimentario.Mapper
{
    public class AlimentosMapper : Profile
    {
        public AlimentosMapper()
        {
            CreateMap<Alimento, AlimentoListaDto>().ReverseMap();
            CreateMap<Alimento, AlimentoDto>().ReverseMap();
            CreateMap<Alimento, AlimentoCreateDto>().ReverseMap();
            CreateMap<ConsumoDiario, ConsumoDiarioList>().ReverseMap();
        }
    }
}
