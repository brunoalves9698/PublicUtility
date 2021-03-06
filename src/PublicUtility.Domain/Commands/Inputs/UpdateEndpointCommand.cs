﻿using Flunt.Notifications;
using Flunt.Validations;
using PublicUtility.Domain.Commands.Core;
using PublicUtility.Domain.Enums;

namespace PublicUtility.Domain.Commands.Inputs
{
    public class UpdateEndpointCommand : Notifiable, ICommand
    {
        public UpdateEndpointCommand() { }

        public UpdateEndpointCommand(
            string serialNumber,
            EEndpointState switchState)
        {
            SerialNumber = serialNumber;
            SwitchState = switchState;
        }

        public string SerialNumber { get; set; }
        public EEndpointState SwitchState { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(SerialNumber, "SerialNumber", "O campo \"Número de Série\" é obrigatório."));
        }
    }
}
