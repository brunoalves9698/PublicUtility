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
    public class DeleteEndpointHanlderTests
    {
        private readonly IEndpointRepository _endpointRepository;
        private readonly EndpointHandler _endpointHandler;
        private readonly DeleteEndpointCommand _deleteEndpointCommand;

        public DeleteEndpointHanlderTests()
        {
            _endpointRepository = new EndpointFakeRepository();
            _endpointHandler = new EndpointHandler(_endpointRepository);
            _deleteEndpointCommand = new DeleteEndpointCommand("1");
        }

        [TestMethod]
        [TestCategory("DeleteEndpointCommand")]
        public void Deve_interromper_a_exclusao_quando_o_comando_for_invalido()
        {
            _deleteEndpointCommand.SerialNumber = null;
            _deleteEndpointCommand.Validate();
            Assert.AreEqual(_deleteEndpointCommand.Invalid, true);
        }

        [TestMethod]
        [TestCategory("DeleteEndpointCommand")]
        public void Deve_prosseguir_a_exclusao_quando_o_comando_for_valido()
        {
            _deleteEndpointCommand.Validate();
            Assert.AreEqual(_deleteEndpointCommand.Valid, true);
        }

        [TestMethod]
        [TestCategory("DeleteEndpointCommand")]
        public void Deve_retornar_erro_quando_serial_number_nao_existir()
        {
            _deleteEndpointCommand.SerialNumber = "2";
            var result = (GenericCommandResult)_endpointHandler.Handle(_deleteEndpointCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        [TestCategory("DeleteEndpointCommand")]
        public void Deve_prosseguir_exclusao_quando_serial_number_existir()
        {
            var result = (GenericCommandResult)_endpointHandler.Handle(_deleteEndpointCommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}
