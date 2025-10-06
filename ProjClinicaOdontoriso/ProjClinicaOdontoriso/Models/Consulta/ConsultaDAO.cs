using ProjClinicaOdontoriso.Configs;
using System.Data;

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

                comando.Parameters.AddWithValue("@_horario", consulta.Horario.TimeOfDay); // pega só o horário
                comando.Parameters.AddWithValue("@_data", consulta.Data.Date); // pega só a data

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

                    // Pega apenas o horário do campo TIME e transforma num DateTime usando a data de hoje
                    Horario = DateTime.Today + leitor.GetTimeSpan("horario_con"),

                    // Já está correto — data_con vem como DateTime
                    Data = leitor.GetDateTime("data_con")
                };

                lista.Add(consulta);
            }

            return lista;
        }

    }
}
