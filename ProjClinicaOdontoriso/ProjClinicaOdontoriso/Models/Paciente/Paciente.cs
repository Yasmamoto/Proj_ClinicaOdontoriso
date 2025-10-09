namespace ProjClinicaOdontoriso.Models.Paciente
{
    public class Paciente
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public DateOnly DataNascimento { get; set; }
        public int Idade { get; set; }
        public string? LocalNascimento { get; set; }
        public string? RG { get; set; }
        public string? CPF { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Profissao { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Email { get; set; }
        public string? Sexo { get; set; }
        public string? Raca { get; set; }
    }
}