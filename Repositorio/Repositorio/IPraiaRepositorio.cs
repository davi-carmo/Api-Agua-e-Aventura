using Agua_e_Aventura.Models.Domain;
using Agua_e_Aventura.Models.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace Agua_e_Aventura.Repositorio.Repositorio
{
    public interface IPraiaRepositorio
    {
       
        Task<Praia> CriarPraiaAsync(Praia praia);

         Task<List<Praia>> TodasAsPraiasAsync();

        Task<Praia> GetPraiaPorId(Guid id);
        Task<Praia> UpdatePraiaAsync(Guid id, UpdateRequestPraiaDTO updatePraia);
        Task<Praia> DeletePraiaAsync(Guid id);
    }
}
