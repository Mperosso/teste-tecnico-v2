using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thunders.TechTest.ApiService.Controller;
using Thunders.TechTest.ApiService.Repository.Interface;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.Tests
{
    public class RelatorioControllerTests
    {
        [Fact]
        public async Task TestObterRelatorioPracasMaisFaturaram()
        {
            // Arrange
            var pedagioRepositoryMock = new Mock<IPedagioRepository>();
            var relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            var reportService = new ReportService(pedagioRepositoryMock.Object, relatorioRepositoryMock.Object);
            var relatorioController = new RelatorioController(reportService);
            // Act
            var result = await relatorioController.ObterRelatorioPracasMaisFaturaram(2);
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestObterValorHoraCidade()
        {
            // Arrange
            var pedagioRepositoryMock = new Mock<IPedagioRepository>();
            var relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            var reportService = new ReportService(pedagioRepositoryMock.Object, relatorioRepositoryMock.Object);
            var relatorioController = new RelatorioController(reportService);
            // Act
            var result = await relatorioController.ObterValorHoraCidade(DateTime.Now.AddHours(-1), DateTime.Now.AddHours(3));
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestObterVeiculosPraca()
        {
            // Arrange
            var pedagioRepositoryMock = new Mock<IPedagioRepository>();
            var relatorioRepositoryMock = new Mock<IRelatorioRepository>();
            var reportService = new ReportService(pedagioRepositoryMock.Object, relatorioRepositoryMock.Object);
            var relatorioController = new RelatorioController(reportService);
            // Act
            var result = await relatorioController.ObterVeiculosPraca(1);
            // Assert
            Assert.NotNull(result);
        }
    }
}
