using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Tests
{
    public class PatioTestes
    {
        [Fact]
        public void ValidarFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = "Ricardo Souza",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Verde",
                Modelo = "Fusca",
                Placa = "asd-9999"
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        // validar com vários parametros
        [Theory]
        [InlineData("Marcia", "ASD-1414", "Preto", "Gol")]
        [InlineData("Luna", "LSD-0025", "Rosa", "Pálio")]
        [InlineData("Verônica", "PSD-0147", "Azul", "Cross Fox")]
        [InlineData("Marília", "JSJ-1945", "Cinza", "Jipe")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Placa = placa,
                Cor = cor,
                Modelo = modelo
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Ricardo", "ASD-1414", "Preto", "Gol")]
        public void LocalizarVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Placa = placa,
                Cor = cor,
                Modelo = modelo
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact(Skip = "Teste ainda não implementado")]
        public void ValidarNomeProprietario()
        {
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            //Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo
            {
                Proprietario = "Ricardo",
                Placa = "SAF-1503",
                Cor = "Verde",
                Modelo = "Celta"
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            Veiculo veiculoAlterado = new Veiculo
            {
                Proprietario = "Ricardo",
                Placa = "SAF-1503",
                Cor = "Azul", // trocar cor
                Modelo = "Celta"
            };

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }
    }
}