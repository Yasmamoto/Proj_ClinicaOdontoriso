
using ProjClinicaOdontoriso.Configs;

namespace ProjClinicaOdontoriso.Models
{
    public class PacienteDAO
    {

        private readonly Conexao _conexao;

        public PacienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }
        public void InserirPac(Paciente paciente)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO paciente VALUES (null, @_nome, @_data_nascimento, @_idade, @_localNascimento, @_rg, @_cpf, @_endereco, @_telefone, @_profissao, @_estadoCivil, @_email, @_sexo, @_raca, null)");

                comando.Parameters.AddWithValue("@_nome", paciente.Nome);
                comando.Parameters.AddWithValue("@_data_nascimento", paciente.DataNascimento);
                comando.Parameters.AddWithValue("@_localNascimento", paciente.LocalNascimento);
                comando.Parameters.AddWithValue("@_rg", paciente.RG);
                comando.Parameters.AddWithValue("@_cpf", paciente.CPF);
                comando.Parameters.AddWithValue(" @_endereco", paciente.Endereco);
                comando.Parameters.AddWithValue("@_telefone", paciente.Telefone);
                comando.Parameters.AddWithValue("@_profissao", paciente.Profissao);
                comando.Parameters.AddWithValue("@_estadoCivil", paciente.EstadoCivil);
                comando.Parameters.AddWithValue("@_email", paciente.Email);
                comando.Parameters.AddWithValue("@_sexo", paciente.Sexo);
                comando.Parameters.AddWithValue("@_raca", paciente.Raca);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Paciente> ListarTodos()
        {
            var lista = new List<Paciente>();

            var comando = _conexao.CreateCommand("SELECT * FROM paciente");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
               var dataNascimento = leitor.GetDateTime("data_nascimento_pac");

                var paciente = new Paciente
                { 
                    Id = leitor.GetInt32("id_pac"),
                    Nome = leitor.GetString("nome_pac"),
                    DataNascimento = DateOnly.FromDateTime(dataNascimento),
                    Idade = leitor.GetInt32("idade_pac"),
                    LocalNascimento = leitor.GetString("local_nascimento_pac"),
                    RG = leitor.GetString("rg_pac"),
                    CPF = leitor.GetString("cpf_pac"),
                    Endereco = leitor.GetString("endereco_pac"),
                    Telefone = leitor.GetString("telefone_pac"),
                    Profissao = leitor.GetString("profissão_pac"),
                    EstadoCivil = leitor.GetString("estado_civil_pac"),
                    Email = leitor.GetString("email_pac"),
                    Sexo = leitor.GetString("sexo_pac"),
                    Raca = leitor.GetString("raca_pac"),
                };

                lista.Add(paciente);
            }

            return lista;
        }


    }
}
