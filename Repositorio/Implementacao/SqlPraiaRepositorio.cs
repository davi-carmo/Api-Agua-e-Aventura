using Agua_e_Aventura.Data;
using Agua_e_Aventura.Models.Domain;
using Agua_e_Aventura.Models.DTOS;
using Agua_e_Aventura.Repositorio.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agua_e_Aventura.Data;

namespace Agua_e_Aventura.Repositorio.Implementacao
{
    public class SqlPraiaRepositorio : IPraiaRepositorio
    {
        private  AguaAventuraDbContext dbContext;

        public SqlPraiaRepositorio(AguaAventuraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Praia> CriarPraiaAsync(Praia praia)
        {
            if (praia == null)
            {
                return null;
            }

            praia.Id = Guid.NewGuid();
            praia.Nota = 0;
            
            await dbContext.AddAsync(praia);
            await dbContext.SaveChangesAsync();

            return praia;
            
        }

        public async Task<Praia> DeletePraiaAsync(Guid id)
        {

            var domainPraia = await dbContext.Praias.FirstOrDefaultAsync(praia => praia.Id == id);

            if(domainPraia == null) 
            {
                return null;
            }

            dbContext.Praias.Remove(domainPraia);
            await dbContext.SaveChangesAsync();

            return domainPraia;
        }

        public async Task<List<Praia>> TodasAsPraiasAsync()
        {
            var domainModel =  dbContext.Praias.Include("Regioes");

            return await domainModel.ToListAsync();

            
        }

        public async Task<Praia> GetPraiaPorId(Guid id)
        {

            var praiaPorID = await dbContext.Praias.FirstOrDefaultAsync(praia => praia.Id == id);

            return praiaPorID;
        }

        public async Task<Praia> UpdatePraiaAsync(Guid id, UpdateRequestPraiaDTO updatePraia)
        {
            var praiaDomain = await dbContext.Praias.FirstOrDefaultAsync(praia => praia.Id == id);

            if(praiaDomain == null) 
            {
                return null;
            }

            praiaDomain.Nome = updatePraia.Nome;
            praiaDomain.Descrição = updatePraia.Descrição;
            praiaDomain.Nota = updatePraia.Nota;
            praiaDomain.RegiaoId = praiaDomain.RegiaoId;
            praiaDomain.UrlFotosId = updatePraia.UrlFotosId;

            await dbContext.SaveChangesAsync();

            return praiaDomain;
            
        }
    }
}
