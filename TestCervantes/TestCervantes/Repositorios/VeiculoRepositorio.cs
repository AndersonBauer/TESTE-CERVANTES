    using Dapper;
    using Npgsql;


namespace TestCervantes.Repositorios
{
    public class VeiculoRepositorio
    {
        public void Create(Veiculo veiculo )
        {
            using NpgsqlConnection conexao = (NpgsqlConnection) new DbConexao().GetConnection();
            conexao.Execute("INSERT INTO veiculo (PLACA, MODELO, ANO, MARCACODIGO, TIPO) VALUES (@Placa, @Modelo, @Ano, @MarcaCodigo, @Tipo);",
                new
                {
                    placa = veiculo.Placa,
                    modelo = veiculo.Modelo,
                    ano = veiculo.Ano,
                    marcaCodigo = veiculo.MarcaCodigo,
                    tipo = veiculo.Tipo
                });
        }

        public void Update(Veiculo veiculo)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            conexao.Execute("UPDATE veiculo SET PLACA = @Placa, MODELO = @Modelo, ANO = @Ano, MARCACODIGO = @MarcaCodigo, TIPO = @Tipo WHERE CODIGO = @Id;",
                new
                {
                    placa = veiculo.Placa,
                    modelo = veiculo.Modelo,
                    ano = veiculo.Ano,
                    marcaCodigo = veiculo.MarcaCodigo,  
                    id = veiculo.Codigo,
                    tipo = veiculo.Tipo
                });
        }

        public void Delete(int id)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            conexao.Execute("DELETE FROM veiculo WHERE CODIGO = @Id;",
                new
                {
                    id
                });
        }

        public Veiculo? GetById(int id)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            return conexao.QueryFirstOrDefault<Veiculo>(@"SELECT * FROM veiculo WHERE CODIGO = @Id;",
                new
                {
                    id      
                }); 
        }

        public List<Veiculo> GetAll()
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            var dados = conexao.Query<dynamic>(@"SELECT * FROM veiculo ORDER BY codigo;");

            List<Veiculo> veiculos = new List<Veiculo>();

            foreach (var i in dados)
            {
                if (i.tipo == "CARRO")
                {
                    veiculos.Add(new Carro(
                            i.codigo,
                            i.placa,
                            i.modelo,
                            i.ano,
                            i.marcacodigo
                        ));
                }else if (i.tipo == "MOTO")
                {
                    veiculos.Add(new Moto(
                        i.codigo,
                        i.placa,
                        i.modelo,
                        i.ano,
                        i.marcacodigo));
                }
            }
            return veiculos;
        }
    }
}   