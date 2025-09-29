﻿using ProjClinicaOdontoriso.Configs;
using System.Data;

namespace ProjClinicaOdontoriso.Models
{
    public class ProcedimentoDAO
    {
        private readonly Conexao _conexao;

        public ProcedimentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Procedimento procedimento)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO procedimento VALUES (null, @_nome, @_tempo, @_descricao, @_valor)");

                comando.Parameters.AddWithValue("@_nome", procedimento.Nome);
                comando.Parameters.AddWithValue("@_tempo", procedimento.Tempo);
                comando.Parameters.AddWithValue("@_descricao", procedimento.Descricao);
                comando.Parameters.AddWithValue("@_valor", procedimento.Valor);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Procedimento> ListarTodos()
        {
            var lista = new List<Procedimento>();

            var comando = _conexao.CreateCommand("SELECT * FROM procedimento");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var procedimento = new Procedimento
                {
                    Id = leitor.GetInt32("id_pro"),
                    Nome = leitor.GetString("nome_pro"),
                    Tempo = TimeOnly.FromTimeSpan(leitor.GetTimeSpan("tempo_pro")),
                    Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_pro")) ? "" : leitor.GetString("descricao_pro"),
                    Valor = leitor.GetFloat("valor_pro")
                };

                lista.Add(procedimento);
            }

            return lista;
        }
    }
}
