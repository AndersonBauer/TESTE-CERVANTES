using Dapper;
using Npgsql;

namespace TestCervantes.Repositorios
{
    public class MarcaRepositorio
    {
        public void InserirMarca(Marca marca)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            conexao.Execute("INSERT INTO marca (NOME) VALUES (@Nome);",
                new
                {
                    Nome = marca.nome
                });
        }

        public void AtualizarMarca(Marca marca)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            conexao.Execute("UPDATE marca SET NOME = @Nome WHERE CODIGO = @Id;",
                new
                {
                    Nome = marca.nome,
                    Id = marca.codigo
                });
        }

        public void DeletarMarca(int id)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            conexao.Execute("DELETE FROM marca WHERE CODIGO = @id;",
                new
                {
                    id
                });
        }

        public Marca? GetMarcaPeloId(int id) {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            return conexao.QueryFirstOrDefault<Marca>(@"SELECT * FROM marca WHERE CODIGO = @id;",
                new {
                    id
                });
        }

        public IEnumerable<Marca> GetAllMarca()
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            return conexao.Query<Marca>(@"SELECT * FROM marca;");        
        }
    }
}
