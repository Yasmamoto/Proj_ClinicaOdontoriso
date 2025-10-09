create database bd_odontoriso;
use bd_odontoriso;

create table funcionario (
    id_fun int primary key auto_increment,
    nome_fun varchar(300),
    data_nascimento_fun date,
    sexo_fun varchar(20),
    cpf_fun varchar(15),
    rg_fun varchar(15),
    titulo_eleitor_fun varchar(30),
    raca_fun varchar(20),
    email_fun varchar(150),
    telefone_fun varchar(30),
    nacionalidade_fun varchar(100),
    estado_fun varchar(5),
    cidade_fun varchar(150),
    endereco_fun varchar(300),
    estado_civil_fun varchar(20),
    cargo_fun varchar(100),
    data_admissao_fun date,
    salario_inicial_fun decimal(10,2),
    ctps_fun varchar(50),
    recebe_salario_familia_fun varchar(5),
    qtd_filhos_fun int,
    escolaridade_fun varchar(50)
    );

create table Dentista(
id_dent int primary key auto_increment,
nome_dent varchar(300),
data_nascimento_den date,
sexo_dent varchar(20), 
cpf_dent varchar(15), 
rg_dent varchar(15), 
titulo_eleitor_dent varchar(30), 
raca_dent varchar(20), 
nacionalidade_dent varchar(100), 
estado_civil_dent varchar(30), 
email_dent varchar(300), 
telefone_dent varchar(30), 
estado_dent varchar(5), 
cidade_dent varchar(150), 
endereco_dent varchar(300), 
data_admissao_dent date, 
salario_inicial_dent float,
ctps_dent varchar(50), 
recebe_sala_fml_dent varchar(5), 
qtd_filhos_dent int, 
faculdade_dent varchar(50), 
data_conclusao_dent date,
cro_dent varchar(30), 
especialidade_dent varchar(500), 
cnpj_dent varchar(30)
);

create table Procedimento(
id_pro int primary key auto_increment,
nome_pro varchar(50),
tempo_pro time,
descricao_pro varchar(500),
valor_pro float
);


create table Paciente(
id_pac int primary key auto_increment,
nome_pac varchar(300),
data_nascimento_pac date,
idade_pac int,
local_nascimento_pac varchar(100),
rg_pac varchar(15),
cpf_pac varchar(15),
endereco_pac varchar(500),
telefone_pac varchar(30),
profissao_pac varchar(50),
estado_civil_pac varchar(30),
email_pac varchar(150),
sexo_pac varchar(30),
raca_pac varchar(30)
);

create table Consulta(
id_con int primary key auto_increment,
horario_con time,
data_con date,
id_pro_fk int,
foreign key (id_pro_fk) references Procedimento (id_pro),
id_pac_fk int,
foreign key (id_pac_fk) references Paciente (id_pac),
id_dent_fk int,
foreign key (id_dent_fk) references Dentista (id_dent)
);

-- inserts de Funcionario e dentista
INSERT INTO Funcionario (
    nome_fun, data_nascimento_fun, sexo_fun, cpf_fun, rg_fun, titulo_eleitor_fun, 
    raca_fun, email_fun, telefone_fun, nacionalidade_fun, estado_fun, cidade_fun, 
    endereco_fun, estado_civil_fun, cargo_fun, data_admissao_fun, salario_inicial_fun, 
    ctps_fun, recebe_salario_familia_fun, qtd_filhos_fun, escolaridade_fun) 
VALUES('Maria Oliveira Santos', '1990-05-12', 'Feminino', '123.456.789-00', '45.678.901-2', '123456789012',
    'Parda', 'maria.santos@email.com', '(11) 99999-8888', 'Brasileira', 'SP', 'São Paulo',
    'Rua das Flores, 120', 'Casada', 'Analista de RH', '2020-03-15', 4500.00,
    'CTPS12345', 'Sim', 2, 'Ensino Superior Completo');
INSERT INTO Funcionario (
    nome_fun, data_nascimento_fun, sexo_fun, cpf_fun, rg_fun, titulo_eleitor_fun, 
    raca_fun, email_fun, telefone_fun, nacionalidade_fun, estado_fun, cidade_fun, 
    endereco_fun, estado_civil_fun, cargo_fun, data_admissao_fun, salario_inicial_fun, 
    ctps_fun, recebe_salario_familia_fun, qtd_filhos_fun, escolaridade_fun) 
