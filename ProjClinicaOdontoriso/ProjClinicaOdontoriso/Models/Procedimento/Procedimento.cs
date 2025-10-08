namespace ProjClinicaOdontoriso.Models
{
    public class Procedimento
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public DateTime Tempo { get; set; }
        public string? Descricao { get; set; }
        public float Valor { get; set; }
    }
}