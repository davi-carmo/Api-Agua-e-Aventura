using Agua_e_Aventura.Models.Domain.Comentarios;
using Agua_e_Aventura.Models.Domain;

namespace Agua_e_Aventura.Models.DTOS
{
    public class DeletePraiaDTO 
    {
        public string Nome { get; set; }

        public string Descrição { get; set; }

        public decimal Nota { get; set; }

        public Regiao regiao { get; set; }


    }
}
