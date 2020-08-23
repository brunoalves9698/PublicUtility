using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicUtility.Domain.Commands.Core;
using PublicUtility.Domain.Commands.Inputs;
using PublicUtility.Domain.Enums;
using PublicUtility.Domain.Handlers;
using PublicUtility.Domain.Repositories;
using PublicUtility.Tests.Fakes.Repositories;

namespace PublicUtility.Tests.Handlers
{
    [TestClass]
    public class UpdateEndpointHanlderTests
    {
        private readonly IEndpointRepository _endpointRepository;
        private readonly EndpointHandler _endpointHandler;
        private readonly UpdateEndpointCommand _updateEndpointCommand;

        public UpdateEndpointHanlderTests()
        {
            _endpointRepository = new EndpointFakeRepository();
            _endpointHandler = new EndpointHandler(_endpointRepository);
            _updateEndpointCommand = new UpdateEndpointCommand("1", EEndpointState.Connected);
        }

        [TestMethod]
        [TestCategory("UpdateEndpointCommand")]
        public void Deve_interromper_a_atualizacao_quando_o_comando_for_invalido()
        {
            _updateEndpointCommand.SerialNumber = null;
            _updateEndpointCommand.Validate();
            Assert.AreEqual(_updateEndpointCommand.Invalid, true);
        }

        [TestMethod]
        [TestCategory("UpdateEndpointCommand")]
        public void Deve_prosseguir_a_atualizacao_quando_o_comando_for_valido()
        {
            _updateEndpointCommand.Validate();
            Assert.AreEqual(_updateEndpointCommand.Valid, true);
        }

        [TestMethod]
        [TestCategory("UpdateEndpointCommand")]
        public void Deve_retornar_erro_quando_serial_number_nao_existir()
        {
            _updateEndpointCommand.SerialNumber = "2";
            var result = (GenericCommandResult)_endpointHandler.Handle(_updateEndpointCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        [TestCategory("UpdateEndpointCommand")]
        public void Deve_prosseguir_atualizacao_quando_serial_number_existir()
        {
            var result = (GenericCommandResult)_endpointHandler.Handle(_updateEndpointCommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}
