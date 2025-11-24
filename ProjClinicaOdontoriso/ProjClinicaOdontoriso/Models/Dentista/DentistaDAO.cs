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
                var comando = _conexao.CreateCommand("INSERT INTO dentista VALUES (null,@_nome_dent, @_data_nascimento_dent, @_sexo_dent, @_cpf_dent, @_rg_dent, @_titulo_eleitor_dent, @_raca_dent, @_email_dent, @_telefone_dent,@_nacionalidade_dent, @_estado_civil_dent, @_estado_dent, @_cidade_dent, @_endereco_dent, @_data_admissao_dent, @_salario_inicial_dent, @_ctps_dent, @_recebe_salario_familia_dent, @_qtd_filhos_dent, @_faculdade_dent, @_data_conclusao_dent, @_cro_dent, @_especialidade_dent, @_cnpj_dent)");
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

        public Dentista? BuscarIdDenti(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM dentista WHERE id_dent = @id");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if(leitor.Read())
            {
                var dentista = new Dentista();
                dentista.Id = leitor.GetInt32("id_dent");
                dentista.Nome = leitor.GetString("nome_dent");
                dentista.DataNascimento = leitor.GetDateTime("data_nascimento_den");
                dentista.Sexo = leitor.GetString("sexo_dent");
                dentista.CPF = leitor.GetString("cpf_dent");
                dentista.RG = leitor.GetString("rg_dent");
                dentista.TituloEleitor = leitor.GetString("titulo_eleitor_dent");
                dentista.Raca = leitor.GetString("raca_dent");
                dentista.Nacionalidade = leitor.GetString("nacionalidade_dent");
                dentista.EstadoCivil = leitor.GetString("estado_civil_dent");
                dentista.Email = leitor.GetString("email_dent");
                dentista.Telefone = leitor.GetString("telefone_dent");
                dentista.Estado = leitor.GetString("estado_dent");
                dentista.Cidade = leitor.GetString("cidade_dent");
                dentista.Endereco = leitor.GetString("endereco_dent");
                dentista.DataAdmissao = leitor.GetDateTime("data_admissao_dent");
                dentista.SalarioInicial = leitor.GetDecimal("salario_inicial_dent");
                dentista.CTPS = leitor.GetString("ctps_dent");
                dentista.RecebeSalarioFamilia = leitor.GetString("recebe_sala_fml_dent");
                dentista.QuantidadeFilhos = leitor.GetInt32("qtd_filhos_dent");
                dentista.Faculdade = leitor.GetString("faculdade_dent");
                dentista.DataConclusao = leitor.GetDateTime("data_conclusao_dent");
                dentista.CRO = leitor.GetString("cro_dent");
                dentista.Especialidade = leitor.GetString("especialidade_dent");
                dentista.CNPJ = leitor.GetString("cnpj_dent");

                return dentista;

            }
            else
            {
                return null;
            }
        }

        public void AtualizarDentis(Dentista dentista)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "UPDATE dentista SET " +
                    "nome_dent = @_nome, " +
                    "data_nascimento_den = @_data_nascimento, " +
                    "sexo_dent = @_sexo, " +
                    "cpf_dent = @_cpf, " +
                    "rg_dent = @_rg, " +
                    "titulo_eleitor_dent = @_titulo_eleitor, " +
                    "raca_dent = @_raca, " +
                    "nacionalidade_dent = @_nacionalidade, " +
                    "estado_civil_dent = @_estado_civil, " +
                    "email_dent = @_email, " +
                    "telefone_dent = @_telefone, " +
                    "estado_dent = @_estado, " +
                    "cidade_dent = @_cidade, " +
                    "endereco_dent = @_endereco, " +
                    "data_admissao_dent = @_data_admissao, " +
                    "salario_inicial_dent = @_salario_inicial, " +
                    "ctps_dent = @_ctps, " +
                    "recebe_sala_fml_dent = @_recebe_salario_familia, " +
                    "qtd_filhos_dent = @_qtd_filhos, " +
                    "faculdade_dent = @_faculdade, " +
                    "data_conclusao_dent = @_data_conclusao, " +
                    "cro_dent = @_cro, " +
                    "especialidade_dent = @_especialidade, " +
                    "cnpj_dent = @_cnpj " +
                    "WHERE id_dent = @_id");

                comando.Parameters.AddWithValue("@_nome", dentista.Nome);
                comando.Parameters.AddWithValue("@_data_nascimento", dentista.DataNascimento?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@_sexo", dentista.Sexo);
                comando.Parameters.AddWithValue("@_cpf", dentista.CPF);
                comando.Parameters.AddWithValue("@_rg", dentista.RG);
                comando.Parameters.AddWithValue("@_titulo_eleitor", dentista.TituloEleitor);
                comando.Parameters.AddWithValue("@_raca", dentista.Raca);
                comando.Parameters.AddWithValue("@_nacionalidade", dentista.Nacionalidade);
                comando.Parameters.AddWithValue("@_estado_civil", dentista.EstadoCivil);
                comando.Parameters.AddWithValue("@_email", dentista.Email);
                comando.Parameters.AddWithValue("@_telefone", dentista.Telefone);
                comando.Parameters.AddWithValue("@_estado", dentista.Estado);
                comando.Parameters.AddWithValue("@_cidade", dentista.Cidade);
                comando.Parameters.AddWithValue("@_endereco", dentista.Endereco);
                comando.Parameters.AddWithValue("@_data_admissao", dentista.DataAdmissao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@_salario_inicial", dentista.SalarioInicial);
                comando.Parameters.AddWithValue("@_ctps", dentista.CTPS);
                comando.Parameters.AddWithValue("@_recebe_salario_familia", dentista.RecebeSalarioFamilia);
                comando.Parameters.AddWithValue("@_qtd_filhos", dentista.QuantidadeFilhos);
                comando.Parameters.AddWithValue("@_faculdade", dentista.Faculdade);
                comando.Parameters.AddWithValue("@_data_conclusao", dentista.DataConclusao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@_cro", dentista.CRO);
                comando.Parameters.AddWithValue("@_especialidade", dentista.Especialidade);
                comando.Parameters.AddWithValue("@_cnpj", dentista.CNPJ);
                comando.Parameters.AddWithValue("@_id", dentista.Id);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}