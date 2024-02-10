using Agua_e_Aventura.Data;
using Agua_e_Aventura.Models.Domain;
using Agua_e_Aventura.Models.DTOS.RegiaoDtos;
using Agua_e_Aventura.Repositorio.Repositorio;

namespace Agua_e_Aventura.Repositorio.Implementacao
{
    public class SqlRegiaoRepositorio : IRegionRepositorio
    {
        private  AguaAventuraDbContext dbContext;

        public SqlRegiaoRepositorio( AguaAventuraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Regiao> CriarRegiaoAsync(CreateRegiaoDto regiaoDto)
        {
            Regiao regiao = new Regiao();

            regiao.Id = Guid.NewGuid();
            regiao.Nome = regiaoDto.Nome;


            await dbContext.Regioes.AddAsync(regiao);
            await dbContext.SaveChangesAsync();

            return regiao;
            
        }
    }
}
