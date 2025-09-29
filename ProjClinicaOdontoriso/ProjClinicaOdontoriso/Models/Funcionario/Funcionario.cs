﻿namespace ProjClinicaOdontoriso.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? CPF { get; set; }
        public string? RG { get; set; }
        public string? CNPJ { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? Email { get; set; }
        public string? Cargo { get; set; }
    }
}