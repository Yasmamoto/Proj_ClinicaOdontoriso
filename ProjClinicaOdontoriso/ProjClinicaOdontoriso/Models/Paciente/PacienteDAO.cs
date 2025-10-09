using ProjClinicaOdontoriso.Configs;

namespace ProjClinicaOdontoriso.Models.Paciente
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
                var comando = _conexao.CreateCommand(" INSERT INTO paciente VALUES (null, @_nome, @_data_nascimento, @_idade, @_localNascimento, @_rg, @_cpf, @_endereco, @_telefone, @_profissao, @_estadoCivil, @_email, @_sexo, @_raca)");

                comando.Parameters.AddWithValue("@_nome", paciente.Nome);
                comando.Parameters.AddWithValue("@_data_nascimento", paciente.DataNascimento.ToDateTime(TimeOnly.MinValue));
                comando.Parameters.AddWithValue("@_idade", paciente.Idade);
                comando.Parameters.AddWithValue("@_localNascimento", paciente.LocalNascimento);
                comando.Parameters.AddWithValue("@_rg", paciente.RG);
                comando.Parameters.AddWithValue("@_cpf", paciente.CPF);
                comando.Parameters.AddWithValue("@_endereco", paciente.Endereco);
                comando.Parameters.AddWithValue("@_telefone", paciente.Telefone);
                comando.Parameters.AddWithValue("@_profissao", paciente.Profissao);
                comando.Parameters.AddWithValue("@_estadoCivil", paciente.EstadoCivil);
                comando.Parameters.AddWithValue("@_email", paciente.Email);
                comando.Parameters.AddWithValue("@_sexo", paciente.Sexo);
                comando.Parameters.AddWithValue("@_raca", paciente.Raca);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir paciente: {ex.Message}");
                throw;
            }
        }

        public List<Paciente> ListarPaciente()
        {
            var lista = new List<Paciente>();

            var comando = _conexao.CreateCommand("SELECT * FROM paciente");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var dataNascimento = leitor.GetDateTime("data_nascimento_pac");

                var paciente = new Paciente
                {
                    Id = leitor.IsDBNull(leitor.GetOrdinal("id_pac")) ? 0 : leitor.GetInt32("id_pac"),
                    Nome = leitor.IsDBNull(leitor.GetOrdinal("nome_pac")) ? "" : leitor.GetString("nome_pac"),
                    DataNascimento = leitor.IsDBNull(leitor.GetOrdinal("data_nascimento_pac")) ? DateOnly.FromDateTime(DateTime.MinValue) : DateOnly.FromDateTime(leitor.GetDateTime("data_nascimento_pac")),
                    Idade = leitor.GetInt32("idade_pac"),
                    LocalNascimento = leitor.GetString("local_nascimento_pac"),
                    RG = leitor.GetString("rg_pac"),
                    CPF = leitor.GetString("cpf_pac"),
                    Endereco = leitor.GetString("endereco_pac"),
                    Telefone = leitor.GetString("telefone_pac"),
                    Profissao = leitor.GetString("profissao_pac"),
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