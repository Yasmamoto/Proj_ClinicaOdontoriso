using ProjClinicaOdontoriso.Configs;

namespace ProjClinicaOdontoriso.Models.Funcionario
{

    public class FuncionarioDAO
    {
        private readonly Conexao _conexao;
        public FuncionarioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }
        public void InserirFunc(Funcionario funcionario)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO funcionario VALUES (null,@_nome_fun, @_data_nascimento_fun, @_sexo_fun, @_cpf_fun, @_rg_fun, @_titulo_eleitor_fun, @_raca_fun, @_email_fun, @_telefone_fun,@_nacionalidade_fun,@_estado_civil_fun, @_estado_fun, @_cidade_fun, @_endereco_fun, @_cargo_fun, @_data_admissao_fun, @_salario_inicial_fun, @_ctps_fun, @_recebe_salario_familia_fun, @_qtd_filhos_fun, @_escolaridade_fun)");
                comando.Parameters.AddWithValue("@_nome_fun", funcionario.Nome);
                comando.Parameters.AddWithValue("@_data_nascimento_fun", funcionario.DataNascimento?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@_sexo_fun", funcionario.Sexo);
                comando.Parameters.AddWithValue("@_cpf_fun", funcionario.CPF);
                comando.Parameters.AddWithValue("@_rg_fun", funcionario.RG);
                comando.Parameters.AddWithValue("@_titulo_eleitor_fun", funcionario.TituloEleitor);
                comando.Parameters.AddWithValue("@_raca_fun", funcionario.Raca);
                comando.Parameters.AddWithValue("@_nacionalidade_fun", funcionario.Nacionalidade);

                comando.Parameters.AddWithValue("@_estado_civil_fun", funcionario.EstadoCivil);

                comando.Parameters.AddWithValue("@_email_fun", funcionario.Email);
                comando.Parameters.AddWithValue("@_telefone_fun", funcionario.Telefone);
                comando.Parameters.AddWithValue("@_estado_fun", funcionario.Estado);
                comando.Parameters.AddWithValue("@_cidade_fun", funcionario.Cidade);
                comando.Parameters.AddWithValue("@_endereco_fun", funcionario.Endereco);
                comando.Parameters.AddWithValue("@_cargo_fun", funcionario.Cargo);
                comando.Parameters.AddWithValue("@_data_admissao_fun", funcionario.DataAdmissao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@_salario_inicial_fun", funcionario.SalarioInicial);
                comando.Parameters.AddWithValue("@_ctps_fun", funcionario.CTPS);
                comando.Parameters.AddWithValue("@_recebe_salario_familia_fun", funcionario.RecebeSalarioFamilia);
                comando.Parameters.AddWithValue("@_qtd_filhos_fun", funcionario.QuantidadeFilhos);
                comando.Parameters.AddWithValue("@_escolaridade_fun", funcionario.Escolaridade);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<Funcionario> ListarFunc()
        {


            var listarfunc = new List<Funcionario>();
            var comando = _conexao.CreateCommand("SELECT id_fun, nome_fun,data_nascimento_fun, cpf_fun, rg_fun,cargo_fun, data_admissao_fun,salario_inicial_fun, ctps_fun FROM funcionario");
            var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                var func = new Funcionario
                {
                    Id = leitor.GetInt32("id_fun"),
                    Nome = leitor.GetString("nome_fun"),
                    DataNascimento = leitor.GetDateTime("data_nascimento_fun"),
                    CPF = leitor.GetString("cpf_fun"),
                    RG = leitor.GetString("rg_fun"),
                    Cargo = leitor.GetString("cargo_fun"),
                    DataAdmissao = leitor.GetDateTime("data_admissao_fun"),
                    SalarioInicial = leitor.GetDecimal("salario_inicial_fun"),
                    CTPS = leitor.GetString("ctps_fun"),
                };
                listarfunc.Add(func);
            }

            return listarfunc;

        }
    }
}
