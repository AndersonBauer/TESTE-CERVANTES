
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using System.Linq;
using TestCervantes.Repositorios;

namespace TestCervantes.Tests
{
    [TestClass]
    public class MarcaRepositorioTests
    {

        // esse teste verifica se o repositório de veículos não permite a inserção de dois veículos com a mesma placa
        // e ainda garante que uma marca seja craida para o teste e removida quando ele acabar
        [TestMethod]
        public void NaoDevePermitirDuasPlacasIguais()
        {
            var marcaRepositorio = new MarcaRepositorio();
            var veiculoRepositorio = new VeiculoRepositorio();

            // Cria uma marca para o teste
            var marca = new Marca(0, "MARCA_TESTE_PLACA");

            marcaRepositorio.InserirMarca(marca);

            try
            {
                // Recupera o código da marca criada
                var marcaCriada = marcaRepositorio
                    .GetAllMarca()
                    .FirstOrDefault(m => m.nome == "MARCA_TESTE_PLACA");

                Assert.IsNotNull(marcaCriada);

                // Primeiro veículo
                var primeiro = new Carro(
                    0,
                    "TEST001",
                    "Carro Teste",
                    2020,
                    marcaCriada.codigo
                );

                veiculoRepositorio.Create(primeiro);

                try
                {
                    // Segundo veículo com a mesma placa
                    var segundo = new Carro(
                        0,
                        "TEST001",
                        "Outro Carro",
                        2021,
                        marcaCriada.codigo
                    );

                    bool deuErro = false;

                    try
                    {
                        veiculoRepositorio.Create(segundo);
                    }
                    catch (PostgresException ex)
                    {
                        deuErro = true;

                        // 23505 = violação de UNIQUE
                        Assert.AreEqual("23505", ex.SqlState);
                    }

                    Assert.IsTrue(deuErro);
                }
                finally
                {
                    // Remove o primeiro veículo
                    var veiculoCriado = veiculoRepositorio
                        .GetAll()
                        .FirstOrDefault(v => v.Placa == "TEST001");

                    if (veiculoCriado != null)
                    {
                        veiculoRepositorio.Delete(veiculoCriado.Codigo);
                    }
                }
            }
            finally
            {
                // Remove a marca criada para o teste
                var marcaCriada = marcaRepositorio
                    .GetAllMarca()
                    .FirstOrDefault(m => m.nome == "MARCA_TESTE_PLACA");

                if (marcaCriada != null)
                {
                    marcaRepositorio.DeletarMarca(marcaCriada.codigo);
                }
            }
        }
        [TestMethod]
        public void DeveInserirMarca()
        {
            var marcaRepositorio = new MarcaRepositorio();
            // Cria uma marca para o teste
            var marca = new Marca(0, "MARCA_TESTE_INSERIR");
            marcaRepositorio.InserirMarca(marca);
            try
            {
                // Recupera o código da marca criada
                var marcaCriada = marcaRepositorio
                    .GetAllMarca()
                    .FirstOrDefault(m => m.nome == "MARCA_TESTE_INSERIR");
                Assert.IsNotNull(marcaCriada);
            }
            finally
            {
                // Remove a marca criada para o teste
                var marcaCriada = marcaRepositorio
                    .GetAllMarca()
                    .FirstOrDefault(m => m.nome == "MARCA_TESTE_INSERIR");
                if (marcaCriada != null)
                {
                    marcaRepositorio.DeletarMarca(marcaCriada.codigo);
                }
            }
        }

        // esse teste verifica se o repositório de marcar não permite a exclusão de uma marqua que tem um veiculo vinculado a ela
        // ciclo de vida desse teste [ cria uma marca, cria um veiculo vinculado a ela, tenta excluir a marca,
        // quando ele não cosnegue ele deletar a marca e ele da um DELETE no veiculo e depois na MARCA encerrando o ciclo]
        [TestMethod]
        public void NaoDevePermitirExcluirMarcaComVeiculoVinculado()
        {
            var marcaRepositorio = new MarcaRepositorio();
            var veiculoRepositorio = new VeiculoRepositorio();

            // Cria uma marca para o teste
            var marca = new Marca(0, "MARCA_TESTE_VINCULO");

            marcaRepositorio.InserirMarca(marca);

            try
            {
                // Busca a marca criada para pegar o código
                var marcaCriada = marcaRepositorio
                    .GetAllMarca()
                    .FirstOrDefault(m => m.nome == "MARCA_TESTE_VINCULO");

                Assert.IsNotNull(marcaCriada);

                // Cria um veículo vinculado à marca
                var veiculo = new Carro(
                    0,
                    "TEST010",
                    "Carro Teste",
                    2020,
                    marcaCriada.codigo
                );

                veiculoRepositorio.Create(veiculo);

                try
                {
                    bool deuErro = false;

                    // Tenta excluir a marca que possui um veículo vinculado
                    try
                    {
                        marcaRepositorio.DeletarMarca(marcaCriada.codigo);
                    }
                    catch (PostgresException ex)
                    {
                        deuErro = true;

                        // 23503 = violação de FOREIGN KEY
                        Assert.AreEqual("23503", ex.SqlState);
                    }

                    // A exclusão deve ter sido impedida
                    Assert.IsTrue(deuErro);
                }
                finally
                {
                    //Rremove o veículo
                    var veiculoCriado = veiculoRepositorio
                        .GetAll()
                        .FirstOrDefault(v => v.Placa == "TEST010");

                    if (veiculoCriado != null)
                    {
                        veiculoRepositorio.Delete(veiculoCriado.Codigo);
                    }
                }
            }
            finally
            {
                // Depois que o veículo foi removido da pra remover a marca
                var marcaCriada = marcaRepositorio
                    .GetAllMarca()
                    .FirstOrDefault(m => m.nome == "MARCA_TESTE_VINCULO");

                if (marcaCriada != null)
                {
                    marcaRepositorio.DeletarMarca(marcaCriada.codigo);
                }
            }
        }
    }
}