VALUES('João Pereira Lima', '1985-11-23', 'Masculino', '987.654.321-00', '12.345.678-9', '987654321000',
    'Branco', 'joao.lima@email.com', '(21) 98888-7777', 'Brasileiro', 'RJ', 'Niterói',
    'Av. Central, 45', 'Solteiro', 'Técnico em Informática', '2018-06-10', 3200.00,
    'CTPS54321', 'Não', 0, 'Ensino Médio Completo');
    
    INSERT INTO Funcionario (
    nome_fun, data_nascimento_fun, sexo_fun, cpf_fun, rg_fun, titulo_eleitor_fun, 
    raca_fun, email_fun, telefone_fun, nacionalidade_fun, estado_fun, cidade_fun, 
    endereco_fun, estado_civil_fun, cargo_fun, data_admissao_fun, salario_inicial_fun, 
    ctps_fun, recebe_salario_familia_fun, qtd_filhos_fun, escolaridade_fun) 
    VALUES('Ana Beatriz Costa', '1998-02-09', 'Feminino', '321.654.987-00', '98.765.432-1', '456789123000',
    'Preta', 'ana.costa@email.com', '(31) 97777-6666', 'Brasileira', 'MG', 'Belo Horizonte',
    'Rua das Palmeiras, 200', 'Solteira', 'Assistente Administrativa', '2022-09-01', 2500.00,
    'CTPS98765', 'Sim', 1, 'Ensino Médio Completo');
    -- insert dent
    INSERT INTO Dentista (
    nome_dent, data_nascimento_den, sexo_dent, cpf_dent, rg_dent, titulo_eleitor_dent, 
    raca_dent, nacionalidade_dent, estado_civil_dent, email_dent, telefone_dent, 
    estado_dent, cidade_dent, endereco_dent, data_admissao_dent, salario_inicial_dent, 
    ctps_dent, recebe_sala_fml_dent, qtd_filhos_dent, faculdade_dent, data_conclusao_dent, 
    cro_dent, especialidade_dent, cnpj_dent)
VALUES ('Dr. Lucas Almeida Santos', '1985-07-20', 'Masculino', '123.456.789-01', 'MG-12.345.678', 
    '1234567890/01', 'Pardo', 'Brasileira', 'Casado', 'lucas.santos@email.com', '(31) 99876-5432', 
    'MG', 'Belo Horizonte', 'Rua das Flores, 100, Centro', '2010-03-15', 5500.00, 
    '0123456 Série 0001', 'Não', 2, 'UFMG', '2008-12-10', 
    'MG-CRO-12345', 'Odontologia Estética e Implantodontia', '12.345.678/0001-90');
    INSERT INTO Dentista (
    nome_dent, data_nascimento_den, sexo_dent, cpf_dent, rg_dent, titulo_eleitor_dent, 
    raca_dent, nacionalidade_dent, estado_civil_dent, email_dent, telefone_dent, 
    estado_dent, cidade_dent, endereco_dent, data_admissao_dent, salario_inicial_dent, 
    ctps_dent, recebe_sala_fml_dent, qtd_filhos_dent, faculdade_dent, data_conclusao_dent, 
    cro_dent, especialidade_dent, cnpj_dent)
VALUES ('Dra. Camila Pires Oliveira', '1992-11-05', 'Feminino', '987.654.321-09', 'SP-98.765.432', 
    '9876543210/09', 'Branca', 'Brasileira', 'Solteira', 'camila.oliveira@email.com', '(11) 99123-4567', 
    'SP', 'São Paulo', 'Av. Paulista, 500, Apto 10', '2018-08-01', 4800.00, 
    '9876543 Série 0009', 'Sim', 0, 'USP', '2016-12-15', 
    'SP-CRO-98765', 'Ortodontia', '98.765.432/0001-01');
    
-- insert Paciente
INSERT INTO paciente (nome_pac, data_nascimento_pac, idade_pac, local_nascimento_pac, rg_pac, cpf_pac,
    endereco_pac, telefone_pac, profissao_pac, estado_civil_pac, email_pac, sexo_pac, 
    raca_pac)
VALUES
( 'Laura Souza', '2012-07-15', 13, 'São Paulo', '45.678.901-3', '456.789.012-33',
 'Rua das Flores, 200', '(11) 97777-8888', 'Estudante', 'Solteira', 'laura.souza@email.com',
 'Feminino', 'Branca');
-- inserts Procedimento e consulta
INSERT INTO Procedimento (nome_pro, tempo_pro, descricao_pro, valor_pro)
VALUES ('Limpeza Dental', '00:45:00', 'Procedimento de remoção de placas e tártaro para manutenção da saúde bucal.', 120.00);
INSERT INTO Procedimento (nome_pro, tempo_pro, descricao_pro, valor_pro)
VALUES ('Clareamento Dental', '01:30:00', 'Tratamento estético para clarear os dentes utilizando produtos específicos.', 350.00);
INSERT INTO Procedimento (nome_pro, tempo_pro, descricao_pro, valor_pro)
VALUES ('Extração de Dente', '00:40:00', 'Remoção de dente comprometido ou que causa desconforto ao paciente.', 200.00);
INSERT INTO Consulta (horario_con, data_con, id_pro_fk)
VALUES ('09:30:00', '2025-10-10', 1);
INSERT INTO Consulta (horario_con, data_con, id_pro_fk)
VALUES ('14:00:00', '2025-10-11', 2);
INSERT INTO Consulta (horario_con, data_con, id_pro_fk)
VALUES ('10:15:00', '2025-01-12', 3);