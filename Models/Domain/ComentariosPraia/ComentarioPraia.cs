using System.ComponentModel.DataAnnotations;

namespace Agua_e_Aventura.Models.Domain.Comentarios
{
    public class ComentarioPraia
    {
       
        public Guid Id { get; set; }
        public string? NomedeUsuario { get; set; }

        public DateTime DataResposta { get; set; }

        public string ComentarioUsuario { get; set; }

        //Navegacao

        public List<RespostaComentarioPraia> Resposta { get; set; }
    }
}
