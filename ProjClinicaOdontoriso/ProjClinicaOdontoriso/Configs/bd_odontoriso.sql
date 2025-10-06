create database bd_odontoriso;
use bd_odontoriso;

CREATE TABLE Funcionario (
    id_fun INT PRIMARY KEY AUTO_INCREMENT,
    nome_fun VARCHAR(300),
    data_nascimento_fun DATE,
    sexo_fun VARCHAR(20),
    cpf_fun VARCHAR(15),
    rg_fun VARCHAR(15),
    titulo_eleitor_fun VARCHAR(30),
    raca_fun VARCHAR(20),
    email_fun VARCHAR(150),
    telefone_fun VARCHAR(30),
    nacionalidade_fun VARCHAR(100),
    estado_fun VARCHAR(5),
    cidade_fun VARCHAR(150),
    endereco_fun VARCHAR(300),
    estado_civil_fun VARCHAR(20),
    cargo_fun VARCHAR(100),
    data_admissao_fun DATE,
    salario_inicial_fun DECIMAL(10,2),
    ctps_fun VARCHAR(50),
    recebe_salario_familia_fun VARCHAR(5),
    qtd_filhos_fun INT,
    escolaridade_fun VARCHAR(50)

create table Dentista(
id_den int primary key auto_increment,
cro_den varchar(50),
especialidade_den varchar(300),
id_fun_fk int not null,
foreign key (id_fun_fk) references Funcionario (id_fun)
);

create table Procedimento(
id_pro int primary key auto_increment,
nome_pro varchar(50),
tempo_pro time,
descricao_pro varchar(500),
valor_pro float
);

create table Responsavel(
id_resp int primary key auto_increment,
nome_resp varchar(300),
parentesco_resp varchar(100),
rg_resp varchar(15),
cpf_resp varchar(15)
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
profissão_pac varchar(50),
estado_civil_pac varchar(30),
email_pac varchar(150),
sexo_pac varchar(30),
raca_pac varchar(30),
id_resp_fk int,
foreign key (id_resp_fk) references Responsavel (id_resp)
);

create table Consulta(
id_con int primary key auto_increment,
horario_con time,
data_con date,
id_pro_fk int,
foreign key (id_pro_fk) references Procedimento (id_pro),
id_pac_fk int,
foreign key (id_pac_fk) references Paciente (id_pac),
id_den_fk int,
foreign key (id_den_fk) references Dentista (id_den)
);

INSERT INTO Funcionario (
    nome_fun, data_nascimento_fun, sexo_fun, cpf_fun, rg_fun, titulo_eleitor_fun, 
    raca_fun, email_fun, telefone_fun, nacionalidade_fun, estado_fun, cidade_fun, 
    endereco_fun, estado_civil_fun, cargo_fun, data_admissao_fun, salario_inicial_fun, 
    ctps_fun, recebe_salario_familia_fun, qtd_filhos_fun, escolaridade_fun
) 
VALUES('Maria Oliveira Santos', '1990-05-12', 'Feminino', '123.456.789-00', '45.678.901-2', '123456789012',
    'Parda', 'maria.santos@email.com', '(11) 99999-8888', 'Brasileira', 'SP', 'São Paulo',
    'Rua das Flores, 120', 'Casada', 'Analista de RH', '2020-03-15', 4500.00,
    'CTPS12345', 'Sim', 2, 'Ensino Superior Completo');
INSERT INTO Funcionario (
    nome_fun, data_nascimento_fun, sexo_fun, cpf_fun, rg_fun, titulo_eleitor_fun, 
    raca_fun, email_fun, telefone_fun, nacionalidade_fun, estado_fun, cidade_fun, 
    endereco_fun, estado_civil_fun, cargo_fun, data_admissao_fun, salario_inicial_fun, 
    ctps_fun, recebe_salario_familia_fun, qtd_filhos_fun, escolaridade_fun
) 
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

INSERT INTO Procedimento (nome_pro, tempo_pro, descricao_pro, valor_pro)
VALUES ('Limpeza Dental', '00:45:00', 'Procedimento de remoção de placas e tártaro para manutenção da saúde bucal.', 120.00);

INSERT INTO Procedimento (nome_pro, tempo_pro, descricao_pro, valor_pro)
VALUES ('Clareamento Dental', '01:30:00', 'Tratamento estético para clarear os dentes utilizando produtos específicos.', 350.00);

INSERT INTO Procedimento (nome_pro, tempo_pro, descricao_pro, valor_pro)
VALUES ('Extração de Dente', '00:40:00', 'Remoção de dente comprometido ou que causa desconforto ao paciente.', 200.00);