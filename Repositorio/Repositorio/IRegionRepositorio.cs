using Agua_e_Aventura.Models.Domain;
using Agua_e_Aventura.Models.DTOS.RegiaoDtos;

namespace Agua_e_Aventura.Repositorio.Repositorio
{
    public interface IRegionRepositorio
    {

        Task<Regiao> CriarRegiaoAsync(CreateRegiaoDto regiaoDto);

    }
}
