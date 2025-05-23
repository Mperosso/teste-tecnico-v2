﻿using Moq;
using Rebus.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thunders.TechTest.ApiService.Controller;
using Thunders.TechTest.ApiService.Enum;
using Thunders.TechTest.ApiService.Messages;
using Thunders.TechTest.ApiService.Repository.Interface;
using Thunders.TechTest.ApiService.Services;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.Tests
{
    public class PedagioControllerTests
    {
        [Fact]
        public async Task TestSalvarPedagio()
        {
            // Arrange
            var pedagioMessage = new PedagioMessage
            {
                PracaId = 1,
                Cidade = "Cidade1",
                Estado = Estados.RJ,
                DataHora = DateTime.Now,
                ValorPago = 10
            };
            
            var busMock = new Mock<IBus>();
            var rebusMessageSenderMock = new Mock<RebusMessageSender>(busMock.Object);
            var messageServiceMock = new Mock<MessageService>(rebusMessageSenderMock.Object);
            var pedagioController = new PedagioController(messageServiceMock.Object);
            // Act
            var result = await pedagioController.Salvar(pedagioMessage);
            // Assert
            Assert.NotNull(result);
        }
    }
}
