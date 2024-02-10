using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agua_e_Aventura.Models.DTOS;
using Agua_e_Aventura.Repositorio.Implementacao;
using Agua_e_Aventura.Models.Domain;
using Agua_e_Aventura.Repositorio.Repositorio;
using AutoMapper;

namespace Agua_e_Aventura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PraiaController : ControllerBase
    {
        private readonly IPraiaRepositorio sqlPraiaRepositorio;
        private  IMapper mapper;

        public PraiaController(IPraiaRepositorio sqlPraiaRepositorio, IMapper _mapper)
        {
            this.sqlPraiaRepositorio = sqlPraiaRepositorio;
            this.mapper = _mapper;
        }

   

        [HttpPost]
        public async Task<IActionResult> Criarpraia([FromBody] UpdateRequestPraiaDTO criarPraia)
        {
            var praiaDomainModel = mapper.Map<Praia>(criarPraia);

            praiaDomainModel = await sqlPraiaRepositorio.CriarPraiaAsync(praiaDomainModel);

            if(praiaDomainModel == null) 
            {

            return NotFound();

            }

            var praiaDto = mapper.Map<PraiaDTO>(praiaDomainModel);


            return Ok(praiaDto);

        
        }

        [HttpGet]        
        public async Task<IActionResult> ObterTodasAsPraias() 
        {
         var domainModel = await sqlPraiaRepositorio.TodasAsPraiasAsync();


            var praiaDTO = new List<PraiaDTO>();

            foreach(var item in domainModel) 
            {
                praiaDTO.Add(new PraiaDTO()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Descrição = item.Descrição,
                    Nota = item.Nota,
                    UrlFotosId = item.UrlFotosId,
                    regiao = item.Regioes
                    

                }) ;
            

            }
            return Ok(praiaDTO);
           
            
            
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePraias([FromRoute] Guid id, [FromBody]UpdateRequestPraiaDTO updatePraia) 
        {
            var domainpraia = await sqlPraiaRepositorio.UpdatePraiaAsync(id, updatePraia);

            if(domainpraia == null) 
            {
                return NotFound();
            }

            var updateDto = mapper.Map<PraiaDTO>(domainpraia);

            return Ok(updateDto);




        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeletPraia([FromRoute]Guid id) 
        {

            var domain = await sqlPraiaRepositorio.DeletePraiaAsync(id);

            if(domain == null) 
            {
                return NotFound();
            }

            var DeleteDto = mapper.Map<DeletePraiaDTO>(domain);

            return Ok(domain);
        
        }
       

        
    }
}
