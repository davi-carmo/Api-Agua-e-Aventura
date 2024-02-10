using Agua_e_Aventura.Models.Domain.Comentarios;

namespace Agua_e_Aventura.Models.Domain
{
    public class Praia
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Descrição { get; set; }

        public decimal Nota { get; set; }

        public string? UrlFotosId { get; set; }

        public Guid? RegiaoId { get; set; }

        
        //Propriedades de Navegação
        public  Regiao? Regioes { get; set; }

        public List<ComentarioPraia>? Comentarios { get; set; }

        public List<Fotos>? Fotos { get; set; }


    }
}
