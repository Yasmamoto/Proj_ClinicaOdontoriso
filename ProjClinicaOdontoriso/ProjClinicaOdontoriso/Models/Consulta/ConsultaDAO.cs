using Microsoft.AspNetCore.Razor.TagHelpers;
using ProjClinicaOdontoriso.Configs;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjClinicaOdontoriso.Models
{
    public class ConsultaDAO
    {
        private readonly Conexao _conexao;

        public ConsultaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Consulta consulta)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO consulta VALUES (null, @_horario, @_data, null, null, null)");

                comando.Parameters.AddWithValue("@_horario", consulta.Horario.TimeOfDay);
                comando.Parameters.AddWithValue("@_data", consulta.Data.Date);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Consulta> ListarTodos()
        {
            var lista = new List<Consulta>();

            var comando = _conexao.CreateCommand("SELECT * FROM consulta");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var consulta = new Consulta
                {
                    Id = leitor.GetInt32("id_con"),
                    Horario = leitor.IsDBNull(leitor.GetOrdinal("horario_con")) ? DateTime.Today : DateTime.Today + leitor.GetTimeSpan("horario_con"),
                    Data = leitor.IsDBNull(leitor.GetOrdinal("data_con")) ? DateTime.Today : leitor.GetDateTime("data_con")
                };

                lista.Add(consulta);
            }

            return lista;
        }
        public Consulta? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM consulta WHERE id_con = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var consulta = new Consulta();
                consulta.Id = leitor.GetInt32("id_con");
                consulta.Horario = leitor.IsDBNull(leitor.GetOrdinal("horario_con")) ? DateTime.Today : DateTime.Today + leitor.GetTimeSpan("horario_con");
                consulta.Data = leitor.IsDBNull(leitor.GetOrdinal("data_con")) ? DateTime.Today : leitor.GetDateTime("data_con");

                return consulta;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Consulta consulta)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "UPDATE consulta SET horario_con = @_horario, data_con = @_data WHERE id_con = @_id;");

                comando.Parameters.AddWithValue("@_horario", consulta.Horario);
                comando.Parameters.AddWithValue("@_data", consulta.Data);
                comando.Parameters.AddWithValue("@_id", consulta.Id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "DELETE FROM consulta WHERE id_con = @id;");

                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}