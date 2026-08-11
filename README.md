Para começar voce precisa ter cumprido todos esses requisitos<br>
* PostgreSQL instalado<br>
* pgAdmin 4 instalado<br>
* Visual Studio instalado<br>
* .NET compatível com o projeto<br>
* O projeto baixado/clonado<br>

PASSO 1 - Criar o banco de dados usando esse comando<br><br>
 CREATE DATABASE VeiculosDB;<br><br>
PASSO 2 - Criar a tabela MARCA com o comando<br><br>
 CREATE TABLE Marca (
    Codigo SERIAL PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL UNIQUE
);<br><br>
PASSO 3 - Criar a tabela VEICULO com o comando <br>
CREATE TABLE Veiculo (
    Codigo SERIAL PRIMARY KEY,
    Placa VARCHAR(10) NOT NULL UNIQUE,
    Modelo VARCHAR(100) NOT NULL,
    Ano INT NOT NULL CHECK (Ano BETWEEN 1950 AND EXTRACT(YEAR FROM CURRENT_DATE)),
    MarcaCodigo INT NOT NULL,
    Tipo VARCHAR(10) NOT NULL CHECK (Tipo IN ('CARRO', 'MOTO')),
    FOREIGN KEY (MarcaCodigo)
        REFERENCES Marca(Codigo)
);<br><br>
PASSO 4 - Criar a tabela LogTransacao com o comando<br><br>
CREATE TABLE LogTransacao (
    ID SERIAL PRIMARY KEY,
    OPERACAO VARCHAR(10) NOT NULL,
    DATAHORA TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    TABELAALTERADA VARCHAR(50) NOT NULL
);<br><br>
PASSO 5 - Criar a função da TRIGGER<br><br>
CREATE OR REPLACE FUNCTION registrar_log_veiculo()
RETURNS TRIGGER AS $$
BEGIN
    IF TG_OP = 'INSERT' THEN
        INSERT INTO LogTransacao (OPERACAO, TABELAALTERADA)
        VALUES ('INSERT', 'Veiculo');
    ELSIF TG_OP = 'UPDATE' THEN
        INSERT INTO LogTransacao (OPERACAO, TABELAALTERADA)
        VALUES ('UPDATE', 'Veiculo');
    ELSIF TG_OP = 'DELETE' THEN
        INSERT INTO LogTransacao (OPERACAO, TABELAALTERADA)
        VALUES ('DELETE', 'Veiculo');
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;<br><br>
PASSO 6 - Criar a TRIGGER com o comando <br><br>
CREATE TRIGGER trigger_log_veiculo
AFTER INSERT OR UPDATE OR DELETE
ON Veiculo
FOR EACH ROW
EXECUTE FUNCTION registrar_log_veiculo();<br><br>
PASSO 7 - Verificar se funciona com esses comandos<br>
INSERT INTO marca (Nome) VALUES ('MITSUBISHI');
SELECT * FROM marca;<br><br>
// salve o id da marca (se for o primeiro insert vai ser 1)<br>
Depois -<br><br>
INSERT INTO veiculo (Placa, Modelo, Ano, Tipo, MarcaCodigo) VALUES ('ABC1D23', 'LANCER', 2022, 'CARRO', 1);
SELECT * FROM veiculo;<br><br>
E por ultimo verificar se a TRIGGER esta funcionando<br><br>
SELECT * FROM LogTransacao;<br><br>
PASSO 8 - Linkar a aplicação ao banco de dados, só trocar lá a parte SENHA_DE_VOCES pela senha que voces usam (Linha 16 do arquivo DbConexao)<br><br>
PASSO 9 - <br>
Abra o projeto no Visual Studio.<br>
Confirme que o PostgreSQL está em execução.<br>
Confirme que o banco VeiculosDB existe.<br>
Confirme que a senha no DbConexao.cs está correta.<br>
Execute o projeto pelo botão Iniciar do Visual Studio.<br>
Cadastre uma marca.<br>
Cadastre um veículo.<br>
Confira no pgAdmin se os dados foram inseridos.<br>
PASSO 10 - Rode esse comando pra ver se as aplicações rodam certinho e se a TRIGGER está funcionando<br>
SELECT * FROM LogTransacao
ORDER BY ID;<br>

Se eu não fiz nada errado e não esqueci de anotar algo provavelmente vai funcionar<br>
