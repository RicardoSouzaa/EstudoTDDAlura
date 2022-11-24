using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTeste : IDisposable
    {
        private Veiculo veiculo;

        public ITestOutputHelper saidaConsoleTeste;

        public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            _saidaConsoleTeste.WriteLine("Construtor Invocado.");
            veiculo = new Veiculo();
        }

        [Fact(DisplayName = "Teste Acelerar veículo")]
        [Trait("funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //Veiculo veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            veiculo = new Veiculo
            {
                Proprietario = "Ricardo",
                Placa = "FFF-5050",
                Cor = "Preto",
                Modelo = "Opalão",
                Tipo = TipoVeiculo.Automovel
            };

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", dados);
        }

        [Fact]
        public void TestarNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomePriprietario = "Ab";

            //Assert
            Assert.Throws<FormatException>
            (
                //Act
                testCode: () => new Veiculo(nomePriprietario)
            );

            saidaConsoleTeste.WriteLine($"Result: {nomePriprietario} contém menos de 3 caracteres, gerou a exception");
        }

        [Fact]
        public void TestarExcecaoQuatroCaracteresDaPlaca()
        {
            //Arrange
            string placa = "ASDF8888";

            //Act
            var mensagem = Assert.Throws<FormatException>
            (
                () => new Veiculo().Placa = placa
            );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        [Fact]
        public void TestarUltimosCaracteresPlacaVeiculoComoNumeros()
        {
            //Arrange
            string placaErrada = "ADS-995X";

            //Assert
            Assert.Throws<FormatException>
            (
                //Act
                () => new Veiculo().Placa = placaErrada
            );
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}