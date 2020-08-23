using Flunt.Notifications;
using Flunt.Validations;
using PublicUtility.Domain.Commands.Core;

namespace PublicUtility.Domain.Commands.Inputs
{
    public class DeleteEndpointCommand : Notifiable, ICommand
    {
        public DeleteEndpointCommand() { }

        public DeleteEndpointCommand(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public string SerialNumber { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(SerialNumber, "SerialNumber", "O campo \"Número de Série\" é obrigatório."));
        }
    }
}
