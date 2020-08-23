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
    public class RegisterEndpointHanlderTests
    {
        private readonly IEndpointRepository _endpointRepository;
        private readonly EndpointHandler _endpointHandler;
        private readonly RegisterEndpointCommand _registerEndpointCommand;

        public RegisterEndpointHanlderTests()
        {
            _endpointRepository = new EndpointFakeRepository();
            _endpointHandler = new EndpointHandler(_endpointRepository);
            _registerEndpointCommand = new RegisterEndpointCommand("2", 1, 1, "v 0.0.1", EEndpointState.Connected);
        }

        [TestMethod]
        [TestCategory("RegisterEndpointCommand")]
        public void Deve_interromper_o_registro_quando_o_comando_for_invalido()
        {
            _registerEndpointCommand.MeterFirmwareVersion = "v 0.0.1234567891234567";
            _registerEndpointCommand.Validate();
            Assert.AreEqual(_registerEndpointCommand.Invalid, true);
        }

        [TestMethod]
        [TestCategory("RegisterEndpointCommand")]
        public void Deve_prosseguir_o_registro_quando_o_comando_for_valido()
        {
            _registerEndpointCommand.Validate();
            Assert.AreEqual(_registerEndpointCommand.Valid, true);
        }

        [TestMethod]
        [TestCategory("RegisterEndpointCommand")]
        public void Deve_interromper_o_registro_quando_o_serial_number_ja_estiver_em_uso()
        {
            _registerEndpointCommand.SerialNumber = "1";
            _endpointHandler.Handle(_registerEndpointCommand);
            Assert.AreEqual(_endpointHandler.Invalid, true);
        }

        [TestMethod]
        [TestCategory("RegisterEndpointCommand")]
        public void Deve_interromper_o_registro_quando_houver_alguma_notificacao()
        {
            _registerEndpointCommand.MeterFirmwareVersion = "v 0.0.1234567891234567";
            _registerEndpointCommand.SerialNumber = "1";
            var result = (GenericCommandResult)_endpointHandler.Handle(_registerEndpointCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        [TestCategory("RegisterEndpointCommand")]
        public void Deve_prosseguir_o_registro_quando_nao_houver_nenhuma_notificacao()
        {
            var result = (GenericCommandResult)_endpointHandler.Handle(_registerEndpointCommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}
