﻿using Flunt.Notifications;
using PublicUtility.Domain.Commands.Core;
using PublicUtility.Domain.Commands.Inputs;
using PublicUtility.Domain.Entities;
using PublicUtility.Domain.Handlers.Core;
using PublicUtility.Domain.Repositories;

namespace PublicUtility.Domain.Handlers
{
    public class EndpointHandler :
        Notifiable,
        IHandler<RegisterEndpointCommand>,
        IHandler<UpdateEndpointCommand>,
        IHandler<DeleteEndpointCommand>
    {
        private readonly IEndpointRepository _repository;


        public EndpointHandler(IEndpointRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(RegisterEndpointCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos. Verifique o preenchimento dos campos e tente novamente.", command.Notifications);

            // Verfica se Serial Number já está cadastrado
            if (_repository.SerialNumberExists(command.SerialNumber))
            {
                AddNotification("SerialNumber", "Este \"Número Serial\" já está em uso.");
                return new GenericCommandResult(false, "Este \"Número Serial\" já está em uso.", command.Notifications);
            }

            // Gera a Entidade
            var endpoint = new Endpoint(
                command.SerialNumber,
                command.MeterModelId,
                command.MeterNumber,
                command.MeterFirmwareVersion,
                command.SwitchState);

            // Checa as Notificações
            if (Invalid)
                return new GenericCommandResult(false, "Dados inválidos. Verifique o preenchimento dos campos e tente novamente.", Notifications);

            // Salva as Informações
            _repository.Save(endpoint);

            // Retorna as Informações
            return new GenericCommandResult(true, "Cadastro realizado com sucesso.", endpoint);
        }

        public ICommandResult Handle(UpdateEndpointCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos. Verifique o preenchimento dos campos e tente novamente.", command.Notifications);

            // Recupera Entidade (para reidratação)
            var endpoint = _repository.GetBySerialNumber(command.SerialNumber);

            if (endpoint == null)
                return new GenericCommandResult(false, "Nenhum Endpoint encontrado com esse Número Serial.", null);

            // Altera a Entidade (reidradação)
            endpoint.Update(command.SwitchState);

            // Checa as Notificações
            if (Invalid)
                return new GenericCommandResult(false, "Dados inválidos. Verifique o preenchimento dos campos e tente novamente.", Notifications);

            // Salva as Informações
            _repository.Update(endpoint);

            // Retorna as Informações
            return new GenericCommandResult(true, "Atualização realizada com sucesso.", endpoint);
        }

        public ICommandResult Handle(DeleteEndpointCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos. Verifique o preenchimento dos campos e tente novamente.", command.Notifications);

            var endpoint = _repository.GetBySerialNumber(command.SerialNumber);

            if (endpoint == null)
                return new GenericCommandResult(false, "Nenhum Endpoint encontrado com esse Número Serial.", null);

            if (_repository.Delete(command.SerialNumber))
                return new GenericCommandResult(true, "Registro excluído com sucesso.", endpoint);
            else
                return new GenericCommandResult(false, "Erro ao excluir registro.", endpoint);
        }
    }
}
