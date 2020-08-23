using Microsoft.AspNetCore.Mvc;
using PublicUtility.Domain.Commands.Core;
using PublicUtility.Domain.Commands.Inputs;
using PublicUtility.Domain.Entities;
using PublicUtility.Domain.Handlers;
using PublicUtility.Domain.Repositories;
using System.Collections.Generic;

namespace PublicUtility.Api.Controllers.v1
{
    [Route("v1/endpoints")]
    [ApiController]
    public class EndpointController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Endpoint> Get([FromServices] IEndpointRepository repository)
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("{serialNumber}")]
        public Endpoint GetBySeriaNumber(string serialNumber, [FromServices] IEndpointRepository repository)
        {
            return repository.GetBySerialNumber(serialNumber);
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult Post(
            [FromBody]RegisterEndpointCommand command,
            [FromServices]EndpointHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("")]
        public GenericCommandResult Put(
        [FromBody]UpdateEndpointCommand command,
        [FromServices]EndpointHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpDelete]
        [Route("{serialNumber}")]
        public GenericCommandResult Delete(
            string serialNumber,
            [FromServices]EndpointHandler handler)
        {
            return (GenericCommandResult)handler.Handle(new DeleteEndpointCommand(serialNumber));
        }
    }
}