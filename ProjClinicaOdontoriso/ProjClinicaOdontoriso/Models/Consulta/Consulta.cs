namespace ProjClinicaOdontoriso.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        public TimeOnly Horario { get; set; }

        public DateOnly Data { get; set; }
    }
}