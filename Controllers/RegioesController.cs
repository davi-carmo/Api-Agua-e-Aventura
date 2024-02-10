using Agua_e_Aventura.Models.Domain;
using Agua_e_Aventura.Models.DTOS.RegiaoDtos;
using Agua_e_Aventura.Repositorio.Implementacao;
using Agua_e_Aventura.Repositorio.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agua_e_Aventura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegioesController : ControllerBase
    {
        private  IRegionRepositorio regionRepositorio;

        public RegioesController(IRegionRepositorio regionRepositorio)
        {
            this.regionRepositorio = regionRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarRegioao([FromBody]CreateRegiaoDto createRegiao) 
        {
            var regiao = await regionRepositorio.CriarRegiaoAsync(createRegiao);

            var regiaoDto = new Regiao()
            {
                Nome = regiao.Nome,
                Id = regiao.Id
            };

            return Ok(regiaoDto);

        
        }
    }
}
