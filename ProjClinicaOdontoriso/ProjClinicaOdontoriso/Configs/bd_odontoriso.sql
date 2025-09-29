create database bd_odontoriso;
use bd_odontoriso;

create table Funcionario(
id_fun int primary key auto_increment,
nome_fun varchar(300),
cpf_fun varchar(15),
rg_fun varchar(15),
cnpj_fun varchar(30),
data_nascimento_fun date,
telefone_fun varchar(30),
estado_fun varchar(10),
cidade_fun varchar(300),
endereco_fun varchar(300),
email_fun varchar(150),
cargo_fun varchar(30)
);

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