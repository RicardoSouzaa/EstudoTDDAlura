using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTeste
    {
        [Fact(DisplayName = "Teste Acelerar veículo")]
        [Trait("funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            Veiculo veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            //Arrange
            Veiculo veiculo = new();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void DadosVeicuos()
        {
            //Arrange
            Veiculo carro = new Veiculo
            {
                Proprietario = "Ricardo",
                Placa = "FFF-5050",
                Cor = "Preto",
                Modelo = "Opalão",
                Tipo = TipoVeiculo.Automovel
            };

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", dados);
        }
    }
}