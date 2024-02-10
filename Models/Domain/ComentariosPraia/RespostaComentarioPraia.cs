using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Agua_e_Aventura.Models.Domain.Comentarios
{
    public class RespostaComentarioPraia
    {
       
        public Guid Id { get; set; }
        public string? NomedeUsuario { get; set; }

        public DateTime DataResposta { get; set; }

        public string RespostasUsuario { get; set; }

        public Guid ComentarioId { get; set; }

        //Navegacao

        public ComentarioPraia Comentario { get; set; }
    }
}
