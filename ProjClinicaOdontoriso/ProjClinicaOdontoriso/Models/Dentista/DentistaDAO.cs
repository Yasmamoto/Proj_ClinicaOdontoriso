using ProjClinicaOdontoriso.Configs;

namespace ProjClinicaOdontoriso.Models.Dentista
{
    public class DentistaDAO
    {
        private readonly Conexao _conexao;
        public DentistaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }
        public void InserirDentis(Dentista dentista)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO dentista VALUES (null,@_nome_dent, @_data_nascimento_dent, @_sexo_dent, @_cpf_dent, @_rg_dent, @_titulo_eleitor_dent, @_raca_dent, @_email_dent, @_telefone_dent,@_nacionalidade_dent, @_estado_civil_dent, @_estado_dent, @_cidade_dent, @_endereco_dent, @_cargo_dent, @_data_admissao_dent, @_salario_inicial_dent, @_ctps_dent, @_recebe_salario_familia_dent, @_qtd_filhos_dent, @_faculdade_dent, @_data_conclusao_dent, @_cro_dent, @_especialidade_dent, @_cnpj_dent)");
                comando.Parameters.AddWithValue("@_nome_dent", dentista.Nome);
                comando.Parameters.AddWithValue("@_data_nascimento_dent", dentista.DataNascimento?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@_sexo_dent", dentista.Sexo);
                comando.Parameters.AddWithValue("@_cpf_dent", dentista.CPF);
                comando.Parameters.AddWithValue("@_rg_dent", dentista.RG);
                comando.Parameters.AddWithValue("@_titulo_eleitor_dent", dentista.TituloEleitor);
                comando.Parameters.AddWithValue("@_raca_dent", dentista.Raca);
                comando.Parameters.AddWithValue("@_nacionalidade_dent", dentista.Nacionalidade);
                comando.Parameters.AddWithValue("@_estado_civil_dent", dentista.EstadoCivil);
                comando.Parameters.AddWithValue("@_email_dent", dentista.Email);
                comando.Parameters.AddWithValue("@_telefone_dent", dentista.Telefone);
                comando.Parameters.AddWithValue("@_estado_dent", dentista.Estado);
                comando.Parameters.AddWithValue("@_cidade_dent", dentista.Cidade);
                comando.Parameters.AddWithValue("@_endereco_dent", dentista.Endereco);
                comando.Parameters.AddWithValue("@_cargo_dent", dentista.Cargo);
                comando.Parameters.AddWithValue("@_data_admissao_dent", dentista.DataAdmissao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@_salario_inicial_dent", dentista.SalarioInicial);
                comando.Parameters.AddWithValue("@_ctps_dent", dentista.CTPS);
                comando.Parameters.AddWithValue("@_recebe_salario_familia_dent", dentista.RecebeSalarioFamilia);
                comando.Parameters.AddWithValue("@_qtd_filhos_dent", dentista.QuantidadeFilhos);
                comando.Parameters.AddWithValue("@_faculdade_dent", dentista.Faculdade);
                comando.Parameters.AddWithValue("@_data_conclusao_dent", dentista.DataConclusao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@_cro_dent", dentista.CRO);
                comando.Parameters.AddWithValue("@_especialidade_dent", dentista.Especialidade);
                comando.Parameters.AddWithValue("@_cnpj_dent", dentista.CNPJ);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<Dentista> ListarDentis()
        {


            var listardentista = new List<Dentista>();
            var comando = _conexao.CreateCommand("SELECT id_dent, nome_dent, cpf_dent, data_admissao_dent,salario_inicial_dent,ctps_dent, cro_dent ,especialidade_dent FROM dentista");
            var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                var dent = new Dentista
                {
                    Id = leitor.GetInt32("id_dent"),
                    Nome = leitor.GetString("nome_dent"),
                    CPF = leitor.GetString("cpf_dent"),
                    DataAdmissao = leitor.GetDateTime("data_admissao_dent"),
                    SalarioInicial = leitor.GetDecimal("salario_inicial_dent"),
                    CTPS = leitor.GetString("ctps_dent"),
                    CRO = leitor.GetString("cro_dent"),
                    Especialidade = leitor.GetString("especialidade_dent")

                };
                listardentista.Add(dent);
            }

            return listardentista;

        }
    }
}