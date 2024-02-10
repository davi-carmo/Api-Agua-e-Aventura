namespace Agua_e_Aventura.Models.DTOS
{
    public class UpdateRequestPraiaDTO
    {
        public string Nome { get; set; }

        public string Descrição { get; set; }

        public string? UrlFotosId { get; set; }

        public decimal Nota { get; set; }

        public Guid RegiaoId { get; set; }
    }
}
