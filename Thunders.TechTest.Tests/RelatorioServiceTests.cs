using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Enum;
using Thunders.TechTest.ApiService.Repository.Interface;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.Tests
{
    public class RelatorioServiceTests
    {
        [Fact]
        public async Task TestGerarRelatorioFaturamentoPracasAsync()
        {
            // Arrange
            var pedagioRepositoryMock = new Mock<IPedagioRepository>();
            var relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            var reportService = new ReportService(pedagioRepositoryMock.Object, relatorioRepositoryMock.Object);
            var pedagios = new List<Pedagio>
            {
                new Pedagio { PracaId = 1, Cidade = "Cidade1", Estado = Estados.RJ, DataHora = DateTime.Now, ValorPago = 10 },
                new Pedagio { PracaId = 2, Cidade = "Cidade2", Estado = Estados.SC, DataHora = DateTime.Now, ValorPago = 20 },
                new Pedagio { PracaId = 1, Cidade = "Cidade1", Estado = Estados.RJ, DataHora = DateTime.Now, ValorPago = 30 }
            };
            pedagioRepositoryMock.Setup(repo => repo.ObterPedagiosAsync()).ReturnsAsync(pedagios);
            // Act
            var result = await reportService.GerarRelatorioFaturamentoPracasAsync(2);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task TestGerarRelatorioValorHoraCidadeAsync()
        {
            // Arrange
            var pedagioRepositoryMock = new Mock<IPedagioRepository>();
            var relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            var reportService = new ReportService(pedagioRepositoryMock.Object, relatorioRepositoryMock.Object);
            var pedagios = new List<Pedagio>
            {
                new Pedagio { Cidade = "Cidade1", Estado = Estados.RJ, DataHora = DateTime.Now, ValorPago = 10 },
                new Pedagio { Cidade = "Cidade2", Estado = Estados.SC, DataHora = DateTime.Now.AddHours(1), ValorPago = 20 },
                new Pedagio { Cidade = "Cidade1", Estado = Estados.RJ, DataHora = DateTime.Now.AddHours(2), ValorPago = 30 }
            };
            pedagioRepositoryMock.Setup(repo => repo.ObterPedagiosAsync()).ReturnsAsync(pedagios);
            // Act
            var result = await reportService.GerarRelatorioValorHoraCidadeAsync(DateTime.Now.AddHours(-1), DateTime.Now.AddHours(3));
            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task TestGerarRelatorioValorHoraCidadeAsync_EmptyList()
        {
            // Arrange
            var pedagioRepositoryMock = new Mock<IPedagioRepository>();
            var relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            var reportService = new ReportService(pedagioRepositoryMock.Object, relatorioRepositoryMock.Object);
            var pedagios = new List<Pedagio>();
            pedagioRepositoryMock.Setup(repo => repo.ObterPedagiosAsync()).ReturnsAsync(pedagios);
            // Act
            var result = await reportService.GerarRelatorioValorHoraCidadeAsync(DateTime.Now.AddHours(-1), DateTime.Now.AddHours(3));
            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task TestGerarRelatorioFaturamentoPracasAsync_EmptyList()
        {
            // Arrange
            var pedagioRepositoryMock = new Mock<IPedagioRepository>();
            var relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            var reportService = new ReportService(pedagioRepositoryMock.Object, relatorioRepositoryMock.Object);
            var pedagios = new List<Pedagio>();
            pedagioRepositoryMock.Setup(repo => repo.ObterPedagiosAsync()).ReturnsAsync(pedagios);
            // Act
            var result = await reportService.GerarRelatorioFaturamentoPracasAsync(2);
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestGerarRelatorioVeiculosPracaAsync()
        {
            // Arrange
            var pedagioRepositoryMock = new Mock<IPedagioRepository>();
            var relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            var reportService = new ReportService(pedagioRepositoryMock.Object, relatorioRepositoryMock.Object);
            var pedagios = new List<Pedagio>
            {
                new Pedagio { PracaId = 1, Cidade = "Cidade1", Estado = Estados.RJ, DataHora = DateTime.Now, TipoVeiculo = TipoVeiculo.Caminhao },
                new Pedagio { PracaId = 2, Cidade = "Cidade2", Estado = Estados.SC, DataHora = DateTime.Now, TipoVeiculo = TipoVeiculo.Caminhao },
                new Pedagio { PracaId = 1, Cidade = "Cidade1", Estado = Estados.RJ, DataHora = DateTime.Now, TipoVeiculo = TipoVeiculo.Caminhao }
            };
            pedagioRepositoryMock.Setup(repo => repo.ObterPedagiosAsync()).ReturnsAsync(pedagios);
            // Act
            var result = await reportService.GerarRelatorioFaturamentoPracasAsync(2);
            // Assert
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task TestGerarRelatorioVeiculosPracaAsync_EmptyList()
        {
            // Arrange
            var pedagioRepositoryMock = new Mock<IPedagioRepository>();
            var relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            var reportService = new ReportService(pedagioRepositoryMock.Object, relatorioRepositoryMock.Object);
            var pedagios = new List<Pedagio>();
            pedagioRepositoryMock.Setup(repo => repo.ObterPedagiosAsync()).ReturnsAsync(pedagios);
            // Act
            var result = await reportService.GerarRelatorioFaturamentoPracasAsync(2);
            // Assert
            Assert.NotNull(result);
        }
    }
}
