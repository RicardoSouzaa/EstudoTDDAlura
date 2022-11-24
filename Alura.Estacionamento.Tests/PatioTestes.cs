using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class PatioTestes : IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        private Operador operador;
        public ITestOutputHelper saidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            _saidaConsoleTeste.WriteLine("Construtor Invocado.");
            veiculo = new Veiculo();
            estacionamento = new Patio();
            operador = new Operador();
            operador.Nome = "Murilo";
        }

        [Fact]
        public void ValidarFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            veiculo = new Veiculo
            {
                Proprietario = "Ricardo Souza",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Verde",
                Modelo = "Fusca",
                Placa = "asd-9999"
            };

            operador.Nome = "Murilo";
            estacionamento.OperadorPatio = operador;

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
            veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Placa = placa,
                Cor = cor,
                Modelo = modelo
            };

            operador.Nome = "Murilo";
            estacionamento.OperadorPatio = operador;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Ricardo", "ASD-1414", "Preto", "Gurgel")]
        public void LocalizarVeiculoNoPatioComBaseNaPlaca(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Placa = placa,
                Cor = cor,
                Modelo = modelo
            };

            estacionamento.OperadorPatio = operador;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculoPlaca(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Theory]
        [InlineData("Ricardo", "ASD-1414", "Preto", "Gurgel")]
        public void LocalizarVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Placa = placa,
                Cor = cor,
                Modelo = modelo
            };

            estacionamento.OperadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculoIdTicket(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }

        [Fact(Skip = "Teste ainda não implementado")]
        public void ValidarNomeProprietario()
        {
        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            veiculo = new Veiculo
            {
                Proprietario = "Ricardo",
                Placa = "SAF-1503",
                Cor = "Verde",
                Modelo = "Celta"
            };

            estacionamento.OperadorPatio = operador;

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

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose Invocado.");
        }
    }
}