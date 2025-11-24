using ProjClinicaOdontoriso.Configs;
using ProjClinicaOdontoriso.Models.Paciente;
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
                comando.Parameters.AddWithValue("@_tempo", procedimento.Tempo.TimeOfDay);
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
                    Nome = leitor.IsDBNull(leitor.GetOrdinal("nome_pro")) ? "" : leitor.GetString("nome_pro"),
                    Tempo = leitor.IsDBNull(leitor.GetOrdinal("tempo_pro")) ? DateTime.Today : DateTime.Today + leitor.GetTimeSpan("tempo_pro"),
                    Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_pro")) ? "" : leitor.GetString("descricao_pro"),
                    Valor = leitor.IsDBNull(leitor.GetOrdinal("valor_pro")) ? 0 : leitor.GetFloat("valor_pro")
                };

                lista.Add(procedimento);
            }

            return lista;
        }
        public Procedimento? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM procedimento WHERE id_pro = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var procedimento = new Procedimento();
                procedimento.Id = leitor.GetInt32("id_pro");
                procedimento.Nome = leitor.IsDBNull(leitor.GetOrdinal("nome_pro")) ? "" : leitor.GetString("nome_pro");
                procedimento.Tempo = leitor.IsDBNull(leitor.GetOrdinal("tempo_pro")) ? DateTime.Today : DateTime.Today + leitor.GetTimeSpan("tempo_pro");
                procedimento.Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_pro")) ? "" : leitor.GetString("descricao_pro");
                procedimento.Valor = leitor.IsDBNull(leitor.GetOrdinal("valor_pro")) ? 0 : leitor.GetFloat("valor_pro");

                return procedimento;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Procedimento procedimento)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "UPDATE procedimento SET nome_pro = @_nome, tempo_pro = @_tempo, descricao_pro = @_descricao, valor_pro = @_valor WHERE id_pro = @_id;");

                comando.Parameters.AddWithValue("@_nome", procedimento.Nome);
                comando.Parameters.AddWithValue("@_tempo", procedimento.Tempo);
                comando.Parameters.AddWithValue("@_descricao", procedimento.Descricao);
                comando.Parameters.AddWithValue("@_valor", procedimento.Valor);
                comando.Parameters.AddWithValue("@_id", procedimento.Id);

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
                "DELETE FROM procedimento WHERE id_pro = @id;");

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
